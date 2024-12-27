export const colorPalette = [
  "#FF6B6B", // Coral
  "#FF8E72", // Sunset Orange
  "#6A67CE", // Soft Purple
  "#4A90E2", // Sky Blue
  "#7DCEA0", // Mint Green
  "#FF5A5F", // Passion Red
  "#E94E77", // Rose Pink
];

export const getRandomColor = () =>
  colorPalette[Math.floor(Math.random() * colorPalette.length)];
