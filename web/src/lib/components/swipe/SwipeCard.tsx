'use client';

import { forwardRef, useState } from 'react';

import CardSwipeable from './CardSwipeable';
import CardStatic from './CardStatic';

interface SwipeCardProps {
  user: any;
  index: number;
  isActive: boolean;
  onUndo: () => void;
  outOfFrame: (idx: number) => void;
  onSwipe: (idx: number) => void;
}

export const sharedCardContainerStyles: React.CSSProperties = {
  position: 'absolute',
  width: '90vw',
  maxWidth: '360px',
  height: '70vh',
};

const SwipeCard = forwardRef<any, SwipeCardProps>(
  ({ user, index, outOfFrame, onSwipe, isActive }, ref) => {
    const [isExpanded, setIsExpanded] = useState(false);

    const handleIsExpanded = () => {
      setIsExpanded(!isExpanded);
    };

    return (
      <>
        {!isExpanded ? (
          <CardSwipeable
            user={user}
            index={index}
            outOfFrame={outOfFrame}
            handleIsExpanded={handleIsExpanded}
            onSwipe={onSwipe}
            isActive={isActive}
            ref={ref}
          />
        ) : (
          <CardStatic
            user={user}
            index={index}
            handleIsExpanded={handleIsExpanded}
          />
        )}
      </>
    );
  }
);

SwipeCard.displayName = 'SwipeCard';
export default SwipeCard;
