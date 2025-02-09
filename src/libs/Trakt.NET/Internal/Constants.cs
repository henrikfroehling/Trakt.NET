using System.Net;
using System.Text.Json;

namespace TraktNET
{
    internal static class Constants
    {
        internal static class API
        {
            internal const string BaseURL = "https://api.trakt.tv/";

            internal const string StagingBaseURL = "https://api-staging.trakt.tv/";

            internal const string BaseAuthorizationURL = "https://trakt.tv/";

            internal const string StagingBaseAuthorizationURL = "https://staging.trakt.tv/";

            internal const int Version = 2;
        }

        internal static class Request
        {
            internal static class Headers
            {
                internal const string APIVersionHeaderKey = "trakt-api-version";

                internal const string APIClientIDHeaderKey = "trakt-api-key";
            }
        }

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

            internal const HttpStatusCode Gone = HttpStatusCode.Gone;

            internal const HttpStatusCode PreconditionFailed = HttpStatusCode.PreconditionFailed;

            internal const HttpStatusCode Denied = (HttpStatusCode)418;

            internal const HttpStatusCode AccountLimitExceeded = (HttpStatusCode)420;

#if NETSTANDARD2_0
            internal const HttpStatusCode ValidationError = (HttpStatusCode)422;
#else
            internal const HttpStatusCode ValidationError = HttpStatusCode.UnprocessableEntity;
#endif

#if NETSTANDARD2_0
            internal const HttpStatusCode LockedUserAccount = (HttpStatusCode)423;
#else
            internal const HttpStatusCode LockedUserAccount = HttpStatusCode.Locked;
#endif

            internal const HttpStatusCode VIPValidationError = HttpStatusCode.UpgradeRequired;

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

#if NETSTANDARD2_0
        internal static class MediaTypeNames
        {
            internal const string ApplicationJson = "application/json";
        }
#endif

        internal static class Json
        {
            internal const string FactoryKey = "trakt";

#if NET8_0_OR_GREATER
            internal static readonly JsonNamingPolicy NamingPolicy = JsonNamingPolicy.SnakeCaseLower;
#else
            internal static readonly JsonNamingPolicy NamingPolicy = new LowerSnakeCaseJsonNamingPolicy();
#endif

            internal static readonly JsonSerializerOptions JsonOptions = new()
            {
                PropertyNamingPolicy = NamingPolicy,
                Converters =
                {
#if NET6_0_OR_GREATER
                    new TimeOnlyJsonConverter(),
#endif
                    new TraktAccessScopeJsonConverter(),
                    new TraktAccessTokenGrantTypeJsonConverter(),
                    new TraktAccessTokenTypeJsonConverter(),
                    new TraktCommentObjectTypeJsonConverter(),
                    new TraktCommentSortOrderJsonConverter(),
                    new TraktCommentTypeJsonConverter(),
                    new TraktDateFormatJsonConverter(),
                    new TraktDayOfWeekJsonConverter(),
                    new TraktEpisodeTypeJsonConverter(),
                    new TraktExtendedInfoJsonConverter(),
                    new TraktFavoriteObjectTypeJsonConverter(),
                    new TraktFilterSectionJsonConverter(),
                    new TraktGenderJsonConverter(),
                    new TraktHiddenItemsSectionJsonConverter(),
                    new TraktHiddenItemTypeJsonConverter(),
                    new TraktHistoryActionTypeJsonConverter(),
                    new TraktKnownForDepartmentJsonConverter(),
                    new TraktLastActivityJsonConverter(),
                    new TraktListItemTypeJsonConverter(),
                    new TraktListPrivacyJsonConverter(),
                    new TraktListSortOrderJsonConverter(),
                    new TraktListTypeJsonConverter(),
                    new TraktMediaAudioJsonConverter(),
                    new TraktMediaAudioChannelJsonConverter(),
                    new TraktMediaHDRJsonConverter(),
                    new TraktMediaResolutionJsonConverter(),
                    new TraktMediaTypeJsonConverter(),
                    new TraktMovieStatusJsonConverter(),
                    new TraktNotesObjectTypeJsonConverter(),
                    new TraktRatingsItemTypeJsonConverter(),
                    new TraktReleaseTypeJsonConverter(),
                    new TraktScrobbleActionTypeJsonConverter(),
                    new TraktSearchFieldJsonConverter(),
                    new TraktSearchIDTypeJsonConverter(),
                    new TraktSearchResultTypeJsonConverter(),
                    new TraktShowStatusJsonConverter(),
                    new TraktSortByJsonConverter(),
                    new TraktSortHowJsonConverter(),
                    new TraktSyncItemTypeJsonConverter(),
                    new TraktSyncTypeJsonConverter(),
                    new TraktTimePeriodJsonConverter(),
                    new TraktUserLikeTypeJsonConverter(),
                    new TraktVideoTypeJsonConverter(),
                    new TraktWatchlistSortOrderJsonConverter()
                }
            };
        }

        internal static class ResponseHeaders
        {
            internal const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";

            internal const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";

            internal const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";

            internal const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";

            internal const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";

            internal const string HEADER_SORT_BY_KEY = "X-Sort-By";

            internal const string HEADER_SORT_HOW_KEY = "X-Sort-How";

            internal const string HEADER_APPLIED_SORT_BY = "X-Applied-Sort-By";

            internal const string HEADER_APPLIED_SORT_HOW = "X-Applied-Sort-How";

            internal const string HEADER_STARTDATE_KEY = "X-Start-Date";

            internal const string HEADER_ENDDATE_KEY = "X-End-Date";

            internal const string HEADER_PRIVATE_USER_KEY = "X-Private-User";

            internal const string HEADER_ITEM_ID = "X-Item-ID";

            internal const string HEADER_ITEM_TYPE = "X-Item-Type";

            internal const string HEADER_RATE_LIMIT = "X-RateLimit";

            internal const string HEADER_RETRY_AFTER = "Retry-After";

            internal const string HEADER_UPGRADE_URL = "X-Upgrade-URL";

            internal const string HEADER_VIP_USER = "X-VIP-User";

            internal const string HEADER_ACCOUNT_LIMIT = "X-Account-Limit";

            internal const string HEADER_ACCOUNT_LOCKED = "X-Account-Locked";

            internal const string HEADER_ACCOUNT_DEACTIVATED = "X-Account-Deactivated";
        }
    }
}
