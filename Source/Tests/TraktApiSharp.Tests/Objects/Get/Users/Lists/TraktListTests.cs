namespace TraktApiSharp.Tests.Objects.Users.Lists
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Utils;

    [TestClass]
    public class TraktListTests
    {
        [TestMethod]
        public void TestTraktListDefaultConstructor()
        {
            var list = new TraktList();

            list.Name.Should().BeNullOrEmpty();
            list.Description.Should().BeNullOrEmpty();
            list.Privacy.Should().BeNull();
            list.DisplayNumbers.Should().NotHaveValue();
            list.AllowComments.Should().NotHaveValue();
            list.SortBy.Should().BeNullOrEmpty();
            list.SortHow.Should().BeNullOrEmpty();
            list.CreatedAt.Should().NotHaveValue();
            list.UpdatedAt.Should().NotHaveValue();
            list.ItemCount.Should().NotHaveValue();
            list.CommentCount.Should().NotHaveValue();
            list.Likes.Should().NotHaveValue();
            list.Ids.Should().BeNull();
            list.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktListReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var list = JsonConvert.DeserializeObject<TraktList>(jsonFile);

            list.Should().NotBeNull();
            list.Name.Should().Be("Star Wars in machete order");
            list.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            list.Privacy.Should().Be(TraktAccessScope.Public);
            list.DisplayNumbers.Should().BeTrue();
            list.AllowComments.Should().BeFalse();
            list.SortBy.Should().Be("rank");
            list.SortHow.Should().Be("asc");
            list.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            list.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            list.ItemCount.Should().Be(5);
            list.CommentCount.Should().Be(1);
            list.Likes.Should().Be(2);
            list.Ids.Should().NotBeNull();
            list.Ids.Trakt.Should().Be(55);
            list.Ids.Slug.Should().Be("star-wars-in-machete-order");
            list.User.Should().NotBeNull();
        }
    }
}
