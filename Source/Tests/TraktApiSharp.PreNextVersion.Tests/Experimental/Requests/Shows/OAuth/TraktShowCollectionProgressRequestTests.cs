namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowCollectionProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsNotAbstract()
        {
            typeof(TraktShowCollectionProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsSealed()
        {
            typeof(TraktShowCollectionProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsSubclassOfATraktShowProgressRequest()
        {
            typeof(TraktShowCollectionProgressRequest).IsSubclassOf(typeof(ATraktShowProgressRequest<TraktShowCollectionProgress>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestHasAuthorizationRequired()
        {
            var request = new TraktShowCollectionProgressRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestHasValidUriTemplate()
        {
            var request = new TraktShowCollectionProgressRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/progress/collection{?hidden,specials,count_specials}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithoutHiddenAndSpecialsAndCountSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithHidden()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Hidden = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("hidden", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithHiddenAndSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Hidden = true,
                Specials = false
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["hidden"] = "true",
                ["specials"] = "false"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithHiddenAndCountSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Hidden = true,
                CountSpecials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["hidden"] = "true",
                ["count_specials"] = "true"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Specials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("specials", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithSpecialsAndCountSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Specials = true,
                CountSpecials = false
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["specials"] = "true",
                ["count_specials"] = "false"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithCountSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                CountSpecials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("count_specials", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestUriParamsWithHiddenAndSpecialsAndCountSpecials()
        {
            var request = new TraktShowCollectionProgressRequest(null)
            {
                Hidden = true,
                Specials = false,
                CountSpecials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["hidden"] = "true",
                ["specials"] = "false",
                ["count_specials"] = "true"
            });
        }
    }
}
