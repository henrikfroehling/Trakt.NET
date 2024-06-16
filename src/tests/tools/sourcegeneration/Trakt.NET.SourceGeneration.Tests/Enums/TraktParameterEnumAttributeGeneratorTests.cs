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

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("SourceGeneration.ParameterEnumTests", source);
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

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("SourceGeneration.ParameterEnumFlagsTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithEnumMemberAttributesCorrectly()
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

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("SourceGeneration.ParameterEnumMemberTests", source);
        }

        [Fact]
        public Task GeneratesParameterEnumExtensionsWithEnumMemberAttributesAndFlagsCorrectly()
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

            return TestHelper.Verify<TraktParameterEnumSourceGenerator>("SourceGeneration.ParameterEnumMemberFlagsTests", source);
        }
    }
}
