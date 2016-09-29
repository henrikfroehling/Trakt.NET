namespace TraktApiSharp.Tests.Experimental.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;

    [TestClass]
    public class TraktScrobbleStopRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestIsNotAbstract()
        {
            typeof(TraktScrobbleStopRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Scrobbles"), TestCategory("With OAuth"), TestCategory("Stop")]
        public void TestTraktScrobbleStopRequestIsSealed()
        {
            typeof(TraktScrobbleStopRequest).IsSealed.Should().BeTrue();
        }
    }
}
