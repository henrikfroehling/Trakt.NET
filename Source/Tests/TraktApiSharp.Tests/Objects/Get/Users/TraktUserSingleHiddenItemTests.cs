namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserSingleHiddenItemTests
    {
        [TestMethod]
        public void TestTraktUserSingleHiddenItemDefaultConstructor()
        {
            var hiddenItem = new TraktUserHiddenItem();

            hiddenItem.HiddenAt.Should().NotHaveValue();
            hiddenItem.Type.Should().BeNull();
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserSingleHiddenItemReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserSingleHiddenItem.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var hiddenItem = JsonConvert.DeserializeObject<TraktUserHiddenItem>(jsonFile);

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2015-05-23T23:18:42.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().NotBeNull();
            hiddenItem.Season.Should().BeNull();
        }
    }
}
