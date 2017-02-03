namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowCommentsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Is_Sealed()
        {
            typeof(TraktShowCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowCommentsRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktShowCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Has_SortOrder_Property()
        {
            var sortingPropertyInfo = typeof(TraktShowCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_TraktShowCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowCommentsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktShowCommentsRequest_TestData))]
        public void Test_TraktShowCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                  IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowCommentsRequest _request1 = new TraktShowCommentsRequest
            {
                Id = _id
            };

            private static readonly TraktShowCommentsRequest _request2 = new TraktShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly TraktShowCommentsRequest _request3 = new TraktShowCommentsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktShowCommentsRequest _request4 = new TraktShowCommentsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktShowCommentsRequest _request5 = new TraktShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktShowCommentsRequest _request6 = new TraktShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktShowCommentsRequest _request7 = new TraktShowCommentsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowCommentsRequest _request8 = new TraktShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
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
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
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
