import { useEffect, useRef } from "react";
import { Box, Flex } from "@chakra-ui/react";

import { UserDto } from "@dapp/shared/src/types/openApiGen";

import { calculateAge } from "~/lib/utils/date/date";

const PeerVideo: React.FC<{ peer?: RTCPeerConnection; user?: UserDto }> = ({
  peer,
  user,
}) => {
  const ref = useRef<HTMLVideoElement>(null);

  useEffect(() => {
    if (peer) {
      peer.ontrack = (event) => {
        // TODO: remove this
        event.streams[0].getTracks().forEach((track) => {
          console.log(`Received track: ${track.kind}`);
        });
        if (ref.current) {
          ref.current.srcObject = event.streams[0];
        }
      };
    }
  }, [peer]);

  if (!user) {
    return null;
  }

  return (
    <Flex
      direction={"column"}
      gap={4}
      fontSize={{ base: "s", md: "s" }}
      fontWeight={"bold"}
      color={"white"}
    >
      <Box
        textTransform={"uppercase"}
        position={"absolute"}
        left={"10px"}
        bottom={"10px"}
      >
        {user.firstName},{" "}
        {calculateAge(new Date(user?.userProfile?.birthDate!))}
      </Box>
      <video
        ref={ref}
        autoPlay
        playsInline
        width="100%"
        height="auto"
        style={{ borderRadius: "10px", marginTop: "10px" }}
      />
    </Flex>
  );
};

export default PeerVideo;
