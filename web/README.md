## 🔋 ⚡ Battery Packed template

- 🚀 **Next.js 14** - **React 18**
- ⛓️ **TypeScript**
- **Chakra-UI** v2
- ✔️ **toolings** for linting, formatting, and conventions configured
  - `eslint`, `prettier`, `husky`, `lint-staged`, `commitlint`, `commitizen`, and `standard-version`
  - `pre-commit`, `pre-push`, `commit-msg`, `prepare-commit-msg` hook configured
- 📱 **PWA-ready** - `next-pwa` configured, enabled by default, just disable it through `next.config.js`
- 🔎 SEO optimization configured - with `next-sitemap`.
  - you'll need to reconfigure or tinker with it to get it right according to your needs, but it's there if you need it.
- 🎨 basic responsive layout configured - don't need it? just remove it 😃
- 🤖 **Automatic Dependency Update** with [Renovate](https://renovatebot.com/)
- 🏎️ **Turbo** setup
- 🧪 **Playwright** E2E Test

## Pre-requisites

1. [Node.js](https://nodejs.org/en/) or nvm installed.
2. `pnpm` installed.

## Getting Started

1. Clone this repo

2. After cloning the project, run this command: `pnpm` or `pnpm install`

3. Then, run the development server:

```bash
pnpm run generate-types
pnpm dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.
