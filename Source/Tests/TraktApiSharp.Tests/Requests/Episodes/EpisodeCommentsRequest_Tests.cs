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
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Episodes")]
    public class EpisodeCommentsRequest_Tests
    {
        [Fact]
        public void Test_EpisodeCommentsRequest_IsNotAbstract()
        {
            typeof(EpisodeCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_EpisodeCommentsRequest_IsSealed()
        {
            typeof(EpisodeCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeCommentsRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(EpisodeCommentsRequest).IsSubclassOf(typeof(AEpisodeRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(EpisodeCommentsRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }
        
        [Fact]
        public void Test_EpisodeCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/comments{/sort_order}{?page,limit}");
        }
        
        [Fact]
        public void Test_EpisodeCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(EpisodeCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_EpisodeCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeCommentsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new EpisodeCommentsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new EpisodeCommentsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new EpisodeCommentsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(EpisodeCommentsRequest_TestData))]
        public void Test_EpisodeCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class EpisodeCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private const uint _episodeNumber = 8;
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly EpisodeCommentsRequest _request1 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber
            };

            private static readonly EpisodeCommentsRequest _request2 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder
            };

            private static readonly EpisodeCommentsRequest _request3 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page
            };

            private static readonly EpisodeCommentsRequest _request4 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Limit = _limit
            };

            private static readonly EpisodeCommentsRequest _request5 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly EpisodeCommentsRequest _request6 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly EpisodeCommentsRequest _request7 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly EpisodeCommentsRequest _request8 = new EpisodeCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                EpisodeNumber = _episodeNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public EpisodeCommentsRequest_TestData()
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
