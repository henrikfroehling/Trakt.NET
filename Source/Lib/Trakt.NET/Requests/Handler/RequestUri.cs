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
        private readonly StringBuilder _result;

        public RequestUri(string uriTemplate, IDictionary<string, object> uriPathParameters)
        {
            _uriTemplate = uriTemplate;
            _uriPathParameters = uriPathParameters;
            _result = new StringBuilder();
        }

        internal string ResolveUrl()
        {
            ParseTemplate();
            return _result.ToString();
        }

        private void ParseTemplate()
        {
            int position = 0;
            State parsingState = State.Default;
            int startPosition = 0;
            int uriSegmentStartPosition = 0;
            bool isFirstQuery = true;

            while (position < _uriTemplate.Length)
            {
                char character = _uriTemplate[position];
                string identifier;
                string uriSegment;

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
                            _result.Append(uriSegment);

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
                                    if (_uriPathParameters.TryGetValue(identifier, out object replacement))
                                        _result.Append(replacement.ToString());
                                    else
                                        throw new InvalidOperationException("uri template value not found");

                                    break;
                                case State.ParsingPathSegment:
                                    if (_uriPathParameters.TryGetValue(identifier, out object segment))
                                        _result.Append($"/{segment.ToString()}");
                                    else
                                        throw new InvalidOperationException("uri template value not found");

                                    break;
                                case State.ParsingQueries:
                                    if (_uriPathParameters.TryGetValue(identifier, out object query))
                                    {
                                        _result.Append(isFirstQuery ? '?' : '&');
                                        isFirstQuery = false;
                                        _result.Append($"{identifier}={GetValue(query)}");
                                    }
                                    else
                                        throw new InvalidOperationException("uri template value not found");

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
                            if (_uriPathParameters.TryGetValue(identifier, out object query))
                            {
                                _result.Append(isFirstQuery ? '?' : '&');
                                isFirstQuery = false;
                                _result.Append($"{identifier}={GetValue(query)}");
                            }
                            else
                                throw new InvalidOperationException("uri template value not found");
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
        }

        private string GetValue(object value)
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
