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
import type { User } from './User';
import type { MatchOrigin } from './MatchOrigin';
/**
 *
 * @export
 * @interface Match
 */
export interface Match {
    /**
     *
     * @type {number}
     * @memberof Match
     */
    id?: number;
    /**
     *
     * @type {string}
     * @memberof Match
     */
    user1Id?: string | null;
    /**
     *
     * @type {User}
     * @memberof Match
     */
    user1?: User;
    /**
     *
     * @type {string}
     * @memberof Match
     */
    user2Id?: string | null;
    /**
     *
     * @type {User}
     * @memberof Match
     */
    user2?: User;
    /**
     *
     * @type {MatchOrigin}
     * @memberof Match
     */
    origin?: MatchOrigin;
    /**
     *
     * @type {Date}
     * @memberof Match
     */
    createdAt?: Date;
    /**
     *
     * @type {Date}
     * @memberof Match
     */
    updatedAt?: Date;
}
/**
 * Check if a given object implements the Match interface.
 */
export declare function instanceOfMatch(value: object): value is Match;
export declare function MatchFromJSON(json: any): Match;
export declare function MatchFromJSONTyped(json: any, ignoreDiscriminator: boolean): Match;
export declare function MatchToJSON(value?: Match | null): any;