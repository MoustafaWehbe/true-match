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
import type { RoomParticipantDto } from './RoomParticipantDto';
import {
    RoomParticipantDtoFromJSON,
    RoomParticipantDtoFromJSONTyped,
    RoomParticipantDtoToJSON,
} from './RoomParticipantDto';

/**
 * 
 * @export
 * @interface RoomParticipantDtoApiResponse
 */
export interface RoomParticipantDtoApiResponse {
    /**
     * 
     * @type {number}
     * @memberof RoomParticipantDtoApiResponse
     */
    statusCode?: number;
    /**
     * 
     * @type {string}
     * @memberof RoomParticipantDtoApiResponse
     */
    message?: string | null;
    /**
     * 
     * @type {RoomParticipantDto}
     * @memberof RoomParticipantDtoApiResponse
     */
    data?: RoomParticipantDto;
}

/**
 * Check if a given object implements the RoomParticipantDtoApiResponse interface.
 */
export function instanceOfRoomParticipantDtoApiResponse(value: object): value is RoomParticipantDtoApiResponse {
    return true;
}

export function RoomParticipantDtoApiResponseFromJSON(json: any): RoomParticipantDtoApiResponse {
    return RoomParticipantDtoApiResponseFromJSONTyped(json, false);
}

export function RoomParticipantDtoApiResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): RoomParticipantDtoApiResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'statusCode': json['statusCode'] == null ? undefined : json['statusCode'],
        'message': json['message'] == null ? undefined : json['message'],
        'data': json['data'] == null ? undefined : RoomParticipantDtoFromJSON(json['data']),
    };
}

export function RoomParticipantDtoApiResponseToJSON(value?: RoomParticipantDtoApiResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'statusCode': value['statusCode'],
        'message': value['message'],
        'data': RoomParticipantDtoToJSON(value['data']),
    };
}
