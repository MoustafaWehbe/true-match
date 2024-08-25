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
 * @interface UpdateSystemQuestionDto
 */
export interface UpdateSystemQuestionDto {
    /**
     *
     * @type {string}
     * @memberof UpdateSystemQuestionDto
     */
    name?: string | null;
    /**
     *
     * @type {number}
     * @memberof UpdateSystemQuestionDto
     */
    categoryId?: number;
}
/**
 * Check if a given object implements the UpdateSystemQuestionDto interface.
 */
export declare function instanceOfUpdateSystemQuestionDto(value: object): value is UpdateSystemQuestionDto;
export declare function UpdateSystemQuestionDtoFromJSON(json: any): UpdateSystemQuestionDto;
export declare function UpdateSystemQuestionDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): UpdateSystemQuestionDto;
export declare function UpdateSystemQuestionDtoToJSON(value?: UpdateSystemQuestionDto | null): any;