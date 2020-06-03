namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaAudioChannel_Tests
    {
        [Fact]
        public void Test_TraktMediaAudioChannel_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaAudioChannel>();

            allValues.Should().NotBeNull().And.HaveCount(12);
            allValues.Should().Contain(new List<TraktMediaAudioChannel>() { TraktMediaAudioChannel.Unspecified, TraktMediaAudioChannel.Channels_1_0,
                                                                            TraktMediaAudioChannel.Channels_2_0, TraktMediaAudioChannel.Channels_2_1,
                                                                            TraktMediaAudioChannel.Channels_3_0, TraktMediaAudioChannel.Channels_3_1,
                                                                            TraktMediaAudioChannel.Channels_4_0, TraktMediaAudioChannel.Channels_4_1,
                                                                            TraktMediaAudioChannel.Channels_5_0, TraktMediaAudioChannel.Channels_5_1,
                                                                            TraktMediaAudioChannel.Channels_6_1, TraktMediaAudioChannel.Channels_7_1 });
        }
    }
}
