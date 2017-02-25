namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class TraktJsonReaderFactory_1_Tests
    {
        public class FakeObjectJsonReader : ITraktObjectJsonReader<object>
        {
            public object ReadObject(string json)
            {
                throw new NotImplementedException();
            }

            public object ReadObject(JsonTextReader jsonReader)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeArrayJsonReader : ITraktArrayJsonReader<object>
        {
            public IEnumerable<object> ReadArray(string json)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_Generic_TypeParameter()
        {
            typeof(TraktJsonReaderFactory<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktJsonReaderFactory<object>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_RegisterObjectReader_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "RegisterObjectReader");

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(2);

            var parameterInfos = methodInfo.GetParameters().ToArray();

            parameterInfos[0].Should().NotBeNull();
            parameterInfos[0].ParameterType.Should().Be(typeof(Func<ITraktObjectJsonReader<object>>));
            parameterInfos[0].Name.Should().Be("creatorFunction");

            parameterInfos[1].Should().NotBeNull();
            parameterInfos[1].ParameterType.Should().Be(typeof(string));
            parameterInfos[1].Name.Should().Be("key");
            parameterInfos[1].DefaultValue.Should().Be("default");
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_RegisterArrayReader_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "RegisterArrayReader");

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(2);

            var parameterInfos = methodInfo.GetParameters().ToArray();

            parameterInfos[0].Should().NotBeNull();
            parameterInfos[0].ParameterType.Should().Be(typeof(Func<ITraktArrayJsonReader<object>>));
            parameterInfos[0].Name.Should().Be("creatorFunction");

            parameterInfos[1].Should().NotBeNull();
            parameterInfos[1].ParameterType.Should().Be(typeof(string));
            parameterInfos[1].Name.Should().Be("key");
            parameterInfos[1].DefaultValue.Should().Be("default");
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_CreateObjectReader_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateObjectReader");

            methodInfo.ReturnType.Should().Be(typeof(ITraktObjectJsonReader<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("key");
            parameterInfo.DefaultValue.Should().Be("default");
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_CreateArrayReader_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "CreateArrayReader");

            methodInfo.ReturnType.Should().Be(typeof(ITraktArrayJsonReader<object>));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("key");
            parameterInfo.DefaultValue.Should().Be("default");
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_ClearObjectReaders_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "ClearObjectReaders");

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_ClearArrayReaders_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "ClearArrayReaders");

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_Has_ClearAllReaders_Method()
        {
            var methodInfo = typeof(TraktJsonReaderFactory<object>).GetMethods().FirstOrDefault(m => m.Name == "ClearAllReaders");

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterObjectReader()
        {
            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader());

            var objectReader = TraktJsonReaderFactory<object>.CreateObjectReader();
            objectReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterArrayReader()
        {
            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader());

            var arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader();
            arrayReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterObjectReader_With_Custom_Key()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader(), key);

            var objectReader = TraktJsonReaderFactory<object>.CreateObjectReader(key);
            objectReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterArrayReader_With_Custom_Key()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader(), key);

            var arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader(key);
            arrayReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterObjectReader_With_Existing_Key()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader(), key);
            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader(), key);

            var objectReader = TraktJsonReaderFactory<object>.CreateObjectReader(key);
            objectReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterArrayReader_With_Existing_Key()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader(), key);
            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader(), key);

            var arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader(key);
            arrayReader.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterObjectReader_ArgumentExceptions()
        {
            TraktJsonReaderFactory<object>.ClearAllReaders();

            Action act = () => TraktJsonReaderFactory<object>.CreateObjectReader();
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_RegisterArrayReader_ArgumentExceptions()
        {
            TraktJsonReaderFactory<object>.ClearAllReaders();

            Action act = () => TraktJsonReaderFactory<object>.CreateArrayReader();
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_ClearObjectReaders()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader());
            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader(), key);

            var objectReader = TraktJsonReaderFactory<object>.CreateObjectReader();
            objectReader.Should().NotBeNull();

            objectReader = TraktJsonReaderFactory<object>.CreateObjectReader(key);
            objectReader.Should().NotBeNull();

            TraktJsonReaderFactory<object>.ClearObjectReaders();

            Action act = () => TraktJsonReaderFactory<object>.CreateObjectReader();
            act.ShouldThrow<ArgumentException>();

            act = () => TraktJsonReaderFactory<object>.CreateObjectReader(key);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_ClearArrayReaders()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader());
            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader(), key);

            var arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader();
            arrayReader.Should().NotBeNull();

            arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader(key);
            arrayReader.Should().NotBeNull();

            TraktJsonReaderFactory<object>.ClearArrayReaders();

            Action act = () => TraktJsonReaderFactory<object>.CreateArrayReader();
            act.ShouldThrow<ArgumentException>();

            act = () => TraktJsonReaderFactory<object>.CreateArrayReader(key);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Test_TraktJsonReaderFactory_1_ClearAllReaders()
        {
            const string key = "fake_reader";

            TraktJsonReaderFactory<object>.ClearAllReaders();

            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader());
            TraktJsonReaderFactory<object>.RegisterObjectReader(() => new FakeObjectJsonReader(), key);

            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader());
            TraktJsonReaderFactory<object>.RegisterArrayReader(() => new FakeArrayJsonReader(), key);

            var objectReader = TraktJsonReaderFactory<object>.CreateObjectReader();
            objectReader.Should().NotBeNull();

            objectReader = TraktJsonReaderFactory<object>.CreateObjectReader(key);
            objectReader.Should().NotBeNull();

            var arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader();
            arrayReader.Should().NotBeNull();

            arrayReader = TraktJsonReaderFactory<object>.CreateArrayReader(key);
            arrayReader.Should().NotBeNull();

            TraktJsonReaderFactory<object>.ClearAllReaders();

            Action act = () => TraktJsonReaderFactory<object>.CreateObjectReader();
            act.ShouldThrow<ArgumentException>();

            act = () => TraktJsonReaderFactory<object>.CreateObjectReader(key);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktJsonReaderFactory<object>.CreateArrayReader();
            act.ShouldThrow<ArgumentException>();

            act = () => TraktJsonReaderFactory<object>.CreateArrayReader(key);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
