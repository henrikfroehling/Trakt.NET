﻿namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PersonShowCreditsCrewItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PersonShowCreditsCrewItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPersonShowCreditsCrewItem>));
        }
    }
}
