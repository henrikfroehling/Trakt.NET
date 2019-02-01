namespace TraktNet.Requests.Handler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal sealed class RequestUri
    {
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
                                        if (isFirstQuery)
                                        {
                                            _result.Append($"?{identifier}={query.ToString()}");
                                            isFirstQuery = false;
                                        }
                                        else
                                            _result.Append($"&{identifier}={query.ToString()}");
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
                                if (isFirstQuery)
                                {
                                    _result.Append($"?{identifier}={query.ToString()}");
                                    isFirstQuery = false;
                                }
                                else
                                    _result.Append($"&{identifier}={query.ToString()}");
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
    }
}
