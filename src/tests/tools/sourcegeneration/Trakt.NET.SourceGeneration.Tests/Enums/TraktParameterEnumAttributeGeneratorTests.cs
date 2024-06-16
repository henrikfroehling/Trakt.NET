namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktParameterEnumAttributeGeneratorTests
    {
        [Fact]
        public Task GeneratesParameterEnumExtensionsCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithFlagsAttributeCorrectly()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumFlagsTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember("first_value")]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberAndFlagsAttributeCorrectly()
        {
            string source = """
                using System;
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    [Flags]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember("first_value")]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberFlagsTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsEmptyParameterDiagnosticsCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("")]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumNullParameterDiagnosticTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsNullParameterDiagnosticsCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum(null)]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumNullParameterDiagnosticTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberEmptyJsonValueCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember("")]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberEmptyJsonValueTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberEmptyDisplayNameCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember("first_value")]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = "")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberEmptyDisplayNameTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberNullJsonValueCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember(null)]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = "Value Nr. 2")]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberNullJsonValueTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithCustomEnumMemberNullDisplayNameCorrectly()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktParameterEnum("testenum")]
                    public enum TestEnum
                    {
                        Unspecified,
                
                        [TraktEnumMember("first_value")]
                        ValueOne,
                
                        [TraktEnumMember("second_value", DisplayName = null)]
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("Enums", "SourceGeneration.ParameterEnumMemberNullDisplayNameTests", source);
        }
    }
}
