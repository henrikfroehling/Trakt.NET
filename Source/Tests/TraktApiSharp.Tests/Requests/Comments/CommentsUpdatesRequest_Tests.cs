namespace TraktApiSharp.Tests.Requests.Comments
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Comments")]
    public class CommentsUpdatesRequest_Tests
    {
        [Fact]
        public void Test_CommentsUpdatesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CommentsUpdatesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CommentsUpdatesRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentsUpdatesRequest();
            request.UriTemplate.Should().Be("comments/updates{/comment_type}{/object_type}{?include_replies,extended,page,limit}");
        }

        [Theory, ClassData(typeof(CommentsUpdatesRequest_TestData))]
        public void Test_CommentsUpdatesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CommentsUpdatesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktCommentType _commentType = TraktCommentType.Shout;
            private static readonly TraktObjectType _objectType = TraktObjectType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;
            private const bool _includeReplies = true;

            private static readonly CommentsUpdatesRequest _request1 = new CommentsUpdatesRequest
            {
                CommentType = _commentType
            };

            private static readonly CommentsUpdatesRequest _request2 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType
            };

            private static readonly CommentsUpdatesRequest _request3 = new CommentsUpdatesRequest
            {
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsUpdatesRequest _request4 = new CommentsUpdatesRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request5 = new CommentsUpdatesRequest
            {
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request6 = new CommentsUpdatesRequest
            {
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request7 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ObjectType = _objectType
            };

            private static readonly CommentsUpdatesRequest _request8 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsUpdatesRequest _request9 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request10 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request11 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request12 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsUpdatesRequest _request13 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request14 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request15 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ObjectType = _objectType,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request16 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request17 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request18 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                IncludeReplies = _includeReplies,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request19 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request20 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request21 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request22 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType,
                IncludeReplies = _includeReplies
            };

            private static readonly CommentsUpdatesRequest _request23 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request24 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request25 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request26 = new CommentsUpdatesRequest
            {
                IncludeReplies = _includeReplies,
                ExtendedInfo = _extendedInfo
            };

            private static readonly CommentsUpdatesRequest _request27 = new CommentsUpdatesRequest
            {
                IncludeReplies = _includeReplies,
                Page = _page
            };

            private static readonly CommentsUpdatesRequest _request28 = new CommentsUpdatesRequest
            {
                IncludeReplies = _includeReplies,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request29 = new CommentsUpdatesRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request30 = new CommentsUpdatesRequest
            {
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request31 = new CommentsUpdatesRequest
            {
                ObjectType = _objectType,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request32 = new CommentsUpdatesRequest
            {
                IncludeReplies = _includeReplies,
                Page = _page,
                Limit = _limit
            };

            private static readonly CommentsUpdatesRequest _request33 = new CommentsUpdatesRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public CommentsUpdatesRequest_TestData()
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
                        ["comment_type"] = strCommentType
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["object_type"] = strObjectType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["include_replies"] = strIncludeReplies,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["include_replies"] = strIncludeReplies
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["comment_type"] = strCommentType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["object_type"] = strObjectType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request32.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["include_replies"] = strIncludeReplies,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request33.GetUriPathParameters(), new Dictionary<string, object>
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
