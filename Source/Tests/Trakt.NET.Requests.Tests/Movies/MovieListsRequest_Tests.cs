namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieListsRequest_Tests
    {
        [Fact]
        public void Test_MovieListsRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieListsRequest();
            request.UriTemplate.Should().Be("movies/{id}/lists{/type}{/sort_order}{?extended,page,limit}");
        }

        [Fact]
        public void Test_MovieListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieListsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieListsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieListsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(MovieListsRequest_TestData))]
        public void Test_MovieListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                           IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MovieListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MovieListsRequest _request1 = new MovieListsRequest
            {
                Id = _id
            };

            private static readonly MovieListsRequest _request2 = new MovieListsRequest
            {
                Id = _id,
                Type = _type
            };

            private static readonly MovieListsRequest _request3 = new MovieListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly MovieListsRequest _request4 = new MovieListsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MovieListsRequest _request5 = new MovieListsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly MovieListsRequest _request6 = new MovieListsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request7 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly MovieListsRequest _request8 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MovieListsRequest _request9 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page
            };

            private static readonly MovieListsRequest _request10 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request11 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request12 = new MovieListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MovieListsRequest _request13 = new MovieListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly MovieListsRequest _request14 = new MovieListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request15 = new MovieListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request16 = new MovieListsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MovieListsRequest _request17 = new MovieListsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request18 = new MovieListsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request19 = new MovieListsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request20 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MovieListsRequest _request21 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly MovieListsRequest _request22 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request23 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request24 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MovieListsRequest _request25 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MovieListsRequest _request26 = new MovieListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MovieListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private static void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strSortOrder = _sortOrder.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
