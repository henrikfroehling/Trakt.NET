namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobbleStopRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestIsNotAbstract()
        {
            typeof(TraktScrobbleStopRequest<,>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestIsSealed()
        {
            typeof(TraktScrobbleStopRequest<,>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestHasGenericTypeParameter()
        {
            typeof(TraktScrobbleStopRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobbleStopRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(TraktScrobbleStopRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPostRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestHasValidUriTemplate()
        {
            var request = new TraktScrobbleStopRequest<int, float>(null);
            request.UriTemplate.Should().Be("scrobble/stop");
        }
    }
}
