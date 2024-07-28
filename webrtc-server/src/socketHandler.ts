import { Server as SocketIOServer, Socket } from "socket.io";
import { userService } from "./services";
import { roomService } from "./services";
import { UserApiResponse } from "./openApiGen";

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

  constructor(io: SocketIOServer) {
    this.io = io;
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", async (socket: Socket) => {
      // console.log("Someone has connected");
      const token = socket.handshake.auth.token as string;
      console.log(token);
      let user: UserApiResponse | null = null;
      try {
        user = await userService.verifyUser(token);
        if (user.statusCode !== 200 && user.statusCode !== 201) {
          throw Error("Unauthorized!");
        }
      } catch {
        socket.disconnect(true);
        throw Error("Unauthorized!");
      }

      socket.on("startRoom", async (roomId) => {
        try {
          const room = await roomService.getRoomById(token, roomId);
          if (room) {
            socket.join(roomId);
            room.data.hasStarted = true;
            await roomService.updateRoom(token, room.data, roomId);
          }
        } catch {
          socket.disconnect(true);
          throw Error("Failde to update room!");
        }
      });

      socket.on("joinRoom", async (roomId) => {
        try {
          const room = await roomService.getRoomById(token, roomId);
          if (room) {
            socket.join(roomId);
            await client.query(
              "INSERT INTO RoomParticipants (room_id, user_id) VALUES ($1, $2)",
              [roomId, user.id]
            );
            socket.emit("availableOffers", room.offers);
          }
        } finally {
          socket.disconnect(true);
          throw Error("Failde to add participant!");
        }
      });

      // this.connectedSockets.push({
      //   socketId: socket.id,
      //   userName,
      // });

      // //a new client has joined. If there are any offers available,
      // //emit them out
      // if (this.offers.length) {
      //   socket.emit("availableOffers", this.offers);
      // }

      // socket.on("newOffer", (newOffer: any) =>
      //   this.handleNewOffer(socket, newOffer, userName)
      // );
      // socket.on("newAnswer", (offerObj: Offer, ackFunction: Function) =>
      //   this.handleNewAnswer(socket, offerObj, ackFunction, userName)
      // );
      // socket.on("sendIceCandidateToSignalingServer", (iceCandidateObj: any) =>
      //   this.handleIceCandidate(socket, iceCandidateObj)
      // );
    });
  }

  // private handleNewOffer(
  //   socket: Socket,
  //   newOffer: any,
  //   userName: string
  // ): void {
  //   this.offers.push({
  //     offererUserName: userName,
  //     offer: newOffer,
  //     offerIceCandidates: [],
  //     answererUserName: null,
  //     answer: null,
  //     answererIceCandidates: [],
  //   });

  //   // console.log(newOffer.sdp.slice(50))
  //   //send out to all connected sockets EXCEPT the caller
  //   socket.broadcast.emit("newOfferAwaiting", this.offers.slice(-1));
  // }

  // private handleNewAnswer(
  //   socket: Socket,
  //   offerObj: Offer,
  //   ackFunction: Function,
  //   userName: string
  // ): void {
  //   console.log(offerObj);
  //   //emit this answer (offerObj) back to CLIENT1
  //   //in order to do that, we need CLIENT1's socketid
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
