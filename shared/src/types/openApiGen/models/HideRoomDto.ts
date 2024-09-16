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
/**
 * 
 * @export
 * @interface HideRoomDto
 */
export interface HideRoomDto {
    /**
     * 
     * @type {number}
     * @memberof HideRoomDto
     */
    roomId: number;
}

/**
 * Check if a given object implements the HideRoomDto interface.
 */
export function instanceOfHideRoomDto(value: object): value is HideRoomDto {
    if (!('roomId' in value) || value['roomId'] === undefined) return false;
    return true;
}

export function HideRoomDtoFromJSON(json: any): HideRoomDto {
    return HideRoomDtoFromJSONTyped(json, false);
}

export function HideRoomDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): HideRoomDto {
    if (json == null) {
        return json;
    }
    return {
        
        'roomId': json['roomId'],
    };
}

export function HideRoomDtoToJSON(value?: HideRoomDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'roomId': value['roomId'],
    };
}
