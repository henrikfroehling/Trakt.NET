namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktCommentType_Tests
    {
        [Fact]
        public void Test_TraktCommentType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktCommentType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktCommentType>() { TraktCommentType.Unspecified, TraktCommentType.Review,
                                                                      TraktCommentType.Shout, TraktCommentType.All });
        }
    }
}
