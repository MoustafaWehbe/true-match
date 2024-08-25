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
 * @interface SimpleApiResponse
 */
export interface SimpleApiResponse {
    /**
     *
     * @type {string}
     * @memberof SimpleApiResponse
     */
    message?: string | null;
}
/**
 * Check if a given object implements the SimpleApiResponse interface.
 */
export declare function instanceOfSimpleApiResponse(value: object): value is SimpleApiResponse;
export declare function SimpleApiResponseFromJSON(json: any): SimpleApiResponse;
export declare function SimpleApiResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): SimpleApiResponse;
export declare function SimpleApiResponseToJSON(value?: SimpleApiResponse | null): any;
