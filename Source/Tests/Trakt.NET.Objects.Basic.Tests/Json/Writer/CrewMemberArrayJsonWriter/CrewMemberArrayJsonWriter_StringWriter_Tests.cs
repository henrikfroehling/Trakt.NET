namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        public void Test_CrewMemberArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<TraktCrewMember>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCrewMembers);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<TraktCrewMember>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrewMembers);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrewMembers);
                json.Should().Be(@"[{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
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
                },
                new TraktCrewMember
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrewMembers);
                json.Should().Be(@"[{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}," +
                                 @"{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
            }
        }
    }
}
