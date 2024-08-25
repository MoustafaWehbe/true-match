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
/**
 *
 * @export
 * @interface CreateRoomDto
 */
export interface CreateRoomDto {
    /**
     *
     * @type {string}
     * @memberof CreateRoomDto
     */
    title?: string | null;
    /**
     *
     * @type {string}
     * @memberof CreateRoomDto
     */
    description?: string | null;
    /**
     *
     * @type {Array<number>}
     * @memberof CreateRoomDto
     */
    questionsCategories?: Array<number> | null;
    /**
     *
     * @type {Date}
     * @memberof CreateRoomDto
     */
    scheduledAt?: Date | null;
}
/**
 * Check if a given object implements the CreateRoomDto interface.
 */
export declare function instanceOfCreateRoomDto(value: object): value is CreateRoomDto;
export declare function CreateRoomDtoFromJSON(json: any): CreateRoomDto;
export declare function CreateRoomDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateRoomDto;
export declare function CreateRoomDtoToJSON(value?: CreateRoomDto | null): any;