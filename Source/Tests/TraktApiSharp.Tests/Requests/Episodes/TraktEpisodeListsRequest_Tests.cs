namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeListsRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeListsRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeListsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_IsSealed()
        {
            typeof(TraktEpisodeListsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeListsRequest).IsSubclassOf(typeof(ATraktEpisodeRequest<TraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktEpisodeListsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeListsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/lists{/type}{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktEpisodeListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListType));
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktEpisodeListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListSortOrder));
        }

        [Fact]
        public void Test_TraktEpisodeListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeListsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeListsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeListsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeListsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktEpisodeListsRequest_TestData))]
        public void Test_TraktEpisodeListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                  IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktEpisodeListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private const uint _episodeNumber = 8;
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktEpisodeListsRequest _request1 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber
            };

            private static readonly TraktEpisodeListsRequest _request2 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type
            };

            private static readonly TraktEpisodeListsRequest _request3 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder
            };

            private static readonly TraktEpisodeListsRequest _request4 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page
            };

            private static readonly TraktEpisodeListsRequest _request5 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request6 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly TraktEpisodeListsRequest _request7 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Page = _page
            };

            private static readonly TraktEpisodeListsRequest _request8 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request9 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request10 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktEpisodeListsRequest _request11 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request12 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request13 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request14 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktEpisodeListsRequest _request15 = new TraktEpisodeListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktEpisodeListsRequest _request16 = new TraktEpisodeListsRequest
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

            public TraktEpisodeListsRequest_TestData()
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
