namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktScrobbleActionType_Tests
    {
        [Fact]
        public void Test_TraktScrobbleActionType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktScrobbleActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktScrobbleActionType>() { TraktScrobbleActionType.Unspecified, TraktScrobbleActionType.Start,
                                                                             TraktScrobbleActionType.Pause, TraktScrobbleActionType.Stop });
        }
    }
}
