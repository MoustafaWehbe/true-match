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
  AllRoomStatus,
  CreateRoomDto,
  MyRoomStatus,
  RoomDtoApiResponse,
  RoomDtoPagedResponse,
  StringApiResponse,
  UpdateRoomDto,
} from '../models/index';
import {
    AllRoomStatusFromJSON,
    AllRoomStatusToJSON,
    CreateRoomDtoFromJSON,
    CreateRoomDtoToJSON,
    MyRoomStatusFromJSON,
    MyRoomStatusToJSON,
    RoomDtoApiResponseFromJSON,
    RoomDtoApiResponseToJSON,
    RoomDtoPagedResponseFromJSON,
    RoomDtoPagedResponseToJSON,
    StringApiResponseFromJSON,
    StringApiResponseToJSON,
    UpdateRoomDtoFromJSON,
    UpdateRoomDtoToJSON,
} from '../models/index';

export interface ApiRoomGetRequest {
    pageNumber?: number;
    pageSize?: number;
    status?: AllRoomStatus;
}

export interface ApiRoomIdDeleteRequest {
    id: number;
}

export interface ApiRoomIdGetRequest {
    id: number;
}

export interface ApiRoomIdPutRequest {
    id: number;
    updateRoomDto?: UpdateRoomDto;
}

export interface ApiRoomMyRoomsGetRequest {
    pageNumber?: number;
    pageSize?: number;
    status?: MyRoomStatus;
}

export interface ApiRoomPostRequest {
    createRoomDto?: CreateRoomDto;
}

export interface ApiRoomStartRoomIdGetRequest {
    id: number;
}

/**
 * 
 */
export class RoomApi extends runtime.BaseAPI {

    /**
     */
    async apiRoomGetRaw(requestParameters: ApiRoomGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoPagedResponse>> {
        const queryParameters: any = {};

        if (requestParameters['pageNumber'] != null) {
            queryParameters['PageNumber'] = requestParameters['pageNumber'];
        }

        if (requestParameters['pageSize'] != null) {
            queryParameters['PageSize'] = requestParameters['pageSize'];
        }

        if (requestParameters['status'] != null) {
            queryParameters['Status'] = requestParameters['status'];
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
            path: `/api/room`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoPagedResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomGet(requestParameters: ApiRoomGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoPagedResponse> {
        const response = await this.apiRoomGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomIdDeleteRaw(requestParameters: ApiRoomIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomIdDelete().'
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
            path: `/api/room/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomIdDelete(requestParameters: ApiRoomIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringApiResponse> {
        const response = await this.apiRoomIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomIdGetRaw(requestParameters: ApiRoomIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomIdGet().'
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
            path: `/api/room/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomIdGet(requestParameters: ApiRoomIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoApiResponse> {
        const response = await this.apiRoomIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomIdPutRaw(requestParameters: ApiRoomIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomIdPut().'
            );
        }

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
            path: `/api/room/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: UpdateRoomDtoToJSON(requestParameters['updateRoomDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomIdPut(requestParameters: ApiRoomIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoApiResponse> {
        const response = await this.apiRoomIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomMyRoomsGetRaw(requestParameters: ApiRoomMyRoomsGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoPagedResponse>> {
        const queryParameters: any = {};

        if (requestParameters['pageNumber'] != null) {
            queryParameters['PageNumber'] = requestParameters['pageNumber'];
        }

        if (requestParameters['pageSize'] != null) {
            queryParameters['PageSize'] = requestParameters['pageSize'];
        }

        if (requestParameters['status'] != null) {
            queryParameters['Status'] = requestParameters['status'];
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
            path: `/api/room/my-rooms`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoPagedResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomMyRoomsGet(requestParameters: ApiRoomMyRoomsGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoPagedResponse> {
        const response = await this.apiRoomMyRoomsGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomPostRaw(requestParameters: ApiRoomPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoApiResponse>> {
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
            path: `/api/room`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateRoomDtoToJSON(requestParameters['createRoomDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomPost(requestParameters: ApiRoomPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoApiResponse> {
        const response = await this.apiRoomPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomStartRoomIdGetRaw(requestParameters: ApiRoomStartRoomIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomDtoApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomStartRoomIdGet().'
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
            path: `/api/room/start-room/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomStartRoomIdGet(requestParameters: ApiRoomStartRoomIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomDtoApiResponse> {
        const response = await this.apiRoomStartRoomIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
