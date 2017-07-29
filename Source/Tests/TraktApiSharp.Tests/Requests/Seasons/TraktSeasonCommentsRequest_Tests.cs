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
    public class TraktSeasonCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonCommentsRequest_IsNotAbstract()
        {
            typeof(TraktSeasonCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_IsSealed()
        {
            typeof(TraktSeasonCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonCommentsRequest).IsSubclassOf(typeof(ATraktSeasonRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktSeasonCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktSeasonCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_TraktSeasonCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonCommentsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktSeasonCommentsRequest_TestData))]
        public void Test_TraktSeasonCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSeasonCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktSeasonCommentsRequest _request1 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber
            };

            private static readonly TraktSeasonCommentsRequest _request2 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder
            };

            private static readonly TraktSeasonCommentsRequest _request3 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page
            };

            private static readonly TraktSeasonCommentsRequest _request4 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Limit = _limit
            };

            private static readonly TraktSeasonCommentsRequest _request5 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktSeasonCommentsRequest _request6 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktSeasonCommentsRequest _request7 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSeasonCommentsRequest _request8 = new TraktSeasonCommentsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSeasonCommentsRequest_TestData()
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
