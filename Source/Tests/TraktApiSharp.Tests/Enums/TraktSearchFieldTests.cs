namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchFieldTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSearchField>))]
            public TraktSearchField Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSearchFieldIsTraktEnumeration()
        {
            var enumeration = new TraktSearchField();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSearchFieldGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchField>();

            allValues.Should().NotBeNull().And.HaveCount(10);
            allValues.Should().Contain(new List<TraktSearchField>() { TraktSearchField.Unspecified, TraktSearchField.Title,
                                                                      TraktSearchField.Tagline, TraktSearchField.Overview,
                                                                      TraktSearchField.People, TraktSearchField.Translations,
                                                                      TraktSearchField.Aliases, TraktSearchField.Name,
                                                                      TraktSearchField.Biography, TraktSearchField.Description });
        }

        [TestMethod]
        public void TestTraktSearchFieldOrOperator()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Title()
        {
            var obj = new TestObject { Value = TraktSearchField.Title };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Title);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Tagline()
        {
            var obj = new TestObject { Value = TraktSearchField.Tagline };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Tagline);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Overview()
        {
            var obj = new TestObject { Value = TraktSearchField.Overview };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Overview);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_People()
        {
            var obj = new TestObject { Value = TraktSearchField.People };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.People);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Translations()
        {
            var obj = new TestObject { Value = TraktSearchField.Translations };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Translations);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Aliases()
        {
            var obj = new TestObject { Value = TraktSearchField.Aliases };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Aliases);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Name()
        {
            var obj = new TestObject { Value = TraktSearchField.Name };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Name);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Biography()
        {
            var obj = new TestObject { Value = TraktSearchField.Biography };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Biography);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Description()
        {
            var obj = new TestObject { Value = TraktSearchField.Description };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Description);
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSearchField.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Unspecified);
        }
    }
}
