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
import type { Coordinate } from './Coordinate';
import {
    CoordinateFromJSON,
    CoordinateFromJSONTyped,
    CoordinateToJSON,
} from './Coordinate';
import type { Ordinates } from './Ordinates';
import {
    OrdinatesFromJSON,
    OrdinatesFromJSONTyped,
    OrdinatesToJSON,
} from './Ordinates';

/**
 * 
 * @export
 * @interface CoordinateSequence
 */
export interface CoordinateSequence {
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly dimension?: number;
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly measures?: number;
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly spatial?: number;
    /**
     * 
     * @type {Ordinates}
     * @memberof CoordinateSequence
     */
    ordinates?: Ordinates;
    /**
     * 
     * @type {boolean}
     * @memberof CoordinateSequence
     */
    readonly hasZ?: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof CoordinateSequence
     */
    readonly hasM?: boolean;
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly zOrdinateIndex?: number;
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly mOrdinateIndex?: number;
    /**
     * 
     * @type {Coordinate}
     * @memberof CoordinateSequence
     */
    first?: Coordinate;
    /**
     * 
     * @type {Coordinate}
     * @memberof CoordinateSequence
     */
    last?: Coordinate;
    /**
     * 
     * @type {number}
     * @memberof CoordinateSequence
     */
    readonly count?: number;
}



/**
 * Check if a given object implements the CoordinateSequence interface.
 */
export function instanceOfCoordinateSequence(value: object): value is CoordinateSequence {
    return true;
}

export function CoordinateSequenceFromJSON(json: any): CoordinateSequence {
    return CoordinateSequenceFromJSONTyped(json, false);
}

export function CoordinateSequenceFromJSONTyped(json: any, ignoreDiscriminator: boolean): CoordinateSequence {
    if (json == null) {
        return json;
    }
    return {
        
        'dimension': json['dimension'] == null ? undefined : json['dimension'],
        'measures': json['measures'] == null ? undefined : json['measures'],
        'spatial': json['spatial'] == null ? undefined : json['spatial'],
        'ordinates': json['ordinates'] == null ? undefined : OrdinatesFromJSON(json['ordinates']),
        'hasZ': json['hasZ'] == null ? undefined : json['hasZ'],
        'hasM': json['hasM'] == null ? undefined : json['hasM'],
        'zOrdinateIndex': json['zOrdinateIndex'] == null ? undefined : json['zOrdinateIndex'],
        'mOrdinateIndex': json['mOrdinateIndex'] == null ? undefined : json['mOrdinateIndex'],
        'first': json['first'] == null ? undefined : CoordinateFromJSON(json['first']),
        'last': json['last'] == null ? undefined : CoordinateFromJSON(json['last']),
        'count': json['count'] == null ? undefined : json['count'],
    };
}

export function CoordinateSequenceToJSON(value?: Omit<CoordinateSequence, 'dimension'|'measures'|'spatial'|'hasZ'|'hasM'|'zOrdinateIndex'|'mOrdinateIndex'|'count'> | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'ordinates': OrdinatesToJSON(value['ordinates']),
        'first': CoordinateToJSON(value['first']),
        'last': CoordinateToJSON(value['last']),
    };
}

