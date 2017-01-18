namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserTests
    {
        [TestMethod]
        public void TestTraktUserDefaultConstructor()
        {
            var user = new TraktUser();

            user.Username.Should().BeNullOrEmpty();
            user.Private.Should().NotHaveValue();
            user.Ids.Should().BeNull();
            user.Name.Should().BeNullOrEmpty();
            user.VIP.Should().NotHaveValue();
            user.VIP_EP.Should().NotHaveValue();
            user.JoinedAt.Should().NotHaveValue();
            user.Location.Should().BeNullOrEmpty();
            user.About.Should().BeNullOrEmpty();
            user.Gender.Should().BeNullOrEmpty();
            user.Age.Should().NotHaveValue();
            user.Images.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var user = JsonConvert.DeserializeObject<TraktUser>(jsonFile);

            user.Should().NotBeNull();
            user.Username.Should().Be("WalterBishopj");
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Private.Should().BeFalse();
            user.Name.Should().Be("Walter");
            user.VIP.Should().BeFalse();
            user.VIP_EP.Should().BeFalse();
            user.JoinedAt.Should().NotHaveValue();
            user.Location.Should().BeNullOrEmpty();
            user.About.Should().BeNullOrEmpty();
            user.Gender.Should().BeNullOrEmpty();
            user.Age.Should().NotHaveValue();
            user.Images.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var user = JsonConvert.DeserializeObject<TraktUser>(jsonFile);

            user.Should().NotBeNull();
            user.Username.Should().Be("randomness");
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Private.Should().BeFalse();
            user.Name.Should().Be("RandomNess");
            user.VIP.Should().BeFalse();
            user.VIP_EP.Should().BeFalse();
            user.JoinedAt.Should().NotHaveValue();
            user.Location.Should().BeNullOrEmpty();
            user.About.Should().BeNullOrEmpty();
            user.Gender.Should().BeNullOrEmpty();
            user.Age.Should().NotHaveValue();
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
        }

        [TestMethod]
        public void TestTraktUserReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var user = JsonConvert.DeserializeObject<TraktUser>(jsonFile);

            user.Should().NotBeNull();
            user.Username.Should().Be("randomness");
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Private.Should().BeFalse();
            user.Name.Should().Be("RandomNess");
            user.VIP.Should().BeFalse();
            user.VIP_EP.Should().BeFalse();
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2013-11-28T17:45:10Z").ToUniversalTime());
            user.Location.Should().Be("Krypton");
            user.About.Should().Be("random ness female");
            user.Gender.Should().Be("female");
            user.Age.Should().Be(21);
            user.Images.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var user = JsonConvert.DeserializeObject<TraktUser>(jsonFile);

            user.Should().NotBeNull();
            user.Username.Should().Be("randomness");
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Private.Should().BeFalse();
            user.Name.Should().Be("RandomNess");
            user.VIP.Should().BeFalse();
            user.VIP_EP.Should().BeFalse();
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2013-11-28T17:45:10Z").ToUniversalTime());
            user.Location.Should().Be("Krypton");
            user.About.Should().Be("random ness female");
            user.Gender.Should().Be("female");
            user.Age.Should().Be(21);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
        }
    }
}
