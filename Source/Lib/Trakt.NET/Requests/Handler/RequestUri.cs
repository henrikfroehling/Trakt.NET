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
            ParsingPathParts,       // {/identifier}
            ParsingQueries,         // {?identifier[,identifier]}
            ParsingFragment         // {#identifier}
        }

        private readonly string _uriTemplate;
        private readonly IDictionary<string, object> _uriPathParameters;
        private List<string> _pathReplacements;
        private List<string> _pathParts;
        private List<string> _queries;
        private string _fragment;
        private StringBuilder _result;

        public RequestUri(string uriTemplate, IDictionary<string, object> uriPathParameters)
        {
            _uriTemplate = uriTemplate;
            _uriPathParameters = uriPathParameters;
            _pathReplacements = new List<string>();
            _pathParts = new List<string>();
            _queries = new List<string>();
            _fragment = "";
            _result = new StringBuilder();
        }

        internal string ResolveUrl()
        {
            ParseTemplate();
            ResolvePathReplacements();
            ResolvePathParts();
            ResolveQueries();
            ResolveFragment();
            return _result.ToString();
        }

        private void ResolvePathReplacements()
        {
            foreach (string replacement in _pathReplacements)
            {

            }
        }

        private void ResolvePathParts()
        {
            foreach (string pathPart in _pathParts)
            {

            }
        }

        private void ResolveQueries()
        {
            foreach (string query in _queries)
            {

            }
        }

        private void ResolveFragment()
        {

        }

        private void ParseTemplate()
        {
            int position = 0;
            State parsingState = State.Default;
            string identifier = "";
            int startPosition = 0;

            while (position < _uriTemplate.Length)
            {
                char character = _uriTemplate[position];

                switch (character)
                {
                    case '{':
                        parsingState = State.ParsingParameter;
                        State nextParsingState = GetParsingState(_uriTemplate[position + 1]);

                        if (nextParsingState == State.None)
                            throw new InvalidOperationException("uri template parsing error");

                        parsingState = nextParsingState;

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
                                    _pathReplacements.Add(identifier);
                                    break;
                                case State.ParsingPathParts:
                                    _pathParts.Add(identifier);
                                    break;
                                case State.ParsingQueries:
                                    _queries.Add(identifier);
                                    break;
                                case State.ParsingFragment:
                                    if (_fragment.Length > 0)
                                        throw new InvalidOperationException("uri template parsing error");

                                    _fragment = identifier;
                                    break;
                            }
                        }

                        identifier = "";
                        parsingState = State.Default;
                        position++;
                        break;
                    case ',':
                        if (parsingState == State.None || parsingState != State.ParsingQueries)
                            throw new InvalidOperationException("uri template parsing error");

                        identifier = _uriTemplate.Substring(startPosition, position - startPosition);

                        if (identifier.Length > 0)
                            _queries.Add(identifier);

                        identifier = "";
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

        private State GetParsingState(char character)
        {
            if (IsAlphaCharacter(character))
                return State.ParsingPathReplacement;

            switch (character)
            {
                case '/': return State.ParsingPathParts;
                case '?': return State.ParsingQueries;
                case '#': return State.ParsingFragment;
            }

            return State.None;
        }

        private bool IsAlphaCharacter(char character)
            => (character > 64 && character < 91) || (character > 96 && character < 123);
    }
}
