﻿namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserFollowRequestObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserFollowRequestObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserFollowRequestObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserFollowRequest>));
        }
    }
}