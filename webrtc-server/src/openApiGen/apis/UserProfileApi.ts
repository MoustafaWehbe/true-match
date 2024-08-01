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


import * as runtime from '../runtime';
import type {
  CreateUserProfileDto,
  UserProfile,
} from '../models/index';
import {
    CreateUserProfileDtoFromJSON,
    CreateUserProfileDtoToJSON,
    UserProfileFromJSON,
    UserProfileToJSON,
} from '../models/index';

export interface ApiUserProfileIdGetRequest {
    id: number;
}

export interface ApiUserProfilePostRequest {
    createUserProfileDto?: CreateUserProfileDto;
}

/**
 * 
 */
export class UserProfileApi extends runtime.BaseAPI {

    /**
     */
    async apiUserProfileIdGetRaw(requestParameters: ApiUserProfileIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<UserProfile>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiUserProfileIdGet().'
            );
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/user-profile/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => UserProfileFromJSON(jsonValue));
    }

    /**
     */
    async apiUserProfileIdGet(requestParameters: ApiUserProfileIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<UserProfile> {
        const response = await this.apiUserProfileIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiUserProfilePostRaw(requestParameters: ApiUserProfilePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<UserProfile>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json-patch+json';

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/user-profile`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateUserProfileDtoToJSON(requestParameters['createUserProfileDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => UserProfileFromJSON(jsonValue));
    }

    /**
     */
    async apiUserProfilePost(requestParameters: ApiUserProfilePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<UserProfile> {
        const response = await this.apiUserProfilePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
