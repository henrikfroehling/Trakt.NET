namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowWatchedProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsNotAbstract()
        {
            typeof(TraktShowWatchedProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsSealed()
        {
            typeof(TraktShowWatchedProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsSubclassOfATraktShowProgressRequest()
        {
            typeof(TraktShowWatchedProgressRequest).IsSubclassOf(typeof(ATraktShowProgressRequest<TraktShowWatchedProgress>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestHasAuthorizationRequired()
        {
            var request = new TraktShowWatchedProgressRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestHasValidUriTemplate()
        {
            var request = new TraktShowWatchedProgressRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/progress/watched{?hidden,specials,count_specials}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestUriParamsWithoutHiddenAndSpecialsAndCountSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestUriParamsWithHidden()
        {
            var request = new TraktShowWatchedProgressRequest(null)
            {
                Hidden = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("hidden", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestUriParamsWithHiddenAndSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
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
        public void TestTraktShowWatchedProgressRequestUriParamsWithHiddenAndCountSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
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
        public void TestTraktShowWatchedProgressRequestUriParamsWithSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
            {
                Specials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("specials", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestUriParamsWithSpecialsAndCountSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
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
        public void TestTraktShowWatchedProgressRequestUriParamsWithCountSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
            {
                CountSpecials = true
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("count_specials", "true");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestUriParamsWithHiddenAndSpecialsAndCountSpecials()
        {
            var request = new TraktShowWatchedProgressRequest(null)
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
