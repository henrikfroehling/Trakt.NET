namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [TestCategory("Requests.Seasons")]
    public class SeasonListsRequest_Tests
    {
        [Fact]
        public void Test_SeasonListsRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonListsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/lists{/type}{/sort_order}{?extended,page,limit}");
        }

        [Fact]
        public void Test_SeasonListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonListsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new SeasonListsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new SeasonListsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(SeasonListsRequest_TestData))]
        public void Test_SeasonListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                            IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SeasonListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly SeasonListsRequest _request1 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber
            };

            private static readonly SeasonListsRequest _request2 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type
            };

            private static readonly SeasonListsRequest _request3 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder
            };

            private static readonly SeasonListsRequest _request4 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonListsRequest _request5 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page
            };

            private static readonly SeasonListsRequest _request6 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request7 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly SeasonListsRequest _request8 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonListsRequest _request9 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Page = _page
            };

            private static readonly SeasonListsRequest _request10 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request11 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request12 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonListsRequest _request13 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly SeasonListsRequest _request14 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request15 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request16 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SeasonListsRequest _request17 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request18 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request19 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request20 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonListsRequest _request21 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly SeasonListsRequest _request22 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request23 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request24 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SeasonListsRequest _request25 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SeasonListsRequest _request26 = new SeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SeasonListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private static void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strType = _type.UriName;
                var strSortOrder = _sortOrder.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
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
