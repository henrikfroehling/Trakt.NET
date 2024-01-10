using System.Net;

namespace TraktNET.Exceptions
{
    /// <summary>Trakt API exception.</summary>
    public partial class TraktApiException : TraktException
    {
        /// <summary>Response HTTP status code.</summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>The server's reason phrase.</summary>
        public string? ReasonPhrase { get; }

        /// <summary>Request HTTP method.</summary>
        public HttpMethod HttpMethod { get; }

        /// <summary><see cref="Uri"/> used to send the request.</summary>
        public Uri? RequestUrl => RequestMessage.RequestUri;

        /// <summary>Request message used to send the request.</summary>
        public HttpRequestMessage RequestMessage { get; }

        /// <summary>HTTP response content as string.</summary>
        public string? ResponseContent { get; }

        protected TraktApiException(string exceptionMessage, HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                    string? responseContent, Exception? innerException = null)
            : base(exceptionMessage, innerException)
        {
            StatusCode = httpStatusCode;
            ReasonPhrase = CreateReasonPhrase(httpStatusCode);
            HttpMethod = httpMethod;
            RequestMessage = requestMessage;
            ResponseContent = responseContent;
        }

        protected static string CreateExceptionMessage(HttpStatusCode httpStatusCode) => $"Trakt API request failed. {CreateReasonPhrase(httpStatusCode)}";

        protected static string CreateReasonPhrase(HttpStatusCode httpStatusCode)
            => httpStatusCode switch
            {
                Constants.StatusCodes.BadRequest => "Bad Request - request couldn't be parsed",
                Constants.StatusCodes.Unauthorized => "Unauthorized - OAuth must be provided",
                Constants.StatusCodes.Forbidden => "Forbidden - invalid API key or unapproved app",
                Constants.StatusCodes.NotFound => "Not Found - method exists, but no record found",
                Constants.StatusCodes.MethodNotFound => "Method Not Found - method doesn't exist",
                Constants.StatusCodes.Conflict => "Conflict - resource already created",
                Constants.StatusCodes.PreconditionFailed => "Precondition Failed - use application/json content type",
                Constants.StatusCodes.AccountLimitExceeded => "Account Limit Exceeded - list count, item count, etc",
                Constants.StatusCodes.UnprocessableEntity => "Unprocessable Entity - validation errors",
                Constants.StatusCodes.LockedUserAccount => "Locked User Account - have the user contact support",
                Constants.StatusCodes.VIPOnly => "VIP Only - user must upgrade to VIP",
                Constants.StatusCodes.RateLimitExceeded => "Rate Limit Exceeded",
                Constants.StatusCodes.ServerError => "Server Error - please open a support ticket",
                Constants.StatusCodes.ServiceUnavailableBadGateway => "Service Unavailable - server overloaded (try again in 30s) - Bad Gateway",
                Constants.StatusCodes.ServiceUnavailable => "Service Unavailable - server overloaded (try again in 30s)",
                Constants.StatusCodes.ServiceUnavailableGatewayTimeout => "Service Unavailable - server overloaded (try again in 30s) - Gateway Timeout",
                Constants.StatusCodes.ServiceUnavailableCloudflareError520 => "Service Unavailable - Cloudflare error - Status Code 520",
                Constants.StatusCodes.ServiceUnavailableCloudflareError521 => "Service Unavailable - Cloudflare error - Status Code 521",
                Constants.StatusCodes.ServiceUnavailableCloudflareError522 => "Service Unavailable - Cloudflare error - Status Code 522",
                _ => $"Response status code does not indicate success: {(int)httpStatusCode}"
            };
    }
}
