namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCommentsRequest_Tests
    {
        [Fact]
        public void Test_UserCommentsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/comments{/comment_type}{/object_type}{?include_replies,extended,page,limit}");
        }

        [Fact]
        public void Test_UserCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserCommentsRequest();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            requestMock = new UserCommentsRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            requestMock = new UserCommentsRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(UserCommentsRequest_TestData))]
        public void Test_UserCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktCommentType _commentType = TraktCommentType.Shout;
            private static readonly TraktObjectType _objectType = TraktObjectType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;
            private const TraktIncludeReplies _includeReplies = TraktIncludeReplies.Only;

            private static readonly UserCommentsRequest _request1 = new UserCommentsRequest
            {
                Username = _username
            };

            private static readonly UserCommentsRequest _request2 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType
            };

            private static readonly UserCommentsRequest _request3 = new UserCommentsRequest
            {
                Username = _username,
                ObjectType = _objectType
            };

            private static readonly UserCommentsRequest _request4 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserCommentsRequest _request5 = new UserCommentsRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserCommentsRequest _request6 = new UserCommentsRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request7 = new UserCommentsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request8 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType
            };

            private static readonly UserCommentsRequest _request9 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserCommentsRequest _request10 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page
            };

            private static readonly UserCommentsRequest _request11 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request12 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request13 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserCommentsRequest _request14 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request15 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request16 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCommentsRequest _request17 = new UserCommentsRequest
            {
                Username = _username,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request18 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request19 = new UserCommentsRequest
            {
                Username = _username,
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request20 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request21 = new UserCommentsRequest
            {
                Username = _username,
                Page = _page,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request22 = new UserCommentsRequest
            {
                Username = _username,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request23 = new UserCommentsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request24 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request25 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request26 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request27 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request28 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request29 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request30 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request31 = new UserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly UserCommentsRequest _request32 = new UserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit,
                IncludeReplies = _includeReplies
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strCommentType = _commentType.UriName;
                var strObjectType = _objectType.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();
                var strIncludeReplies = _includeReplies.ToString().ToLower();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request32.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit,
                        ["include_replies"] = strIncludeReplies
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
