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


/**
 * 
 * @export
 */
export const AllRoomStatus = {
    NUMBER_0: 0,
    NUMBER_1: 1,
    NUMBER_2: 2
} as const;
export type AllRoomStatus = typeof AllRoomStatus[keyof typeof AllRoomStatus];


export function instanceOfAllRoomStatus(value: any): boolean {
    for (const key in AllRoomStatus) {
        if (Object.prototype.hasOwnProperty.call(AllRoomStatus, key)) {
            if (AllRoomStatus[key as keyof typeof AllRoomStatus] === value) {
                return true;
            }
        }
    }
    return false;
}

export function AllRoomStatusFromJSON(json: any): AllRoomStatus {
    return AllRoomStatusFromJSONTyped(json, false);
}

export function AllRoomStatusFromJSONTyped(json: any, ignoreDiscriminator: boolean): AllRoomStatus {
    return json as AllRoomStatus;
}

export function AllRoomStatusToJSON(value?: AllRoomStatus | null): any {
    return value as any;
}
