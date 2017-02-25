namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class ITraktArrayJsonReader_1_Tests
    {
        [Fact]
        public void Test_ITraktArrayJsonReader_1_Is_Interface()
        {
            typeof(ITraktArrayJsonReader<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktArrayJsonReader_1_Has_ReadArray_From_Json_Method()
        {
            var methodInfo = typeof(ITraktArrayJsonReader<object>).GetMethods()
                .Where(m => m.Name == "ReadArray" && m.GetParameters().Length == 1)
                .FirstOrDefault(m => m.GetParameters()[0].ParameterType == typeof(string));

            methodInfo.ReturnType.Should().Be(typeof(IEnumerable<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("json");
        }

        [Fact]
        public void Test_ITraktArrayJsonReader_1_Has_ReadArray_From_JsonReader_Method()
        {
            var methodInfo = typeof(ITraktArrayJsonReader<object>).GetMethods()
                .Where(m => m.Name == "ReadArray" && m.GetParameters().Length == 1)
                .FirstOrDefault(m => m.GetParameters()[0].ParameterType == typeof(JsonTextReader));

            methodInfo.ReturnType.Should().Be(typeof(IEnumerable<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(JsonTextReader));
            parameterInfo.Name.Should().Be("jsonReader");
        }
    }
}
