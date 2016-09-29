namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobblePauseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Pause")]
        public void TestTraktScrobblePauseRequestIsNotAbstract()
        {
            typeof(TraktScrobblePauseRequest).IsAbstract.Should().BeFalse();
        }
    }
}
