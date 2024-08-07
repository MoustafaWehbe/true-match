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

  return <video ref={ref} autoPlay playsInline />;
};

const Room = ({ roomId: roomID }: { roomId: string }) => {
  const cardBg = useColorModeValue('white', 'gray.700');
  const cardTextColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const [peers, setPeers] = useState<RTCPeerConnection[]>([]);
  const userVideo = useRef<HTMLVideoElement>(null);
  const peersRef = useRef<PeerRef[]>([]);

  const createPeer = useCallback(
    (userToSignal: string, callerID: string, stream: MediaStream) => {
      const peer = new RTCPeerConnection({
        iceServers: [
          {
            urls: 'stun:stun.stunprotocol.org',
          },
        ],
      });

      peer.onicecandidate = (event) => {
        if (event.candidate) {
          socket.emit('ice-candidate', {
            target: userToSignal,
            candidate: event.candidate,
          });
        }
      };

      peer.ontrack = (event) => {
        const remoteVideo = document.createElement('video');
        remoteVideo.srcObject = event.streams[0];
        remoteVideo.autoplay = true;
        remoteVideo.playsInline = true;
        document.body.appendChild(remoteVideo);
      };

      stream.getTracks().forEach((track) => peer.addTrack(track, stream));

      peer.createOffer().then((offer) => {
        peer.setLocalDescription(offer).then(() => {
          socket.emit('offer', {
            target: userToSignal,
            caller: callerID,
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
      callerID: string,
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
          socket.emit('ice-candidate', {
            target: callerID,
            candidate: event.candidate,
          });
        }
      };

      peer.ontrack = (event) => {
        const remoteVideo = document.createElement('video');
        remoteVideo.srcObject = event.streams[0];
        remoteVideo.autoplay = true;
        remoteVideo.playsInline = true;
        document.body.appendChild(remoteVideo);
      };

      stream.getTracks().forEach((track) => peer.addTrack(track, stream));

      peer
        .setRemoteDescription(new RTCSessionDescription(incomingSdp))
        .then(() => {
          peer.createAnswer().then((answer) => {
            peer.setLocalDescription(answer).then(() => {
              socket.emit('answer', {
                target: callerID,
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
    const handleReceiveCall = (incoming: {
      sdp: RTCSessionDescriptionInit;
      caller: string;
    }) => {
      const peer = addPeer(
        incoming.sdp,
        incoming.caller,
        userVideo.current!.srcObject as MediaStream
      );

      peersRef.current.push({
        peerID: incoming.caller,
        peer,
      });

      setPeers((users) => [...users, peer]);
    };

    const handleAnswer = (message: {
      sdp: RTCSessionDescriptionInit;
      caller: string;
    }) => {
      const item = peersRef.current.find((p) => p.peerID === message.caller);
      item?.peer.setRemoteDescription(new RTCSessionDescription(message.sdp));
    };

    const handleNewICECandidateMsg = (incoming: {
      id: string;
      candidate: RTCIceCandidateInit;
    }) => {
      const item = peersRef.current.find((p) => p.peerID === incoming.id);
      if (item) {
        const candidate = new RTCIceCandidate(incoming.candidate);
        item.peer.addIceCandidate(candidate);
      }
    };

    navigator.mediaDevices
      .getUserMedia({ video: true, audio: true })
      .then((stream) => {
        if (userVideo.current) {
          userVideo.current.srcObject = stream;
        }

        socket.emit('join', roomID);

        socket.on('all-users', (users: string[]) => {
          const peers: RTCPeerConnection[] = [];
          users.forEach((userID) => {
            const peer = createPeer(userID, socket.id!, stream);
            peersRef.current.push({
              peerID: userID,
              peer,
            });
            peers.push(peer);
          });
          setPeers(peers);
        });

        socket.on('offer', handleReceiveCall);
        socket.on('answer', handleAnswer);
        socket.on('ice-candidate', handleNewICECandidateMsg);
      });

    return () => {
      socket.off('all-users');
      socket.off('offer', handleReceiveCall);
      socket.off('answer', handleAnswer);
      socket.off('ice-candidate', handleNewICECandidateMsg);

      peersRef.current.forEach(({ peer }) => {
        peer.close();
      });

      socket.emit('leave-room', roomID);
    };
  }, [addPeer, createPeer, roomID]);

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
        <video muted ref={userVideo} autoPlay playsInline />
        {peers.map((peer, index) => (
          <Video key={index} peer={peer} />
        ))}
      </Box>
    </Flex>
  );
};

export default Room;
