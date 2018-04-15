namespace TraktApiSharp.Tests.Modules.TraktSearchModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Search")]
    public partial class TraktSearchModule_ests
    {
        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypes()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithField()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithField()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithMutlipleFields()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithMutlipleFields()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilter()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Show;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilter()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndField()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Show;
            const string query = "batman";
            var field = TraktSearchField.Tagline;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndField()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Tagline;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndMultipleFields()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Show;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndMultipleFields()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOption()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Episode;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOption()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndField()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Episode;
            const string query = "batman";
            var field = TraktSearchField.Overview;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndField()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Overview;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndMutlipleFields()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Episode;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndMutlipleFields()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Person;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Person;
            const string query = "batman";
            var field = TraktSearchField.Translations;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Translations;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndPageAndMutlipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Person;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPageAndMutlipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.List;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.List;
            const string query = "batman";
            var field = TraktSearchField.Aliases;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Aliases;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndExtendedOptionAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.List;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.People;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.People;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPageAndMutlipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPageAndMutlipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Biography;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Biography;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Name;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Name;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithFilterAndPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfo()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&extended={extendedInfo}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfo()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&extended={extendedInfo}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndField()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Description;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndField()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Description;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndMultipleFields()
        {
            const int itemCount = 5;
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndMultipleFields()
        {
            const int itemCount = 5;
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPageAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&page={page}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithExtendedInfoAndPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPage()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPageAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPageAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPageAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&page={page}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithLimit()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithLimitAndField()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&page={page}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPageAndLimit()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&page={page}&limit={limit}",
                                                                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPageAndLimitAndField()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsWithPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesWithPageAndLimitAndMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
                                                                                        null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsComplete()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var field = TraktSearchField.Title;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesComplete()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var field = TraktSearchField.Title;

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsCompleteWithMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsMultipleTypesCompleteWithMultipleFields()
        {
            const int itemCount = 5;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);
            const string query = "batman";
            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithStartYear(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
                                                                                        extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsExceptions()
        {
            var type = TraktSearchResultType.Movie;
            const string query = "batman";
            var uri = $"search/{type.UriName}?query={query}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResultsArgumentExceptions()
        {
            var type = TraktSearchResultType.Movie;
            const string query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}", SEARCH_TEXT_QUERY_RESULTS_JSON);

            var searchResultType = default(TraktSearchResultType);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(searchResultType, null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(TraktSearchResultType.Unspecified, query);
            act.Should().Throw<ArgumentException>();
        }
    }
}
