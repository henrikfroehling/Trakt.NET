namespace TraktApiSharp.Tests.Requests.Search
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Search;
    using Xunit;

    [Category("Requests.Search")]
    public class SearchTextQueryRequest_Tests
    {
        [Fact]
        public void Test_SearchTextQueryRequest_IsNotAbstract()
        {
            typeof(SearchTextQueryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SearchTextQueryRequest_IsSealed()
        {
            typeof(SearchTextQueryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Inherits_ASearchRequest()
        {
            typeof(SearchTextQueryRequest).IsSubclassOf(typeof(ASearchRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Implements_ISupportsFilter_Interface()
        {
            typeof(SearchTextQueryRequest).GetInterfaces().Should().Contain(typeof(ISupportsFilter));
        }

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
            request.UriTemplate.Should().Be("search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}");
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Has_SearchFields_Property()
        {
            var propertyInfo = typeof(SearchTextQueryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SearchFields")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSearchField));
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Has_Query_Property()
        {
            var propertyInfo = typeof(SearchTextQueryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Query")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Validate_Throws_ArgumentNullException()
        {
            // no result types set
            var request = new SearchTextQueryRequest { Query = "query" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // no query set
            request = new SearchTextQueryRequest { ResultTypes = TraktSearchResultType.Episode };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_SearchTextQueryRequest_Validate_Throws_ArgumentException()
        {
            // result types is unspecified
            var request = new SearchTextQueryRequest { Query = "query", ResultTypes = TraktSearchResultType.Unspecified };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // query is empty
            request = new SearchTextQueryRequest { Query = string.Empty, ResultTypes = TraktSearchResultType.Episode };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
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
            private static readonly TraktSearchFilter _filter = new TraktSearchFilter().WithYears(2005, 2016);
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
