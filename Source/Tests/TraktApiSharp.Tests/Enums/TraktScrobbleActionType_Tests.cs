namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktScrobbleActionType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktScrobbleActionType>))]
            public TraktScrobbleActionType Value { get; set; }
        }

        [Fact]
        public void Test_TraktScrobbleActionType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktScrobbleActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktScrobbleActionType>() { TraktScrobbleActionType.Unspecified, TraktScrobbleActionType.Start,
                                                                             TraktScrobbleActionType.Pause, TraktScrobbleActionType.Stop });
        }

        [Fact]
        public void Test_TraktScrobbleActionType_WriteAndReadJson_Start()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Start };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Start);
        }

        [Fact]
        public void Test_TraktScrobbleActionType_WriteAndReadJson_Pause()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Pause };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Pause);
        }

        [Fact]
        public void Test_TraktScrobbleActionType_WriteAndReadJson_Stop()
        {
            var obj = new TestObject { Value = TraktScrobbleActionType.Stop };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktScrobbleActionType.Stop);
        }

        [Fact]
        public void Test_TraktScrobbleActionType_WriteAndReadJson_Unspecified()
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
