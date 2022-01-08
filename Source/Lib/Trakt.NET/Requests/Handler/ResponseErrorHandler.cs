namespace TraktNet.Requests.Handler
{
    using Base;
    using Exceptions;
    using Objects.Basic;
    using Objects.Json;
    using Objects.Post.Checkins.Responses;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class ResponseErrorHandler
    {
        internal static async Task HandleErrorsAsync(ExtendedHttpRequestMessage requestMessage, HttpResponseMessage responseMessage,
                                                     bool isCheckinRequest = false, bool isDeviceRequest = false, bool isInAuthorizationPolling = false,
                                                     bool isAuthorizationRequest = false, bool isAuthorizationRevoke = false,
                                                     CancellationToken cancellationToken = default)
        {
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            if (responseMessage == null)
                throw new ArgumentNullException(nameof(responseMessage));

            string responseContent = string.Empty;

            if (responseMessage.Content != null)
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var errorParameters = new ResponseErrorParameters
            {
                IsCheckinRequest = isCheckinRequest,
                RequestBody = requestMessage.RequestBodyJson,
                ResponseBody = responseContent ?? string.Empty,
                ServerReasonPhrase = responseMessage.ReasonPhrase,
                StatusCode = responseMessage.StatusCode,
                Url = requestMessage.Url,
                RequestObjectType = requestMessage.RequestObjectType ?? RequestObjectType.Unspecified,
                ObjectId = requestMessage.ObjectId,
                SeasonNumber = requestMessage.SeasonNumber ?? 0,
                EpisodeNumber = requestMessage.EpisodeNumber ?? 0,
                IsDeviceRequest = isDeviceRequest,
                IsInAuthorizationPolling = isInAuthorizationPolling,
                IsAuthorizationRequest = isAuthorizationRequest,
                IsAuthorizationRevoke = isAuthorizationRevoke
            };

            ResponseHeaderParser.ParsePagedResponseHeaderValues(errorParameters.Headers, responseMessage.Headers);
            await HandleErrorsAsync(errorParameters, cancellationToken).ConfigureAwait(false);
        }

        private static async Task HandleErrorsAsync(ResponseErrorParameters errorParameters, CancellationToken cancellationToken = default)
        {
            switch (errorParameters.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    HandleNotFoundError(errorParameters);
                    break;
                case HttpStatusCode.Conflict:
                    await HandleConflictErrorAsync(errorParameters, cancellationToken).ConfigureAwait(false);
                    break;
                case HttpStatusCode.BadRequest:
                    HandleBadRequestError(errorParameters);
                    break;
                case HttpStatusCode.Unauthorized:
                    HandleUnauthorizedError(errorParameters);
                    break;
                case HttpStatusCode.Forbidden:
                    HandleForbiddenError(errorParameters);
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    HandleMethodNotAllowedError(errorParameters);
                    break;
                case HttpStatusCode.Gone:
                    HandleGoneError(errorParameters);
                    break;
                case HttpStatusCode.InternalServerError:
                    HandleInternalServerError(errorParameters);
                    break;
                case HttpStatusCode.BadGateway:
                    HandleBadGatewayError(errorParameters);
                    break;
                case (HttpStatusCode)412:
                    HandlePreconditionError(errorParameters);
                    break;
                case (HttpStatusCode)418:
                    HandleDeniedError(errorParameters);
                    break;
                case (HttpStatusCode)422:
                    HandleValidationError(errorParameters);
                    break;
                case (HttpStatusCode)423:
                    HandleLockedUserAccountError(errorParameters);
                    break;
                case (HttpStatusCode)426:
                    HandleFailedVIPValidationError(errorParameters);
                    break;
                case (HttpStatusCode)429:
                    await HandleRateLimitErrorAsync(errorParameters, cancellationToken).ConfigureAwait(false);
                    break;
                case (HttpStatusCode)503:
                case (HttpStatusCode)504:
                    HandleServerOverloadedError(errorParameters);
                    break;
                case (HttpStatusCode)520:
                case (HttpStatusCode)521:
                case (HttpStatusCode)522:
                    HandleCloudflareError(errorParameters);
                    break;
            }

            await HandleUnknownErrorAsync(errorParameters, cancellationToken).ConfigureAwait(false);
        }

        private static void HandleNotFoundError(ResponseErrorParameters errorParameters)
        {
            string requestUrl = errorParameters.Url;
            string requestBody = errorParameters.RequestBody;
            string responseBody = errorParameters.ResponseBody;
            string reasonPhrase = errorParameters.ServerReasonPhrase;
            RequestObjectType requestObjectType = errorParameters.RequestObjectType;
            bool isDeviceRequest = errorParameters.IsDeviceRequest;
            bool isInAuthorizationPolling = errorParameters.IsInAuthorizationPolling;
            bool isAuthorizationRequest = errorParameters.IsAuthorizationRequest;
            bool isAuthorizationRevoke = errorParameters.IsAuthorizationRevoke;

            if (isDeviceRequest || isInAuthorizationPolling)
            {
                throw new TraktAuthenticationDeviceException("Not Found - invalid device code")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            else if (isAuthorizationRequest)
            {
                throw new TraktAuthenticationOAuthException("Resource not found")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            else if (isAuthorizationRevoke)
            {
                throw new TraktAuthenticationException("Resource not found")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            else if (requestObjectType != RequestObjectType.Unspecified && !isDeviceRequest && !isInAuthorizationPolling && !isAuthorizationRequest && !isAuthorizationRevoke)
            {
                HandleNotFoundObjectError(errorParameters, requestUrl, requestBody, responseBody, reasonPhrase, requestObjectType);
            }

            throw new TraktNotFoundException($"Resource not found - Reason Phrase: {reasonPhrase}")
            {
                RequestUrl = requestUrl,
                RequestBody = requestBody,
                Response = responseBody,
                ServerReasonPhrase = reasonPhrase
            };
        }

        private static void HandleNotFoundObjectError(ResponseErrorParameters errorParameters, string requestUrl, string requestBody, string responseBody, string reasonPhrase, RequestObjectType requestObjectType)
        {
            string objectId = errorParameters.ObjectId;
            uint seasonNr = errorParameters.SeasonNumber;
            uint episodeNr = errorParameters.EpisodeNumber;

            switch (requestObjectType)
            {
                case RequestObjectType.Episodes:
                    throw new TraktEpisodeNotFoundException(objectId, seasonNr, episodeNr)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Seasons:
                    throw new TraktSeasonNotFoundException(objectId, seasonNr)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Shows:
                    throw new TraktShowNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Movies:
                    throw new TraktMovieNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.People:
                    throw new TraktPersonNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Comments:
                    throw new TraktCommentNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Lists:
                    throw new TraktListNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
                case RequestObjectType.Object:
                    throw new TraktObjectNotFoundException(objectId)
                    {
                        RequestUrl = requestUrl,
                        RequestBody = requestBody,
                        Response = responseBody,
                        ServerReasonPhrase = reasonPhrase
                    };
            }
        }

        private static async Task HandleConflictErrorAsync(ResponseErrorParameters errorParameters, CancellationToken cancellationToken = default)
        {
            string requestUrl = errorParameters.Url;
            string requestBody = errorParameters.RequestBody;
            string responseBody = errorParameters.ResponseBody;
            string reasonPhrase = errorParameters.ServerReasonPhrase;

            if (errorParameters.IsCheckinRequest)
            {
                ITraktCheckinPostErrorResponse errorResponse = null;

                if (!string.IsNullOrEmpty(errorParameters.ResponseBody))
                {
                    IObjectJsonReader<ITraktCheckinPostErrorResponse> errorResponseReader = JsonFactoryContainer.CreateObjectReader<ITraktCheckinPostErrorResponse>();
                    errorResponse = await errorResponseReader.ReadObjectAsync(errorParameters.ResponseBody, cancellationToken).ConfigureAwait(false);
                }

                throw new TraktCheckinException("checkin is already in progress")
                {
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase,
                    ExpiresAt = errorResponse?.ExpiresAt
                };
            }
            else if (errorParameters.IsInAuthorizationPolling)
            {
                // Authorization Polling - Already Used
                throw new TraktAuthenticationDeviceException("Already Used - user already approved this code")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }

            throw new TraktConflictException
            {
                RequestUrl = requestUrl,
                RequestBody = requestBody,
                Response = responseBody,
                ServerReasonPhrase = reasonPhrase
            };
        }

        private static void HandleBadRequestError(ResponseErrorParameters errorParameters)
        {
            if (!errorParameters.IsInAuthorizationPolling)
            {
                throw new TraktBadRequestException
                {
                    RequestUrl = errorParameters.Url,
                    RequestBody = errorParameters.RequestBody,
                    Response = errorParameters.ResponseBody,
                    ServerReasonPhrase = errorParameters.ServerReasonPhrase
                };
            }
        }

        private static void HandleUnauthorizedError(ResponseErrorParameters errorParameters)
        {
            if (!errorParameters.IsAuthorizationRequest && !errorParameters.IsAuthorizationRevoke)
            {
                throw new TraktAuthorizationException
                {
                    RequestUrl = errorParameters.Url,
                    RequestBody = errorParameters.RequestBody,
                    Response = errorParameters.ResponseBody,
                    ServerReasonPhrase = errorParameters.ServerReasonPhrase
                };
            }
        }

        private static void HandleForbiddenError(ResponseErrorParameters errorParameters)
        {
            throw new TraktForbiddenException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleMethodNotAllowedError(ResponseErrorParameters errorParameters)
        {
            throw new TraktMethodNotFoundException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleGoneError(ResponseErrorParameters errorParameters)
        {
            if (errorParameters.IsInAuthorizationPolling)
            {
                // Authorization Polling - Expired
                throw new TraktAuthenticationDeviceException("Expired - the tokens have expired, restart the process")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = errorParameters.Url,
                    RequestBody = errorParameters.RequestBody,
                    Response = errorParameters.ResponseBody,
                    ServerReasonPhrase = errorParameters.ServerReasonPhrase
                };
            }
        }

        private static void HandleInternalServerError(ResponseErrorParameters errorParameters)
        {
            throw new TraktServerException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleBadGatewayError(ResponseErrorParameters errorParameters)
        {
            throw new TraktBadGatewayException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandlePreconditionError(ResponseErrorParameters errorParameters)
        {
            throw new TraktPreconditionFailedException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleDeniedError(ResponseErrorParameters errorParameters)
        {
            if (errorParameters.IsInAuthorizationPolling)
            {
                // Authorization Polling - Denied
                throw new TraktAuthenticationDeviceException("Denied - user explicitly denied this code")
                {
                    StatusCode = (HttpStatusCode)418,
                    RequestUrl = errorParameters.Url,
                    RequestBody = errorParameters.RequestBody,
                    Response = errorParameters.ResponseBody,
                    ServerReasonPhrase = errorParameters.ServerReasonPhrase
                };
            }
        }

        private static void HandleValidationError(ResponseErrorParameters errorParameters)
        {
            throw new TraktValidationException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleLockedUserAccountError(ResponseErrorParameters errorParameters)
        {
            throw new TraktLockedUserAccountException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleFailedVIPValidationError(ResponseErrorParameters errorParameters)
        {
            throw new TraktFailedVIPValidationException
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase,
                UpgradeURL = !string.IsNullOrEmpty(errorParameters.Headers.UpgradeURL) ? errorParameters.Headers.UpgradeURL : ""
            };
        }

        private static async Task HandleRateLimitErrorAsync(ResponseErrorParameters errorParameters, CancellationToken cancellationToken = default)
        {
            string requestUrl = errorParameters.Url;
            string requestBody = errorParameters.RequestBody;
            string responseBody = errorParameters.ResponseBody;
            string reasonPhrase = errorParameters.ServerReasonPhrase;

            if (errorParameters.IsInAuthorizationPolling)
            {
                // Authorization Polling - Slow Down
                throw new TraktAuthenticationDeviceException("Slow Down - your app is polling too quickly")
                {
                    StatusCode = (HttpStatusCode)429,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }

            ITraktRateLimitInfo rateLimitInfo = null;

            try
            {
                if (!string.IsNullOrEmpty(errorParameters.Headers.RateLimit))
                {
                    IObjectJsonReader<ITraktRateLimitInfo> rateLimitInfoReader = JsonFactoryContainer.CreateObjectReader<ITraktRateLimitInfo>();
                    rateLimitInfo = await rateLimitInfoReader.ReadObjectAsync(errorParameters.Headers.RateLimit, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new TraktException("json convert exception", ex);
            }

            throw new TraktRateLimitException
            {
                RequestUrl = requestUrl,
                RequestBody = requestBody,
                Response = responseBody,
                ServerReasonPhrase = reasonPhrase,
                RateLimitInfo = rateLimitInfo,
                RetryAfter = errorParameters.Headers.RetryAfter
            };
        }

        private static void HandleServerOverloadedError(ResponseErrorParameters errorParameters)
        {
            throw new TraktServerUnavailableException("Service Unavailable - server overloaded (try again in 30s)")
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static void HandleCloudflareError(ResponseErrorParameters errorParameters)
        {
            throw new TraktServerUnavailableException("Service Unavailable - Cloudflare error")
            {
                RequestUrl = errorParameters.Url,
                RequestBody = errorParameters.RequestBody,
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Response = errorParameters.ResponseBody,
                ServerReasonPhrase = errorParameters.ServerReasonPhrase
            };
        }

        private static async Task HandleUnknownErrorAsync(ResponseErrorParameters errorParameters, CancellationToken cancellationToken = default)
        {
            string requestUrl = errorParameters.Url;
            string requestBody = errorParameters.RequestBody;
            string responseBody = errorParameters.ResponseBody;
            string reasonPhrase = errorParameters.ServerReasonPhrase;

            if (errorParameters.IsDeviceRequest || errorParameters.IsInAuthorizationPolling)
            {
                throw new TraktAuthenticationDeviceException("unknown exception")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            else if (errorParameters.IsAuthorizationRequest)
            {
                throw new TraktAuthenticationOAuthException("unknown exception")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            else if (errorParameters.IsAuthorizationRevoke)
            {
                throw new TraktAuthenticationException("unknown exception")
                {
                    StatusCode = errorParameters.StatusCode,
                    RequestUrl = requestUrl,
                    RequestBody = requestBody,
                    Response = responseBody,
                    ServerReasonPhrase = reasonPhrase
                };
            }

            ITraktError error;

            try
            {
                IObjectJsonReader<ITraktError> errorReader = JsonFactoryContainer.CreateObjectReader<ITraktError>();
                error = await errorReader.ReadObjectAsync(responseBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new TraktException("json convert exception", ex);
            }

            var errorMessage = (error == null || string.IsNullOrEmpty(error.Description))
                                    ? $"Trakt API error without content. Response status code was {(int)errorParameters.StatusCode}"
                                    : error.Description;

            throw new TraktException(errorMessage)
            {
                StatusCode = errorParameters.StatusCode,
                RequestUrl = requestUrl,
                RequestBody = requestBody,
                Response = responseBody,
                ServerReasonPhrase = reasonPhrase
            };
        }
    }
}
