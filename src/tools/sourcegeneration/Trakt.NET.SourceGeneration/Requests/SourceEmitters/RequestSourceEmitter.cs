using Microsoft.CodeAnalysis;
using System.Buffers;
using System.Runtime.CompilerServices;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class RequestSourceEmitter(SourceProductionContext context) : SourceEmitter<RequestGenerationSpecification>(context)
    {
        private static readonly IReadOnlyList<string> Usings = [
            "System.Text",
            "System.Web"
        ];

        private readonly SourceWriter _sourceWriter = new();

        private string _requestName = string.Empty;
        private string _requestNamespace = string.Empty;
        private string _httpMethodValue = string.Empty;
        private string _uriPath = string.Empty;
        private string _oauthRequirementValue = string.Empty;
        private bool _supportsExtendedInfo;
        private bool _supportsPagination;
        private bool _hasOAuthRequirementDefined;
        private bool _hasOptionalQueries;

        private string _resolvedUriPath = string.Empty;
        private readonly List<PlaceHolder> _uriPlaceHolders = [];
        private bool _hasOptionalPlaceholders;

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
            _hasOptionalQueries = _supportsExtendedInfo || _supportsPagination;

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

                    if (placeHolder.IsRequired)
                    {
                        modifier += " required";
                        setOrInit = "init";
                    }

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
            => _sourceWriter.WriteLine($"private {_requestName}() : base(HttpMethod.{_httpMethodValue}, (Uri?)null) {{ }}");

        private void WriteBuildUriMethod()
        {
            if (_hasOptionalQueries)
            {
                _sourceWriter.WriteLine("internal void BuildUri()");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();

                const string requestUriName = "requestUri";

                _sourceWriter.WriteLine("List<string> queries = [];");

                if (_hasOptionalPlaceholders)
                {
                    _sourceWriter.WriteLine($"string {requestUriName} = $\"{_resolvedUriPath}\".Replace(\"//\", \"/\");");
                }
                else
                {
                    _sourceWriter.WriteLine($"string {requestUriName} = $\"{_resolvedUriPath}\";");
                }

                if (_supportsExtendedInfo)
                {
                    _sourceWriter.WriteEmptyLine();

                    _sourceWriter.WriteLine("if (ExtendedInfo.HasValue && ExtendedInfo.Value != TraktExtendedInfo.None)");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine("queries.Add(ExtendedInfo.Value.ToUriPath());");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }

                if (_supportsPagination)
                {
                    _sourceWriter.WriteEmptyLine();

                    _sourceWriter.WriteLine("if (Page.HasValue && Page.Value > 0)");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine("queries.Add($\"page={Page.Value}\");");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');

                    _sourceWriter.WriteEmptyLine();

                    _sourceWriter.WriteLine("if (Limit.HasValue && Limit.Value > 0)");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine("queries.Add($\"limit={Limit.Value}\");");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }

                _sourceWriter.WriteEmptyLine();

                _sourceWriter.WriteLine("if (queries.Count > 0)");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();
                _sourceWriter.WriteLine($"{requestUriName} = {requestUriName} + \"?\" + string.Join(\"&\", queries);");
                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
                _sourceWriter.WriteEmptyLine();
                _sourceWriter.WriteLine($"string? encodedUriPath = HttpUtility.UrlEncode({requestUriName}, Encoding.UTF8);");
                _sourceWriter.WriteLine("RequestUri = new Uri(encodedUriPath);");

                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
            }
            else
            {
                _sourceWriter.WriteLine("internal void BuildUri()");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();

                if (_hasOptionalPlaceholders)
                {
                    _sourceWriter.WriteLine($"string uriPath = $\"{_resolvedUriPath}\".Replace(\"//\", \"/\");");
                }
                else
                {
                    _sourceWriter.WriteLine($"string uriPath = $\"{_resolvedUriPath}\";");
                }

                _sourceWriter.WriteLine("string? encodedUriPath = HttpUtility.UrlEncode(uriPath, Encoding.UTF8);");
                _sourceWriter.WriteLine("RequestUri = new Uri(encodedUriPath);");
                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
            }
        }

        private void ParseRequestUri()
        {
            const int StackallocCharThreshold = 128;

            char[]? rentedBuffer = null;
            ReadOnlySpan<char> uriPath = _uriPath.AsSpan();
            int initialBufferLength = (int)(1.2 * uriPath.Length);

            Span<char> destination = initialBufferLength <= StackallocCharThreshold
                ? stackalloc char[StackallocCharThreshold]
                : (rentedBuffer = ArrayPool<char>.Shared.Rent(initialBufferLength));

            UriParserState state = UriParserState.Default;
            int charsWritten = 0;

            bool firstPlaceHolderNameLetterNeedsToBeUppercase = false;
            int placeHolderNameStartPosition = 0;
            int placeHolderTypeStartPosition = 0;

            string placeHolderName = string.Empty;
            string placeHolderType = string.Empty;

            for (int i = 0; i < uriPath.Length; i++)
            {
                char currentCharacter = uriPath[i];

                switch (state)
                {
                    case UriParserState.ParsingPlaceHolderName:
                    {
                        switch (currentCharacter)
                        {
                            case ':':
                                state = UriParserState.ParsingPlaceHolderType;
                                placeHolderTypeStartPosition = i + 1;
                                placeHolderName = destination.Slice(placeHolderNameStartPosition, charsWritten - placeHolderNameStartPosition).ToString();
                                placeHolderNameStartPosition = 0;
                                break;
                            case '_':
                                // Ignore this character, so '_' gets removed from the name.
                                firstPlaceHolderNameLetterNeedsToBeUppercase = true;
                                break;
                            default:
                            {
                                if (firstPlaceHolderNameLetterNeedsToBeUppercase)
                                {
                                    // Flip last bit to switch character casing.
                                    WriteChar((char)(currentCharacter ^ 32), ref destination);
                                    firstPlaceHolderNameLetterNeedsToBeUppercase = false;
                                }
                                else
                                {
                                    WriteChar(currentCharacter, ref destination);
                                }

                                break;
                            }
                        }

                        break;
                    }
                    case UriParserState.ParsingPlaceHolderType:
                    {
                        switch (currentCharacter)
                        {
                            case '}':
                                WriteChar(currentCharacter, ref destination);
                                state = UriParserState.Default;
                                placeHolderType = uriPath.Slice(placeHolderTypeStartPosition, i - placeHolderTypeStartPosition).ToString();
                                placeHolderTypeStartPosition = 0;

                                bool isOptional = placeHolderType.IndexOf('?') >= 0;
                                _hasOptionalPlaceholders = _hasOptionalPlaceholders || isOptional;

                                _uriPlaceHolders.Add(new PlaceHolder
                                {
                                    Name = placeHolderName,
                                    ValueType = placeHolderType,
                                    IsRequired = !isOptional
                                });

                                break;
                            default:
                                // Just proceed with the current character.
                                break;
                        }

                        break;
                    }
                    case UriParserState.Default:
                    {
                        switch (currentCharacter)
                        {
                            case '{':
                                WriteChar(currentCharacter, ref destination);
                                state = UriParserState.ParsingPlaceHolderName;
                                placeHolderNameStartPosition = i + 1;
                                firstPlaceHolderNameLetterNeedsToBeUppercase = true;
                                break;
                            default:
                                WriteChar(currentCharacter, ref destination);
                                break;
                        }

                        break;
                    }
                }
            }

            _resolvedUriPath = destination.Slice(0, charsWritten).ToString();

            if (rentedBuffer != null)
            {
                destination.Slice(0, charsWritten).Clear();
                ArrayPool<char>.Shared.Return(rentedBuffer);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void WriteChar(char value, ref Span<char> destination)
            {
                if (charsWritten == destination.Length)
                {
                    ExpandBuffer(ref destination);
                }

                destination[charsWritten++] = value;
            }

            void ExpandBuffer(ref Span<char> destination)
            {
                int newSize = checked(destination.Length * 2);
                char[] newBuffer = ArrayPool<char>.Shared.Rent(newSize);
                destination.CopyTo(newBuffer);

                if (rentedBuffer != null)
                {
                    destination.Slice(0, charsWritten).Clear();
                    ArrayPool<char>.Shared.Return(rentedBuffer);
                }

                rentedBuffer = newBuffer;
                destination = rentedBuffer;
            }
        }

        private readonly record struct PlaceHolder
        {
            public required string Name { get; init; }

            public required string ValueType { get; init; }

            public required bool IsRequired { get; init; }
        }

        private enum UriParserState
        {
            Default,
            ParsingPlaceHolderName,
            ParsingPlaceHolderType
        }
    }
}
