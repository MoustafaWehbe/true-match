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
import type { UserProfileLifeStyleDto } from './UserProfileLifeStyleDto';
import {
    UserProfileLifeStyleDtoFromJSON,
    UserProfileLifeStyleDtoFromJSONTyped,
    UserProfileLifeStyleDtoToJSON,
} from './UserProfileLifeStyleDto';
import type { UserProfileInterestDto } from './UserProfileInterestDto';
import {
    UserProfileInterestDtoFromJSON,
    UserProfileInterestDtoFromJSONTyped,
    UserProfileInterestDtoToJSON,
} from './UserProfileInterestDto';

/**
 * 
 * @export
 * @interface CreateUserProfileDto
 */
export interface CreateUserProfileDto {
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    gender: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    nationality: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    placeToLive: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    bio: string;
    /**
     * 
     * @type {number}
     * @memberof CreateUserProfileDto
     */
    height: number;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    relationshipGoal: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    education: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    zodiac: string;
    /**
     * 
     * @type {string}
     * @memberof CreateUserProfileDto
     */
    loveStyle: string;
    /**
     * 
     * @type {Array<UserProfileInterestDto>}
     * @memberof CreateUserProfileDto
     */
    userProfileInterests?: Array<UserProfileInterestDto> | null;
    /**
     * 
     * @type {Array<UserProfileLifeStyleDto>}
     * @memberof CreateUserProfileDto
     */
    userProfileLifeStyles?: Array<UserProfileLifeStyleDto> | null;
}



/**
 * Check if a given object implements the CreateUserProfileDto interface.
 */
export function instanceOfCreateUserProfileDto(value: object): value is CreateUserProfileDto {
    if (!('gender' in value) || value['gender'] === undefined) return false;
    if (!('nationality' in value) || value['nationality'] === undefined) return false;
    if (!('placeToLive' in value) || value['placeToLive'] === undefined) return false;
    if (!('bio' in value) || value['bio'] === undefined) return false;
    if (!('height' in value) || value['height'] === undefined) return false;
    if (!('relationshipGoal' in value) || value['relationshipGoal'] === undefined) return false;
    if (!('education' in value) || value['education'] === undefined) return false;
    if (!('zodiac' in value) || value['zodiac'] === undefined) return false;
    if (!('loveStyle' in value) || value['loveStyle'] === undefined) return false;
    return true;
}

export function CreateUserProfileDtoFromJSON(json: any): CreateUserProfileDto {
    return CreateUserProfileDtoFromJSONTyped(json, false);
}

export function CreateUserProfileDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateUserProfileDto {
    if (json == null) {
        return json;
    }
    return {
        
        'gender': json['gender'],
        'nationality': json['nationality'],
        'placeToLive': json['placeToLive'],
        'bio': json['bio'],
        'height': json['height'],
        'relationshipGoal': json['relationshipGoal'],
        'education': json['education'],
        'zodiac': json['zodiac'],
        'loveStyle': json['loveStyle'],
        'userProfileInterests': json['userProfileInterests'] == null ? undefined : ((json['userProfileInterests'] as Array<any>).map(UserProfileInterestDtoFromJSON)),
        'userProfileLifeStyles': json['userProfileLifeStyles'] == null ? undefined : ((json['userProfileLifeStyles'] as Array<any>).map(UserProfileLifeStyleDtoFromJSON)),
    };
}

export function CreateUserProfileDtoToJSON(value?: CreateUserProfileDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'gender': value['gender'],
        'nationality': value['nationality'],
        'placeToLive': value['placeToLive'],
        'bio': value['bio'],
        'height': value['height'],
        'relationshipGoal': value['relationshipGoal'],
        'education': value['education'],
        'zodiac': value['zodiac'],
        'loveStyle': value['loveStyle'],
        'userProfileInterests': value['userProfileInterests'] == null ? undefined : ((value['userProfileInterests'] as Array<any>).map(UserProfileInterestDtoToJSON)),
        'userProfileLifeStyles': value['userProfileLifeStyles'] == null ? undefined : ((value['userProfileLifeStyles'] as Array<any>).map(UserProfileLifeStyleDtoToJSON)),
    };
}

