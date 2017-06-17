namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class ITraktJsonReaderFactory_1_Tests
    {
        [Fact]
        public void Test_ITraktJsonReaderFactory_1_Is_Interface()
        {
            typeof(ITraktJsonReaderFactory<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktJsonReaderFactory_1_Has_Generic_TypeParameter()
        {
            typeof(ITraktJsonReaderFactory<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktJsonReaderFactory<object>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktJsonReaderFactory_1_Has_CreateObjectReader_Method()
        {
            var methodInfo = typeof(ITraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateObjectReader");

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(ITraktObjectJsonReader<object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [Fact]
        public void Test_ITraktJsonReaderFactory_1_Has_CreateArrayReader_Method()
        {
            var methodInfo = typeof(ITraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateArrayReader");

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(ITraktArrayJsonReader<object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
