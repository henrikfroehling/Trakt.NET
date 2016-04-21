namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaAudioChannelTests
    {
        [TestMethod]
        public void TestTraktMediaAudioChannelHasMembers()
        {
            typeof(TraktMediaAudioChannel).GetEnumNames().Should().HaveCount(12)
                                                         .And.Contain("Unspecified", "Channels_1_0", "Channels_2_0", "Channels_2_1", "Channels_3_0", "Channels_3_1",
                                                                      "Channels_4_0", "Channels_4_1", "Channels_5_0", "Channels_5_1", "Channels_6_1", "Channels_7_1");
        }

        [TestMethod]
        public void TestTraktMediaAudioChannelGetAsString()
        {
            TraktMediaAudioChannel.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaAudioChannel.Channels_1_0.AsString().Should().Be("1.0");
            TraktMediaAudioChannel.Channels_2_0.AsString().Should().Be("2.0");
            TraktMediaAudioChannel.Channels_2_1.AsString().Should().Be("2.1");
            TraktMediaAudioChannel.Channels_3_0.AsString().Should().Be("3.0");
            TraktMediaAudioChannel.Channels_3_1.AsString().Should().Be("3.1");
            TraktMediaAudioChannel.Channels_4_0.AsString().Should().Be("4.0");
            TraktMediaAudioChannel.Channels_4_1.AsString().Should().Be("4.1");
            TraktMediaAudioChannel.Channels_5_0.AsString().Should().Be("5.0");
            TraktMediaAudioChannel.Channels_5_1.AsString().Should().Be("5.1");
            TraktMediaAudioChannel.Channels_6_1.AsString().Should().Be("6.1");
            TraktMediaAudioChannel.Channels_7_1.AsString().Should().Be("7.1");
        }
    }
}
