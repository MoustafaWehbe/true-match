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
 * @interface SystemQuestionDto
 */
export interface SystemQuestionDto {
    /**
     * 
     * @type {number}
     * @memberof SystemQuestionDto
     */
    id?: number;
    /**
     * 
     * @type {string}
     * @memberof SystemQuestionDto
     */
    name?: string | null;
    /**
     * 
     * @type {number}
     * @memberof SystemQuestionDto
     */
    categoryId?: number;
}

/**
 * Check if a given object implements the SystemQuestionDto interface.
 */
export function instanceOfSystemQuestionDto(value: object): value is SystemQuestionDto {
    return true;
}

export function SystemQuestionDtoFromJSON(json: any): SystemQuestionDto {
    return SystemQuestionDtoFromJSONTyped(json, false);
}

export function SystemQuestionDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): SystemQuestionDto {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'name': json['name'] == null ? undefined : json['name'],
        'categoryId': json['categoryId'] == null ? undefined : json['categoryId'],
    };
}

export function SystemQuestionDtoToJSON(value?: SystemQuestionDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'id': value['id'],
        'name': value['name'],
        'categoryId': value['categoryId'],
    };
}
