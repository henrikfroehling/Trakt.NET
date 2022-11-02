namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [TestCategory("Requests.Comments")]
    public class CommentLikesRequest_Tests
    {
        [Fact]
        public void Test_CommentLikesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CommentLikesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CommentLikesRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentLikesRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentLikesRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentLikesRequest();
            request.UriTemplate.Should().Be("comments/{id}/likes{?extended,page,limit}");
        }

        [Fact]
        public void Test_CommentLikesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentLikesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new CommentLikesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new CommentLikesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(CommentLikesRequest_TestData))]
        public void Test_CommentLikesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CommentLikesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly CommentLikesRequest _request1 = new CommentLikesRequest
            {
                Id = _id
            };

            private static readonly CommentLikesRequest _request2 = new CommentLikesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly CommentLikesRequest _request3 = new CommentLikesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly CommentLikesRequest _request4 = new CommentLikesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentLikesRequest _request5 = new CommentLikesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentLikesRequest _request6 = new CommentLikesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly CommentLikesRequest _request7 = new CommentLikesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly CommentLikesRequest _request8 = new CommentLikesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public CommentLikesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
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

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
