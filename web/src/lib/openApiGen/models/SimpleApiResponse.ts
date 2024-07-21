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
 * @interface SimpleApiResponse
 */
export interface SimpleApiResponse {
    /**
     * 
     * @type {string}
     * @memberof SimpleApiResponse
     */
    message?: string | null;
}

/**
 * Check if a given object implements the SimpleApiResponse interface.
 */
export function instanceOfSimpleApiResponse(value: object): value is SimpleApiResponse {
    return true;
}

export function SimpleApiResponseFromJSON(json: any): SimpleApiResponse {
    return SimpleApiResponseFromJSONTyped(json, false);
}

export function SimpleApiResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): SimpleApiResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'message': json['message'] == null ? undefined : json['message'],
    };
}

export function SimpleApiResponseToJSON(value?: SimpleApiResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'message': value['message'],
    };
}

