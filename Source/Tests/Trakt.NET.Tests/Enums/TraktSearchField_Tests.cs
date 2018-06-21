namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSearchField_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSearchField>))]
            public TraktSearchField Value { get; set; }
        }

        [Fact]
        public void Test_TraktSearchField_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchField>();

            allValues.Should().NotBeNull().And.HaveCount(10);
            allValues.Should().Contain(new List<TraktSearchField>() { TraktSearchField.Unspecified, TraktSearchField.Title,
                                                                      TraktSearchField.Tagline, TraktSearchField.Overview,
                                                                      TraktSearchField.People, TraktSearchField.Translations,
                                                                      TraktSearchField.Aliases, TraktSearchField.Name,
                                                                      TraktSearchField.Biography, TraktSearchField.Description });
        }

        [Fact]
        public void Test_TraktSearchField_OrOperator()
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
            result |= TraktSearchField.Overview;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Overview.Value);
            result.ObjectName.Should().Be("title,tagline,overview");
            result.UriName.Should().Be("title,tagline,overview");
            result.DisplayName.Should().Be("Title, Tagline, Overview");

            oldResult = result;
            result |= TraktSearchField.People;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.People.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people");
            result.UriName.Should().Be("title,tagline,overview,people");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People");

            oldResult = result;
            result |= TraktSearchField.Translations;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Translations.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations");
            result.UriName.Should().Be("title,tagline,overview,people,translations");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations");

            oldResult = result;
            result |= TraktSearchField.Aliases;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Aliases.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases");

            oldResult = result;
            result |= TraktSearchField.Name;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Name.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name");

            oldResult = result;
            result |= TraktSearchField.Biography;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Biography.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name, Biography");

            oldResult = result;
            result |= TraktSearchField.Description;

            result.Value.Should().Be(oldResult.Value | TraktSearchField.Description.Value);
            result.ObjectName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography,description");
            result.UriName.Should().Be("title,tagline,overview,people,translations,aliases,name,biography,description");
            result.DisplayName.Should().Be("Title, Tagline, Overview, People, Translations, Aliases, Name, Biography, Description");
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Title()
        {
            var obj = new TestObject { Value = TraktSearchField.Title };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Title);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Tagline()
        {
            var obj = new TestObject { Value = TraktSearchField.Tagline };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Tagline);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Overview()
        {
            var obj = new TestObject { Value = TraktSearchField.Overview };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Overview);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_People()
        {
            var obj = new TestObject { Value = TraktSearchField.People };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.People);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Translations()
        {
            var obj = new TestObject { Value = TraktSearchField.Translations };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Translations);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Aliases()
        {
            var obj = new TestObject { Value = TraktSearchField.Aliases };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Aliases);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Name()
        {
            var obj = new TestObject { Value = TraktSearchField.Name };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Name);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Biography()
        {
            var obj = new TestObject { Value = TraktSearchField.Biography };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Biography);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Description()
        {
            var obj = new TestObject { Value = TraktSearchField.Description };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchField.Description);
        }

        [Fact]
        public void Test_TraktSearchField_WriteAndReadJson_Unspecified()
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
