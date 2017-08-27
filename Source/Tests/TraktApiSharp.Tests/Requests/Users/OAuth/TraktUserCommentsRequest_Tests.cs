namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCommentsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Is_Sealed()
        {
            typeof(TraktUserCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Inherits_ATraktUsersPagedGetRequest_1()
        {
            typeof(TraktUserCommentsRequest).IsSubclassOf(typeof(AUsersPagedGetRequest<ITraktUserComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Has_CommentType_Property()
        {
            var propertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "CommentType")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentType));
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Has_ObjectType_Property()
        {
            var propertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ObjectType")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktObjectType));
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/comments{/comment_type}{/object_type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktUserCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new TraktUserCommentsRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new TraktUserCommentsRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new TraktUserCommentsRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserCommentsRequest_TestData))]
        public void Test_TraktUserCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                  IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktCommentType _commentType = TraktCommentType.Shout;
            private static readonly TraktObjectType _objectType = TraktObjectType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserCommentsRequest _request1 = new TraktUserCommentsRequest
            {
                Username = _username
            };

            private static readonly TraktUserCommentsRequest _request2 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType
            };

            private static readonly TraktUserCommentsRequest _request3 = new TraktUserCommentsRequest
            {
                Username = _username,
                ObjectType = _objectType
            };

            private static readonly TraktUserCommentsRequest _request4 = new TraktUserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserCommentsRequest _request5 = new TraktUserCommentsRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly TraktUserCommentsRequest _request6 = new TraktUserCommentsRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request7 = new TraktUserCommentsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request8 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType
            };

            private static readonly TraktUserCommentsRequest _request9 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserCommentsRequest _request10 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page
            };

            private static readonly TraktUserCommentsRequest _request11 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request12 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request13 = new TraktUserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUserCommentsRequest _request14 = new TraktUserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request15 = new TraktUserCommentsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCommentsRequest _request16 = new TraktUserCommentsRequest
            {
                Username = _username,
                CommentType = _commentType,
                ObjectType = _objectType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserCommentsRequest_TestData()
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
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
