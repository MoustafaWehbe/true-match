"use strict";
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
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.TextApiResponse = exports.BlobApiResponse = exports.VoidApiResponse = exports.JSONApiResponse = exports.COLLECTION_FORMATS = exports.RequiredError = exports.FetchError = exports.ResponseError = exports.BaseAPI = exports.DefaultConfig = exports.Configuration = exports.BASE_PATH = void 0;
exports.querystring = querystring;
exports.mapValues = mapValues;
exports.canConsumeForm = canConsumeForm;
exports.BASE_PATH = "http://localhost".replace(/\/+$/, "");
var Configuration = /** @class */ (function () {
    function Configuration(configuration) {
        if (configuration === void 0) { configuration = {}; }
        this.configuration = configuration;
    }
    Object.defineProperty(Configuration.prototype, "config", {
        set: function (configuration) {
            this.configuration = configuration;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "basePath", {
        get: function () {
            return this.configuration.basePath != null ? this.configuration.basePath : exports.BASE_PATH;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "fetchApi", {
        get: function () {
            return this.configuration.fetchApi;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "middleware", {
        get: function () {
            return this.configuration.middleware || [];
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "queryParamsStringify", {
        get: function () {
            return this.configuration.queryParamsStringify || querystring;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "username", {
        get: function () {
            return this.configuration.username;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "password", {
        get: function () {
            return this.configuration.password;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "apiKey", {
        get: function () {
            var apiKey = this.configuration.apiKey;
            if (apiKey) {
                return typeof apiKey === 'function' ? apiKey : function () { return apiKey; };
            }
            return undefined;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "accessToken", {
        get: function () {
            var _this = this;
            var accessToken = this.configuration.accessToken;
            if (accessToken) {
                return typeof accessToken === 'function' ? accessToken : function () { return __awaiter(_this, void 0, void 0, function () { return __generator(this, function (_a) {
                    return [2 /*return*/, accessToken];
                }); }); };
            }
            return undefined;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "headers", {
        get: function () {
            return this.configuration.headers;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Configuration.prototype, "credentials", {
        get: function () {
            return this.configuration.credentials;
        },
        enumerable: false,
        configurable: true
    });
    return Configuration;
}());
exports.Configuration = Configuration;
exports.DefaultConfig = new Configuration();
/**
 * This is the base class for all generated API classes.
 */
var BaseAPI = /** @class */ (function () {
    function BaseAPI(configuration) {
        if (configuration === void 0) { configuration = exports.DefaultConfig; }
        var _this = this;
        this.configuration = configuration;
        this.fetchApi = function (url, init) { return __awaiter(_this, void 0, void 0, function () {
            var fetchParams, _i, _a, middleware, response, e_1, _b, _c, middleware, _d, _e, middleware;
            return __generator(this, function (_f) {
                switch (_f.label) {
                    case 0:
                        fetchParams = { url: url, init: init };
                        _i = 0, _a = this.middleware;
                        _f.label = 1;
                    case 1:
                        if (!(_i < _a.length)) return [3 /*break*/, 4];
                        middleware = _a[_i];
                        if (!middleware.pre) return [3 /*break*/, 3];
                        return [4 /*yield*/, middleware.pre(__assign({ fetch: this.fetchApi }, fetchParams))];
                    case 2:
                        fetchParams = (_f.sent()) || fetchParams;
                        _f.label = 3;
                    case 3:
                        _i++;
                        return [3 /*break*/, 1];
                    case 4:
                        response = undefined;
                        _f.label = 5;
                    case 5:
                        _f.trys.push([5, 7, , 12]);
                        return [4 /*yield*/, (this.configuration.fetchApi || fetch)(fetchParams.url, fetchParams.init)];
                    case 6:
                        response = _f.sent();
                        return [3 /*break*/, 12];
                    case 7:
                        e_1 = _f.sent();
                        _b = 0, _c = this.middleware;
                        _f.label = 8;
                    case 8:
                        if (!(_b < _c.length)) return [3 /*break*/, 11];
                        middleware = _c[_b];
                        if (!middleware.onError) return [3 /*break*/, 10];
                        return [4 /*yield*/, middleware.onError({
                                fetch: this.fetchApi,
                                url: fetchParams.url,
                                init: fetchParams.init,
                                error: e_1,
                                response: response ? response.clone() : undefined,
                            })];
                    case 9:
                        response = (_f.sent()) || response;
                        _f.label = 10;
                    case 10:
                        _b++;
                        return [3 /*break*/, 8];
                    case 11:
                        if (response === undefined) {
                            if (e_1 instanceof Error) {
                                throw new FetchError(e_1, 'The request failed and the interceptors did not return an alternative response');
                            }
                            else {
                                throw e_1;
                            }
                        }
                        return [3 /*break*/, 12];
                    case 12:
                        _d = 0, _e = this.middleware;
                        _f.label = 13;
                    case 13:
                        if (!(_d < _e.length)) return [3 /*break*/, 16];
                        middleware = _e[_d];
                        if (!middleware.post) return [3 /*break*/, 15];
                        return [4 /*yield*/, middleware.post({
                                fetch: this.fetchApi,
                                url: fetchParams.url,
                                init: fetchParams.init,
                                response: response.clone(),
                            })];
                    case 14:
                        response = (_f.sent()) || response;
                        _f.label = 15;
                    case 15:
                        _d++;
                        return [3 /*break*/, 13];
                    case 16: return [2 /*return*/, response];
                }
            });
        }); };
        this.middleware = configuration.middleware;
    }
    BaseAPI.prototype.withMiddleware = function () {
        var _a;
        var middlewares = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            middlewares[_i] = arguments[_i];
        }
        var next = this.clone();
        next.middleware = (_a = next.middleware).concat.apply(_a, middlewares);
        return next;
    };
    BaseAPI.prototype.withPreMiddleware = function () {
        var preMiddlewares = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            preMiddlewares[_i] = arguments[_i];
        }
        var middlewares = preMiddlewares.map(function (pre) { return ({ pre: pre }); });
        return this.withMiddleware.apply(this, middlewares);
    };
    BaseAPI.prototype.withPostMiddleware = function () {
        var postMiddlewares = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            postMiddlewares[_i] = arguments[_i];
        }
        var middlewares = postMiddlewares.map(function (post) { return ({ post: post }); });
        return this.withMiddleware.apply(this, middlewares);
    };
    /**
     * Check if the given MIME is a JSON MIME.
     * JSON MIME examples:
     *   application/json
     *   application/json; charset=UTF8
     *   APPLICATION/JSON
     *   application/vnd.company+json
     * @param mime - MIME (Multipurpose Internet Mail Extensions)
     * @return True if the given MIME is JSON, false otherwise.
     */
    BaseAPI.prototype.isJsonMime = function (mime) {
        if (!mime) {
            return false;
        }
        return BaseAPI.jsonRegex.test(mime);
    };
    BaseAPI.prototype.request = function (context, initOverrides) {
        return __awaiter(this, void 0, void 0, function () {
            var _a, url, init, response;
            return __generator(this, function (_b) {
                switch (_b.label) {
                    case 0: return [4 /*yield*/, this.createFetchParams(context, initOverrides)];
                    case 1:
                        _a = _b.sent(), url = _a.url, init = _a.init;
                        return [4 /*yield*/, this.fetchApi(url, init)];
                    case 2:
                        response = _b.sent();
                        if (response && (response.status >= 200 && response.status < 300)) {
                            return [2 /*return*/, response];
                        }
                        throw new ResponseError(response, 'Response returned an error code');
                }
            });
        });
    };
    BaseAPI.prototype.createFetchParams = function (context, initOverrides) {
        return __awaiter(this, void 0, void 0, function () {
            var url, headers, initOverrideFn, initParams, overriddenInit, _a, body, init;
            var _this = this;
            return __generator(this, function (_b) {
                switch (_b.label) {
                    case 0:
                        url = this.configuration.basePath + context.path;
                        if (context.query !== undefined && Object.keys(context.query).length !== 0) {
                            // only add the querystring to the URL if there are query parameters.
                            // this is done to avoid urls ending with a "?" character which buggy webservers
                            // do not handle correctly sometimes.
                            url += '?' + this.configuration.queryParamsStringify(context.query);
                        }
                        headers = Object.assign({}, this.configuration.headers, context.headers);
                        Object.keys(headers).forEach(function (key) { return headers[key] === undefined ? delete headers[key] : {}; });
                        initOverrideFn = typeof initOverrides === "function"
                            ? initOverrides
                            : function () { return __awaiter(_this, void 0, void 0, function () { return __generator(this, function (_a) {
                                return [2 /*return*/, initOverrides];
                            }); }); };
                        initParams = {
                            method: context.method,
                            headers: headers,
                            body: context.body,
                            credentials: this.configuration.credentials,
                        };
                        _a = [__assign({}, initParams)];
                        return [4 /*yield*/, initOverrideFn({
                                init: initParams,
                                context: context,
                            })];
                    case 1:
                        overriddenInit = __assign.apply(void 0, _a.concat([(_b.sent())]));
                        if (isFormData(overriddenInit.body)
                            || (overriddenInit.body instanceof URLSearchParams)
                            || isBlob(overriddenInit.body)) {
                            body = overriddenInit.body;
                        }
                        else if (this.isJsonMime(headers['Content-Type'])) {
                            body = JSON.stringify(overriddenInit.body);
                        }
                        else {
                            body = overriddenInit.body;
                        }
                        init = __assign(__assign({}, overriddenInit), { body: body });
                        return [2 /*return*/, { url: url, init: init }];
                }
            });
        });
    };
    /**
     * Create a shallow clone of `this` by constructing a new instance
     * and then shallow cloning data members.
     */
    BaseAPI.prototype.clone = function () {
        var constructor = this.constructor;
        var next = new constructor(this.configuration);
        next.middleware = this.middleware.slice();
        return next;
    };
    BaseAPI.jsonRegex = new RegExp('^(:?application\/json|[^;/ \t]+\/[^;/ \t]+[+]json)[ \t]*(:?;.*)?$', 'i');
    return BaseAPI;
}());
exports.BaseAPI = BaseAPI;
;
function isBlob(value) {
    return typeof Blob !== 'undefined' && value instanceof Blob;
}
function isFormData(value) {
    return typeof FormData !== "undefined" && value instanceof FormData;
}
var ResponseError = /** @class */ (function (_super) {
    __extends(ResponseError, _super);
    function ResponseError(response, msg) {
        var _this = _super.call(this, msg) || this;
        _this.response = response;
        _this.name = "ResponseError";
        return _this;
    }
    return ResponseError;
}(Error));
exports.ResponseError = ResponseError;
var FetchError = /** @class */ (function (_super) {
    __extends(FetchError, _super);
    function FetchError(cause, msg) {
        var _this = _super.call(this, msg) || this;
        _this.cause = cause;
        _this.name = "FetchError";
        return _this;
    }
    return FetchError;
}(Error));
exports.FetchError = FetchError;
var RequiredError = /** @class */ (function (_super) {
    __extends(RequiredError, _super);
    function RequiredError(field, msg) {
        var _this = _super.call(this, msg) || this;
        _this.field = field;
        _this.name = "RequiredError";
        return _this;
    }
    return RequiredError;
}(Error));
exports.RequiredError = RequiredError;
exports.COLLECTION_FORMATS = {
    csv: ",",
    ssv: " ",
    tsv: "\t",
    pipes: "|",
};
function querystring(params, prefix) {
    if (prefix === void 0) { prefix = ''; }
    return Object.keys(params)
        .map(function (key) { return querystringSingleKey(key, params[key], prefix); })
        .filter(function (part) { return part.length > 0; })
        .join('&');
}
function querystringSingleKey(key, value, keyPrefix) {
    if (keyPrefix === void 0) { keyPrefix = ''; }
    var fullKey = keyPrefix + (keyPrefix.length ? "[".concat(key, "]") : key);
    if (value instanceof Array) {
        var multiValue = value.map(function (singleValue) { return encodeURIComponent(String(singleValue)); })
            .join("&".concat(encodeURIComponent(fullKey), "="));
        return "".concat(encodeURIComponent(fullKey), "=").concat(multiValue);
    }
    if (value instanceof Set) {
        var valueAsArray = Array.from(value);
        return querystringSingleKey(key, valueAsArray, keyPrefix);
    }
    if (value instanceof Date) {
        return "".concat(encodeURIComponent(fullKey), "=").concat(encodeURIComponent(value.toISOString()));
    }
    if (value instanceof Object) {
        return querystring(value, fullKey);
    }
    return "".concat(encodeURIComponent(fullKey), "=").concat(encodeURIComponent(String(value)));
}
function mapValues(data, fn) {
    return Object.keys(data).reduce(function (acc, key) {
        var _a;
        return (__assign(__assign({}, acc), (_a = {}, _a[key] = fn(data[key]), _a)));
    }, {});
}
function canConsumeForm(consumes) {
    for (var _i = 0, consumes_1 = consumes; _i < consumes_1.length; _i++) {
        var consume = consumes_1[_i];
        if ('multipart/form-data' === consume.contentType) {
            return true;
        }
    }
    return false;
}
var JSONApiResponse = /** @class */ (function () {
    function JSONApiResponse(raw, transformer) {
        if (transformer === void 0) { transformer = function (jsonValue) { return jsonValue; }; }
        this.raw = raw;
        this.transformer = transformer;
    }
    JSONApiResponse.prototype.value = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _a;
            return __generator(this, function (_b) {
                switch (_b.label) {
                    case 0:
                        _a = this.transformer;
                        return [4 /*yield*/, this.raw.json()];
                    case 1: return [2 /*return*/, _a.apply(this, [_b.sent()])];
                }
            });
        });
    };
    return JSONApiResponse;
}());
exports.JSONApiResponse = JSONApiResponse;
var VoidApiResponse = /** @class */ (function () {
    function VoidApiResponse(raw) {
        this.raw = raw;
    }
    VoidApiResponse.prototype.value = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                return [2 /*return*/, undefined];
            });
        });
    };
    return VoidApiResponse;
}());
exports.VoidApiResponse = VoidApiResponse;
var BlobApiResponse = /** @class */ (function () {
    function BlobApiResponse(raw) {
        this.raw = raw;
    }
    BlobApiResponse.prototype.value = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.raw.blob()];
                    case 1: return [2 /*return*/, _a.sent()];
                }
            });
        });
    };
    ;
    return BlobApiResponse;
}());
exports.BlobApiResponse = BlobApiResponse;
var TextApiResponse = /** @class */ (function () {
    function TextApiResponse(raw) {
        this.raw = raw;
    }
    TextApiResponse.prototype.value = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.raw.text()];
                    case 1: return [2 /*return*/, _a.sent()];
                }
            });
        });
    };
    ;
    return TextApiResponse;
}());
exports.TextApiResponse = TextApiResponse;
