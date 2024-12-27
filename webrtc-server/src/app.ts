import fs from "fs";
import https, { Server as HTTPSServer } from "https";

import { instrument } from "@socket.io/admin-ui";
import express, { Application } from "express";
import { Server as SocketIOServer } from "socket.io";

import authMiddleware from "./middlwares/authMiddleware";
import SocketHandler from "./socketHandler";

class App {
  public server: Application;
  public expressServer!: HTTPSServer | any;
  public io!: SocketIOServer;

  constructor() {
    this.server = express();
    this.setupHTTPS();
    this.setupSocketIO();
  }

  //we need a key and cert to run https
  //we generated them with mkcert
  // $ mkcert create-ca
  // $ mkcert create-cert
  private setupHTTPS(): void {
    const key = fs.readFileSync("./certs/create-cert-key.pem");
    const cert = fs.readFileSync("./certs/create-cert.pem");

    //we changed our express setup so we can use https
    //pass the key and cert to createServer on https
    this.expressServer = https.createServer({ key, cert }, this.server);
  }

  private setupSocketIO(): void {
    this.io = new SocketIOServer(this.expressServer, {
      cors: {
        origin: [
          "https://localhost",
          "http://localhost:3000",
          "https://admin.socket.io",
          "https://192.168.43.7", // Laptop WebSocket server
          "http://192.168.43.7:3000", // Laptop React App
        ],
        credentials: true,
        methods: ["GET", "POST"],
      },
    });
    instrument(this.io, { auth: false });
    this.io.use(authMiddleware);
    new SocketHandler(this.io);
  }

  public start(): void {
    const PORT = process.env.PORT || 8181;
    this.expressServer.listen(PORT, "0.0.0.0", () => {
      console.log(`Server is running on port ${PORT}`);
    });
  }
}

export default new App();
