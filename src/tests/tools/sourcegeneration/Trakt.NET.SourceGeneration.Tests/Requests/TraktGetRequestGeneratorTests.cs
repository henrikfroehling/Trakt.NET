namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktGetRequestGeneratorTests
    {
        [Fact]
        public Task TestGenerateGetRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequest", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestExtendedInfo", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestPagination", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestOAuth", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestAll", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameter", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string?}")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestNullableParameter", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterExtendedInfo", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterPagination", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterOAuth", source, RequestTestType.GetRequest);
        }

        [Fact]
        public Task TestGenerateGetRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequestParameterAll", source, RequestTestType.GetRequest);
        }
    }
}
