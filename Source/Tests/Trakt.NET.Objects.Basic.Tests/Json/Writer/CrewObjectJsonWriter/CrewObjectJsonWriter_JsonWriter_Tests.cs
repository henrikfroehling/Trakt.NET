namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.People;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CrewObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CrewObjectJsonWriter();
            ITraktCrew traktCrew = new TraktCrew();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCrew);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktCrew traktCrew = new TraktCrew();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Production_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""production"":[{""jobs"":[""Production Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Art_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""art"":[{""jobs"":[""Art Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Crew_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""crew"":[{""jobs"":[""Crew Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_CostumeAndMakeup_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""costume & make-up"":[{""jobs"":[""CostumeAndMakeup Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Directing_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""directing"":[{""jobs"":[""Directing Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Writing_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""writing"":[{""jobs"":[""Writing Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Sound_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""sound"":[{""jobs"":[""Sound Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Camera_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""camera"":[{""jobs"":[""Camera Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Lighting_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""lighting"":[{""jobs"":[""Lighting Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_VisualEffects_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""visual effects"":[{""jobs"":[""VisualEffects Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Only_Editing_Property()
        {
            ITraktCrew traktCrew = new TraktCrew
            {
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""editing"":[{""jobs"":[""Editing Member""]," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktCrew traktCrew = new TraktCrew
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""production"":[{""jobs"":[""Production Member""]," +
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
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }
    }
}
