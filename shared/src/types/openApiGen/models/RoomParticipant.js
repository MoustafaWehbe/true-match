"use strict";
/* tslint:disable */
/* eslint-disable */
/**
 * Dapp Api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
Object.defineProperty(exports, "__esModule", { value: true });
exports.instanceOfRoomParticipant = instanceOfRoomParticipant;
exports.RoomParticipantFromJSON = RoomParticipantFromJSON;
exports.RoomParticipantFromJSONTyped = RoomParticipantFromJSONTyped;
exports.RoomParticipantToJSON = RoomParticipantToJSON;
var User_1 = require("./User");
var Room_1 = require("./Room");
/**
 * Check if a given object implements the RoomParticipant interface.
 */
function instanceOfRoomParticipant(value) {
    return true;
}
function RoomParticipantFromJSON(json) {
    return RoomParticipantFromJSONTyped(json, false);
}
function RoomParticipantFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'roomId': json['roomId'] == null ? undefined : json['roomId'],
        'userId': json['userId'] == null ? undefined : json['userId'],
        'isInterested': json['isInterested'] == null ? undefined : json['isInterested'],
        'attended': json['attended'] == null ? undefined : json['attended'],
        'attendedFromTime': json['attendedFromTime'] == null ? undefined : (new Date(json['attendedFromTime'])),
        'attendedToTime': json['attendedToTime'] == null ? undefined : (new Date(json['attendedToTime'])),
        'socketId': json['socketId'] == null ? undefined : json['socketId'],
        'createdAt': json['createdAt'] == null ? undefined : (new Date(json['createdAt'])),
        'updatedAt': json['updatedAt'] == null ? undefined : (new Date(json['updatedAt'])),
        'room': json['room'] == null ? undefined : (0, Room_1.RoomFromJSON)(json['room']),
        'user': json['user'] == null ? undefined : (0, User_1.UserFromJSON)(json['user']),
    };
}
function RoomParticipantToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'roomId': value['roomId'],
        'userId': value['userId'],
        'isInterested': value['isInterested'],
        'attended': value['attended'],
        'attendedFromTime': value['attendedFromTime'] == null ? undefined : (value['attendedFromTime'].toISOString()),
        'attendedToTime': value['attendedToTime'] == null ? undefined : (value['attendedToTime'].toISOString()),
        'socketId': value['socketId'],
        'createdAt': value['createdAt'] == null ? undefined : ((value['createdAt']).toISOString()),
        'updatedAt': value['updatedAt'] == null ? undefined : ((value['updatedAt']).toISOString()),
        'room': (0, Room_1.RoomToJSON)(value['room']),
        'user': (0, User_1.UserToJSON)(value['user']),
    };
}
