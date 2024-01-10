using System.Net;

namespace TraktNET.Exceptions
{
    public partial class TraktApiException
    {
        internal static TraktApiException Create(HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                 string? responseContent, Exception? innerException = null)
            => httpStatusCode switch
            {
                Constants.StatusCodes.BadRequest => new TraktApiBadRequestException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.Unauthorized => new TraktApiAuthorizationException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.Forbidden => new TraktApiForbiddenException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.NotFound => new TraktApiNotFoundException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.MethodNotFound => new TraktApiMethodNotFoundException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.Conflict => new TraktApiConflictException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.PreconditionFailed => new TraktApiPreconditionFailedException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.AccountLimitExceeded => new TraktApiAccountLimitException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.UnprocessableEntity => new TraktApiValidationException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.LockedUserAccount => new TraktApiLockedUserAccountException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.VIPOnly => new TraktApiVIPValidationException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.RateLimitExceeded => new TraktApiRateLimitException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServerError => new TraktApiServerException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailableBadGateway => new TraktApiBadGatewayException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailable => new TraktApiServerUnavailableException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailableGatewayTimeout => new TraktApiGatewayTimeoutException(httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError520 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError521 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, innerException),
                Constants.StatusCodes.ServiceUnavailableCloudflareError522 => new TraktApiCloudflareException(httpStatusCode, httpMethod, requestMessage, responseContent, innerException),
                _ => new TraktApiException(CreateExceptionMessage(httpStatusCode), httpStatusCode, httpMethod, requestMessage, responseContent, innerException),
            };
    }
}
