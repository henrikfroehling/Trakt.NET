namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
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
        public void Test_CrewMemberObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember();
            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCrewMember);
            json.Should().Be(@"{}");
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_Object_Only_Jobs_Property()
        {
            ITraktCrewMember traktCrewMember = new TraktCrewMember
            {
                Jobs = new List<string>
                {
                    "Crew Member"
                }
            };

            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCrewMember);
            json.Should().Be(@"{""jobs"":[""Crew Member""]}");
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_Object_Only_Person_Property()
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

            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCrewMember);
            json.Should().Be(@"{""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}");
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonWriter_WriteObject_Object_Complete()
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

            var traktJsonWriter = new CrewMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCrewMember);
            json.Should().Be(@"{""jobs"":[""Crew Member""]," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}");
        }
    }
}
