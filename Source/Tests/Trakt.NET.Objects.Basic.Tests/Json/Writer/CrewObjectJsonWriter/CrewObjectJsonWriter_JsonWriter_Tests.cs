﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
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

    [Category("Objects.Basic.JsonWriter")]
    public partial class CrewObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CrewObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CrewObjectJsonWriter();
            ITraktCrew traktCrew = new TraktCrew();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCrew);
            action.Should().Throw<ArgumentNullException>();
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""production"":[{""job"":""Production Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""art"":[{""job"":""Art Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""crew"":[{""job"":""Crew Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""costume & make-up"":[{""job"":""CostumeAndMakeup Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""directing"":[{""job"":""Directing Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""writing"":[{""job"":""Writing Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""sound"":[{""job"":""Sound Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""camera"":[{""job"":""Camera Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""lighting"":[{""job"":""Lighting Member""," +
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""visual effects"":[{""job"":""VisualEffects Member""," +
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""editing"":[{""job"":""Editing Member""," +
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CrewObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCrew);
                stringWriter.ToString().Should().Be(@"{""production"":[{""job"":""Production Member""," +
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
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]}");
            }
        }
    }
}