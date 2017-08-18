﻿namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserFriendObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserFriendObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserFriendObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserFriend>));
        }
    }
}