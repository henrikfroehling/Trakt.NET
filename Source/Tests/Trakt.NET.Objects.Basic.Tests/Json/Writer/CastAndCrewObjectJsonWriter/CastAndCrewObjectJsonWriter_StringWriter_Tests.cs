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
    public partial class CastAndCrewObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CastAndCrewObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CastAndCrewObjectJsonWriter();
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCastAndCrew);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastAndCrewObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastAndCrew);
                json.Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_StringWriter_Only_Cast_Property()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Cast = new List<ITraktCastMember>
                {
                    new TraktCastMember
                    {
                        Characters = new List<string>
                        {
                            "Character 1"
                        },
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
                        Characters = new List<string>
                        {
                            "Character 2"
                        },
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastAndCrewObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastAndCrew);
                json.Should().Be(@"{""cast"":[{""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]}");
            }
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_StringWriter_Only_Crew_Property()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Crew = new TraktCrew
                {
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Director 1"
                            },
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
                            Jobs = new List<string>
                            {
                                "Director 2"
                            },
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
                            Jobs = new List<string>
                            {
                                "Editor 1"
                            },
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
                            Jobs = new List<string>
                            {
                                "Editor 2"
                            },
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastAndCrewObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastAndCrew);
                json.Should().Be(@"{""crew"":{" +
                                 @"""directing"":" +
                                 @"[{""jobs"":[""Director 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""jobs"":[""Director 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""editing"":" +
                                 @"[{""jobs"":[""Editor 1""],""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                                 @"{""jobs"":[""Editor 2""],""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]" +
                                 @"}}");
            }
        }

        [Fact]
        public async Task Test_CastAndCrewObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew
            {
                Cast = new List<ITraktCastMember>
                {
                    new TraktCastMember
                    {
                        Characters = new List<string>
                        {
                            "Character 1"
                        },
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
                        Characters = new List<string>
                        {
                            "Character 2"
                        },
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
                            Jobs = new List<string>
                            {
                                "Director 1"
                            },
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
                            Jobs = new List<string>
                            {
                                "Director 2"
                            },
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
                            Jobs = new List<string>
                            {
                                "Editor 1"
                            },
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
                            Jobs = new List<string>
                            {
                                "Editor 2"
                            },
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastAndCrewObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastAndCrew);
                json.Should().Be(@"{""cast"":[{""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""crew"":{" +
                                 @"""directing"":" +
                                 @"[{""jobs"":[""Director 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""jobs"":[""Director 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""editing"":" +
                                 @"[{""jobs"":[""Editor 1""],""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                                 @"{""jobs"":[""Editor 2""],""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]}" +
                                 @"}");
            }
        }
    }
}
