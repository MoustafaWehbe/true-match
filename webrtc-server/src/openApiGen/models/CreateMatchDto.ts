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
import type { MatchOrigin } from './MatchOrigin';
import {
    MatchOriginFromJSON,
    MatchOriginFromJSONTyped,
    MatchOriginToJSON,
} from './MatchOrigin';

/**
 * 
 * @export
 * @interface CreateMatchDto
 */
export interface CreateMatchDto {
    /**
     * 
     * @type {string}
     * @memberof CreateMatchDto
     */
    user2Id?: string | null;
    /**
     * 
     * @type {MatchOrigin}
     * @memberof CreateMatchDto
     */
    origin?: MatchOrigin;
}

/**
 * Check if a given object implements the CreateMatchDto interface.
 */
export function instanceOfCreateMatchDto(value: object): value is CreateMatchDto {
    return true;
}

export function CreateMatchDtoFromJSON(json: any): CreateMatchDto {
    return CreateMatchDtoFromJSONTyped(json, false);
}

export function CreateMatchDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateMatchDto {
    if (json == null) {
        return json;
    }
    return {
        
        'user2Id': json['user2Id'] == null ? undefined : json['user2Id'],
        'origin': json['origin'] == null ? undefined : MatchOriginFromJSON(json['origin']),
    };
}

export function CreateMatchDtoToJSON(value?: CreateMatchDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'user2Id': value['user2Id'],
        'origin': MatchOriginToJSON(value['origin']),
    };
}
