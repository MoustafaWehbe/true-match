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
exports.instanceOfLoginDto = instanceOfLoginDto;
exports.LoginDtoFromJSON = LoginDtoFromJSON;
exports.LoginDtoFromJSONTyped = LoginDtoFromJSONTyped;
exports.LoginDtoToJSON = LoginDtoToJSON;
/**
 * Check if a given object implements the LoginDto interface.
 */
function instanceOfLoginDto(value) {
    if (!('email' in value) || value['email'] === undefined)
        return false;
    if (!('password' in value) || value['password'] === undefined)
        return false;
    return true;
}
function LoginDtoFromJSON(json) {
    return LoginDtoFromJSONTyped(json, false);
}
function LoginDtoFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'email': json['email'],
        'password': json['password'],
    };
}
function LoginDtoToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'email': value['email'],
        'password': value['password'],
    };
}