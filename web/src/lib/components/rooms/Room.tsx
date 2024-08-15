'use client';

import React, { useEffect, useRef, useState } from 'react';
import { Box, Button, Flex, Text, useColorModeValue } from '@chakra-ui/react';
import { socket } from '~/lib/utils/socket/socket';
import RoomSettings from './RoomSettings';
import { WebRTCHandler } from '~/lib/utils/webrtc/WebRTCHandler';
import PeerVideo from './PeerVideo';

const Room = ({ roomId: roomID }: { roomId: string }) => {
  const cardBg = useColorModeValue('white', 'gray.700');
  const cardTextColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const userJoinedBg = useColorModeValue('gray.100', 'gray.900');
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const webRTCHandler = useRef<WebRTCHandler | null>(null);
  const [peers, setPeers] = useState<
    { peerID: string; peer: RTCPeerConnection }[]
  >([]);

  useEffect(() => {
    webRTCHandler.current = new WebRTCHandler(roomID, setPeers);
    webRTCHandler.current.init(localVideoRef);

    return () => {
      webRTCHandler.current?.closeConnections();
    };
  }, [roomID]);

  const onToggleMic = () => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  };

  const onToggleVideo = () => {
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
        {peers?.map((peer, index) => (
          <PeerVideo key={index} peer={peer.peer} />
        ))}
        {peers?.length === 0 && (
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
      <RoomSettings
        onToggleMic={onToggleMic}
        onToggleVideo={onToggleVideo}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
      />
    </Flex>
  );
};

export default Room;
