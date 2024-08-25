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
 * @interface RegisterDto
 */
export interface RegisterDto {
    /**
     * 
     * @type {string}
     * @memberof RegisterDto
     */
    firstName: string;
    /**
     * 
     * @type {string}
     * @memberof RegisterDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof RegisterDto
     */
    email: string;
    /**
     * 
     * @type {string}
     * @memberof RegisterDto
     */
    password: string;
}

/**
 * Check if a given object implements the RegisterDto interface.
 */
export function instanceOfRegisterDto(value: object): value is RegisterDto {
    if (!('firstName' in value) || value['firstName'] === undefined) return false;
    if (!('email' in value) || value['email'] === undefined) return false;
    if (!('password' in value) || value['password'] === undefined) return false;
    return true;
}

export function RegisterDtoFromJSON(json: any): RegisterDto {
    return RegisterDtoFromJSONTyped(json, false);
}

export function RegisterDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): RegisterDto {
    if (json == null) {
        return json;
    }
    return {
        
        'firstName': json['firstName'],
        'lastName': json['lastName'] == null ? undefined : json['lastName'],
        'email': json['email'],
        'password': json['password'],
    };
}

export function RegisterDtoToJSON(value?: RegisterDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'firstName': value['firstName'],
        'lastName': value['lastName'],
        'email': value['email'],
        'password': value['password'],
    };
}
