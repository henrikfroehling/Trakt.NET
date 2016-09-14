namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
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
            //allValues.Should().Contain(new List<TraktSearchField>() { TraktSearchField.Unspecified, TraktSearchField.Title,
            //                                                          TraktSearchField.Tagline, TraktSearchField.Overview,
            //                                                          TraktSearchField.People, TraktSearchField.Translations,
            //                                                          TraktSearchField.Aliases, TraktSearchField.Name,
            //                                                          TraktSearchField.Biography, TraktSearchField.Description });
        }

        [TestMethod]
        public void TestTraktSearchFieldOrOperator()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Title()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Tagline()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Overview()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_People()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Translations()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Aliases()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Name()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Biography()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Description()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchFieldWriteAndReadJson_Unspecified()
        {
            Assert.Fail();
        }
    }
}
