namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktShowStatus_Tests
    {
        [Fact]
        public void Test_TraktShowStatus_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktShowStatus>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktShowStatus>() { TraktShowStatus.Unspecified, TraktShowStatus.ReturningSeries,
                                                                     TraktShowStatus.InProduction, TraktShowStatus.Canceled,
                                                                     TraktShowStatus.Ended });
        }
    }
}
