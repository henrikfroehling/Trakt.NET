namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktScrobbleActionTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktScrobbleActionType>))]
            public TraktScrobbleActionType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeIsTraktEnumeration()
        {
            var enumeration = new TraktScrobbleActionType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktScrobbleActionTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktScrobbleActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktScrobbleActionType>() { TraktScrobbleActionType.Unspecified, TraktScrobbleActionType.Start,
                                                                             TraktScrobbleActionType.Pause, TraktScrobbleActionType.Stop });
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
