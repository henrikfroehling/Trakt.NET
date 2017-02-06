namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestIsNotAbstract()
        {
            typeof(TraktUserCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestIsSealed()
        {
            typeof(TraktUserCommentsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestIsSubclassOfATraktUsersPaginationGetRequest()
        {
            typeof(TraktUserCommentsRequest).IsSubclassOf(typeof(ATraktUsersPaginationGetRequest<TraktUserComment>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserCommentsRequest(null);
            //request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasValidUriTemplate()
        {
            var request = new TraktUserCommentsRequest(null);
            request.UriTemplate.Should().Be("users/{username}/comments{/comment_type}{/object_type}{?extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasCommentTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "CommentType")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktCommentType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasCommentObjectTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ObjectType")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktObjectType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserCommentsRequest).GetMethods()
                                                             .Where(m => m.Name == "GetUriPathParameters")
                                                             .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsernameAndCommentType()
        {
            var username = "username";
            var commentType = TraktCommentType.Review;

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username,
                CommentType = commentType
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["comment_type"] = commentType.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsernameAndUnspecifiedCommentType()
        {
            var username = "username";
            var commentType = TraktCommentType.Unspecified;

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username,
                CommentType = commentType
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsernameAndObjectType()
        {
            var username = "username";
            var objectType = TraktObjectType.Season;

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username,
                ObjectType = objectType
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["object_type"] = objectType.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsernameAndUnspecifiedObjectType()
        {
            var username = "username";
            var objectType = TraktObjectType.Unspecified;

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username,
                ObjectType = objectType
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCommentsRequestUriParamsWithUsernameAndCommentTypeAndObjectType()
        {
            var username = "username";
            var commentType = TraktCommentType.Review;
            var objectType = TraktObjectType.Season;

            var request = new TraktUserCommentsRequest(null)
            {
                Username = username,
                CommentType = commentType,
                ObjectType = objectType
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["comment_type"] = commentType.UriName,
                ["object_type"] = objectType.UriName
            });
        }
    }
}
