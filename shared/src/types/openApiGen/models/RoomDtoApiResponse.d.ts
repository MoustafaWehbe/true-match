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
import type { RoomDto } from './RoomDto';
/**
 *
 * @export
 * @interface RoomDtoApiResponse
 */
export interface RoomDtoApiResponse {
    /**
     *
     * @type {number}
     * @memberof RoomDtoApiResponse
     */
    statusCode?: number;
    /**
     *
     * @type {string}
     * @memberof RoomDtoApiResponse
     */
    message?: string | null;
    /**
     *
     * @type {RoomDto}
     * @memberof RoomDtoApiResponse
     */
    data?: RoomDto;
}
/**
 * Check if a given object implements the RoomDtoApiResponse interface.
 */
export declare function instanceOfRoomDtoApiResponse(value: object): value is RoomDtoApiResponse;
export declare function RoomDtoApiResponseFromJSON(json: any): RoomDtoApiResponse;
export declare function RoomDtoApiResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): RoomDtoApiResponse;
export declare function RoomDtoApiResponseToJSON(value?: RoomDtoApiResponse | null): any;