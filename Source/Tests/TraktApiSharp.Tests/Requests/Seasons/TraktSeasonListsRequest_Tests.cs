namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonListsRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonListsRequest_IsNotAbstract()
        {
            typeof(TraktSeasonListsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_IsSealed()
        {
            typeof(TraktSeasonListsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonListsRequest).IsSubclassOf(typeof(ATraktSeasonRequest<TraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktSeasonListsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonListsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/lists{/type}{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktSeasonListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListType));
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktSeasonListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListSortOrder));
        }

        [Fact]
        public void Test_TraktSeasonListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonListsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonListsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonListsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktSeasonListsRequest_TestData))]
        public void Test_TraktSeasonListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSeasonListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktSeasonListsRequest _request1 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber
            };

            private static readonly TraktSeasonListsRequest _request2 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type
            };

            private static readonly TraktSeasonListsRequest _request3 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder
            };

            private static readonly TraktSeasonListsRequest _request4 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page
            };

            private static readonly TraktSeasonListsRequest _request5 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request6 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly TraktSeasonListsRequest _request7 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Page = _page
            };

            private static readonly TraktSeasonListsRequest _request8 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request9 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request10 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktSeasonListsRequest _request11 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request12 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request13 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request14 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktSeasonListsRequest _request15 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktSeasonListsRequest _request16 = new TraktSeasonListsRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSeasonListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strType = _type.UriName;
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
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
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
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
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
