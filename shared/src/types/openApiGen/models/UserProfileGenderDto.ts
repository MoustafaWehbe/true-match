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
 * @interface UserProfileGenderDto
 */
export interface UserProfileGenderDto {
    /**
     * 
     * @type {number}
     * @memberof UserProfileGenderDto
     */
    genderId?: number;
    /**
     * 
     * @type {boolean}
     * @memberof UserProfileGenderDto
     */
    isMain?: boolean | null;
}

/**
 * Check if a given object implements the UserProfileGenderDto interface.
 */
export function instanceOfUserProfileGenderDto(value: object): value is UserProfileGenderDto {
    return true;
}

export function UserProfileGenderDtoFromJSON(json: any): UserProfileGenderDto {
    return UserProfileGenderDtoFromJSONTyped(json, false);
}

export function UserProfileGenderDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): UserProfileGenderDto {
    if (json == null) {
        return json;
    }
    return {
        
        'genderId': json['genderId'] == null ? undefined : json['genderId'],
        'isMain': json['isMain'] == null ? undefined : json['isMain'],
    };
}

export function UserProfileGenderDtoToJSON(value?: UserProfileGenderDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'genderId': value['genderId'],
        'isMain': value['isMain'],
    };
}

