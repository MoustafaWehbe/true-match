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
 * @interface IconUrl
 */
export interface IconUrl {
    /**
     * 
     * @type {string}
     * @memberof IconUrl
     */
    url?: string | null;
    /**
     * 
     * @type {string}
     * @memberof IconUrl
     */
    quality?: string | null;
    /**
     * 
     * @type {number}
     * @memberof IconUrl
     */
    width?: number;
    /**
     * 
     * @type {number}
     * @memberof IconUrl
     */
    height?: number;
}

/**
 * Check if a given object implements the IconUrl interface.
 */
export function instanceOfIconUrl(value: object): value is IconUrl {
    return true;
}

export function IconUrlFromJSON(json: any): IconUrl {
    return IconUrlFromJSONTyped(json, false);
}

export function IconUrlFromJSONTyped(json: any, ignoreDiscriminator: boolean): IconUrl {
    if (json == null) {
        return json;
    }
    return {
        
        'url': json['url'] == null ? undefined : json['url'],
        'quality': json['quality'] == null ? undefined : json['quality'],
        'width': json['width'] == null ? undefined : json['width'],
        'height': json['height'] == null ? undefined : json['height'],
    };
}

export function IconUrlToJSON(value?: IconUrl | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'url': value['url'],
        'quality': value['quality'],
        'width': value['width'],
        'height': value['height'],
    };
}

