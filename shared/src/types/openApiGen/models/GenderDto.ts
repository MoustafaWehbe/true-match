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
 * @interface GenderDto
 */
export interface GenderDto {
    /**
     * 
     * @type {number}
     * @memberof GenderDto
     */
    id?: number;
    /**
     * 
     * @type {string}
     * @memberof GenderDto
     */
    name?: string | null;
    /**
     * 
     * @type {string}
     * @memberof GenderDto
     */
    description?: string | null;
    /**
     * 
     * @type {number}
     * @memberof GenderDto
     */
    parentId?: number | null;
    /**
     * 
     * @type {Array<GenderDto>}
     * @memberof GenderDto
     */
    children?: Array<GenderDto> | null;
}

/**
 * Check if a given object implements the GenderDto interface.
 */
export function instanceOfGenderDto(value: object): value is GenderDto {
    return true;
}

export function GenderDtoFromJSON(json: any): GenderDto {
    return GenderDtoFromJSONTyped(json, false);
}

export function GenderDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): GenderDto {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'name': json['name'] == null ? undefined : json['name'],
        'description': json['description'] == null ? undefined : json['description'],
        'parentId': json['parentId'] == null ? undefined : json['parentId'],
        'children': json['children'] == null ? undefined : ((json['children'] as Array<any>).map(GenderDtoFromJSON)),
    };
}

export function GenderDtoToJSON(value?: GenderDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'id': value['id'],
        'name': value['name'],
        'description': value['description'],
        'parentId': value['parentId'],
        'children': value['children'] == null ? undefined : ((value['children'] as Array<any>).map(GenderDtoToJSON)),
    };
}

