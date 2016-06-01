namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktScrobbleModuleTests
    {
        [TestMethod]
        public void TestTraktScrobbleModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktScrobbleModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StartMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovie()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PauseMovie

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovie()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovie()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulevMovieWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StartEpisode

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PauseMovie

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulevEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
