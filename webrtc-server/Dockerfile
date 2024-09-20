FROM node:20-alpine

WORKDIR /app

# Copy only the necessary files for installation
COPY package.json yarn.lock ./

# Copy the workspaces' package.json files
COPY webrtc-server/package.json webrtc-server/
COPY shared/package.json shared/

# Install dependencies
RUN yarn install --production

# Copy the rest of the application code
COPY . .

# Expose port
EXPOSE 8080

# Start the application
CMD ["yarn", "workspace", "@dapp/webrtc-server", "start"]
