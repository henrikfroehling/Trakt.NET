namespace TraktApiSharp.Tests.Requests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Comments")]
    public class TraktCommentRepliesRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentRepliesRequest_IsNotAbstract()
        {
            typeof(TraktCommentRepliesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_IsSealed()
        {
            typeof(TraktCommentRepliesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktCommentRepliesRequest).IsSubclassOf(typeof(ATraktGetRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentRepliesRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktCommentRepliesRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktCommentRepliesRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentRepliesRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentRepliesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentRepliesRequest();
            request.UriTemplate.Should().Be("comments/{id}/replies{?page,limit}");
        }
        
        [Fact]
        public void Test_TraktCommentRepliesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktCommentRepliesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentRepliesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentRepliesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktCommentRepliesRequest_TestData))]
        public void Test_TraktCommentRepliesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktCommentRepliesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktCommentRepliesRequest _request1 = new TraktCommentRepliesRequest
            {
                Id = _id
            };

            private static readonly TraktCommentRepliesRequest _request2 = new TraktCommentRepliesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktCommentRepliesRequest _request3 = new TraktCommentRepliesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktCommentRepliesRequest _request4 = new TraktCommentRepliesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktCommentRepliesRequest_TestData()
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
