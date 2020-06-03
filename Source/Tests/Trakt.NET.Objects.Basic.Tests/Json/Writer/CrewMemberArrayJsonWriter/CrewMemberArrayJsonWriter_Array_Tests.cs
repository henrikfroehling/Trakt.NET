namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CrewMemberArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CrewMemberArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<TraktCrewMember>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrewMembers);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
                {
                    Job = "Crew Member",
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrewMembers);
            json.Should().Be(@"[{""job"":""Crew Member"",""jobs"":[""Crew Member""]," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
                {
                    Job = "Crew Member",
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
                },
                new TraktCrewMember
                {
                    Job = "Crew Member",
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrewMembers);
            json.Should().Be(@"[{""job"":""Crew Member"",""jobs"":[""Crew Member""]," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}," +
                             @"{""job"":""Crew Member"",""jobs"":[""Crew Member""]," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
        }
    }
}
