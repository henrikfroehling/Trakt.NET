namespace TraktNet.Requests.Tests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Episodes;
    using Xunit;

    [Category("Requests.Episodes")]
    public class EpisodeListsRequest_Tests
    {
        [Fact]
        public void Test_EpisodeListsRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeListsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/lists{/type}{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_EpisodeListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeListsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new EpisodeListsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new EpisodeListsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // episode number == 0
            request = new EpisodeListsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(EpisodeListsRequest_TestData))]
        public void Test_EpisodeListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class EpisodeListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private const uint _episodeNumber = 8;
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly EpisodeListsRequest _request1 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber
            };

            private static readonly EpisodeListsRequest _request2 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type
            };

            private static readonly EpisodeListsRequest _request3 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder
            };

            private static readonly EpisodeListsRequest _request4 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page
            };

            private static readonly EpisodeListsRequest _request5 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request6 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly EpisodeListsRequest _request7 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Page = _page
            };

            private static readonly EpisodeListsRequest _request8 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request9 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request10 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly EpisodeListsRequest _request11 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request12 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request13 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request14 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly EpisodeListsRequest _request15 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly EpisodeListsRequest _request16 = new EpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public EpisodeListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strEpisodeNumber = _episodeNumber.ToString();
                var strType = _type.UriName;
                var strSortOrder = _sortOrder.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
