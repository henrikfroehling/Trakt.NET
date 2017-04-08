﻿namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ITraktMostAnticipatedShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMostAnticipatedShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMostAnticipatedShow>));
        }
    }
}
