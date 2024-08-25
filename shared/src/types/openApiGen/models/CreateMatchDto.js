"use strict";
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
Object.defineProperty(exports, "__esModule", { value: true });
exports.instanceOfCreateMatchDto = instanceOfCreateMatchDto;
exports.CreateMatchDtoFromJSON = CreateMatchDtoFromJSON;
exports.CreateMatchDtoFromJSONTyped = CreateMatchDtoFromJSONTyped;
exports.CreateMatchDtoToJSON = CreateMatchDtoToJSON;
var MatchOrigin_1 = require("./MatchOrigin");
/**
 * Check if a given object implements the CreateMatchDto interface.
 */
function instanceOfCreateMatchDto(value) {
    return true;
}
function CreateMatchDtoFromJSON(json) {
    return CreateMatchDtoFromJSONTyped(json, false);
}
function CreateMatchDtoFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'user2Id': json['user2Id'] == null ? undefined : json['user2Id'],
        'origin': json['origin'] == null ? undefined : (0, MatchOrigin_1.MatchOriginFromJSON)(json['origin']),
    };
}
function CreateMatchDtoToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'user2Id': value['user2Id'],
        'origin': (0, MatchOrigin_1.MatchOriginToJSON)(value['origin']),
    };
}
