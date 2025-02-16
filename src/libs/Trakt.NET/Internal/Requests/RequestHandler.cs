using System.Net.Http.Headers;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        internal static async Task<TraktResponse> ExecuteNoContentRequestAsync(TraktContext context, RequestBase request,
            CancellationToken cancellationToken = default)
        {
            using RequestResponse response = await ExecuteRequestAsync(false, context, request, cancellationToken).ConfigureAwait(false);
            return TraktResponse.Create(response.ResponseMessage.StatusCode, response.TraktHeaders, response.ResponseMessage.Headers);
        }

        internal static async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(
            TraktContext context, RequestBase request, CancellationToken cancellationToken = default)
            where TResponseContentType : class
        {
            using var response = (ContentRequestResponse)await ExecuteRequestAsync(true, context, request, cancellationToken).ConfigureAwait(false);

            TResponseContentType? responseContent =
                await response.ResponseContentStream.ReadAsJsonAsync<TResponseContentType>(cancellationToken).ConfigureAwait(false);

            return TraktResponse<TResponseContentType>.Create(response.ResponseMessage.StatusCode, responseContent,
                response.TraktHeaders, response.ResponseMessage.Headers, response.ResponseMessage.Content.Headers);
        }

        internal static async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(
            TraktContext context, RequestBase request, CancellationToken cancellationToken = default)
        {
            using var response = (ContentRequestResponse)await ExecuteRequestAsync(true, context, request, cancellationToken).ConfigureAwait(false);

            IReadOnlyList<TResponseContentType>? responseContent =
                await response.ResponseContentStream.ReadAsJsonArrayAsync<TResponseContentType>(cancellationToken).ConfigureAwait(false);

            return TraktListResponse<TResponseContentType>.Create(response.ResponseMessage.StatusCode, responseContent,
                response.TraktHeaders, response.ResponseMessage.Headers, response.ResponseMessage.Content.Headers);
        }

        internal static async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedListRequestAsync<TResponseContentType>(
            TraktContext context, RequestBase request, Func<uint?, uint?, RequestBase>? requestBuilder, CancellationToken cancellationToken = default)
        {
            using var response = (ContentRequestResponse)await ExecuteRequestAsync(true, context, request, cancellationToken).ConfigureAwait(false);

            IReadOnlyList<TResponseContentType>? responseContent =
                await response.ResponseContentStream.ReadAsJsonArrayAsync<TResponseContentType>(cancellationToken).ConfigureAwait(false);

            var pagedResponse = TraktPagedResponse<TResponseContentType>.Create(response.ResponseMessage.StatusCode, responseContent,
                response.TraktHeaders, response.ResponseMessage.Headers, response.ResponseMessage.Content.Headers);

            pagedResponse.Context = context;
            pagedResponse.RequestBuilder = requestBuilder;

            return pagedResponse;
        }

        private static async Task<RequestResponse> ExecuteRequestAsync(bool withContent, TraktContext context, RequestBase request,
            CancellationToken cancellationToken = default)
        {
            request.Validate();
            request.BuildUri();
            AddRequestMessageHeaders(context, request);

            HttpClient httpClient = context.GetHttpClient();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                cancellationToken).ConfigureAwait(false);

            TraktResponseHeaders traktHeaders = await ParseTraktResponseHeadersAsync(responseMessage.Headers, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
            {
                await HandleErrorAsync(request, responseMessage, traktHeaders, false, cancellationToken).ConfigureAwait(false);
            }

            if (withContent)
            {
#if NET5_0_OR_GREATER
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage, cancellationToken).ConfigureAwait(false);
#else
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
#endif

                return new ContentRequestResponse
                {
                    ResponseMessage = responseMessage,
                    ResponseContentStream = responseContentStream,
                    TraktHeaders = traktHeaders
                };
            }

            return new RequestResponse
            {
                ResponseMessage = responseMessage,
                TraktHeaders = traktHeaders
            };
        }

        private static void AddRequestMessageHeaders(TraktContext context, RequestBase request)
        {
            request.Headers.Add(Constants.Request.Headers.APIVersionHeaderKey, $"{Constants.API.Version}");
            request.Headers.Add(Constants.Request.Headers.APIClientIDHeaderKey, context.ClientID);

            TraktOAuthRequirement oauthRequirement = request.OAuthRequirement;

            if (oauthRequirement == TraktOAuthRequirement.NotRequired)
            {
                return;
            }

            if (context.IgnoreOAuthIfOptional && (oauthRequirement == TraktOAuthRequirement.Optional
                || oauthRequirement == TraktOAuthRequirement.OptionalButMightBeRequired))
            {
                return;
            }

            if (context.Authorization != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(Constants.Request.AuthenticationScheme, context.Authorization!.AccessToken ?? string.Empty);
            }
        }

#if NET5_0_OR_GREATER
        private static Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage responseMessage, CancellationToken cancellationToken = default)
            => responseMessage.Content.ReadAsStreamAsync(cancellationToken);
#else
        private static Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage responseMessage)
            => responseMessage.Content.ReadAsStreamAsync();
#endif
    }

    internal record class RequestResponse : IDisposable
    {
        internal required HttpResponseMessage ResponseMessage { get; init; }

        internal required TraktResponseHeaders TraktHeaders { get; init; }

        public virtual void Dispose() => ResponseMessage.Dispose();
    }

    internal record class ContentRequestResponse : RequestResponse
    {
        internal required Stream ResponseContentStream { get; init; }

        public override void Dispose()
        {
            base.Dispose();
            ResponseContentStream?.Dispose();
        }
    }
}
