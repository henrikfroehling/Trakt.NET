namespace TraktApiSharp.Tests.Requests.Shows
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
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowListsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowListsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowListsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowListsRequest_Is_Sealed()
        {
            typeof(TraktShowListsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowListsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowListsRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowListsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktShowListsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktShowListsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowListsRequest();
            request.UriTemplate.Should().Be("shows/{id}/lists{/type}{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktShowListsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktShowListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListType));
        }

        [Fact]
        public void Test_TraktShowListsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktShowListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListSortOrder));
        }

        [Fact]
        public void Test_TraktShowListsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowListsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowListsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowListsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktShowListsRequest_TestData))]
        public void Test_TraktShowListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                               IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowListsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktListType _type = TraktListType.Official;
            private static readonly TraktListSortOrder _sortOrder = TraktListSortOrder.Comments;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowListsRequest _request1 = new TraktShowListsRequest
            {
                Id = _id
            };

            private static readonly TraktShowListsRequest _request2 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type
            };

            private static readonly TraktShowListsRequest _request3 = new TraktShowListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly TraktShowListsRequest _request4 = new TraktShowListsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktShowListsRequest _request5 = new TraktShowListsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request6 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder
            };

            private static readonly TraktShowListsRequest _request7 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page
            };

            private static readonly TraktShowListsRequest _request8 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request9 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request10 = new TraktShowListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktShowListsRequest _request11 = new TraktShowListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request12 = new TraktShowListsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request13 = new TraktShowListsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request14 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktShowListsRequest _request15 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktShowListsRequest _request16 = new TraktShowListsRequest
            {
                Id = _id,
                Type = _type,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strSortOrder = _sortOrder.UriName;
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
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
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
