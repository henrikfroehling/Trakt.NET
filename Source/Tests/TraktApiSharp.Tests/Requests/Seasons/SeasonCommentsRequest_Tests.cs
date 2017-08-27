namespace TraktApiSharp.Tests.Requests.Seasons
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
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class SeasonCommentsRequest_Tests
    {
        [Fact]
        public void Test_SeasonCommentsRequest_IsNotAbstract()
        {
            typeof(SeasonCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SeasonCommentsRequest_IsSealed()
        {
            typeof(SeasonCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Inherits_ASeasonRequest_1()
        {
            typeof(SeasonCommentsRequest).IsSubclassOf(typeof(ASeasonRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Implements_ISupportsPagination_Interface()
        {
            typeof(SeasonCommentsRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(SeasonCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_SeasonCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonCommentsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new SeasonCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new SeasonCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
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
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
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
                Page = _page
            };

            private static readonly SeasonCommentsRequest _request4 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request5 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly SeasonCommentsRequest _request6 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request7 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly SeasonCommentsRequest _request8 = new SeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SeasonCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strSortOrder = _sortOrder.UriName;
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
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
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
