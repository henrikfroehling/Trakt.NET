namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktCrew_Tests
    {
        [Fact]
        public void Test_TraktCrew_Default_Constructor()
        {
            var traktCrew = new TraktCrew();

            traktCrew.Production.Should().BeNull();
            traktCrew.Art.Should().BeNull();
            traktCrew.Crew.Should().BeNull();
            traktCrew.CostumeAndMakeup.Should().BeNull();
            traktCrew.Directing.Should().BeNull();
            traktCrew.Writing.Should().BeNull();
            traktCrew.Sound.Should().BeNull();
            traktCrew.Camera.Should().BeNull();
            traktCrew.Lighting.Should().BeNull();
            traktCrew.VisualEffects.Should().BeNull();
            traktCrew.Editing.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCrew_From_Json()
        {
            var jsonReader = new CrewObjectJsonReader();
            var traktCrew = await jsonReader.ReadObjectAsync(JSON) as TraktCrew;

            traktCrew.Should().NotBeNull();

            traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
            var productionCrew = traktCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
            productionCrew[0].Person.Should().NotBeNull();
            productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
            productionCrew[0].Person.Ids.Should().NotBeNull();
            productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            productionCrew[1].Should().NotBeNull();
            productionCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
            productionCrew[1].Person.Should().NotBeNull();
            productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            productionCrew[1].Person.Ids.Should().NotBeNull();
            productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
            var artCrew = traktCrew.Art.ToArray();

            artCrew[0].Should().NotBeNull();
            artCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Artist");
            artCrew[0].Person.Should().NotBeNull();
            artCrew[0].Person.Name.Should().Be("Bryan Cranston");
            artCrew[0].Person.Ids.Should().NotBeNull();
            artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            artCrew[1].Should().NotBeNull();
            artCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Artist");
            artCrew[1].Person.Should().NotBeNull();
            artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            artCrew[1].Person.Ids.Should().NotBeNull();
            artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
            var crew = traktCrew.Crew.ToArray();

            crew[0].Should().NotBeNull();
            crew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member");
            crew[0].Person.Should().NotBeNull();
            crew[0].Person.Name.Should().Be("Bryan Cranston");
            crew[0].Person.Ids.Should().NotBeNull();
            crew[0].Person.Ids.Trakt.Should().Be(297737U);
            crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            crew[0].Person.Ids.Tmdb.Should().Be(17419U);
            crew[0].Person.Ids.TvRage.Should().Be(1797U);

            crew[1].Should().NotBeNull();
            crew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member");
            crew[1].Person.Should().NotBeNull();
            crew[1].Person.Name.Should().Be("Samuel L.Jackson");
            crew[1].Person.Ids.Should().NotBeNull();
            crew[1].Person.Ids.Trakt.Should().Be(9486U);
            crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            crew[1].Person.Ids.Tmdb.Should().Be(2231U);
            crew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

            costumeAndMakeupCrew[0].Should().NotBeNull();
            costumeAndMakeupCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Make-Up Artist");
            costumeAndMakeupCrew[0].Person.Should().NotBeNull();
            costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
            costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            costumeAndMakeupCrew[1].Should().NotBeNull();
            costumeAndMakeupCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Make-Up Artist");
            costumeAndMakeupCrew[1].Person.Should().NotBeNull();
            costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
            var directingCrew = traktCrew.Directing.ToArray();

            directingCrew[0].Should().NotBeNull();
            directingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            directingCrew[0].Person.Should().NotBeNull();
            directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
            directingCrew[0].Person.Ids.Should().NotBeNull();
            directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            directingCrew[1].Should().NotBeNull();
            directingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            directingCrew[1].Person.Should().NotBeNull();
            directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            directingCrew[1].Person.Ids.Should().NotBeNull();
            directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
            var writingCrew = traktCrew.Writing.ToArray();

            writingCrew[0].Should().NotBeNull();
            writingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer");
            writingCrew[0].Person.Should().NotBeNull();
            writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
            writingCrew[0].Person.Ids.Should().NotBeNull();
            writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            writingCrew[1].Should().NotBeNull();
            writingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer");
            writingCrew[1].Person.Should().NotBeNull();
            writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            writingCrew[1].Person.Ids.Should().NotBeNull();
            writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
            var soundCrew = traktCrew.Sound.ToArray();

            soundCrew[0].Should().NotBeNull();
            soundCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer");
            soundCrew[0].Person.Should().NotBeNull();
            soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
            soundCrew[0].Person.Ids.Should().NotBeNull();
            soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            soundCrew[1].Should().NotBeNull();
            soundCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer");
            soundCrew[1].Person.Should().NotBeNull();
            soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            soundCrew[1].Person.Ids.Should().NotBeNull();
            soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
            var cameraCrew = traktCrew.Camera.ToArray();

            cameraCrew[0].Should().NotBeNull();
            cameraCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera");
            cameraCrew[0].Person.Should().NotBeNull();
            cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
            cameraCrew[0].Person.Ids.Should().NotBeNull();
            cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            cameraCrew[1].Should().NotBeNull();
            cameraCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera");
            cameraCrew[1].Person.Should().NotBeNull();
            cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            cameraCrew[1].Person.Ids.Should().NotBeNull();
            cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
            var lightingCrew = traktCrew.Lighting.ToArray();

            lightingCrew[0].Should().NotBeNull();
            lightingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician");
            lightingCrew[0].Person.Should().NotBeNull();
            lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
            lightingCrew[0].Person.Ids.Should().NotBeNull();
            lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            lightingCrew[1].Should().NotBeNull();
            lightingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician");
            lightingCrew[1].Person.Should().NotBeNull();
            lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            lightingCrew[1].Person.Ids.Should().NotBeNull();
            lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            var vfxCrew = traktCrew.VisualEffects.ToArray();

            vfxCrew[0].Should().NotBeNull();
            vfxCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist");
            vfxCrew[0].Person.Should().NotBeNull();
            vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
            vfxCrew[0].Person.Ids.Should().NotBeNull();
            vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            vfxCrew[1].Should().NotBeNull();
            vfxCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist");
            vfxCrew[1].Person.Should().NotBeNull();
            vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            vfxCrew[1].Person.Ids.Should().NotBeNull();
            vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

            traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
            var editingCrew = traktCrew.Editing.ToArray();

            editingCrew[0].Should().NotBeNull();
            editingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor");
            editingCrew[0].Person.Should().NotBeNull();
            editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
            editingCrew[0].Person.Ids.Should().NotBeNull();
            editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
            editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
            editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
            editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

            editingCrew[1].Should().NotBeNull();
            editingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor");
            editingCrew[1].Person.Should().NotBeNull();
            editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
            editingCrew[1].Person.Ids.Should().NotBeNull();
            editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
            editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
            editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
            editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
            editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
        }

        private const string JSON =
            @"{
                ""production"": [
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ]
              }";
    }
}
