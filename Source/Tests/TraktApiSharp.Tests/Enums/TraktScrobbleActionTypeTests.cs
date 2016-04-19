namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktScrobbleActionTypeTests
    {
        [TestMethod]
        public void TestTraktScrobbleActionTypeHasMembers()
        {
            typeof(TraktScrobbleActionType).GetEnumNames().Should().HaveCount(4)
                                                          .And.Contain("Unspecified", "Start", "Pause", "Stop");
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeGetAsString()
        {
            TraktScrobbleActionType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktScrobbleActionType.Start.AsString().Should().Be("start");
            TraktScrobbleActionType.Pause.AsString().Should().Be("pause");
            TraktScrobbleActionType.Stop.AsString().Should().Be("stop");
        }
    }
}
