using System.Net;

namespace TraktNET
{
    internal static class Constants
    {
        internal const string APIBaseURL = "https://api.trakt.tv/";

        internal const string APIStagingBaseURL = "https://api-staging.trakt.tv/";

        internal const int API_VERSION = 2;

        internal static class StatusCodes
        {
            internal const HttpStatusCode Success = HttpStatusCode.OK;

            internal const HttpStatusCode SuccessResourceCreated = HttpStatusCode.Created;

            internal const HttpStatusCode SuccessNoContent = HttpStatusCode.NoContent;

            internal const HttpStatusCode BadRequest = HttpStatusCode.BadRequest;

            internal const HttpStatusCode Unauthorized = HttpStatusCode.Unauthorized;

            internal const HttpStatusCode Forbidden = HttpStatusCode.Forbidden;

            internal const HttpStatusCode NotFound = HttpStatusCode.NotFound;

            internal const HttpStatusCode MethodNotFound = HttpStatusCode.MethodNotAllowed;

            internal const HttpStatusCode Conflict = HttpStatusCode.Conflict;

            internal const HttpStatusCode PreconditionFailed = HttpStatusCode.PreconditionFailed;

            internal const HttpStatusCode AccountLimitExceeded = (HttpStatusCode)420;

#if NETSTANDARD2_0
            internal const HttpStatusCode UnprocessableEntity = (HttpStatusCode)422;
#else
            internal const HttpStatusCode UnprocessableEntity = HttpStatusCode.UnprocessableEntity;
#endif

#if NETSTANDARD2_0
            internal const HttpStatusCode LockedUserAccount = (HttpStatusCode)423;
#else
            internal const HttpStatusCode LockedUserAccount = HttpStatusCode.Locked;
#endif

            internal const HttpStatusCode VIPOnly = HttpStatusCode.UpgradeRequired;

#if NETSTANDARD2_0
            internal const HttpStatusCode RateLimitExceeded = (HttpStatusCode)429;
#else
            internal const HttpStatusCode RateLimitExceeded = HttpStatusCode.TooManyRequests;
#endif

            internal const HttpStatusCode ServerError = HttpStatusCode.InternalServerError;

            internal const HttpStatusCode ServiceUnavailableBadGateway = HttpStatusCode.BadGateway;

            internal const HttpStatusCode ServiceUnavailable = HttpStatusCode.ServiceUnavailable;

            internal const HttpStatusCode ServiceUnavailableGatewayTimeout = HttpStatusCode.GatewayTimeout;

            internal const HttpStatusCode ServiceUnavailableCloudflareError520 = (HttpStatusCode)520;

            internal const HttpStatusCode ServiceUnavailableCloudflareError521 = (HttpStatusCode)521;

            internal const HttpStatusCode ServiceUnavailableCloudflareError522 = (HttpStatusCode)522;
        }
    }
}
