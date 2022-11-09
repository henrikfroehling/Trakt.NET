﻿namespace Trakt.NET.Tests.Utility
{
    using FluentAssertions;
    using RichardSzalay.MockHttp;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using TraktNet.Enums;
    using TraktNet.Requests.Handler;

    internal class TestHttpClientProvider : IHttpClientProvider
    {
        private const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";
        private const string HEADER_STARTDATE_KEY = "X-Start-Date";
        private const string HEADER_ENDDATE_KEY = "X-End-Date";
        private const string HEADER_SORT_BY_KEY = "X-Sort-By";
        private const string HEADER_SORT_HOW_KEY = "X-Sort-How";
        private const string TRAKT_API_HEADER_KEY = "trakt-api-key";
        private const string TRAKT_API_VERSION_HEADER_KEY = "trakt-api-version";
        private const string TRAKT_API_AUTHORIZATION_HEADEY_KEY = "Authorization";
        private const string ACCEPT_MEDIA_TYPE = "application/json";
        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly MockHttpMessageHandler _mockHttpMessageHandler;

        public TestHttpClientProvider(string baseUrl)
        {
            _baseUrl = baseUrl;
            _clientId = TestConstants.TRAKT_CLIENT_ID;
            _mockHttpMessageHandler = new MockHttpMessageHandler();
        }

        public HttpClient GetHttpClient()
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            var httpClient = new HttpClient(_mockHttpMessageHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ACCEPT_MEDIA_TYPE));
            return httpClient;
        }

        internal void SetupMockResponse(string uri, string responseContent,
                                        uint? page = null, uint? limit = null,
                                        int? pageCount = null, int? itemCount = null,
                                        int? userCount = null, string startDate = null,
                                        string endDate = null, TraktSortBy? sortBy = null,
                                        TraktSortHow? sortHow = null)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            _clientId.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (page.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_KEY, $"{page.GetValueOrDefault()}");

            if (limit.HasValue)
                response.Headers.Add(HEADER_PAGINATION_LIMIT_KEY, $"{limit.GetValueOrDefault()}");

            if (pageCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount.GetValueOrDefault()}");

            if (itemCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount.GetValueOrDefault()}");

            if (userCount.HasValue)
                response.Headers.Add(HEADER_TRENDING_USER_COUNT_KEY, $"{userCount.GetValueOrDefault()}");

            if (!string.IsNullOrEmpty(startDate))
                response.Headers.Add(HEADER_STARTDATE_KEY, startDate);

            if (!string.IsNullOrEmpty(endDate))
                response.Headers.Add(HEADER_ENDDATE_KEY, endDate);

            if (sortBy.HasValue)
                response.Headers.Add(HEADER_SORT_BY_KEY, SortByToString(sortBy.Value));

            if (sortHow.HasValue)
                response.Headers.Add(HEADER_SORT_HOW_KEY, SortHowToString(sortHow.Value));

            response.Headers.Add("Accept", ACCEPT_MEDIA_TYPE);
            response.Content = new StringContent(responseContent);

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" }
                })
                .Respond(r => response);
        }

        internal void SetupMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" }
                })
                .Respond(httpStatusCode);
        }

        internal void SetupOAuthMockResponse(string uri, string responseContent,
                                             uint? page = null, uint? limit = null,
                                             int? pageCount = null, int? itemCount = null,
                                             int? userCount = null, string startDate = null,
                                             string endDate = null, TraktSortBy? sortBy = null,
                                             TraktSortHow? sortHow = null)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            _clientId.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (page.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_KEY, $"{page.GetValueOrDefault()}");

            if (limit.HasValue)
                response.Headers.Add(HEADER_PAGINATION_LIMIT_KEY, $"{limit.GetValueOrDefault()}");

            if (pageCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount.GetValueOrDefault()}");

            if (itemCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount.GetValueOrDefault()}");

            if (userCount.HasValue)
                response.Headers.Add(HEADER_TRENDING_USER_COUNT_KEY, $"{userCount.GetValueOrDefault()}");

            if (!string.IsNullOrEmpty(startDate))
                response.Headers.Add(HEADER_STARTDATE_KEY, startDate);

            if (!string.IsNullOrEmpty(endDate))
                response.Headers.Add(HEADER_ENDDATE_KEY, endDate);

            if (sortBy.HasValue)
                response.Headers.Add(HEADER_SORT_BY_KEY, SortByToString(sortBy.Value));

            if (sortHow.HasValue)
                response.Headers.Add(HEADER_SORT_HOW_KEY, SortHowToString(sortHow.Value));

            response.Headers.Add("Accept", ACCEPT_MEDIA_TYPE);
            response.Content = new StringContent(responseContent);

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" },
                    { TRAKT_API_AUTHORIZATION_HEADEY_KEY, $"Bearer {TestConstants.MOCK_AUTHORIZATION.AccessToken}" }
                })
                .Respond(r => response);
        }

        internal void SetupOAuthMockResponse(string uri, string requestContent, string responseContent)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            _clientId.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" },
                    { TRAKT_API_AUTHORIZATION_HEADEY_KEY, $"Bearer {TestConstants.MOCK_AUTHORIZATION.AccessToken}" }
                })
                .WithContent(requestContent)
                .Respond(ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void SetupOAuthMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" },
                    { TRAKT_API_AUTHORIZATION_HEADEY_KEY, $"Bearer {TestConstants.MOCK_AUTHORIZATION.AccessToken}" }
                })
                .Respond(httpStatusCode);
        }

        internal void SetupAuthenticationMockResponse(string uri, string requestContent, string responseContent)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void SetupAuthenticationMockResponse(string uri, string requestContent)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(HttpStatusCode.NoContent);
        }

        internal void SetupAuthenticationMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            _mockHttpMessageHandler.When(_baseUrl + uri).Respond(httpStatusCode);
        }

        internal void SetupAuthenticationMockResponse(string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(httpStatusCode, ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void ChangeAuthenticationMockResponse(string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.Clear();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(httpStatusCode, ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void AddExpectationMockResponse(string uri, string requestContent, string responseContent)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.Expect(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void AddExpectationMockResponse(string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.Expect(_baseUrl + uri)
                .WithContent(requestContent)
                .Respond(httpStatusCode, ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void AddExpectationMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.Expect(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" },
                    { TRAKT_API_AUTHORIZATION_HEADEY_KEY, $"Bearer {TestConstants.MOCK_AUTHORIZATION.AccessToken}" }
                })
                .Respond(httpStatusCode);
        }

        internal void VerifyNoOutstandingExpectations()
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _mockHttpMessageHandler.VerifyNoOutstandingExpectation();
        }

        private static string SortByToString(TraktSortBy sortBy)
            => sortBy switch
            {
                TraktSortBy.Rank => "rank",
                TraktSortBy.Added => "added",
                TraktSortBy.Title => "title",
                TraktSortBy.Released => "released",
                TraktSortBy.Runtime => "runtime",
                TraktSortBy.Popularity => "popularity",
                TraktSortBy.Percentage => "percentage",
                TraktSortBy.Votes => "votes",
                TraktSortBy.MyRating => "my_rating",
                TraktSortBy.Random => "random",
                TraktSortBy.Watched => "watched",
                TraktSortBy.Collected => "collected",
                TraktSortBy.Unspecified => null,
                _ => null
            };

        private static string SortHowToString(TraktSortHow sortHow)
            => sortHow switch
            {
                TraktSortHow.Ascending => "asc",
                TraktSortHow.Descending => "desc",
                TraktSortHow.Unspecified => null,
                _ => null
            };
    }
}
