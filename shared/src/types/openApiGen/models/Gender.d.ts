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
export declare const Gender: {
    readonly NUMBER_0: 0;
    readonly NUMBER_1: 1;
};
export type Gender = typeof Gender[keyof typeof Gender];
export declare function instanceOfGender(value: any): boolean;
export declare function GenderFromJSON(json: any): Gender;
export declare function GenderFromJSONTyped(json: any, ignoreDiscriminator: boolean): Gender;
export declare function GenderToJSON(value?: Gender | null): any;