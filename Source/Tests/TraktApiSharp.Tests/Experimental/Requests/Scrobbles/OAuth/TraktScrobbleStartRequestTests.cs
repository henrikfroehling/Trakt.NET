namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobbleStartRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestIsNotAbstract()
        {
            typeof(TraktScrobbleStartRequest<,>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestIsSealed()
        {
            typeof(TraktScrobbleStartRequest<,>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestHasGenericTypeParameter()
        {
            typeof(TraktScrobbleStartRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobbleStartRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(TraktScrobbleStartRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPostRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestHasValidUriTemplate()
        {
            var request = new TraktScrobbleStartRequest<int, float>(null);
            request.UriTemplate.Should().Be("scrobble/start");
        }
    }
}
