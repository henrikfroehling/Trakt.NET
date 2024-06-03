using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class RequestSourceEmitter(SourceProductionContext context) : SourceEmitter<RequestGenerationSpecification>(context)
    {
        private static readonly IReadOnlyList<string> Usings = [];

        private readonly SourceWriter _sourceWriter = new();

        private string _requestName = string.Empty;
        private string _requestNamespace = string.Empty;
        private string _httpMethodValue = string.Empty;
        private string _uriPath = string.Empty;
        private string _oauthRequirementValue = string.Empty;
        private bool _supportsExtendedInfo;
        private bool _supportsPagination;
        private bool _hasOAuthRequirementDefined;

        private readonly List<UriSegment> _uriSegments = [];
        private readonly List<PlaceHolder> _uriPlaceHolders = [];

        public override void Emit(RequestGenerationSpecification generationSpecification)
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

        private void Setup(RequestGenerationSpecification enumGenerationSpecification)
        {
            _requestName = enumGenerationSpecification.Name;
            _requestNamespace = enumGenerationSpecification.Namespace!;
            _httpMethodValue = enumGenerationSpecification.HttpMethodValue;
            _uriPath = enumGenerationSpecification.UriPath;
            _oauthRequirementValue = enumGenerationSpecification.OAuthRequirementValue;
            _supportsExtendedInfo = enumGenerationSpecification.SupportsExtendedInfo;
            _supportsPagination = enumGenerationSpecification.SupportsPagination;
            _hasOAuthRequirementDefined = enumGenerationSpecification.HasOAuthRequirementDefined;

            ParseRequestUri();
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

        private void WriteRequestClassContent()
        {
            bool needsEmptyLine = false;

            if (_uriPlaceHolders.Count > 0)
            {
                foreach (PlaceHolder placeHolder in _uriPlaceHolders)
                {
                    string modifier = "internal";
                    string setOrInit = "set";

                    // TODO Check for language support for "required" and "init" keywords
                    //if (placeHolder.IsRequired)
                    //{
                    //    modifier += " required";
                    //    setOrInit = "init";
                    //}

                    _sourceWriter.WriteLine($"{modifier} {placeHolder.ValueType} {placeHolder.Name} {{ get; {setOrInit}; }}");
                    _sourceWriter.WriteEmptyLine();
                }
            }

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

        private string BuildUriPath()
        {
            string uriPath = string.Empty;

            if (_uriSegments.Count > 0)
            {
                foreach (UriSegment segment in _uriSegments)
                {
                    if (segment.SegmentType == UriSegmentType.Path)
                    {
                        uriPath += segment.Value;
                    }
                    else
                    {
                        uriPath += "{" + segment.Value + "}";
                    }
                }
            }

            return uriPath;
        }

        private void WriteBuildUriMethod()
        {
            if (_supportsExtendedInfo || _supportsPagination)
            {
                _sourceWriter.WriteLine("internal void BuildUri()");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();

                const string requestUriName = "requestUri";
                const string firstParameterName = "firstParameter";

                _sourceWriter.WriteLine($"string {requestUriName} = $\"{BuildUriPath()}\";");

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
            else
            {
                string uriPath = $"\"{_uriPath}\"";

                if (_uriPlaceHolders.Count > 0)
                {
                    uriPath = $"$\"{BuildUriPath()}\"";
                }

                _sourceWriter.WriteLine($"internal void BuildUri() => RequestUri = new Uri({uriPath});");
            }
        }

        private void WriteBuildUriExtendedInfo(string requestUriName, string firstParameterName)
        {
            _sourceWriter.WriteLine("if (ExtendedInfo.HasValue && ExtendedInfo.Value != TraktExtendedInfo.None)");
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
            _sourceWriter.WriteLine("if (Page.HasValue && Page.Value > 0)");
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
            _sourceWriter.WriteLine("if (Limit.HasValue && Limit.Value > 0)");
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

        private void ParseRequestUri()
        {
            int position = 0;
            int startPosition = 0;

            while (position < _uriPath.Length)
            {
                char character = _uriPath[position];

                switch (character)
                {
                    case '{':
                        string uriSegment = _uriPath.Substring(startPosition, position - startPosition);

                        if (uriSegment.Length > 0)
                        {
                            _uriSegments.Add(new UriSegment
                            {
                                Value = uriSegment,
                                SegmentType = UriSegmentType.Path
                            });
                        }

                        position++;
                        startPosition = position;
                        break;
                    case '}':
                        string placeHolder = _uriPath.Substring(startPosition, position - startPosition);
                        int colonIndex = placeHolder.IndexOf(':');

                        if (placeHolder.Length > 0 && colonIndex > 0)
                        {
                            string placeHolderName = placeHolder.Substring(0, colonIndex);
                            string placeHolderType = placeHolder.Substring(colonIndex + 1, placeHolder.Length - (colonIndex + 1));

                            _uriSegments.Add(new UriSegment
                            {
                                Value = placeHolderName,
                                SegmentType = UriSegmentType.PlaceHolder
                            });

                            _uriPlaceHolders.Add(new PlaceHolder
                            {
                                Name = placeHolderName,
                                ValueType = placeHolderType,
                                IsRequired = !placeHolderType.EndsWith("?", StringComparison.InvariantCulture)
                                    || placeHolderType.EndsWith("!", StringComparison.InvariantCulture)
                            });
                        }

                        position++;
                        startPosition = position;
                        break;
                    default:
                        position++;
                        break;
                }
            }

            if (position > startPosition)
            {
                string uriSegment = _uriPath.Substring(startPosition, position - startPosition);

                if (uriSegment.Length > 0)
                {
                    _uriSegments.Add(new UriSegment
                    {
                        Value = uriSegment,
                        SegmentType = UriSegmentType.Path
                    });
                }
            }
        }

        private enum UriSegmentType
        {
            Path,
            PlaceHolder
        }

        private readonly record struct UriSegment
        {
            public required string Value { get; init; }

            public required UriSegmentType SegmentType { get; init; }
        }

        private readonly record struct PlaceHolder
        {
            public required string Name { get; init; }

            public required string ValueType { get; init; }

            public required bool IsRequired { get; init; }
        }
    }
}
