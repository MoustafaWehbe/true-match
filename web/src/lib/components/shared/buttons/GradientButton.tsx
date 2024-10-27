import { FC } from "react";
import { Button, ButtonProps } from "@chakra-ui/react";

interface GradientButtonProps extends ButtonProps {
  startColor?: string;
  endColor?: string;
}

const GradientButton: FC<GradientButtonProps> = ({
  startColor = "teal.500", // Default start color
  endColor = "green.500", // Default end color
  ...props
}) => {
  return (
    <Button
      bgGradient={`linear(to-r, ${startColor}, ${endColor})`}
      color="white"
      _hover={{ bgGradient: `linear(to-r, ${startColor}, ${endColor})` }}
      _active={{ bgGradient: `linear(to-r, ${startColor}, ${endColor})` }}
      {...props}
    />
  );
};

export default GradientButton;
