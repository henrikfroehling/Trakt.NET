namespace TraktNET.SourceGeneration.Enums
{
    public sealed class TraktEnumAttributeGeneratorTests
    {
        [Fact]
        public Task GeneratesEnumExtensionsCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithCustomEnumMemberCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumMemberTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithCustomEnumMemberEmptyJsonValueCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumMemberEmptyJsonValueTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithCustomEnumMemberEmptyDisplayNameCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumMemberEmptyDisplayNameTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithCustomEnumMemberNullJsonValueDiagnosticsCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumMemberNullJsonValueDiagnosticsTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithCustomEnumMemberNullDisplayNameDiagnosticsCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("Enums", "SourceGeneration.EnumMemberNullDisplayNameDiagnosticsTests", source);
        }
    }
}
