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
 * @interface QuestionCategoryDto
 */
export interface QuestionCategoryDto {
    /**
     *
     * @type {number}
     * @memberof QuestionCategoryDto
     */
    id?: number;
    /**
     *
     * @type {string}
     * @memberof QuestionCategoryDto
     */
    name?: string | null;
}
/**
 * Check if a given object implements the QuestionCategoryDto interface.
 */
export declare function instanceOfQuestionCategoryDto(value: object): value is QuestionCategoryDto;
export declare function QuestionCategoryDtoFromJSON(json: any): QuestionCategoryDto;
export declare function QuestionCategoryDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): QuestionCategoryDto;
export declare function QuestionCategoryDtoToJSON(value?: QuestionCategoryDto | null): any;
