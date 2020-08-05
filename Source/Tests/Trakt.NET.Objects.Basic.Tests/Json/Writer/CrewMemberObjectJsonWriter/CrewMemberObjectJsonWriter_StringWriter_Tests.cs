namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.People;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CrewMemberObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CrewMemberObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            ITraktCrewMember traktCrewMember = new TraktCrewMember();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCrewMember);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CrewMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCrewMember);
                json.Should().Be(@"{}");
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_StringWriter_Only_Jobs_Property()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember
            {
                Jobs = new List<string>
                {
                    "Crew Member"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CrewMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCrewMember);
                json.Should().Be(@"{""jobs"":[""Crew Member""]}");
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_StringWriter_Only_Person_Property()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember
            {
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737U,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419U,
                        TvRage = 1797U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CrewMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCrewMember);
                json.Should().Be(@"{""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}");
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember
            {
                Jobs = new List<string>
                {
                    "Crew Member"
                },
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737U,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419U,
                        TvRage = 1797U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CrewMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCrewMember);
                json.Should().Be(@"{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}");
            }
        }
    }
}
