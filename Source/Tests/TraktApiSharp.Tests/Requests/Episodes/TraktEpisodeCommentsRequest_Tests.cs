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
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCommentsRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeCommentsRequest_IsSealed()
        {
            typeof(TraktEpisodeCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeCommentsRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeCommentsRequest).IsSubclassOf(typeof(ATraktEpisodeRequest<TraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktEpisodeCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }
        
        [Fact]
        public void Test_TraktEpisodeCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/comments{/sort_order}{?page,limit}");
        }
        
        [Fact]
        public void Test_TraktEpisodeCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktEpisodeCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_TraktEpisodeCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeCommentsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeCommentsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeCommentsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeCommentsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktEpisodeCommentsRequest_TestData))]
        public void Test_TraktEpisodeCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktEpisodeCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private const uint _episodeNumber = 8;
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktEpisodeCommentsRequest _request1 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber
            };

            private static readonly TraktEpisodeCommentsRequest _request2 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder
            };

            private static readonly TraktEpisodeCommentsRequest _request3 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page
            };

            private static readonly TraktEpisodeCommentsRequest _request4 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Limit = _limit
            };

            private static readonly TraktEpisodeCommentsRequest _request5 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktEpisodeCommentsRequest _request6 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktEpisodeCommentsRequest _request7 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktEpisodeCommentsRequest _request8 = new TraktEpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktEpisodeCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strEpisodeNumber = _episodeNumber.ToString();
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
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["episode"] = strEpisodeNumber,
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
