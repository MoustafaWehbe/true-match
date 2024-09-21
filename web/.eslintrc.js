module.exports = {
  extends: ['../.eslintrc.js'],
  overrides: [
    {
      files: ['*.jsx', '*.tsx'],
      parser: '@typescript-eslint/parser',
    },
  ],
};
