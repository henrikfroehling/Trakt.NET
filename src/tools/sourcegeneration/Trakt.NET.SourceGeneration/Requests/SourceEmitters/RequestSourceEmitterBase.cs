using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    public abstract class RequestSourceEmitterBase<T>(SourceProductionContext context) : SourceEmitter<T>(context) where T : RequestGenerationSpecification
    {
        private static readonly IReadOnlyList<string> Usings = [];

        protected SourceWriter _sourceWriter = new();

        protected string _requestName = string.Empty;
        protected string _requestNamespace = string.Empty;
        protected string _httpMethodValue = string.Empty;
        protected string _uriPath = string.Empty;
        protected string _oauthRequirementValue = string.Empty;
        protected bool _supportsExtendedInfo;
        protected bool _supportsPagination;
        protected bool _hasOAuthRequirementDefined;

        public override void Emit(T generationSpecification)
        {
            if (generationSpecification == null)
            {
                return;
            }

            Setup(generationSpecification);

            WriteHeaderAndUsings();
            WriteNamespaceStart();
            WriteRequestClass();
            WriteNamespaceEnd();

            AddSource(_requestName + Constants.GeneratedFilenameSuffix, _sourceWriter.ToSourceText());
        }

        protected virtual void Setup(T enumGenerationSpecification)
        {
            _requestName = enumGenerationSpecification.Name;
            _requestNamespace = enumGenerationSpecification.Namespace!;
            _httpMethodValue = enumGenerationSpecification.HttpMethodValue;
            _uriPath = enumGenerationSpecification.UriPath;
            _oauthRequirementValue = enumGenerationSpecification.OAuthRequirementValue;
            _supportsExtendedInfo = enumGenerationSpecification.SupportsExtendedInfo;
            _supportsPagination = enumGenerationSpecification.SupportsPagination;
            _hasOAuthRequirementDefined = enumGenerationSpecification.HasOAuthRequirementDefined;
        }

        private void WriteHeaderAndUsings()
        {
            _sourceWriter.WriteLine(Constants.Header);

            foreach (string @using in Usings)
            {
                _sourceWriter.WriteLine($"using {@using};");
            }

            if (Usings.Count > 0)
            {
                _sourceWriter.WriteEmptyLine();
            }
        }

        private void WriteNamespaceStart()
        {
            _sourceWriter.WriteLine($"namespace {_requestNamespace}");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
        }

        private void WriteNamespaceEnd()
        {
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteRequestClass()
        {
            _sourceWriter.WriteLine($"internal sealed partial class {_requestName} : HttpRequestMessage");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            WriteRequestClassContent();

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        protected virtual void WriteRequestClassContent()
        {
            bool needsEmptyLine = false;

            if (_supportsExtendedInfo)
            {
                WriteExtendedInfoProperty();
                needsEmptyLine = true;
            }

            if (_supportsPagination)
            {
                if (needsEmptyLine)
                {
                    _sourceWriter.WriteEmptyLine();
                }
                else
                {
                    needsEmptyLine = true;
                }

                WritePaginationProperties();
            }

            if (_hasOAuthRequirementDefined)
            {
                if (needsEmptyLine)
                {
                    _sourceWriter.WriteEmptyLine();
                }
                else
                {
                    needsEmptyLine = true;
                }

                WirteOAuthRequirementProperty();
            }

            if (needsEmptyLine)
            {
                _sourceWriter.WriteEmptyLine();
            }

            WriteRequestConstructor();
            _sourceWriter.WriteEmptyLine();

            WriteBuildUriMethod();
        }

        private void WriteExtendedInfoProperty()
            => _sourceWriter.WriteLine("internal TraktExtendedInfo? ExtendedInfo { get; set; }");

        private void WritePaginationProperties()
        {
            _sourceWriter.WriteLine("internal uint? Page { get; set; }");
            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine("internal uint? Limit { get; set; }");
        }

        private void WirteOAuthRequirementProperty()
            => _sourceWriter.WriteLine($"internal TraktOAuthRequirement OAuthRequirement {{ get; }} = TraktOAuthRequirement.{_oauthRequirementValue};");

        private void WriteRequestConstructor()
            => _sourceWriter.WriteLine($"private {_requestName}() : base(HttpMethod.{_httpMethodValue}, (Uri?)null) {{}}");

        private void WriteBuildUriMethod()
        {
            _sourceWriter.WriteLine("internal void BuildUri()");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            const string requestUriName = "requestUri";
            const string firstParameterName = "firstParameter";

            // TODO Parse URI path parameters and encode URI path

            _sourceWriter.WriteLine($"string {requestUriName} = \"{_uriPath}\";");

            if (_supportsExtendedInfo || _supportsPagination)
            {
                _sourceWriter.WriteLine($"bool {firstParameterName} = true;");
            }

            if (_supportsExtendedInfo)
            {
                _sourceWriter.WriteEmptyLine();
                WriteBuildUriExtendedInfo(requestUriName, firstParameterName);
            }

            if (_supportsPagination)
            {
                _sourceWriter.WriteEmptyLine();
                WriteBuildUriPagination(requestUriName, firstParameterName);
            }

            _sourceWriter.WriteEmptyLine();

            _sourceWriter.WriteLine($"RequestUri = new Uri({requestUriName});");

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteBuildUriExtendedInfo(string requestUriName, string firstParameterName)
        {
            _sourceWriter.WriteLine("if (ExtendedInfo.HasValue)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"if ({firstParameterName})");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"?{{ExtendedInfo.Value.ToUriPath()}}\";");
            _sourceWriter.WriteLine($"{firstParameterName} = false;");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.WriteLine("else");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"&{{ExtendedInfo.Value.ToUriPath()}}\";");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteBuildUriPagination(string requestUriName, string firstParameterName)
        {
            WriteBuildUriPaginationPage(requestUriName, firstParameterName);
            _sourceWriter.WriteEmptyLine();
            WriteBuildUriPaginationLimit(requestUriName, firstParameterName);
        }

        private void WriteBuildUriPaginationPage(string requestUriName, string firstParameterName)
        {
            _sourceWriter.WriteLine("if (Page.HasValue)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"if ({firstParameterName})");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"?page={{Page.Value}}\";");
            _sourceWriter.WriteLine($"{firstParameterName} = false;");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.WriteLine("else");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"&page={{Page.Value}}\";");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteBuildUriPaginationLimit(string requestUriName, string firstParameterName)
        {
            _sourceWriter.WriteLine("if (Limit.HasValue)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"if ({firstParameterName})");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"?limit={{Limit.Value}}\";");
            _sourceWriter.WriteLine($"{firstParameterName} = false;");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.WriteLine("else");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{requestUriName} += $\"&limit={{Limit.Value}}\";");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }
    }
}
