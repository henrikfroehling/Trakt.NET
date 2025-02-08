namespace TraktNET.Enums
{
    public class TraktExtendedInfoTests
    {
        [Fact]
        public void TestTraktExtendedInfoToJson()
        {
            TraktExtendedInfo.None.ToJson().ShouldBeEmpty();
            TraktExtendedInfo.Metadata.ToJson().ShouldBe("metadata");
            TraktExtendedInfo.Full.ToJson().ShouldBe("full");
            TraktExtendedInfo.NoSeasons.ToJson().ShouldBe("noseasons");
            TraktExtendedInfo.Episodes.ToJson().ShouldBe("episodes");
            TraktExtendedInfo.GuestStars.ToJson().ShouldBe("guest_stars");
            TraktExtendedInfo.Comments.ToJson().ShouldBe("comments");
            TraktExtendedInfo.VIP.ToJson().ShouldBe("vip");
            TraktExtendedInfo.Images.ToJson().ShouldBe("images");
        }

        [Fact]
        public void TestTraktExtendedInfoFromJson()
        {
            string.Empty.ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
            "metadata".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Metadata);
            "full".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Full);
            "noseasons".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.NoSeasons);
            "episodes".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Episodes);
            "guest_stars".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.GuestStars);
            "comments".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Comments);
            "vip".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.VIP);
            "images".ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.Images);

            string? nullValue = null;
            nullValue.ToTraktExtendedInfo().ShouldBe(TraktExtendedInfo.None);
        }

        [Fact]
        public void TestTraktExtendedInfoDisplayName()
        {
            TraktExtendedInfo.None.DisplayName().ShouldBe("None");
            TraktExtendedInfo.Metadata.DisplayName().ShouldBe("Metadata");
            TraktExtendedInfo.Full.DisplayName().ShouldBe("Full");
            TraktExtendedInfo.NoSeasons.DisplayName().ShouldBe("No Seasons");
            TraktExtendedInfo.Episodes.DisplayName().ShouldBe("Episodes");
            TraktExtendedInfo.GuestStars.DisplayName().ShouldBe("Guest Stars");
            TraktExtendedInfo.Comments.DisplayName().ShouldBe("Comments");
            TraktExtendedInfo.VIP.DisplayName().ShouldBe("VIP");
            TraktExtendedInfo.Images.DisplayName().ShouldBe("Images");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.DisplayName().ShouldBe("Full, VIP");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.DisplayName().ShouldBe("Full, Images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.DisplayName().ShouldBe("Full, Comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.DisplayName().ShouldBe("Episodes, Guest Stars");
        }

        [Fact]
        public void TestTraktExtendedInfoAsQuery()
        {
            TraktExtendedInfo.None.AsQuery().ShouldBeEmpty();
            TraktExtendedInfo.Metadata.AsQuery().ShouldBe("extended=metadata");
            TraktExtendedInfo.Full.AsQuery().ShouldBe("extended=full");
            TraktExtendedInfo.NoSeasons.AsQuery().ShouldBe("extended=noseasons");
            TraktExtendedInfo.Episodes.AsQuery().ShouldBe("extended=episodes");
            TraktExtendedInfo.GuestStars.AsQuery().ShouldBe("extended=guest_stars");
            TraktExtendedInfo.Comments.AsQuery().ShouldBe("extended=comments");
            TraktExtendedInfo.VIP.AsQuery().ShouldBe("extended=vip");
            TraktExtendedInfo.Images.AsQuery().ShouldBe("extended=images");

            TraktExtendedInfo fullAndVIP = TraktExtendedInfo.Full | TraktExtendedInfo.VIP;
            fullAndVIP.AsQuery().ShouldBe("extended=full,vip");

            TraktExtendedInfo fullAndImages = TraktExtendedInfo.Full | TraktExtendedInfo.Images;
            fullAndImages.AsQuery().ShouldBe("extended=full,images");

            TraktExtendedInfo fullAndComments = TraktExtendedInfo.Full | TraktExtendedInfo.Comments;
            fullAndComments.AsQuery().ShouldBe("extended=full,comments");

            TraktExtendedInfo episodesAndGuestStarts = TraktExtendedInfo.Episodes | TraktExtendedInfo.GuestStars;
            episodesAndGuestStarts.AsQuery().ShouldBe("extended=episodes,guest_stars");
        }
    }
}
