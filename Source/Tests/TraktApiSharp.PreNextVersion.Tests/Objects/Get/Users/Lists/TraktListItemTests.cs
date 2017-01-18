namespace TraktApiSharp.Tests.Objects.Get.Users.Lists
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Utils;

    [TestClass]
    public class TraktListItemTests
    {
        [TestMethod]
        public void TestTraktListItemDefaultConstructor()
        {
            var listItem = new TraktListItem();

            listItem.Rank.Should().BeNullOrEmpty();
            listItem.ListedAt.Should().NotHaveValue();
            listItem.Type.Should().BeNull();
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktListItemReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var listItems = JsonConvert.DeserializeObject<IEnumerable<TraktListItem>>(jsonFile);

            listItems.Should().NotBeNull().And.HaveCount(5);

            var items = listItems.ToArray();

            items[0].Rank.Should().Be("1");
            items[0].ListedAt.Should().Be(DateTime.Parse("2014-06-16T06:07:12.000Z").ToUniversalTime());
            items[0].Type.Should().Be(TraktListItemType.Movie);
            items[0].Movie.Should().NotBeNull();
            items[0].Show.Should().BeNull();
            items[0].Season.Should().BeNull();
            items[0].Episode.Should().BeNull();
            items[0].Person.Should().BeNull();

            items[1].Rank.Should().Be("2");
            items[1].ListedAt.Should().Be(DateTime.Parse("2014-06-16T06:07:12.000Z").ToUniversalTime());
            items[1].Type.Should().Be(TraktListItemType.Show);
            items[1].Movie.Should().BeNull();
            items[1].Show.Should().NotBeNull();
            items[1].Season.Should().BeNull();
            items[1].Episode.Should().BeNull();
            items[1].Person.Should().BeNull();

            items[2].Rank.Should().Be("3");
            items[2].ListedAt.Should().Be(DateTime.Parse("2014-06-16T06:07:12.000Z").ToUniversalTime());
            items[2].Type.Should().Be(TraktListItemType.Season);
            items[2].Movie.Should().BeNull();
            items[2].Show.Should().NotBeNull();
            items[2].Season.Should().NotBeNull();
            items[2].Episode.Should().BeNull();
            items[2].Person.Should().BeNull();

            items[3].Rank.Should().Be("4");
            items[3].ListedAt.Should().Be(DateTime.Parse("2014-06-17T06:52:03.000Z").ToUniversalTime());
            items[3].Type.Should().Be(TraktListItemType.Episode);
            items[3].Movie.Should().BeNull();
            items[3].Show.Should().NotBeNull();
            items[3].Season.Should().BeNull();
            items[3].Episode.Should().NotBeNull();
            items[3].Person.Should().BeNull();

            items[4].Rank.Should().Be("5");
            items[4].ListedAt.Should().Be(DateTime.Parse("2014-06-17T06:52:03.000Z").ToUniversalTime());
            items[4].Type.Should().Be(TraktListItemType.Person);
            items[4].Movie.Should().BeNull();
            items[4].Show.Should().BeNull();
            items[4].Season.Should().BeNull();
            items[4].Episode.Should().BeNull();
            items[4].Person.Should().NotBeNull();
        }
    }
}
