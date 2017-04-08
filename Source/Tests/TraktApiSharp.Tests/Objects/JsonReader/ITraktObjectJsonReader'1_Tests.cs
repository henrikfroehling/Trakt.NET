namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class ITraktObjectJsonReader_1_Tests
    {
        [Fact]
        public void Test_ITraktObjectJsonReader_1_Is_Interface()
        {
            typeof(ITraktObjectJsonReader<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktObjectJsonReader_1_Has_ReadObjectAsync_From_Json_Method()
        {
            var methodInfo = typeof(ITraktObjectJsonReader<object>).GetMethods()
                .Where(m => m.Name == "ReadObjectAsync" && m.GetParameters().Length == 2)
                .FirstOrDefault(m => m.GetParameters()[0].ParameterType == typeof(string)
                                     && m.GetParameters()[1].ParameterType == typeof(CancellationToken));

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(Task<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(2);

            var parameterInfo = methodInfo.GetParameters()[0];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("json");

            parameterInfo = methodInfo.GetParameters()[1];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(CancellationToken));
            parameterInfo.Name.Should().Be("cancellationToken");
        }

        [Fact]
        public void Test_ITraktObjectJsonReader_1_Has_ReadObjectAsync_From_Stream_Method()
        {
            var methodInfo = typeof(ITraktObjectJsonReader<object>).GetMethods()
                .Where(m => m.Name == "ReadObjectAsync" && m.GetParameters().Length == 2)
                .FirstOrDefault(m => m.GetParameters()[0].ParameterType == typeof(Stream)
                                     && m.GetParameters()[1].ParameterType == typeof(CancellationToken));

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(Task<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(2);

            var parameterInfo = methodInfo.GetParameters()[0];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(Stream));
            parameterInfo.Name.Should().Be("stream");

            parameterInfo = methodInfo.GetParameters()[1];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(CancellationToken));
            parameterInfo.Name.Should().Be("cancellationToken");
        }

        [Fact]
        public void Test_ITraktObjectJsonReader_1_Has_ReadObjectAsync_From_JsonReader_Method()
        {
            var methodInfo = typeof(ITraktObjectJsonReader<object>).GetMethods()
                .Where(m => m.Name == "ReadObjectAsync" && m.GetParameters().Length == 2)
                .FirstOrDefault(m => m.GetParameters()[0].ParameterType == typeof(JsonTextReader)
                                     && m.GetParameters()[1].ParameterType == typeof(CancellationToken));

            methodInfo.Should().NotBeNull();
            methodInfo.ReturnType.Should().Be(typeof(Task<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(2);

            var parameterInfo = methodInfo.GetParameters()[0];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(JsonTextReader));
            parameterInfo.Name.Should().Be("jsonReader");

            parameterInfo = methodInfo.GetParameters()[1];

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(CancellationToken));
            parameterInfo.Name.Should().Be("cancellationToken");
        }
    }
}
