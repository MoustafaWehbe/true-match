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
  UpdateRoomParticipantDto,
} from '../models/index';
import {
    RoomParticipantDtoApiResponseFromJSON,
    RoomParticipantDtoApiResponseToJSON,
    UpdateRoomParticipantDtoFromJSON,
    UpdateRoomParticipantDtoToJSON,
} from '../models/index';

export interface ApiRoomParticipantIdPutRequest {
    id: number;
    updateRoomParticipantDto?: UpdateRoomParticipantDto;
}

export interface ApiRoomParticipantPostRequest {
    roomId?: number;
}

/**
 * 
 */
export class RoomParticipantApi extends runtime.BaseAPI {

    /**
     */
    async apiRoomParticipantIdPutRaw(requestParameters: ApiRoomParticipantIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomParticipantDtoApiResponse>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling apiRoomParticipantIdPut().'
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
            path: `/api/room-participant/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: UpdateRoomParticipantDtoToJSON(requestParameters['updateRoomParticipantDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomParticipantDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantIdPut(requestParameters: ApiRoomParticipantIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomParticipantDtoApiResponse> {
        const response = await this.apiRoomParticipantIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiRoomParticipantPostRaw(requestParameters: ApiRoomParticipantPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<RoomParticipantDtoApiResponse>> {
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
            path: `/api/room-participant`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => RoomParticipantDtoApiResponseFromJSON(jsonValue));
    }

    /**
     */
    async apiRoomParticipantPost(requestParameters: ApiRoomParticipantPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<RoomParticipantDtoApiResponse> {
        const response = await this.apiRoomParticipantPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
