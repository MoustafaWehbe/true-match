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
  RoomParticipantDtoApiResponse,
  SimpleApiResponseApiResponse,
} from '../models/index';
import {
    RoomParticipantDtoApiResponseFromJSON,
    RoomParticipantDtoApiResponseToJSON,
    SimpleApiResponseApiResponseFromJSON,
    SimpleApiResponseApiResponseToJSON,
} from '../models/index';

export interface ApiRoomParticipantDeregisterIdPostRequest {
    id: number;
}

export interface ApiRoomParticipantJoinIdPostRequest {
    id: string;
    roomId?: number;
}

export interface ApiRoomParticipantLeaveIdPutRequest {
    roomId: number;
    id: string;
}

export interface ApiRoomParticipantRegisterIdPostRequest {
    id: number;
}

/**
 * 
 */
export class RoomParticipantApi extends runtime.BaseAPI {

    /**
     */
    async apiRoomParticipantDeregisterIdPostRaw(requestParameters: ApiRoomParticipantDeregisterIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<SimpleApiResponseApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomParticipantDeregisterIdPost().'
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
            path: `/api/room-participant/deregister/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => SimpleApiResponseApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantDeregisterIdPost(requestParameters: ApiRoomParticipantDeregisterIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<SimpleApiResponseApiResponse> {
        const response = await this.apiRoomParticipantDeregisterIdPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomParticipantJoinIdPostRaw(requestParameters: ApiRoomParticipantJoinIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<SimpleApiResponseApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomParticipantJoinIdPost().'
            );
        }

        const queryParameters: any = {};

        if (requestParameters['roomId'] != null) {
            queryParameters['roomId'] = requestParameters['roomId'];
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/room-participant/join/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => SimpleApiResponseApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantJoinIdPost(requestParameters: ApiRoomParticipantJoinIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<SimpleApiResponseApiResponse> {
        const response = await this.apiRoomParticipantJoinIdPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomParticipantLeaveIdPutRaw(requestParameters: ApiRoomParticipantLeaveIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<SimpleApiResponseApiResponse>> {
        if (requestParameters['roomId'] == null) {
            throw new runtime.RequiredError(
                'roomId',
                'Required parameter "roomId" was null or undefined when calling apiRoomParticipantLeaveIdPut().'
            );
        }

        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomParticipantLeaveIdPut().'
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
            path: `/api/room-participant/leave/{id}`.replace(`{${"roomId"}}`, encodeURIComponent(String(requestParameters['roomId']))).replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => SimpleApiResponseApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantLeaveIdPut(requestParameters: ApiRoomParticipantLeaveIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<SimpleApiResponseApiResponse> {
        const response = await this.apiRoomParticipantLeaveIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomParticipantRegisterIdPostRaw(requestParameters: ApiRoomParticipantRegisterIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomParticipantDtoApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomParticipantRegisterIdPost().'
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
            path: `/api/room-participant/register/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomParticipantDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantRegisterIdPost(requestParameters: ApiRoomParticipantRegisterIdPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomParticipantDtoApiResponse> {
        const response = await this.apiRoomParticipantRegisterIdPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
