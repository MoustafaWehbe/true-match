import { Server as SocketIOServer } from "socket.io";

interface Offer {
  offererUserName: string;
  offer: any;
  offerIceCandidates: any[];
  answererUserName: string | null;
  answer: any | null;
  answererIceCandidates: any[];
}

interface ConnectedSocket {
  socketId: string;
  userName: string;
}

class SocketHandler {
  private io: SocketIOServer;
  private offers: Offer[] = [
    // offererUserName
    // offer
    // offerIceCandidates
    // answererUserName
    // answer
    // answererIceCandidates
  ];
  private connectedSockets: ConnectedSocket[] = [
    //username, socketId
  ];
  private rooms: any = {};

  constructor(io: SocketIOServer) {
    this.io = io;
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", socket => {
      console.log("New client connected");

      socket.on("join", room => {
        if (!this.rooms[room]) {
          this.rooms[room] = [];
        }
        this.rooms[room].push(socket.id);
        socket.join(room);
        socket.broadcast.to(room).emit("user-joined", socket.id);
      });

      //payload:
      // {
      //   target,
      //   user,
      //   sdp,
      // }
      socket.on("offer", payload => {
        this.io.to(payload.target).emit("offer", payload);
      });

      //payload:
      // target,
      // sdp,
      socket.on("answer", payload => {
        this.io.to(payload.target).emit("answer", payload);
      });

      // incoming:
      // target: userToSignal,
      // user,
      // candidate: event.candidate,
      socket.on("ice-candidate", incoming => {
        this.io.to(incoming.target).emit("ice-candidate", incoming);
      });

      socket.on("disconnect", () => {
        for (const room in this.rooms) {
          this.rooms[room] = this.rooms[room].filter(
            (id: any) => id !== socket.id,
          );
        }
        console.log("Client disconnected");
      });
    });
  }

  // private handleConnection(): void {
  //   this.io.on("connection", async (socket: Socket) => {
  //     // console.log("Someone has connected");
  //     const token = socket.handshake.auth.token as string;
  //     let user: UserApiResponse | null = null;
  //     try {
  //       user = await userService.verifyUser(token);
  //       if (user.statusCode !== 200 && user.statusCode !== 201) {
  //         throw Error("Unauthorized!");
  //       }
  //     } catch {
  //       socket.disconnect(true);
  //       throw Error("Unauthorized!");
  //     }
  //     const userName = user.data.firstName + " " + user.data.lastName;

  //     // this.connectedSockets.push({
  //     //   socketId: socket.id,
  //     //   userName,
  //     // });

  //     // //a new client has joined. If there are any offers available,
  //     // //emit them out
  //     // if (this.offers.length) {
  //     //   socket.emit("availableOffers", this.offers);
  //     // }

  //     socket.on("startRoom", async ({ roomId }: { roomId: number }) => {
  //       this.handleStartRoom(roomId, socket, token);
  //     });

  //     socket.on("joinRoom", async ({ roomId }: { roomId: number }) => {
  //       this.handleJoinRoom(roomId, socket, token);
  //     });

  //     socket.on("newOffer", (newOffer: { offer: Offer; roomId: number }) =>
  //       this.handleNewOffer(socket, newOffer, userName, token)
  //     );
  //     // socket.on(
  //     //   "newAnswer",
  //     //   (newOffer: { offer: Offer; roomId: number }, ackFunction: Function) =>
  //     //     this.handleNewAnswer(socket, newOffer, userName, token, ackFunction)
  //     // );
  //     // socket.on("sendIceCandidateToSignalingServer", (iceCandidateObj: any) =>
  //     //   this.handleIceCandidate(socket, iceCandidateObj)
  //     // );
  //   });
  // }

  // private async handleStartRoom(roomId: number, socket: Socket, token: string) {
  //   try {
  //     const room = await roomService.getRoomById(token, roomId);
  //     if (room) {
  //       socket.join(roomId.toString());
  //       room.data.status = 1;
  //       await roomService.updateRoom(token, room.data, roomId);
  //     }
  //   } catch {
  //     socket.disconnect(true);
  //     throw Error("Failde to update room!");
  //   }
  // }

  // private async handleJoinRoom(roomId: number, socket: Socket, token: string) {
  //   try {
  //     const room = await roomService.getRoomById(token, roomId);
  //     if (room) {
  //       await roomService.joinRoom(token, roomId, socket.id);
  //       socket.join(roomId.toString());
  //       socket.emit("availableOffers", room.data.offers);
  //     }
  //   } finally {
  //     socket.disconnect(true);
  //     throw Error("Failde to add participant!");
  //   }
  // }

  // private async handleNewOffer(
  //   socket: Socket,
  //   newOffer: { offer: Offer; roomId: number },
  //   userName: string,
  //   token: string
  // ): Promise<void> {
  //   const room = await roomService.getRoomById(token, newOffer.roomId);

  //   const offerObj: any = {
  //     offererUserName: userName,
  //     offer: newOffer,
  //     offerIceCandidates: [],
  //     answererUserName: null,
  //     answer: null,
  //     answererIceCandidates: [],
  //   };

  //   room.data.offers = [...room.data.offers, offerObj];

  //   await roomService.updateRoom(token, room.data, newOffer.roomId);
  //   socket.to(newOffer.roomId.toString()).emit("newOfferAwaiting", [offerObj]);

  //   // console.log(newOffer.sdp.slice(50))
  //   //send out to all connected sockets EXCEPT the caller
  //   // socket.broadcast.emit("newOfferAwaiting", this.offers.slice(-1));
  // }

  // private async handleNewAnswer(
  //   socket: Socket,
  //   newOffer: { offer: Offer; roomId: number },
  //   userName: string,
  //   token: string,
  //   ackFunction: Function
  // ): void {
  //   console.log(newOffer);
  //   const room = await roomService.getRoomById(token, newOffer.roomId);
  //   const participantToAnswer = room.data.roomParticipants.find(rp => rp.)
  //   //emit this answer (offerObj) back to CLIENT1
  //   //in order to do that, we need CLIENT1's socketid
  //   const socketToAnswer = room.data.roomParticipants.find(
  //     (participant) => participant === offerObj.offererUserName
  //   );

  //   const socketToAnswer = this.connectedSockets.find(
  //     (s) => s.userName === offerObj.offererUserName
  //   );

  //   if (!socketToAnswer) {
  //     console.log("No matching socket");
  //     return;
  //   }

  //   //we found the matching socket, so we can emit to it!
  //   const socketIdToAnswer = socketToAnswer.socketId;
  //   //we find the offer to update so we can emit it
  //   const offerToUpdate = this.offers.find(
  //     (o) => o.offererUserName === offerObj.offererUserName
  //   );

  //   if (!offerToUpdate) {
  //     console.log("No OfferToUpdate");
  //     return;
  //   }

  //   //send back to the answerer all the iceCandidates we have already collected
  //   ackFunction(offerToUpdate.offerIceCandidates);
  //   offerToUpdate.answer = offerObj.answer;
  //   offerToUpdate.answererUserName = userName;

  //   //socket has a .to() which allows emiting to a "room"
  //   //every socket has it's own room
  //   socket.to(socketIdToAnswer).emit("answerResponse", offerToUpdate);
  // }

  // private handleIceCandidate(socket: Socket, iceCandidateObj: any): void {
  //   const { didIOffer, iceUserName, iceCandidate } = iceCandidateObj;
  //   // console.log(iceCandidate);
  //   if (didIOffer) {
  //     //this ice is coming from the offerer. Send to the answerer
  //     const offerInOffers = this.offers.find(
  //       (o) => o.offererUserName === iceUserName
  //     );
  //     if (offerInOffers) {
  //       offerInOffers.offerIceCandidates.push(iceCandidate);
  //       // 1. When the answerer answers, all existing ice candidates are sent
  //       // 2. Any candidates that come in after the offer has been answered, will be passed through
  //       if (offerInOffers.answererUserName) {
  //         //pass it through to the other socket
  //         const socketToSendTo = this.connectedSockets.find(
  //           (s) => s.userName === offerInOffers.answererUserName
  //         );
  //         if (socketToSendTo) {
  //           socket
  //             .to(socketToSendTo.socketId)
  //             .emit("receivedIceCandidateFromServer", iceCandidate);
  //         } else {
  //           console.log("Ice candidate recieved but could not find answere");
  //         }
  //       }
  //     }
  //   } else {
  //     //this ice is coming from the answerer. Send to the offerer
  //     //pass it through to the other socket
  //     const offerInOffers = this.offers.find(
  //       (o) => o.answererUserName === iceUserName
  //     );
  //     const socketToSendTo = this.connectedSockets.find(
  //       (s) => s.userName === offerInOffers.offererUserName
  //     );
  //     if (socketToSendTo) {
  //       socket
  //         .to(socketToSendTo.socketId)
  //         .emit("receivedIceCandidateFromServer", iceCandidate);
  //     } else {
  //       console.log("Ice candidate recieved but could not find offerer");
  //     }
  //   }
  //   // console.log(offers)
  // }
}

export default SocketHandler;
