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
    public class TraktUserHiddenItemsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestIsNotAbstract()
        {
            typeof(TraktUserHiddenItemsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestIsSealed()
        {
            typeof(TraktUserHiddenItemsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestIsSubclassOfATraktUsersPaginationGetRequest()
        {
            typeof(TraktUserHiddenItemsRequest).IsSubclassOf(typeof(ATraktUsersPaginationGetRequest<TraktUserHiddenItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestHasAuthorizationRequired()
        {
            var request = new TraktUserHiddenItemsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestHasValidUriTemplate()
        {
            var request = new TraktUserHiddenItemsRequest(null);
            request.UriTemplate.Should().Be("users/hidden/{section}{?type,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestHasSectionProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserHiddenItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Section")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktHiddenItemsSection));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserHiddenItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktHiddenItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserHiddenItemsRequest).GetMethods()
                                                                .Where(m => m.Name == "GetUriPathParameters")
                                                                .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestUriParamsWithSection()
        {
            var section = TraktHiddenItemsSection.Calendar;

            var request = new TraktUserHiddenItemsRequest(null)
            {
                Section = section
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("section", section.UriName);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestUriParamsWithSectionAndType()
        {
            var section = TraktHiddenItemsSection.Calendar;
            var type = TraktHiddenItemType.Movie;

            var request = new TraktUserHiddenItemsRequest(null)
            {
                Section = section,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["section"] = section.UriName,
                ["type"] = type.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserHiddenItemsRequestUriParamsWithSectionAndUnspecifiedType()
        {
            var section = TraktHiddenItemsSection.Calendar;
            var type = TraktHiddenItemType.Unspecified;

            var request = new TraktUserHiddenItemsRequest(null)
            {
                Section = section,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("section", section.UriName);
        }
    }
}
