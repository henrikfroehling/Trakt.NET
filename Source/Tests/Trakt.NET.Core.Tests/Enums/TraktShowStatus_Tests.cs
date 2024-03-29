﻿namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktShowStatus_Tests
    {
        [Fact]
        public void Test_TraktShowStatus_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktShowStatus>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktShowStatus>() { TraktShowStatus.Unspecified, TraktShowStatus.ReturningSeries,
                                                                     TraktShowStatus.InProduction, TraktShowStatus.Canceled,
                                                                     TraktShowStatus.Ended, TraktShowStatus.Upcoming,
                                                                     TraktShowStatus.Planned, TraktShowStatus.Continuing,
                                                                     TraktShowStatus.Pilot });
        }
    }
}
