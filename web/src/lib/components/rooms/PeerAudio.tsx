import { useEffect, useRef } from "react";

const PeerAudio: React.FC<{ peer?: RTCPeerConnection }> = ({ peer }) => {
  const ref = useRef<HTMLAudioElement>(null);

  useEffect(() => {
    if (peer) {
      peer.ontrack = (event) => {
        if (ref.current) {
          ref.current.srcObject = event.streams[0];
        }
      };
    }
  }, [peer]);

  return (
    <audio
      ref={ref}
      autoPlay
      style={{ borderRadius: "10px", marginTop: "10px" }}
    />
  );
};

export default PeerAudio;
