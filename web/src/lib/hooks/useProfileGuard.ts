import { useEffect } from "react";
import { useSelector } from "react-redux";
import { useRouter } from "next/navigation";

import { ONBOARDING_ROUTE } from "../consts";
import { RootState } from "../state/store";

const useProfileGuard = () => {
  const router = useRouter();
  const { user, isFetchingUser } = useSelector(
    (state: RootState) => state.user
  );

  useEffect(() => {
    const checkAccess = async () => {
      if (
        !user?.userProfile?.birthDate ||
        !user.userProfile.userProfileGenders?.length ||
        !(
          user.userProfile.selectedDescriptors &&
          user.userProfile.selectedDescriptors.find(
            (desc) => desc.availableDescriptorId === 3
          )
        ) ||
        !(
          user.userProfile.selectedDescriptors &&
          user.userProfile.selectedDescriptors.find(
            (desc) => desc.availableDescriptorId === 2
          )
        ) ||
        !user.media?.length ||
        !user.userProfile.pos
      ) {
        window.location.href = "/onboarding";
      }
    };

    if (
      user &&
      !isFetchingUser &&
      !window.location.pathname.slice(1).includes(ONBOARDING_ROUTE)
    ) {
      checkAccess();
    }
  }, [router, user, isFetchingUser]);
};

export default useProfileGuard;
