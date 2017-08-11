namespace TraktApiSharp.Tests.Requests.Movies
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
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieCommentsRequest_IsNotAbstract()
        {
            typeof(TraktMovieCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_IsSealed()
        {
            typeof(TraktMovieCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieCommentsRequest).IsSubclassOf(typeof(ATraktMovieRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktMovieCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieCommentsRequest();
            request.UriTemplate.Should().Be("movies/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktMovieCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_TraktMovieCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieCommentsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktMovieCommentsRequest_TestData))]
        public void Test_TraktMovieCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMovieCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMovieCommentsRequest _request1 = new TraktMovieCommentsRequest
            {
                Id = _id
            };

            private static readonly TraktMovieCommentsRequest _request2 = new TraktMovieCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly TraktMovieCommentsRequest _request3 = new TraktMovieCommentsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktMovieCommentsRequest _request4 = new TraktMovieCommentsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktMovieCommentsRequest _request5 = new TraktMovieCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktMovieCommentsRequest _request6 = new TraktMovieCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktMovieCommentsRequest _request7 = new TraktMovieCommentsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMovieCommentsRequest _request8 = new TraktMovieCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMovieCommentsRequest_TestData()
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
