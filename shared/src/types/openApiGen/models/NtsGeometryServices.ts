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
import type { CoordinateSequenceFactory } from './CoordinateSequenceFactory';
import {
    CoordinateSequenceFactoryFromJSON,
    CoordinateSequenceFactoryFromJSONTyped,
    CoordinateSequenceFactoryToJSON,
} from './CoordinateSequenceFactory';
import type { PrecisionModel } from './PrecisionModel';
import {
    PrecisionModelFromJSON,
    PrecisionModelFromJSONTyped,
    PrecisionModelToJSON,
} from './PrecisionModel';

/**
 * 
 * @export
 * @interface NtsGeometryServices
 */
export interface NtsGeometryServices {
    /**
     * 
     * @type {object}
     * @memberof NtsGeometryServices
     */
    geometryOverlay?: object;
    /**
     * 
     * @type {object}
     * @memberof NtsGeometryServices
     */
    coordinateEqualityComparer?: object;
    /**
     * 
     * @type {number}
     * @memberof NtsGeometryServices
     */
    readonly defaultSRID?: number;
    /**
     * 
     * @type {CoordinateSequenceFactory}
     * @memberof NtsGeometryServices
     */
    defaultCoordinateSequenceFactory?: CoordinateSequenceFactory;
    /**
     * 
     * @type {PrecisionModel}
     * @memberof NtsGeometryServices
     */
    defaultPrecisionModel?: PrecisionModel;
}

/**
 * Check if a given object implements the NtsGeometryServices interface.
 */
export function instanceOfNtsGeometryServices(value: object): value is NtsGeometryServices {
    return true;
}

export function NtsGeometryServicesFromJSON(json: any): NtsGeometryServices {
    return NtsGeometryServicesFromJSONTyped(json, false);
}

export function NtsGeometryServicesFromJSONTyped(json: any, ignoreDiscriminator: boolean): NtsGeometryServices {
    if (json == null) {
        return json;
    }
    return {
        
        'geometryOverlay': json['geometryOverlay'] == null ? undefined : json['geometryOverlay'],
        'coordinateEqualityComparer': json['coordinateEqualityComparer'] == null ? undefined : json['coordinateEqualityComparer'],
        'defaultSRID': json['defaultSRID'] == null ? undefined : json['defaultSRID'],
        'defaultCoordinateSequenceFactory': json['defaultCoordinateSequenceFactory'] == null ? undefined : CoordinateSequenceFactoryFromJSON(json['defaultCoordinateSequenceFactory']),
        'defaultPrecisionModel': json['defaultPrecisionModel'] == null ? undefined : PrecisionModelFromJSON(json['defaultPrecisionModel']),
    };
}

export function NtsGeometryServicesToJSON(value?: Omit<NtsGeometryServices, 'defaultSRID'> | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'geometryOverlay': value['geometryOverlay'],
        'coordinateEqualityComparer': value['coordinateEqualityComparer'],
        'defaultCoordinateSequenceFactory': CoordinateSequenceFactoryToJSON(value['defaultCoordinateSequenceFactory']),
        'defaultPrecisionModel': PrecisionModelToJSON(value['defaultPrecisionModel']),
    };
}

