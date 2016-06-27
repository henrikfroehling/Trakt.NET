namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktScrobbleActionTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktScrobbleActionTypeConverter))]
            public TraktScrobbleActionType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeHasMembers()
        {
            typeof(TraktScrobbleActionType).GetEnumNames().Should().HaveCount(4)
                                                          .And.Contain("Unspecified", "Start", "Pause", "Stop");
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeGetAsString()
        {
            TraktScrobbleActionType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktScrobbleActionType.Start.AsString().Should().Be("start");
            TraktScrobbleActionType.Pause.AsString().Should().Be("pause");
            TraktScrobbleActionType.Stop.AsString().Should().Be("scrobble");
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeWriteAndReadJson_Start()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Start };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Start);
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeWriteAndReadJson_Pause()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Pause };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Pause);
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeWriteAndReadJson_Stop()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Stop };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Stop);
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Unspecified);
        }
    }
}
