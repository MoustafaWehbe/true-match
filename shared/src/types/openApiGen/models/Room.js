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
exports.instanceOfRoom = instanceOfRoom;
exports.RoomFromJSON = RoomFromJSON;
exports.RoomFromJSONTyped = RoomFromJSONTyped;
exports.RoomToJSON = RoomToJSON;
var User_1 = require("./User");
var RoomParticipant_1 = require("./RoomParticipant");
/**
 * Check if a given object implements the Room interface.
 */
function instanceOfRoom(value) {
    return true;
}
function RoomFromJSON(json) {
    return RoomFromJSONTyped(json, false);
}
function RoomFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'id': json['id'] == null ? undefined : json['id'],
        'title': json['title'] == null ? undefined : json['title'],
        'description': json['description'] == null ? undefined : json['description'],
        'status': json['status'] == null ? undefined : json['status'],
        'scheduledAt': json['scheduledAt'] == null ? undefined : (new Date(json['scheduledAt'])),
        'finishedAt': json['finishedAt'] == null ? undefined : (new Date(json['finishedAt'])),
        'createdAt': json['createdAt'] == null ? undefined : (new Date(json['createdAt'])),
        'updatedAt': json['updatedAt'] == null ? undefined : (new Date(json['updatedAt'])),
        'offers': json['offers'] == null ? undefined : json['offers'],
        'questionsCategories': json['questionsCategories'] == null ? undefined : json['questionsCategories'],
        'userId': json['userId'] == null ? undefined : json['userId'],
        'user': json['user'] == null ? undefined : (0, User_1.UserFromJSON)(json['user']),
        'roomParticipants': json['roomParticipants'] == null ? undefined : (json['roomParticipants'].map(RoomParticipant_1.RoomParticipantFromJSON)),
    };
}
function RoomToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'id': value['id'],
        'title': value['title'],
        'description': value['description'],
        'status': value['status'],
        'scheduledAt': value['scheduledAt'] == null ? undefined : (value['scheduledAt'].toISOString()),
        'finishedAt': value['finishedAt'] == null ? undefined : (value['finishedAt'].toISOString()),
        'createdAt': value['createdAt'] == null ? undefined : ((value['createdAt']).toISOString()),
        'updatedAt': value['updatedAt'] == null ? undefined : ((value['updatedAt']).toISOString()),
        'offers': value['offers'],
        'questionsCategories': value['questionsCategories'],
        'userId': value['userId'],
        'user': (0, User_1.UserToJSON)(value['user']),
        'roomParticipants': value['roomParticipants'] == null ? undefined : (value['roomParticipants'].map(RoomParticipant_1.RoomParticipantToJSON)),
    };
}