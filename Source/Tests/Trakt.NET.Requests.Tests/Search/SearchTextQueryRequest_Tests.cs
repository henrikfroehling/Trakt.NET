namespace TraktNet.Requests.Tests.Search
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;
    using TraktNet.Requests.Search;
    using Xunit;

    [Category("Requests.Search")]
    public class SearchTextQueryRequest_Tests
    {
        [Fact]
        public void Test_SearchTextQueryRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new SearchTextQueryRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Has_Valid_UriTemplate()
        {
            var request = new SearchTextQueryRequest();
            request.UriTemplate.Should().Be("search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,certifications,networks,status,extended,page,limit}");
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Validate_Throws_ArgumentNullException()
        {
            // no result types set
            var request = new SearchTextQueryRequest { Query = "query" };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // no query set
            request = new SearchTextQueryRequest { ResultTypes = TraktSearchResultType.Episode };

            act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Validate_Throws_ArgumentException()
        {
            // result types is unspecified
            var request = new SearchTextQueryRequest { Query = "query", ResultTypes = TraktSearchResultType.Unspecified };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(SearchTextQueryRequest_TestData))]
        public void Test_SearchTextQueryRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SearchTextQueryRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSearchResultType _resultTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
            private const string _query = "searchQuery";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktSearchFilter _filter = TraktFilterDirectory.SearchFilter.WithYears(2005, 2016).Build();
            private static readonly TraktSearchField _searchFields = TraktSearchField.Description | TraktSearchField.Title;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly SearchTextQueryRequest _request1 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query
            };

            private static readonly SearchTextQueryRequest _request2 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SearchTextQueryRequest _request3 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Filter = _filter
            };

            private static readonly SearchTextQueryRequest _request4 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                SearchFields = _searchFields
            };

            private static readonly SearchTextQueryRequest _request5 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Page = _page
            };

            private static readonly SearchTextQueryRequest _request6 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Limit = _limit
            };

            private static readonly SearchTextQueryRequest _request7 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly SearchTextQueryRequest _request8 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                SearchFields = _searchFields
            };

            private static readonly SearchTextQueryRequest _request9 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                SearchFields = _searchFields,
                Page = _page
            };

            private static readonly SearchTextQueryRequest _request10 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                SearchFields = _searchFields,
                Page = _page,
                Limit = _limit
            };

            private static readonly SearchTextQueryRequest _request11 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Filter = _filter,
                SearchFields = _searchFields
            };

            private static readonly SearchTextQueryRequest _request12 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Filter = _filter,
                SearchFields = _searchFields,
                Page = _page
            };

            private static readonly SearchTextQueryRequest _request13 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Filter = _filter,
                SearchFields = _searchFields,
                Page = _page,
                Limit = _limit
            };

            private static readonly SearchTextQueryRequest _request14 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                SearchFields = _searchFields,
                Page = _page
            };

            private static readonly SearchTextQueryRequest _request15 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                SearchFields = _searchFields,
                Page = _page,
                Limit = _limit
            };

            private static readonly SearchTextQueryRequest _request16 = new SearchTextQueryRequest
            {
                ResultTypes = _resultTypes,
                Query = _query,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SearchTextQueryRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strResultTypes = _resultTypes.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();
                var strSearchFields = _searchFields.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["extended"] = strExtendedInfo,
                        ["fields"] = strSearchFields
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["extended"] = strExtendedInfo,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["extended"] = strExtendedInfo,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["fields"] = strSearchFields,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strResultTypes,
                        ["query"] = _query,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
