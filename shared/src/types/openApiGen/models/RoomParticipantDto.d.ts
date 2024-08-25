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
 * @interface RoomParticipantDto
 */
export interface RoomParticipantDto {
    /**
     *
     * @type {boolean}
     * @memberof RoomParticipantDto
     */
    isInterested?: boolean;
    /**
     *
     * @type {boolean}
     * @memberof RoomParticipantDto
     */
    attended?: boolean;
    /**
     *
     * @type {Date}
     * @memberof RoomParticipantDto
     */
    attendedFromTime?: Date | null;
    /**
     *
     * @type {Date}
     * @memberof RoomParticipantDto
     */
    attendedToTime?: Date | null;
    /**
     *
     * @type {number}
     * @memberof RoomParticipantDto
     */
    roomId?: number;
    /**
     *
     * @type {string}
     * @memberof RoomParticipantDto
     */
    socketId?: string | null;
    /**
     *
     * @type {string}
     * @memberof RoomParticipantDto
     */
    userId?: string | null;
}
/**
 * Check if a given object implements the RoomParticipantDto interface.
 */
export declare function instanceOfRoomParticipantDto(value: object): value is RoomParticipantDto;
export declare function RoomParticipantDtoFromJSON(json: any): RoomParticipantDto;
export declare function RoomParticipantDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): RoomParticipantDto;
export declare function RoomParticipantDtoToJSON(value?: RoomParticipantDto | null): any;