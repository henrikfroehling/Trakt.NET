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
    public partial class CastAndCrewObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CastAndCrewObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew();
            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastAndCrew);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_Object_Only_Cast_Property()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Cast = new List<ITraktCastMember>
                {
                    new TraktCastMember
                    {
                        Character = "Character 1",
                        Person = new TraktPerson
                        {
                            Name = "Person 1",
                            Ids = new TraktPersonIds
                            {
                                Slug = "person-1"
                            }
                        }
                    },
                    new TraktCastMember
                    {
                        Character = "Character 2",
                        Person = new TraktPerson
                        {
                            Name = "Person 2",
                            Ids = new TraktPersonIds
                            {
                                Slug = "person-2"
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastAndCrew);
            json.Should().Be(@"{""cast"":[{""character"":""Character 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                             @"{""character"":""Character 2"",""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]}");
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_Object_Only_Crew_Property()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Crew = new TraktCrew
                {
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Director 1",
                            Person = new TraktPerson
                            {
                                Name = "Person 1",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-1"
                                }
                            }
                        },
                        new TraktCrewMember
                        {
                            Job = "Director 2",
                            Person = new TraktPerson
                            {
                                Name = "Person 2",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-2"
                                }
                            }
                        }
                    },
                    Editing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Editor 1",
                            Person = new TraktPerson
                            {
                                Name = "Person 3",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-3"
                                }
                            }
                        },
                        new TraktCrewMember
                        {
                            Job = "Editor 2",
                            Person = new TraktPerson
                            {
                                Name = "Person 4",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-4"
                                }
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastAndCrew);
            json.Should().Be(@"{""crew"":{" +
                             @"""directing"":" +
                             @"[{""job"":""Director 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                             @"{""job"":""Director 2"",""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                             @"""editing"":" +
                             @"[{""job"":""Editor 1"",""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                             @"{""job"":""Editor 2"",""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]" +
                             @"}}");
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Cast = new List<ITraktCastMember>
                {
                    new TraktCastMember
                    {
                        Character = "Character 1",
                        Person = new TraktPerson
                        {
                            Name = "Person 1",
                            Ids = new TraktPersonIds
                            {
                                Slug = "person-1"
                            }
                        }
                    },
                    new TraktCastMember
                    {
                        Character = "Character 2",
                        Person = new TraktPerson
                        {
                            Name = "Person 2",
                            Ids = new TraktPersonIds
                            {
                                Slug = "person-2"
                            }
                        }
                    }
                },
                Crew = new TraktCrew
                {
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Director 1",
                            Person = new TraktPerson
                            {
                                Name = "Person 1",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-1"
                                }
                            }
                        },
                        new TraktCrewMember
                        {
                            Job = "Director 2",
                            Person = new TraktPerson
                            {
                                Name = "Person 2",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-2"
                                }
                            }
                        }
                    },
                    Editing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Editor 1",
                            Person = new TraktPerson
                            {
                                Name = "Person 3",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-3"
                                }
                            }
                        },
                        new TraktCrewMember
                        {
                            Job = "Editor 2",
                            Person = new TraktPerson
                            {
                                Name = "Person 4",
                                Ids = new TraktPersonIds
                                {
                                    Slug = "person-4"
                                }
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastAndCrew);
            json.Should().Be(@"{""cast"":[{""character"":""Character 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                             @"{""character"":""Character 2"",""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                             @"""crew"":{" +
                             @"""directing"":" +
                             @"[{""job"":""Director 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                             @"{""job"":""Director 2"",""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                             @"""editing"":" +
                             @"[{""job"":""Editor 1"",""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                             @"{""job"":""Editor 2"",""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]}" +
                             @"}");
        }
    }
}
