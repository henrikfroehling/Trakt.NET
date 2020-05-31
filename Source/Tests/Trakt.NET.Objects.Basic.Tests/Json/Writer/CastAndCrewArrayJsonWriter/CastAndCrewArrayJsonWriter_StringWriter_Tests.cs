﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
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
    public partial class CastAndCrewArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CastAndCrewArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCastAndCrew>();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = new List<TraktCastAndCrew>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCastAndCrews);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = new List<TraktCastAndCrew>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastAndCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCastAndCrews);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = new List<ITraktCastAndCrew>
            {
                new TraktCastAndCrew
                {
                    Cast = new List<ITraktCastMember>
                    {
                        new TraktCastMember
                        {
                            Character = "Character 1",
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
                            Character = "Character 2",
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
                                Job = "Director 1",
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
                                Job = "Director 2",
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
                                Job = "Editor 1",
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
                                Job = "Editor 2",
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastAndCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCastAndCrews);
                json.Should().Be(@"[{""cast"":[{""character"":""Character 1"",""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""character"":""Character 2"",""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""crew"":{" +
                                 @"""directing"":" +
                                 @"[{""job"":""Director 1"",""jobs"":[""Director 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""job"":""Director 2"",""jobs"":[""Director 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""editing"":" +
                                 @"[{""job"":""Editor 1"",""jobs"":[""Editor 1""],""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                                 @"{""job"":""Editor 2"",""jobs"":[""Editor 2""],""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]}" +
                                 @"}]");
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = new List<ITraktCastAndCrew>
            {
                new TraktCastAndCrew
                {
                    Cast = new List<ITraktCastMember>
                    {
                        new TraktCastMember
                        {
                            Character = "Character 1",
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
                            Character = "Character 2",
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
                                Job = "Director 1",
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
                                Job = "Director 2",
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
                                Job = "Editor 1",
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
                                Job = "Editor 2",
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
                },
                new TraktCastAndCrew
                {
                    Cast = new List<ITraktCastMember>
                    {
                        new TraktCastMember
                        {
                            Character = "Character 1",
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
                            Character = "Character 2",
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
                                Job = "Director 1",
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
                                Job = "Director 2",
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
                                Job = "Editor 1",
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
                                Job = "Editor 2",
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastAndCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCastAndCrews);
                json.Should().Be(@"[{""cast"":[{""character"":""Character 1"",""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""character"":""Character 2"",""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""crew"":{" +
                                 @"""directing"":" +
                                 @"[{""job"":""Director 1"",""jobs"":[""Director 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""job"":""Director 2"",""jobs"":[""Director 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""editing"":" +
                                 @"[{""job"":""Editor 1"",""jobs"":[""Editor 1""],""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                                 @"{""job"":""Editor 2"",""jobs"":[""Editor 2""],""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]}" +
                                 @"}," +
                                 @"{""cast"":[{""character"":""Character 1"",""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""character"":""Character 2"",""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""crew"":{" +
                                 @"""directing"":" +
                                 @"[{""job"":""Director 1"",""jobs"":[""Director 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                 @"{""job"":""Director 2"",""jobs"":[""Director 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]," +
                                 @"""editing"":" +
                                 @"[{""job"":""Editor 1"",""jobs"":[""Editor 1""],""person"":{""name"":""Person 3"",""ids"":{""trakt"":0,""slug"":""person-3""}}}," +
                                 @"{""job"":""Editor 2"",""jobs"":[""Editor 2""],""person"":{""name"":""Person 4"",""ids"":{""trakt"":0,""slug"":""person-4""}}}]}" +
                                 @"}]");
            }
        }
    }
}
