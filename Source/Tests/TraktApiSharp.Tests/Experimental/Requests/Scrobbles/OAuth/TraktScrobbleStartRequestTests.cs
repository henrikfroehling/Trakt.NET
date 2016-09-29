namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobbleStartRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Start")]
        public void TestTraktScrobbleStartRequestIsNotAbstract()
        {
            typeof(TraktScrobbleStartRequest).IsAbstract.Should().BeFalse();
        }
    }
}
