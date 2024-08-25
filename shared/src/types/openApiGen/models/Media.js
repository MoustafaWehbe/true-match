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
exports.instanceOfMedia = instanceOfMedia;
exports.MediaFromJSON = MediaFromJSON;
exports.MediaFromJSONTyped = MediaFromJSONTyped;
exports.MediaToJSON = MediaToJSON;
var User_1 = require("./User");
var MediaType_1 = require("./MediaType");
/**
 * Check if a given object implements the Media interface.
 */
function instanceOfMedia(value) {
    if (!('url' in value) || value['url'] === undefined)
        return false;
    if (!('mediaType' in value) || value['mediaType'] === undefined)
        return false;
    return true;
}
function MediaFromJSON(json) {
    return MediaFromJSONTyped(json, false);
}
function MediaFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'id': json['id'] == null ? undefined : json['id'],
        'url': json['url'],
        'createdAt': json['createdAt'] == null ? undefined : (new Date(json['createdAt'])),
        'updatedAt': json['updatedAt'] == null ? undefined : (new Date(json['updatedAt'])),
        'mediaType': (0, MediaType_1.MediaTypeFromJSON)(json['mediaType']),
        'userId': json['userId'] == null ? undefined : json['userId'],
        'user': json['user'] == null ? undefined : (0, User_1.UserFromJSON)(json['user']),
    };
}
function MediaToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'id': value['id'],
        'url': value['url'],
        'createdAt': value['createdAt'] == null ? undefined : ((value['createdAt']).toISOString()),
        'updatedAt': value['updatedAt'] == null ? undefined : ((value['updatedAt']).toISOString()),
        'mediaType': (0, MediaType_1.MediaTypeToJSON)(value['mediaType']),
        'userId': value['userId'],
        'user': (0, User_1.UserToJSON)(value['user']),
    };
}