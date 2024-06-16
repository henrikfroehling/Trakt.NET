namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktEnumGeneratorTests
    {
        [Fact]
        public Task TestGeneratesEnumExtensions()
        {
            string source = """
                using TraktNET;

                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
                    public enum TestEnum
                    {
                        Unspecified,
                        ValueOne,
                        ValueTwo
                    }
                }
                """;

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumTests", source);
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMember()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberTests", source);
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyJsonValue()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberEmptyJsonValueTests", source);
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberEmptyDisplayName()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberEmptyDisplayNameTests", source);
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberNullJsonValueDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberNullJsonValueDiagnosticsTests", source);
        }

        [Fact]
        public Task TestGeneratesEnumExtensionsWithCustomEnumMemberNullDisplayNameDiagnostics()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktEnum]
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums",
                "SourceGeneration.EnumMemberNullDisplayNameDiagnosticsTests", source);
        }
    }
}
