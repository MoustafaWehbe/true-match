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
exports.Gender = void 0;
exports.instanceOfGender = instanceOfGender;
exports.GenderFromJSON = GenderFromJSON;
exports.GenderFromJSONTyped = GenderFromJSONTyped;
exports.GenderToJSON = GenderToJSON;
/**
 *
 * @export
 */
exports.Gender = {
    NUMBER_0: 0,
    NUMBER_1: 1
};
function instanceOfGender(value) {
    for (var key in exports.Gender) {
        if (Object.prototype.hasOwnProperty.call(exports.Gender, key)) {
            if (exports.Gender[key] === value) {
                return true;
            }
        }
    }
    return false;
}
function GenderFromJSON(json) {
    return GenderFromJSONTyped(json, false);
}
function GenderFromJSONTyped(json, ignoreDiscriminator) {
    return json;
}
function GenderToJSON(value) {
    return value;
}
