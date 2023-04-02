namespace TraktNet.Objects.Get.Tests.People.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonWriter")]
    public partial class PersonObjectJsonWriter_Tests
    {
        private readonly DateTime BIRTHDAY_AT = DateTime.UtcNow.Date;
        private readonly DateTime DEATH_AT = DateTime.UtcNow.Date;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new PersonObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Name_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Name = "Bryan Cranston"
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""name"":""Bryan Cranston""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Ids = new TraktPersonIds
                {
                    Trakt = 297737,
                    Slug = "bryan-cranston",
                    Imdb = "nm0186505",
                    Tmdb = 17419,
                    TvRage = 1797
                }
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Biography_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Biography = "Bryan Lee Cranston(born March 7, 1956)..."
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""biography"":""Bryan Lee Cranston(born March 7, 1956)...""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Birthday_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Birthday = BIRTHDAY_AT
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be($"{{\"birthday\":\"{BIRTHDAY_AT.ToTraktDateString()}\"}}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Death_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Death = DEATH_AT
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be($"{{\"death\":\"{DEATH_AT.ToTraktDateString()}\"}}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Birthplace_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Birthplace = "San Fernando Valley, California, USA"
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""birthplace"":""San Fernando Valley, California, USA""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Homepage_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Homepage = "http://www.bryancranston.com/"
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""homepage"":""http://www.bryancranston.com/""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_Gender_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                Gender = "male"
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""gender"":""male""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_KnownForDepartment_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                KnownForDepartment = "acting"
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""known_for_department"":""acting""}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_SocialIds_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                SocialIds = new TraktPersonSocialIds
                {
                    Twitter = "BryanCranston",
                    Facebook = "thebryancranston",
                    Instagram = "bryancranston",
                    Wikipedia = "Bryan_Cranston"
                }
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""social_ids"":{""twitter"":""BryanCranston"",""facebook"":""thebryancranston""," +
                             @"""instagram"":""bryancranston"",""wikipedia"":""Bryan_Cranston""}}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Only_UpdatedAt_Property()
        {
            ITraktPerson traktPerson = new TraktPerson
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_PersonObjectJsonWriter_WriteObject_Complete()
        {
            ITraktPerson traktPerson = new TraktPerson
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
                Gender = "male",
                KnownForDepartment = "acting",
                SocialIds = new TraktPersonSocialIds
                {
                    Twitter = "BryanCranston",
                    Facebook = "thebryancranston",
                    Instagram = "bryancranston",
                    Wikipedia = "Bryan_Cranston"
                },
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new PersonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktPerson);
            json.Should().Be(@"{""name"":""Bryan Cranston""," +
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
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
