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
            var nullResult = default(TraktSearchField);

            var result = nullResult | TraktSearchField.Title;
            result.Should().BeNull();

            result = TraktSearchField.Title | nullResult;
            result.Should().BeNull();

            result = nullResult | nullResult;
            result.Should().BeNull();

            // -----------------------------------------------------

            result = TraktSearchField.Title | TraktSearchField.Unspecified;
            result.Should().Be(TraktSearchField.Unspecified);

            result = TraktSearchField.Unspecified | TraktSearchField.Title;
            result.Should().Be(TraktSearchField.Unspecified);

            result = TraktSearchField.Unspecified | TraktSearchField.Unspecified;
            result.Should().Be(TraktSearchField.Unspecified);

            // -----------------------------------------------------

            result = TraktSearchField.Title;

            result.Value.Should().Be(1);
            result.ObjectName.Should().Be("title");
            result.UriName.Should().Be("title");
            result.DisplayName.Should().Be("Title");

            var oldResult = result;
            result = TraktSearchField.Title | TraktSearchField.Tagline;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Tagline.Value);
            result.ObjectName.Should().Be("title,tagline");
            result.UriName.Should().Be("title,tagline");
            result.DisplayName.Should().Be("Title, Tagline");

            oldResult = result;
            result = result | TraktSearchField.Overview;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Overview.Value);
            result.ObjectName.Should().Be("title,tagline,overview");
            result.UriName.Should().Be("title,tagline,overview");
            result.DisplayName.Should().Be("Title, Tagline, Overview");

            oldResult = result;
            result = result | TraktSearchField.People;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.People.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people");
            result.UriName.Should().Be("title,tagline,overview,people");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People");

            oldResult = result;
            result = result | TraktSearchField.Translations;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Translations.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations");
            result.UriName.Should().Be("title,tagline,overview,people,translations");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations");

            oldResult = result;
            result = result | TraktSearchField.Aliases;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Aliases.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases");

            oldResult = result;
            result = result | TraktSearchField.Name;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Name.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name");

            oldResult = result;
            result = result | TraktSearchField.Biography;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Biography.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name, Biography");

            oldResult = result;
            result = result | TraktSearchField.Description;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Description.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography,description");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography,description");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name, Biography, Description");
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
