namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktPutRequestGeneratorTests
    {
        [Fact]
        public Task TestGeneratePutRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequest", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestExtendedInfo", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestOAuth", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestAll", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string?}")]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestNullableParameter", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterExtendedInfo", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterPagination", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterOAuth", source, RequestTestType.PutRequest);
        }

        [Fact]
        public Task TestGeneratePutRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPutRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPutRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPutRequestSourceGenerator>("Requests", "SourceGeneration.PutRequestParameterAll", source, RequestTestType.PutRequest);
        }
    }
}
