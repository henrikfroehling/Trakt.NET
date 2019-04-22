namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [Category("Requests.Comments")]
    public class ACommentsRequest_Tests
    {
        private sealed class CommentsRequestMock : ACommentsRequest
        {
            public override string UriTemplate => throw new System.NotImplementedException();
        }

        [Fact]
        public void Test_ACommentsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new CommentsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(ACommentsRequest_TestData))]
        public void Test_ACommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ACommentsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktCommentType _commentType = TraktCommentType.Shout;
            private static readonly TraktObjectType _objectType = TraktObjectType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;
            private const bool _includeReplies = true;

            private static readonly CommentsRequestMock _requestMock1 = new CommentsRequestMock
            {
                CommentType = _commentType
            };

            private static readonly CommentsRequestMock _requestMock2 = new CommentsRequestMock
            {
                ObjectType = _objectType
            };

            private static readonly CommentsRequestMock _requestMock3 = new CommentsRequestMock
            {
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsRequestMock _requestMock4 = new CommentsRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock5 = new CommentsRequestMock
            {
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock6 = new CommentsRequestMock
            {
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock7 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ObjectType = _objectType
            };

            private static readonly CommentsRequestMock _requestMock8 = new CommentsRequestMock
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsRequestMock _requestMock9 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock10 = new CommentsRequestMock
            {
                CommentType = _commentType,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock11 = new CommentsRequestMock
            {
                CommentType = _commentType,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock12 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsRequestMock _requestMock13 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock14 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock15 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock16 = new CommentsRequestMock
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock17 = new CommentsRequestMock
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock18 = new CommentsRequestMock
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock19 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock20 = new CommentsRequestMock
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock21 = new CommentsRequestMock
            {
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock22 = new CommentsRequestMock
            {
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsRequestMock _requestMock23 = new CommentsRequestMock
            {
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock24 = new CommentsRequestMock
            {
                ObjectType = _objectType,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock25 = new CommentsRequestMock
            {
                ObjectType = _objectType,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock26 = new CommentsRequestMock
            {
                IncludeReplies = _includeReplies,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsRequestMock _requestMock27 = new CommentsRequestMock
            {
                IncludeReplies = _includeReplies,
                Page = _page
            };

            private static readonly CommentsRequestMock _requestMock28 = new CommentsRequestMock
            {
                IncludeReplies = _includeReplies,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock29 = new CommentsRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock30 = new CommentsRequestMock
            {
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock31 = new CommentsRequestMock
            {
                ObjectType = _objectType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock32 = new CommentsRequestMock
            {
                IncludeReplies = _includeReplies,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsRequestMock _requestMock33 = new CommentsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ACommentsRequest_TestData()
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

                _data.Add(new object[] { _requestMock1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType
                    }});

                _data.Add(new object[] { _requestMock2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _requestMock3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _requestMock4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _requestMock8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _requestMock9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _requestMock13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _requestMock23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _requestMock27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _requestMock28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock32.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _requestMock33.GetUriPathParameters(), new Dictionary<string, object>
                    {
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
