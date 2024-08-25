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
 * @interface CreateSystemQuestionDto
 */
export interface CreateSystemQuestionDto {
    /**
     *
     * @type {string}
     * @memberof CreateSystemQuestionDto
     */
    name?: string | null;
    /**
     *
     * @type {number}
     * @memberof CreateSystemQuestionDto
     */
    categoryId?: number;
}
/**
 * Check if a given object implements the CreateSystemQuestionDto interface.
 */
export declare function instanceOfCreateSystemQuestionDto(value: object): value is CreateSystemQuestionDto;
export declare function CreateSystemQuestionDtoFromJSON(json: any): CreateSystemQuestionDto;
export declare function CreateSystemQuestionDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateSystemQuestionDto;
export declare function CreateSystemQuestionDtoToJSON(value?: CreateSystemQuestionDto | null): any;