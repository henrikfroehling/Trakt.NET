namespace TraktNet.Objects.Get.Tests.People.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonWriter")]
    public partial class RecentlyUpdatedRecentlyUpdatedPersonObjectJsonWriter_Tests
    {
        private readonly DateTime BIRTHDAY_AT = DateTime.UtcNow.Date;
        private readonly DateTime DEATH_AT = DateTime.UtcNow.Date;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new RecentlyUpdatedPersonObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonWriter_WriteObject_Only_RecentlyUpdatedAt_Property()
        {
            ITraktRecentlyUpdatedPerson traktRecentlyUpdatedPerson = new TraktRecentlyUpdatedPerson
            {
                RecentlyUpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new RecentlyUpdatedPersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecentlyUpdatedPerson);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonWriter_WriteObject_Only_Person_Property()
        {
            ITraktRecentlyUpdatedPerson traktRecentlyUpdatedPerson = new TraktRecentlyUpdatedPerson
            {
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419,
                        TvRage = 1797
                    },
                    Biography = "Bryan Lee Cranston(born March 7, 1956)...",
                    Birthday = BIRTHDAY_AT,
                    Death = DEATH_AT,
                    Birthplace = "San Fernando Valley, California, USA",
                    Homepage = "http://www.bryancranston.com/",
                    Gender = TraktGender.Male,
                    KnownForDepartment = TraktKnownForDepartment.Acting,
                    SocialIds = new TraktPersonSocialIds
                    {
                        Twitter = "BryanCranston",
                        Facebook = "thebryancranston",
                        Instagram = "bryancranston",
                        Wikipedia = "Bryan_Cranston"
                    },
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new RecentlyUpdatedPersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecentlyUpdatedPerson);
            json.Should().Be(@"{""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}," +
                             @"""biography"":""Bryan Lee Cranston(born March 7, 1956)...""," +
                             $"\"birthday\":\"{BIRTHDAY_AT.ToTraktDateString()}\"," +
                             $"\"death\":\"{DEATH_AT.ToTraktDateString()}\"," +
                             @"""birthplace"":""San Fernando Valley, California, USA""," +
                             @"""homepage"":""http://www.bryancranston.com/""," +
                             @"""gender"":""male""," +
                             @"""known_for_department"":""acting""," +
                             @"""social_ids"":{""twitter"":""BryanCranston"",""facebook"":""thebryancranston""," +
                             @"""instagram"":""bryancranston"",""wikipedia"":""Bryan_Cranston""}," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonWriter_WriteObject_Complete()
        {
            ITraktRecentlyUpdatedPerson traktRecentlyUpdatedPerson = new TraktRecentlyUpdatedPerson
            {
                RecentlyUpdatedAt = UPDATED_AT,
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419,
                        TvRage = 1797
                    },
                    Biography = "Bryan Lee Cranston(born March 7, 1956)...",
                    Birthday = BIRTHDAY_AT,
                    Death = DEATH_AT,
                    Birthplace = "San Fernando Valley, California, USA",
                    Homepage = "http://www.bryancranston.com/",
                    Gender = TraktGender.Male,
                    KnownForDepartment = TraktKnownForDepartment.Acting,
                    SocialIds = new TraktPersonSocialIds
                    {
                        Twitter = "BryanCranston",
                        Facebook = "thebryancranston",
                        Instagram = "bryancranston",
                        Wikipedia = "Bryan_Cranston"
                    },
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new RecentlyUpdatedPersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecentlyUpdatedPerson);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}," +
                             @"""biography"":""Bryan Lee Cranston(born March 7, 1956)...""," +
                             $"\"birthday\":\"{BIRTHDAY_AT.ToTraktDateString()}\"," +
                             $"\"death\":\"{DEATH_AT.ToTraktDateString()}\"," +
                             @"""birthplace"":""San Fernando Valley, California, USA""," +
                             @"""homepage"":""http://www.bryancranston.com/""," +
                             @"""gender"":""male""," +
                             @"""known_for_department"":""acting""," +
                             @"""social_ids"":{""twitter"":""BryanCranston"",""facebook"":""thebryancranston""," +
                             @"""instagram"":""bryancranston"",""wikipedia"":""Bryan_Cranston""}," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }
    }
}
