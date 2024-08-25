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
exports.instanceOfRoomContentDtoListApiResponse = instanceOfRoomContentDtoListApiResponse;
exports.RoomContentDtoListApiResponseFromJSON = RoomContentDtoListApiResponseFromJSON;
exports.RoomContentDtoListApiResponseFromJSONTyped = RoomContentDtoListApiResponseFromJSONTyped;
exports.RoomContentDtoListApiResponseToJSON = RoomContentDtoListApiResponseToJSON;
var RoomContentDto_1 = require("./RoomContentDto");
/**
 * Check if a given object implements the RoomContentDtoListApiResponse interface.
 */
function instanceOfRoomContentDtoListApiResponse(value) {
    return true;
}
function RoomContentDtoListApiResponseFromJSON(json) {
    return RoomContentDtoListApiResponseFromJSONTyped(json, false);
}
function RoomContentDtoListApiResponseFromJSONTyped(json, ignoreDiscriminator) {
    if (json == null) {
        return json;
    }
    return {
        'statusCode': json['statusCode'] == null ? undefined : json['statusCode'],
        'message': json['message'] == null ? undefined : json['message'],
        'data': json['data'] == null ? undefined : (json['data'].map(RoomContentDto_1.RoomContentDtoFromJSON)),
    };
}
function RoomContentDtoListApiResponseToJSON(value) {
    if (value == null) {
        return value;
    }
    return {
        'statusCode': value['statusCode'],
        'message': value['message'],
        'data': value['data'] == null ? undefined : (value['data'].map(RoomContentDto_1.RoomContentDtoToJSON)),
    };
}