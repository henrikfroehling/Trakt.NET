﻿namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserHiddenItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);
                traktUserHiddenItem.Should().BeNull();
            }
        }
    }
}
