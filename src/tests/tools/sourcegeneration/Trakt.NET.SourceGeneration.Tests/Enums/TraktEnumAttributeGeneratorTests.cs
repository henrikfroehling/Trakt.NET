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

            return TestHelper.Verify<TraktEnumSourceGenerator>("SourceGeneration.EnumTests", source);
        }

        [Fact]
        public Task GeneratesEnumExtensionsWithEnumMemberAttributesCorrectly()
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

            return TestHelper.Verify<TraktEnumSourceGenerator>("SourceGeneration.EnumMemberTests", source);
        }
    }
}
