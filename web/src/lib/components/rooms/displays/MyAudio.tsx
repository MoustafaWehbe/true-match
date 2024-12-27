import { useSelector } from "react-redux";

import UserCard from "./UserCard";

import { RootState } from "~/lib/state/store";
import { colorPalette } from "~/lib/utils/colors/colors";

interface MyAudioProps {
  localAudioRef: React.RefObject<HTMLAudioElement>;
}

const MyAudio = ({ localAudioRef }: MyAudioProps) => {
  const { user } = useSelector((state: RootState) => state.user);

  if (!user) {
    return null;
  }

  return (
    <>
      <UserCard
        color={colorPalette[0]}
        user={user}
        isMe
        isOwner={false}
        onUserCardClicked={() => {}}
        onRemoveUser={() => {}}
      />
      <audio
        muted
        ref={localAudioRef}
        autoPlay
        style={{
          borderRadius: "10px",
          height: "100%",
          objectFit: "cover",
        }}
      />
    </>
  );
};
export default MyAudio;
