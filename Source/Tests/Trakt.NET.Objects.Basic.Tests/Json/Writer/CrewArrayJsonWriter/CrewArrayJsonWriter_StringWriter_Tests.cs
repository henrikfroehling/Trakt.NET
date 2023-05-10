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

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CrewArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
            IList<ITraktCrew> traktCrews = new List<ITraktCrew>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCrews);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IList<ITraktCrew> traktCrews = new List<ITraktCrew>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrews);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IList<ITraktCrew> traktCrews = new List<ITraktCrew>
            {
                new TraktCrew
                {
                    Production = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Production Member"
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
                    },
                    Art = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Art Member"
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
                    },
                    Crew = new List<ITraktCrewMember>
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
                    },
                    CostumeAndMakeup = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "CostumeAndMakeup Member"
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
                    },
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Directing Member"
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
                    },
                    Writing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Writing Member"
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
                    },
                    Sound = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Sound Member"
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
                    },
                    Camera = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Camera Member"
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
                    },
                    Lighting = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Lighting Member"
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
                    },
                    VisualEffects = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "VisualEffects Member"
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
                    },
                    Editing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Editing Member"
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
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrews);
                json.Should().Be(@"[{""production"":[{""jobs"":[""Production Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""art"":[{""jobs"":[""Art Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""crew"":[{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""costume & make-up"":[{""jobs"":[""CostumeAndMakeup Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""directing"":[{""jobs"":[""Directing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""writing"":[{""jobs"":[""Writing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""sound"":[{""jobs"":[""Sound Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""camera"":[{""jobs"":[""Camera Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""lighting"":[{""jobs"":[""Lighting Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""visual effects"":[{""jobs"":[""VisualEffects Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""editing"":[{""jobs"":[""Editing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}]");
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IList<ITraktCrew> traktCrews = new List<ITraktCrew>
            {
                new TraktCrew
                {
                    Production = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Production Member"
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
                    },
                    Art = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Art Member"
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
                    },
                    Crew = new List<ITraktCrewMember>
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
                    },
                    CostumeAndMakeup = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "CostumeAndMakeup Member"
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
                    },
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Directing Member"
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
                    },
                    Writing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Writing Member"
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
                    },
                    Sound = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Sound Member"
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
                    },
                    Camera = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Camera Member"
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
                    },
                    Lighting = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Lighting Member"
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
                    },
                    VisualEffects = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "VisualEffects Member"
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
                    },
                    Editing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Editing Member"
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
                    }
                },
                new TraktCrew
                {
                    Production = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Production Member"
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
                    },
                    Art = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Art Member"
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
                    },
                    Crew = new List<ITraktCrewMember>
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
                    },
                    CostumeAndMakeup = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "CostumeAndMakeup Member"
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
                    },
                    Directing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Directing Member"
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
                    },
                    Writing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Writing Member"
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
                    },
                    Sound = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Sound Member"
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
                    },
                    Camera = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Camera Member"
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
                    },
                    Lighting = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Lighting Member"
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
                    },
                    VisualEffects = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "VisualEffects Member"
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
                    },
                    Editing = new List<ITraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Jobs = new List<string>
                            {
                                "Editing Member"
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
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCrews);
                json.Should().Be(@"[{""production"":[{""jobs"":[""Production Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""art"":[{""jobs"":[""Art Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""crew"":[{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""costume & make-up"":[{""jobs"":[""CostumeAndMakeup Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""directing"":[{""jobs"":[""Directing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""writing"":[{""jobs"":[""Writing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""sound"":[{""jobs"":[""Sound Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""camera"":[{""jobs"":[""Camera Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""lighting"":[{""jobs"":[""Lighting Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""visual effects"":[{""jobs"":[""VisualEffects Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""editing"":[{""jobs"":[""Editing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}," +
                                 @"{""production"":[{""jobs"":[""Production Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""art"":[{""jobs"":[""Art Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""crew"":[{""jobs"":[""Crew Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""costume & make-up"":[{""jobs"":[""CostumeAndMakeup Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""directing"":[{""jobs"":[""Directing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""writing"":[{""jobs"":[""Writing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""sound"":[{""jobs"":[""Sound Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""camera"":[{""jobs"":[""Camera Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""lighting"":[{""jobs"":[""Lighting Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""visual effects"":[{""jobs"":[""VisualEffects Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                                 @"""editing"":[{""jobs"":[""Editing Member""]," +
                                 @"""person"":{""name"":""Bryan Cranston""," +
                                 @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                 @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}]");
            }
        }
    }
}
