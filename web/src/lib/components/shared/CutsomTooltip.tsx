import React, { PropsWithChildren } from "react";
import { Tooltip, TooltipProps } from "@chakra-ui/react";

interface CustomTooltipProps extends Omit<TooltipProps, "label"> {
  label: string;
}

const CustomTooltip = ({
  label,
  children,
  ...tooltipProps
}: PropsWithChildren<CustomTooltipProps>) => {
  return (
    <Tooltip
      placement="top"
      hasArrow
      arrowSize={10}
      fontSize="md"
      bg="pink.600"
      color="white"
      px={4}
      py={2}
      borderRadius="md"
      shadow="md"
      {...tooltipProps}
      label={label}
    >
      {children}
    </Tooltip>
  );
};

export default CustomTooltip;
