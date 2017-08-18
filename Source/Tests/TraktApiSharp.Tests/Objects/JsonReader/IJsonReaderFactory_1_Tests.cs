namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class IJsonReaderFactory_1_Tests
    {
        [Fact]
        public void Test_IJsonReaderFactory_1_Is_Interface()
        {
            typeof(IJsonReaderFactory<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IJsonReaderFactory_1_Has_Generic_TypeParameter()
        {
            typeof(IJsonReaderFactory<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IJsonReaderFactory<object>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IJsonReaderFactory_1_Has_CreateObjectReader_Method()
        {
            var methodInfo = typeof(IJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateObjectReader");

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(ITraktObjectJsonReader<object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [Fact]
        public void Test_IJsonReaderFactory_1_Has_CreateArrayReader_Method()
        {
            var methodInfo = typeof(IJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateArrayReader");

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(IArrayJsonReader<object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
