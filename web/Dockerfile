# Use a Node.js base image
FROM node:20-alpine

# Set working directory
WORKDIR /app

# Copy only the necessary files for installation
COPY package.json yarn.lock ./

# Copy the workspaces' package.json files
COPY web/package.json web/
COPY shared/package.json shared/

# Install dependencies
RUN yarn install --production

# Copy the rest of the application code
COPY . .

# Build the Next.js application
RUN yarn workspace @dapp/web build

# Expose port
EXPOSE 3000

# Start the application
CMD ["yarn", "workspace", "@dapp/web", "start"]
