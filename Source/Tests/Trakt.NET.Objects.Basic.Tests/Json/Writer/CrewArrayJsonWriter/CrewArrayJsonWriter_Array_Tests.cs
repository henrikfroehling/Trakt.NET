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
    public partial class CrewArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CrewArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCrew> traktCrews = new List<TraktCrew>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrews);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCrew> traktCrews = new List<ITraktCrew>
            {
                new TraktCrew
                {
                    Production = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Production Member",
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
                    Art = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Art Member",
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
                    Crew = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Crew Member",
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
                    CostumeAndMakeup = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "CostumeAndMakeup Member",
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
                    Directing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Directing Member",
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
                    Writing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Writing Member",
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
                    Sound = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Sound Member",
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
                    Camera = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Camera Member",
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
                    Lighting = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Lighting Member",
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
                    VisualEffects = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "VisualEffects Member",
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
                    Editing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Editing Member",
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrews);
            json.Should().Be(@"[{""production"":[{""job"":""Production Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""art"":[{""job"":""Art Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""crew"":[{""job"":""Crew Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""costume & make-up"":[{""job"":""CostumeAndMakeup Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""directing"":[{""job"":""Directing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""writing"":[{""job"":""Writing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""sound"":[{""job"":""Sound Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""camera"":[{""job"":""Camera Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""lighting"":[{""job"":""Lighting Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""visual effects"":[{""job"":""VisualEffects Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""editing"":[{""job"":""Editing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}]");
        }

        [Fact]
        public async Task Test_CrewArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCrew> traktCrews = new List<ITraktCrew>
            {
                new TraktCrew
                {
                    Production = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Production Member",
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
                    Art = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Art Member",
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
                    Crew = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Crew Member",
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
                    CostumeAndMakeup = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "CostumeAndMakeup Member",
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
                    Directing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Directing Member",
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
                    Writing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Writing Member",
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
                    Sound = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Sound Member",
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
                    Camera = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Camera Member",
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
                    Lighting = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Lighting Member",
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
                    VisualEffects = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "VisualEffects Member",
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
                    Editing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Editing Member",
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
                    Production = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Production Member",
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
                    Art = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Art Member",
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
                    Crew = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Crew Member",
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
                    CostumeAndMakeup = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "CostumeAndMakeup Member",
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
                    Directing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Directing Member",
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
                    Writing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Writing Member",
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
                    Sound = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Sound Member",
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
                    Camera = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Camera Member",
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
                    Lighting = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Lighting Member",
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
                    VisualEffects = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "VisualEffects Member",
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
                    Editing = new List<TraktCrewMember>
                    {
                        new TraktCrewMember
                        {
                            Job = "Editing Member",
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCrew>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCrews);
            json.Should().Be(@"[{""production"":[{""job"":""Production Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""art"":[{""job"":""Art Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""crew"":[{""job"":""Crew Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""costume & make-up"":[{""job"":""CostumeAndMakeup Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""directing"":[{""job"":""Directing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""writing"":[{""job"":""Writing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""sound"":[{""job"":""Sound Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""camera"":[{""job"":""Camera Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""lighting"":[{""job"":""Lighting Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""visual effects"":[{""job"":""VisualEffects Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""editing"":[{""job"":""Editing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}," +
                             @"{""production"":[{""job"":""Production Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""art"":[{""job"":""Art Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""crew"":[{""job"":""Crew Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""costume & make-up"":[{""job"":""CostumeAndMakeup Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""directing"":[{""job"":""Directing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""writing"":[{""job"":""Writing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""sound"":[{""job"":""Sound Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""camera"":[{""job"":""Camera Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""lighting"":[{""job"":""Lighting Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""visual effects"":[{""job"":""VisualEffects Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]," +
                             @"""editing"":[{""job"":""Editing Member""," +
                             @"""person"":{""name"":""Bryan Cranston""," +
                             @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                             @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}]");
        }
    }
}
