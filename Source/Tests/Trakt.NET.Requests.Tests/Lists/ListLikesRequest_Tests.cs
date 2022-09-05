namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
    public class ListLikesRequest_Tests
    {
        [Fact]
        public void Test_ListLikesRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new ListLikesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ListLikesRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListLikesRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_ListLikesRequest_Has_Valid_UriTemplate()
        {
            var request = new ListLikesRequest();
            request.UriTemplate.Should().Be("lists/{id}/likes{?page,limit}");
        }

        [Fact]
        public void Test_ListLikesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ListLikesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ListLikesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ListLikesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(ListLikesRequest_TestData))]
        public void Test_ListLikesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ListLikesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly ListLikesRequest _request1 = new ListLikesRequest
            {
                Id = _id
            };

            private static readonly ListLikesRequest _request2 = new ListLikesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly ListLikesRequest _request3 = new ListLikesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly ListLikesRequest _request4 = new ListLikesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ListLikesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
