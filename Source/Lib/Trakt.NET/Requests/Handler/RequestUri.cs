namespace TraktNet.Requests.Handler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal sealed class RequestUri
    {
        private static readonly char[] HEX_DIGITS =
            new char[] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F'
            };

        private enum UriSegmentType
        {
            UriSegment,
            Replacement,
            PathSegment,
            Query
        }

        private sealed class UriSegment
        {
            public string SegmentValue { get; set; }

            public UriSegmentType Type { get; set; }
        }

        private enum State
        {
            None,
            Default,
            ParsingParameter,       // {???}
            ParsingPathReplacement, // {identifier}
            ParsingPathSegment,     // {/identifier}
            ParsingQueries,         // {?identifier[,identifier]}
        }

        private readonly string _uriTemplate;
        private readonly IDictionary<string, object> _uriPathParameters;
        private readonly List<UriSegment> _segments;
        private readonly StringBuilder _result;

        internal RequestUri(string uriTemplate, IDictionary<string, object> uriPathParameters)
        {
            _uriTemplate = uriTemplate;
            _uriPathParameters = uriPathParameters;
            _segments = new List<UriSegment>();
            _result = new StringBuilder();
        }

        internal string ResolveUrl()
        {
            ParseTemplate();
            ResolveUriSegments();
            return _result.ToString();
        }

        private void ParseTemplate()
        {
            int position = 0;
            State parsingState = State.Default;
            int startPosition = 0;
            int uriSegmentStartPosition = 0;
            string uriSegment;

            while (position < _uriTemplate.Length)
            {
                char character = _uriTemplate[position];
                string identifier;

                switch (character)
                {
                    case '{':
                        char nextCharacter = _uriTemplate[position + 1];

                        switch (nextCharacter)
                        {
                            case '/':
                                parsingState = State.ParsingPathSegment;
                                break;
                            case '?':
                                parsingState = State.ParsingQueries;
                                break;
                            default:
                                if ((nextCharacter > 64 && nextCharacter < 91) || (nextCharacter > 96 && nextCharacter < 123))
                                    parsingState = State.ParsingPathReplacement;
                                else
                                    parsingState = State.None;

                                break;
                        }

                        uriSegment = _uriTemplate.Substring(uriSegmentStartPosition, position - uriSegmentStartPosition);

                        if (uriSegment.Length > 0)
                        {
                            _segments.Add(new UriSegment
                            {
                                SegmentValue = uriSegment,
                                Type = UriSegmentType.UriSegment
                            });
                        }

                        if (parsingState == State.None)
                            throw new InvalidOperationException("uri template parsing error");

                        if (parsingState != State.ParsingPathReplacement)
                        {
                            position += 2;
                            startPosition = position;
                            continue;
                        }

                        position++;
                        startPosition = position;
                        break;
                    case '}':
                        if (parsingState == State.None)
                            throw new InvalidOperationException("uri template parsing error");

                        identifier = _uriTemplate.Substring(startPosition, position - startPosition);

                        if (identifier.Length > 0)
                        {
                            switch (parsingState)
                            {
                                case State.ParsingPathReplacement:
                                    _segments.Add(new UriSegment
                                    {
                                        SegmentValue = identifier,
                                        Type = UriSegmentType.Replacement
                                    });

                                    break;
                                case State.ParsingPathSegment:
                                    _segments.Add(new UriSegment
                                    {
                                        SegmentValue = identifier,
                                        Type = UriSegmentType.PathSegment
                                    });

                                    break;
                                case State.ParsingQueries:
                                    _segments.Add(new UriSegment
                                    {
                                        SegmentValue = identifier,
                                        Type = UriSegmentType.Query
                                    });

                                    break;
                            }
                        }

                        parsingState = State.Default;
                        position++;
                        uriSegmentStartPosition = position;
                        break;
                    case ',':
                        if (parsingState != State.ParsingQueries)
                            throw new InvalidOperationException("uri template parsing error");

                        identifier = _uriTemplate.Substring(startPosition, position - startPosition);

                        if (identifier.Length > 0)
                        {
                            _segments.Add(new UriSegment
                            {
                                SegmentValue = identifier,
                                Type = UriSegmentType.Query
                            });
                        }

                        position++;
                        startPosition = position;
                        break;
                    default:
                        if (parsingState == State.None)
                            throw new InvalidOperationException("uri template parsing error");

                        position++;
                        break;
                }
            }

            if (position == _uriTemplate.Length)
            {
                uriSegment = _uriTemplate.Substring(uriSegmentStartPosition, position - uriSegmentStartPosition);

                if (uriSegment.Length > 0)
                {
                    _segments.Add(new UriSegment
                    {
                        SegmentValue = uriSegment,
                        Type = UriSegmentType.UriSegment
                    });
                }
            }
        }

        private void ResolveUriSegments()
        {
            bool isFirstQuery = true;

            for (int i = 0; i < _segments.Count; i++)
            {
                UriSegment uriSegment = _segments[i];

                switch (uriSegment.Type)
                {
                    case UriSegmentType.UriSegment:
                        _result.Append(uriSegment.SegmentValue);
                        break;
                    case UriSegmentType.Replacement:
                        if (_uriPathParameters.TryGetValue(uriSegment.SegmentValue, out object replacement))
                            _result.Append(Encode(replacement.ToString()));

                        break;
                    case UriSegmentType.PathSegment:
                        if (_uriPathParameters.TryGetValue(uriSegment.SegmentValue, out object segment))
                            _result.Append($"/{Encode(segment.ToString())}");

                        break;
                    case UriSegmentType.Query:
                        if (_uriPathParameters.TryGetValue(uriSegment.SegmentValue, out object query))
                        {
                            _result.Append(isFirstQuery ? '?' : '&');
                            isFirstQuery = false;
                            _result.Append($"{uriSegment.SegmentValue}={ResolveValue(query)}");
                        }

                        break;
                    default:
                        throw new InvalidOperationException("invalid uri segment type");
                }
            }
        }

        private string ResolveValue(object value)
        {
            if (value is string val)
                return Encode(val);
            else
            {
                var list = value as IList;

                if (list == null && value is IEnumerable<string>)
                    list = ((IEnumerable<string>)value).ToList();

                if (list != null)
                {
                    if (list.Count == 1)
                        return Encode(list[0].ToString());
                    else
                    {
                        var result = new StringBuilder();

                        for (int i = 0; i < list.Count; i++)
                        {
                            result.Append(',');
                            result.Append(list[i].ToString());
                        }

                        return Encode(result.ToString().Substring(1));
                    }
                }
                else
                    return Encode(value.ToString());
            }
        }

        private static string Encode(string value)
        {
            var result = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                char character = value[i];

                switch (character)
                {
                    case '-':
                    case '.':
                    case '_':
                    case '~':
                        result.Append(character);
                        break;
                    default:
                        if ((character > 64 && character < 123) || (character > 47 && character < 58))
                            result.Append(character);
                        else
                        {
                            byte[] characterBytes = Encoding.UTF8.GetBytes(new char[] { character });

                            for (int j = 0; j < characterBytes.Length; j++)
                            {
                                var escaped = new char[3];

                                escaped[0] = '%';
                                escaped[1] = HEX_DIGITS[(characterBytes[j] & 240) >> 4];
                                escaped[2] = HEX_DIGITS[characterBytes[j] & 15];

                                result.Append(escaped);
                            }
                        }

                        break;
                }
            }

            return result.ToString();
        }
    }
}
