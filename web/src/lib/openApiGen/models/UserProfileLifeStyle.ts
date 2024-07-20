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
import type { UserProfile } from './UserProfile';
import {
    UserProfileFromJSON,
    UserProfileFromJSONTyped,
    UserProfileToJSON,
} from './UserProfile';
import type { LifeStyle } from './LifeStyle';
import {
    LifeStyleFromJSON,
    LifeStyleFromJSONTyped,
    LifeStyleToJSON,
} from './LifeStyle';

/**
 * 
 * @export
 * @interface UserProfileLifeStyle
 */
export interface UserProfileLifeStyle {
    /**
     * 
     * @type {number}
     * @memberof UserProfileLifeStyle
     */
    userProfileId?: number;
    /**
     * 
     * @type {number}
     * @memberof UserProfileLifeStyle
     */
    lifeStyleId?: number;
    /**
     * 
     * @type {UserProfile}
     * @memberof UserProfileLifeStyle
     */
    userProfile?: UserProfile;
    /**
     * 
     * @type {LifeStyle}
     * @memberof UserProfileLifeStyle
     */
    lifeStyle?: LifeStyle;
}

/**
 * Check if a given object implements the UserProfileLifeStyle interface.
 */
export function instanceOfUserProfileLifeStyle(value: object): value is UserProfileLifeStyle {
    return true;
}

export function UserProfileLifeStyleFromJSON(json: any): UserProfileLifeStyle {
    return UserProfileLifeStyleFromJSONTyped(json, false);
}

export function UserProfileLifeStyleFromJSONTyped(json: any, ignoreDiscriminator: boolean): UserProfileLifeStyle {
    if (json == null) {
        return json;
    }
    return {
        
        'userProfileId': json['userProfileId'] == null ? undefined : json['userProfileId'],
        'lifeStyleId': json['lifeStyleId'] == null ? undefined : json['lifeStyleId'],
        'userProfile': json['userProfile'] == null ? undefined : UserProfileFromJSON(json['userProfile']),
        'lifeStyle': json['lifeStyle'] == null ? undefined : LifeStyleFromJSON(json['lifeStyle']),
    };
}

export function UserProfileLifeStyleToJSON(value?: UserProfileLifeStyle | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'userProfileId': value['userProfileId'],
        'lifeStyleId': value['lifeStyleId'],
        'userProfile': UserProfileToJSON(value['userProfile']),
        'lifeStyle': LifeStyleToJSON(value['lifeStyle']),
    };
}

