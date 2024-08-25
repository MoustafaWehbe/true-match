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

import { mapValues } from '../runtime';
import type { User } from './User';
import {
    UserFromJSON,
    UserFromJSONTyped,
    UserToJSON,
} from './User';
import type { Room } from './Room';
import {
    RoomFromJSON,
    RoomFromJSONTyped,
    RoomToJSON,
} from './Room';

/**
 * 
 * @export
 * @interface RoomParticipant
 */
export interface RoomParticipant {
    /**
     * 
     * @type {number}
     * @memberof RoomParticipant
     */
    roomId?: number;
    /**
     * 
     * @type {string}
     * @memberof RoomParticipant
     */
    userId?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof RoomParticipant
     */
    isInterested?: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof RoomParticipant
     */
    attended?: boolean;
    /**
     * 
     * @type {Date}
     * @memberof RoomParticipant
     */
    attendedFromTime?: Date | null;
    /**
     * 
     * @type {Date}
     * @memberof RoomParticipant
     */
    attendedToTime?: Date | null;
    /**
     * 
     * @type {string}
     * @memberof RoomParticipant
     */
    socketId?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof RoomParticipant
     */
    createdAt?: Date;
    /**
     * 
     * @type {Date}
     * @memberof RoomParticipant
     */
    updatedAt?: Date;
    /**
     * 
     * @type {Room}
     * @memberof RoomParticipant
     */
    room?: Room;
    /**
     * 
     * @type {User}
     * @memberof RoomParticipant
     */
    user?: User;
}

/**
 * Check if a given object implements the RoomParticipant interface.
 */
export function instanceOfRoomParticipant(value: object): value is RoomParticipant {
    return true;
}

export function RoomParticipantFromJSON(json: any): RoomParticipant {
    return RoomParticipantFromJSONTyped(json, false);
}

export function RoomParticipantFromJSONTyped(json: any, ignoreDiscriminator: boolean): RoomParticipant {
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
        'room': json['room'] == null ? undefined : RoomFromJSON(json['room']),
        'user': json['user'] == null ? undefined : UserFromJSON(json['user']),
    };
}

export function RoomParticipantToJSON(value?: RoomParticipant | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'roomId': value['roomId'],
        'userId': value['userId'],
        'isInterested': value['isInterested'],
        'attended': value['attended'],
        'attendedFromTime': value['attendedFromTime'] == null ? undefined : ((value['attendedFromTime'] as any).toISOString()),
        'attendedToTime': value['attendedToTime'] == null ? undefined : ((value['attendedToTime'] as any).toISOString()),
        'socketId': value['socketId'],
        'createdAt': value['createdAt'] == null ? undefined : ((value['createdAt']).toISOString()),
        'updatedAt': value['updatedAt'] == null ? undefined : ((value['updatedAt']).toISOString()),
        'room': RoomToJSON(value['room']),
        'user': UserToJSON(value['user']),
    };
}
