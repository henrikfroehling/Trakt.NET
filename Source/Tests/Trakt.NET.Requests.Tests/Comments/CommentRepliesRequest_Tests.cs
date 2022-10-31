namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments;
    using Xunit;

    [TestCategory("Requests.Comments")]
    public class CommentRepliesRequest_Tests
    {
        [Fact]
        public void Test_CommentRepliesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CommentRepliesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CommentRepliesRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentRepliesRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentRepliesRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentRepliesRequest();
            request.UriTemplate.Should().Be("comments/{id}/replies{?page,limit}");
        }

        [Fact]
        public void Test_CommentRepliesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentRepliesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new CommentRepliesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new CommentRepliesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(CommentRepliesRequest_TestData))]
        public void Test_CommentRepliesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                               IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CommentRepliesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly CommentRepliesRequest _request1 = new CommentRepliesRequest
            {
                Id = _id
            };

            private static readonly CommentRepliesRequest _request2 = new CommentRepliesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly CommentRepliesRequest _request3 = new CommentRepliesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly CommentRepliesRequest _request4 = new CommentRepliesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public CommentRepliesRequest_TestData()
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
