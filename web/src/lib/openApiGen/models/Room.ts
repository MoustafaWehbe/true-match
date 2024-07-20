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
import type { RoomParticipant } from './RoomParticipant';
import {
    RoomParticipantFromJSON,
    RoomParticipantFromJSONTyped,
    RoomParticipantToJSON,
} from './RoomParticipant';

/**
 * 
 * @export
 * @interface Room
 */
export interface Room {
    /**
     * 
     * @type {number}
     * @memberof Room
     */
    id?: number;
    /**
     * 
     * @type {string}
     * @memberof Room
     */
    title?: string | null;
    /**
     * 
     * @type {string}
     * @memberof Room
     */
    description?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof Room
     */
    hasStarted?: boolean;
    /**
     * 
     * @type {Date}
     * @memberof Room
     */
    scheduledAt?: Date | null;
    /**
     * 
     * @type {Date}
     * @memberof Room
     */
    finishedAt?: Date | null;
    /**
     * 
     * @type {Date}
     * @memberof Room
     */
    createdAt?: Date;
    /**
     * 
     * @type {Date}
     * @memberof Room
     */
    updatedAt?: Date;
    /**
     * 
     * @type {string}
     * @memberof Room
     */
    userId?: string | null;
    /**
     * 
     * @type {User}
     * @memberof Room
     */
    user?: User;
    /**
     * 
     * @type {Array<RoomParticipant>}
     * @memberof Room
     */
    roomParticipants?: Array<RoomParticipant> | null;
}

/**
 * Check if a given object implements the Room interface.
 */
export function instanceOfRoom(value: object): value is Room {
    return true;
}

export function RoomFromJSON(json: any): Room {
    return RoomFromJSONTyped(json, false);
}

export function RoomFromJSONTyped(json: any, ignoreDiscriminator: boolean): Room {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'title': json['title'] == null ? undefined : json['title'],
        'description': json['description'] == null ? undefined : json['description'],
        'hasStarted': json['hasStarted'] == null ? undefined : json['hasStarted'],
        'scheduledAt': json['scheduledAt'] == null ? undefined : (new Date(json['scheduledAt'])),
        'finishedAt': json['finishedAt'] == null ? undefined : (new Date(json['finishedAt'])),
        'createdAt': json['createdAt'] == null ? undefined : (new Date(json['createdAt'])),
        'updatedAt': json['updatedAt'] == null ? undefined : (new Date(json['updatedAt'])),
        'userId': json['userId'] == null ? undefined : json['userId'],
        'user': json['user'] == null ? undefined : UserFromJSON(json['user']),
        'roomParticipants': json['roomParticipants'] == null ? undefined : ((json['roomParticipants'] as Array<any>).map(RoomParticipantFromJSON)),
    };
}

export function RoomToJSON(value?: Room | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'id': value['id'],
        'title': value['title'],
        'description': value['description'],
        'hasStarted': value['hasStarted'],
        'scheduledAt': value['scheduledAt'] == null ? undefined : ((value['scheduledAt'] as any).toISOString()),
        'finishedAt': value['finishedAt'] == null ? undefined : ((value['finishedAt'] as any).toISOString()),
        'createdAt': value['createdAt'] == null ? undefined : ((value['createdAt']).toISOString()),
        'updatedAt': value['updatedAt'] == null ? undefined : ((value['updatedAt']).toISOString()),
        'userId': value['userId'],
        'user': UserToJSON(value['user']),
        'roomParticipants': value['roomParticipants'] == null ? undefined : ((value['roomParticipants'] as Array<any>).map(RoomParticipantToJSON)),
    };
}

