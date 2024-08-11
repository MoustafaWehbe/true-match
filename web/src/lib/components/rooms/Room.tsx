'use client';

import React, { useCallback, useEffect, useRef, useState } from 'react';
import {
  Box,
  Button,
  Flex,
  Stack,
  Text,
  useColorModeValue,
  useToast,
} from '@chakra-ui/react';
import { socket } from '~/lib/utils/socket/socket';
import {
  FaMicrophone,
  FaMicrophoneSlash,
  FaVideo,
  FaVideoSlash,
} from 'react-icons/fa';

const peerConfiguration = {
  iceServers: [
    {
      urls: ['stun:stun.l.google.com:19302', 'stun:stun1.l.google.com:19302'],
    },
  ],
};

interface PeerRef {
  peerID: string;
  peer: RTCPeerConnection;
}

const Video: React.FC<{ peer: RTCPeerConnection }> = ({ peer }) => {
  const ref = useRef<HTMLVideoElement>(null);

  useEffect(() => {
    peer.ontrack = (event) => {
      if (ref.current) {
        ref.current.srcObject = event.streams[0];
      }
    };
  }, [peer]);

  return (
    <video
      ref={ref}
      autoPlay
      playsInline
      width="100%"
      height="auto"
      style={{ borderRadius: '10px', marginTop: '10px' }}
    />
  );
};

const Room = ({ roomId: roomID }: { roomId: string }) => {
  const cardBg = useColorModeValue('white', 'gray.700');
  const cardTextColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const [peers, setPeers] = useState<RTCPeerConnection[]>([]);
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const peersRef = useRef<PeerRef[]>([]);
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const userJoinedBg = useColorModeValue('gray.100', 'gray.900');

  const createPeer = useCallback(
    (userToSignal: string, userId: string, stream: MediaStream) => {
      const peer = new RTCPeerConnection({
        iceServers: [
          {
            urls: 'stun:stun.stunprotocol.org',
          },
        ],
      });

      peer.onicecandidate = (event) => {
        if (event.candidate) {
          console.log('sending ice candidate', event.candidate);
          socket.emit('ice-candidate', {
            target: userToSignal,
            user: socket.id,
            candidate: event.candidate,
          });
        }
      };

      stream.getTracks().forEach((track) => peer.addTrack(track, stream));

      peer.createOffer().then((offer) => {
        peer.setLocalDescription(offer).then(() => {
          console.log(
            'setting local description as the offer and sending the offer',
            { userToSignal, userId, sdp: peer.localDescription }
          );
          socket.emit('offer', {
            target: userToSignal,
            user: userId,
            sdp: peer.localDescription,
          });
        });
      });

      return peer;
    },
    []
  );

  const addPeer = useCallback(
    (
      incomingSdp: RTCSessionDescriptionInit,
      userId: string,
      stream: MediaStream
    ) => {
      const peer = new RTCPeerConnection({
        iceServers: [
          {
            urls: 'stun:stun.stunprotocol.org',
          },
        ],
      });

      peer.onicecandidate = (event) => {
        if (event.candidate) {
          console.log(
            'sending ice candidate after receiving an offer',
            event.candidate
          );
          socket.emit('ice-candidate', {
            target: userId,
            user: socket.id,
            candidate: event.candidate,
          });
        }
      };

      stream.getTracks().forEach((track) => peer.addTrack(track, stream));

      peer
        .setRemoteDescription(new RTCSessionDescription(incomingSdp))
        .then(() => {
          peer.createAnswer().then((answer) => {
            peer.setLocalDescription(answer).then(() => {
              console.log(
                'setting local description as the answer and sending the answer',
                { userId, sdp: peer.localDescription }
              );
              socket.emit('answer', {
                target: userId,
                user: socket.id,
                sdp: peer.localDescription,
              });
            });
          });
        });

      return peer;
    },
    []
  );

  useEffect(() => {
    const handleReceiveOffer = (incoming: {
      sdp: RTCSessionDescriptionInit;
      user: string;
    }) => {
      const peer = addPeer(
        incoming.sdp,
        incoming.user,
        localVideoRef.current!.srcObject as MediaStream
      );

      console.log('created a peer after receiving an offer');

      peersRef.current.push({
        peerID: incoming.user,
        peer,
      });

      setPeers((users) => [...users, peer]);
    };

    const handleAnswer = (message: {
      sdp: RTCSessionDescriptionInit;
      user: string;
    }) => {
      console.log('received an answer', { ...message });
      console.log(peersRef.current);
      const item = peersRef.current.find((p) => p.peerID === message.user);
      item?.peer.setRemoteDescription(new RTCSessionDescription(message.sdp));
    };

    const handleNewICECandidateMsg = (incoming: {
      user: string;
      target: string;
      candidate: RTCIceCandidateInit;
    }) => {
      console.log('incoming from new ice.c', { incoming });
      const item = peersRef.current.find((p) => p.peerID === incoming.user);
      if (item) {
        const candidate = new RTCIceCandidate(incoming.candidate);
        item.peer.addIceCandidate(candidate);
      }
    };

    const fetchUserMedia = () => {
      return navigator.mediaDevices.getUserMedia({
        video: true,
        audio: true,
      });
    };

    const start = async () => {
      const stream = await fetchUserMedia();
      if (localVideoRef.current) {
        localVideoRef.current.srcObject = stream;
      }

      console.log('sending join event', roomID);
      socket.emit('join', roomID);

      // socket.on('all-users', (users: string[]) => {
      //   console.log(users);
      //   const peers: RTCPeerConnection[] = [];
      //   users.forEach((userID) => {
      //     const peer = createPeer(userID, socket.id!, stream);
      //     peersRef.current.push({
      //       peerID: userID,
      //       peer,
      //     });
      //     peers.push(peer);
      //   });
      //   setPeers(peers);
      // });

      socket.on('user-joined', (userID: string) => {
        const peer = createPeer(userID, socket.id!, stream);
        console.log('peer created after user joined');
        peersRef.current.push({
          peerID: userID,
          peer,
        });
        setPeers((prevPeers) => [...prevPeers, peer]);
      });

      socket.on('offer', handleReceiveOffer);
      socket.on('answer', handleAnswer);
      socket.on('ice-candidate', handleNewICECandidateMsg);
    };

    start();
    console.log('callingStart');

    return () => {
      console.log('exiting the component.');
      // socket.off('all-users');
      socket.off('user-joined');
      socket.off('offer', handleReceiveOffer);
      socket.off('answer', handleAnswer);
      socket.off('ice-candidate', handleNewICECandidateMsg);

      peersRef.current.forEach(({ peer }) => {
        peer.close();
      });

      socket.emit('leave-room', roomID);
    };
  }, [addPeer, createPeer, roomID]);

  const toggleMic = () => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  };

  const toggleVideo = () => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getVideoTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsVideoOn((prev) => !prev);
    }
  };

  return (
    <Flex
      direction="column"
      align="center"
      justify="center"
      height="100%"
      bg={cardBg}
      color={cardTextColor}
    >
      <Box borderWidth="1px" borderRadius="lg" p={4} width="full">
        <video
          muted
          ref={localVideoRef}
          autoPlay
          playsInline
          width="100%"
          style={{ borderRadius: '10px', height: '300px', width: '100%' }}
        />
        {peers.map((peer, index) => (
          <Video key={index} peer={peer} />
        ))}
        {peers.length === 0 && (
          <Flex
            direction="column"
            align="center"
            justify="center"
            height="50vh"
            bg={userJoinedBg}
            borderRadius="lg"
            p={6}
            mt={4}
          >
            <Text fontSize="xl" mb={4}>
              Waiting for another user to join...
            </Text>
            <Button
              colorScheme="teal"
              onClick={() => socket.emit('reconnectUser', { roomID })}
            >
              Try Reconnecting
            </Button>
          </Flex>
        )}
      </Box>
      <Stack direction="row" spacing={4} mt={4} mb={8}>
        <Button
          onClick={toggleMic}
          leftIcon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
          variant="outline"
        >
          {isMicOn ? 'Mute' : 'Unmute'}
        </Button>
        <Button
          onClick={toggleVideo}
          leftIcon={isVideoOn ? <FaVideo /> : <FaVideoSlash />}
          variant="outline"
        >
          {isVideoOn ? 'Turn Off Video' : 'Turn On Video'}
        </Button>
      </Stack>
    </Flex>
  );
};

export default Room;
