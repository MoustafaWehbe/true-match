import { useEffect, useRef } from 'react';

const PeerVideo: React.FC<{ peer?: RTCPeerConnection }> = ({ peer }) => {
  const ref = useRef<HTMLVideoElement>(null);

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

export default PeerVideo;
