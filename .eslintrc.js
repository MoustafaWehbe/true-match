module.exports = {
  root: true,
  parser: "@typescript-eslint/parser",
  extends: ["plugin:react/recommended", "prettier"],
  plugins: ["@typescript-eslint", "react-hooks", "react", "simple-import-sort"],
  parserOptions: {
    ecmaVersion: 2018,
    sourceType: "module",
    ecmaFeatures: {
      jsx: true,
    },
  },
  settings: {
    react: {
      version: "detect",
      componentWrapperFunctions: [
        "observer",
        "forwardRef",
        { property: "forwardRef", object: "React" },
      ],
    },
  },
  env: {
    browser: true,
    node: true,
    jest: true,
    es6: true,
  },
  rules: {
    "react-hooks/rules-of-hooks": "error",
    "react-hooks/exhaustive-deps": "error",
    "@typescript-eslint/no-unused-vars": [
      "error",
      {
        argsIgnorePattern: "^_",
        varsIgnorePattern: "^_",
        args: "after-used",
        ignoreRestSiblings: true,
      },
    ],
    "no-unused-expressions": 0,
    "@typescript-eslint/no-unused-expressions": 2,
    "no-console": 0,
    "no-confusing-arrow": 0,
    "no-else-return": 0,
    "no-return-assign": [2, "except-parens"],
    "no-underscore-dangle": 0,
    camelcase: 0,
    "prefer-arrow-callback": [
      "error",
      {
        allowNamedFunctions: true,
      },
    ],
    "class-methods-use-this": 0,
    "no-restricted-syntax": 0,
    "no-param-reassign": [
      "error",
      {
        props: false,
      },
    ],
    "react/prop-types": 0,
    "react/no-multi-comp": 0,
    "react/jsx-filename-extension": 0,
    "react/no-unescaped-entities": 0,
    "import/no-extraneous-dependencies": 0,
    "react/destructuring-assignment": 0,
    "arrow-body-style": 0,
    "no-nested-ternary": 0,
    "simple-import-sort/imports": [
      "error",
      {
        groups: [
          [
            "^(assert|buffer|child_process|cluster|console|constants|crypto|dgram|dns|domain|events|fs|http|https|module|net|os|path|punycode|querystring|readline|repl|stream|string_decoder|sys|timers|tls|tty|url|util|vm|zlib|freelist|v8|process|async_hooks|http2|perf_hooks)(/.*|$)",
          ],
          // Packages. `react` related packages come first.
          ["^react", "^@?\\w"],
          // Internal packages.
          ["^(@|@truematch)(/[^web]*|$)"],
          // Web imports.
          ["^(@|@truematch/web)(/.*|$)"],
          // Side effect imports.
          ["^\\u0000"],
          // Parent imports. Put `..` last.
          ["^\\.\\.(?!/?$)", "^\\.\\./?$"],
          // Other relative imports. Put same-folder imports and `.` last.
          ["^\\./(?=.*/)(?!/?$)", "^\\.(?!/?$)", "^\\./?$"],
          // Style imports.
          ["^.+\\.s?css$"],
        ],
      },
    ],
    "react/react-in-jsx-scope": "off",
    "react/jsx-uses-react": "off",
  },
  globals: {
    JSX: true,
  },
};
