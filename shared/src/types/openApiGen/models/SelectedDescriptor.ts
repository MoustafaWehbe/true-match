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
 * @interface SelectedDescriptor
 */
export interface SelectedDescriptor {
    /**
     * 
     * @type {number}
     * @memberof SelectedDescriptor
     */
    availableDescriptorId?: number;
    /**
     * 
     * @type {string}
     * @memberof SelectedDescriptor
     */
    descriptorId?: string | null;
    /**
     * 
     * @type {Array<string>}
     * @memberof SelectedDescriptor
     */
    choicesIds?: Array<string> | null;
    /**
     * 
     * @type {any}
     * @memberof SelectedDescriptor
     */
    singleValue?: any | null;
}

/**
 * Check if a given object implements the SelectedDescriptor interface.
 */
export function instanceOfSelectedDescriptor(value: object): value is SelectedDescriptor {
    return true;
}

export function SelectedDescriptorFromJSON(json: any): SelectedDescriptor {
    return SelectedDescriptorFromJSONTyped(json, false);
}

export function SelectedDescriptorFromJSONTyped(json: any, ignoreDiscriminator: boolean): SelectedDescriptor {
    if (json == null) {
        return json;
    }
    return {
        
        'availableDescriptorId': json['availableDescriptorId'] == null ? undefined : json['availableDescriptorId'],
        'descriptorId': json['descriptorId'] == null ? undefined : json['descriptorId'],
        'choicesIds': json['choicesIds'] == null ? undefined : json['choicesIds'],
        'singleValue': json['singleValue'] == null ? undefined : json['singleValue'],
    };
}

export function SelectedDescriptorToJSON(value?: SelectedDescriptor | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'availableDescriptorId': value['availableDescriptorId'],
        'descriptorId': value['descriptorId'],
        'choicesIds': value['choicesIds'],
        'singleValue': value['singleValue'],
    };
}
