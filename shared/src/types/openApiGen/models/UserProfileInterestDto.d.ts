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
 * @interface UserProfileInterestDto
 */
export interface UserProfileInterestDto {
    /**
     *
     * @type {number}
     * @memberof UserProfileInterestDto
     */
    interestId?: number;
}
/**
 * Check if a given object implements the UserProfileInterestDto interface.
 */
export declare function instanceOfUserProfileInterestDto(value: object): value is UserProfileInterestDto;
export declare function UserProfileInterestDtoFromJSON(json: any): UserProfileInterestDto;
export declare function UserProfileInterestDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): UserProfileInterestDto;
export declare function UserProfileInterestDtoToJSON(value?: UserProfileInterestDto | null): any;
