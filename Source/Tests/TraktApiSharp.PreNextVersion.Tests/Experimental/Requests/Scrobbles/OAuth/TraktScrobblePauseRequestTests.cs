namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobblePauseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestIsNotAbstract()
        {
            typeof(TraktScrobblePauseRequest<,>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestIsSealed()
        {
            typeof(TraktScrobblePauseRequest<,>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestHasGenericTypeParameter()
        {
            typeof(TraktScrobblePauseRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobblePauseRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(TraktScrobblePauseRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPostRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestHasValidUriTemplate()
        {
            var request = new TraktScrobblePauseRequest<int, float>(null);
            request.UriTemplate.Should().Be("scrobble/pause");
        }
    }
}
