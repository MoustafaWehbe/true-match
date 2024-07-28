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
  LoginDto,
  RegisterDto,
  SimpleApiResponseApiResponse,
  StringApiResponse,
  UserApiResponse,
} from '../models/index';
import {
    LoginDtoFromJSON,
    LoginDtoToJSON,
    RegisterDtoFromJSON,
    RegisterDtoToJSON,
    SimpleApiResponseApiResponseFromJSON,
    SimpleApiResponseApiResponseToJSON,
    StringApiResponseFromJSON,
    StringApiResponseToJSON,
    UserApiResponseFromJSON,
    UserApiResponseToJSON,
} from '../models/index';

export interface ApiAcountLoginPostRequest {
    loginDto?: LoginDto;
}

export interface ApiAcountRegisterPostRequest {
    registerDto?: RegisterDto;
}

/**
 * 
 */
export class AccountApi extends runtime.BaseAPI {

    /**
     */
    async apiAcountLoginPostRaw(requestParameters: ApiAcountLoginPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<UserApiResponse>> {
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
            path: `/api/acount/login`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: LoginDtoToJSON(requestParameters['loginDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => UserApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiAcountLoginPost(requestParameters: ApiAcountLoginPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<UserApiResponse> {
        const response = await this.apiAcountLoginPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAcountLogoutPostRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<SimpleApiResponseApiResponse>> {
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
            path: `/api/acount/logout`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => SimpleApiResponseApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiAcountLogoutPost(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<SimpleApiResponseApiResponse> {
        const response = await this.apiAcountLogoutPostRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAcountRegisterPostRaw(requestParameters: ApiAcountRegisterPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<UserApiResponse>> {
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
            path: `/api/acount/register`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: RegisterDtoToJSON(requestParameters['registerDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => UserApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiAcountRegisterPost(requestParameters: ApiAcountRegisterPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<UserApiResponse> {
        const response = await this.apiAcountRegisterPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
