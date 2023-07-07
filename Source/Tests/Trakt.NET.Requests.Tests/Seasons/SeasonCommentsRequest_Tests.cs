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
    public class SeasonCommentsRequest_Tests
    {
        [Fact]
        public void Test_SeasonCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/comments{/sort_order}{?extended,page,limit}");
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonCommentsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new SeasonCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new SeasonCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(SeasonCommentsRequest_TestData))]
        public void Test_SeasonCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                               IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SeasonCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private static readonly TraktShowsCommentSortOrder _sortOrder = TraktShowsCommentSortOrder.Newest;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly SeasonCommentsRequest _request1 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber
            };

            private static readonly SeasonCommentsRequest _request2 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder
            };

            private static readonly SeasonCommentsRequest _request3 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonCommentsRequest _request4 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page
            };

            private static readonly SeasonCommentsRequest _request5 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request6 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonCommentsRequest _request7 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly SeasonCommentsRequest _request8 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request9 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SeasonCommentsRequest _request10 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request11 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request12 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request13 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request14 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SeasonCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private static void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
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
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
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
