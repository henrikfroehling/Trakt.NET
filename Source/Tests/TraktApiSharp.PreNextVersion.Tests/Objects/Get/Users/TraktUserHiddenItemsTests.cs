namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserHiddenItemsTests
    {
        [TestMethod]
        public void TestTraktUserHiddenItemsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var hiddenItems = JsonConvert.DeserializeObject<IEnumerable<TraktUserHiddenItem>>(jsonFile);

            hiddenItems.Should().NotBeNull().And.HaveCount(3);

            var hiddenItemsArray = hiddenItems.ToArray();

            hiddenItemsArray[0].HiddenAt.Should().Be(DateTime.Parse("2015-05-23T23:18:42.000Z").ToUniversalTime());
            hiddenItemsArray[0].Type.Should().Be(TraktHiddenItemType.Show);
            hiddenItemsArray[0].Movie.Should().BeNull();
            hiddenItemsArray[0].Show.Should().NotBeNull();
            hiddenItemsArray[0].Season.Should().BeNull();

            hiddenItemsArray[1].HiddenAt.Should().Be(DateTime.Parse("2015-03-30T23:19:33.000Z").ToUniversalTime());
            hiddenItemsArray[1].Type.Should().Be(TraktHiddenItemType.Movie);
            hiddenItemsArray[1].Movie.Should().NotBeNull();
            hiddenItemsArray[1].Show.Should().BeNull();
            hiddenItemsArray[1].Season.Should().BeNull();

            hiddenItemsArray[2].HiddenAt.Should().Be(DateTime.Parse("2015-04-02T23:19:33.000Z").ToUniversalTime());
            hiddenItemsArray[2].Type.Should().Be(TraktHiddenItemType.Season);
            hiddenItemsArray[2].Movie.Should().BeNull();
            hiddenItemsArray[2].Show.Should().BeNull();
            hiddenItemsArray[2].Season.Should().NotBeNull();
        }
    }
}
