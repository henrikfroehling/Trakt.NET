namespace UriTemplates
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplate.cs" />
    /// </summary>
    internal class UriTemplate
    {
        private static readonly Dictionary<char, OperatorInfo> _Operators = new Dictionary<char, OperatorInfo>() {
            { '\0', new OperatorInfo { Default = true, First = "", Seperator = ',', Named = false, IfEmpty = "", AllowReserved = false} },
            { '+', new OperatorInfo { Default = false, First = "", Seperator = ',', Named = false, IfEmpty = "", AllowReserved = true} },
            { '.', new OperatorInfo { Default = false, First = ".", Seperator = '.', Named = false, IfEmpty = "", AllowReserved = false} },
            { '/', new OperatorInfo { Default = false, First = "/", Seperator = '/', Named = false, IfEmpty = "", AllowReserved = false} },
            { ';', new OperatorInfo { Default = false, First = ";", Seperator = ';', Named = true, IfEmpty = "", AllowReserved = false} },
            { '?', new OperatorInfo { Default = false, First = "?", Seperator = '&', Named = true, IfEmpty = "=", AllowReserved = false} },
            { '&', new OperatorInfo { Default = false, First = "&", Seperator = '&', Named = true, IfEmpty = "=", AllowReserved = false} },
            { '#', new OperatorInfo { Default = false, First = "#", Seperator = ',', Named = false, IfEmpty = "", AllowReserved = true} }
        };

        private readonly string _template;
        private readonly Dictionary<string, object> _Parameters;
        private enum States { CopyingLiterals, ParsingExpression }
        private readonly bool _resolvePartially;

        internal UriTemplate(string template, bool resolvePartially = false, bool caseInsensitiveParameterNames = false)
        {
            _resolvePartially = resolvePartially;
            _template = template;

            _Parameters = caseInsensitiveParameterNames
                ? new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, object>();
        }

        public override string ToString() => _template;

        internal void SetParameter(string name, object value)
        {
            _Parameters[name] = value;
        }

        internal string Resolve()
        {
            Result result = ResolveResult();
            return result.ToString();
        }

        private Result ResolveResult()
        {
            States currentState = States.CopyingLiterals;
            var result = new Result();
            StringBuilder currentExpression = null;

            foreach (char character in _template)
            {
                switch (currentState)
                {
                    case States.CopyingLiterals:
                        if (character == '{')
                        {
                            currentState = States.ParsingExpression;
                            currentExpression = new StringBuilder();
                        }
                        else if (character == '}')
                        {
                            throw new ArgumentException("Malformed template, unexpected } : " + result);
                        }
                        else
                        {
                            result.Append(character);
                        }

                        break;
                    case States.ParsingExpression:
                        if (character == '}')
                        {
                            ProcessExpression(currentExpression, result);
                            currentState = States.CopyingLiterals;
                        }
                        else
                        {
                            currentExpression.Append(character);
                        }

                        break;
                }
            }

            if (currentState == States.ParsingExpression)
            {
                result.Append("{");
                result.Append(currentExpression.ToString());
                throw new ArgumentException("Malformed template, missing } : " + result);
            }

            if (result.ErrorDetected)
                throw new ArgumentException("Malformed template : " + result);

            return result;
        }

        private void ProcessExpression(StringBuilder currentExpression, Result result)
        {
            if (currentExpression.Length == 0)
            {
                result.ErrorDetected = true;
                result.Append("{}");
                return;
            }

            OperatorInfo op = GetOperator(currentExpression[0]);
            int firstChar = op.Default ? 0 : 1;
            bool multivariableExpression = false;
            var varSpec = new VarSpec(op);

            for (int i = firstChar; i < currentExpression.Length; i++)
            {
                char currentChar = currentExpression[i];

                switch (currentChar)
                {
                    case '*':
                        varSpec.Explode = true;
                        break;
                    case ':':  // Parse Prefix Modifier
                        var prefixText = new StringBuilder();
                        currentChar = currentExpression[++i];

                        while (currentChar >= '0' && currentChar <= '9' && i < currentExpression.Length)
                        {
                            prefixText.Append(currentChar);
                            i++;

                            if (i < currentExpression.Length)
                                currentChar = currentExpression[i];
                        }

                        varSpec.PrefixLength = int.Parse(prefixText.ToString());
                        i--;
                        break;
                    case ',':
                        multivariableExpression = true;
                        bool success = ProcessVariable(varSpec, result, multivariableExpression);
                        bool isFirst = varSpec.First;

                        // Reset for new variable
                        varSpec = new VarSpec(op);

                        if (success || !isFirst || _resolvePartially)
                            varSpec.First = false;

                        if (!success && _resolvePartially)
                            result.Append(",");

                        break;
                    default:
                        if (IsVarNameChar(currentChar))
                            varSpec.VarName.Append(currentChar);
                        else
                            result.ErrorDetected = true;

                        break;
                }
            }

            ProcessVariable(varSpec, result, multivariableExpression);

            if (multivariableExpression && _resolvePartially)
                result.Append("}");
        }

        private bool ProcessVariable(VarSpec varSpec, Result result, bool multiVariableExpression = false)
        {
            string varname = varSpec.VarName.ToString();
            result.ParameterNames.Add(varname);

            if (!_Parameters.ContainsKey(varname)
                || _Parameters[varname] == null
                || (_Parameters[varname] is IList && ((IList)_Parameters[varname]).Count == 0)
                || (_Parameters[varname] is IDictionary && ((IDictionary)_Parameters[varname]).Count == 0))
            {
                if (_resolvePartially)
                {
                    if (multiVariableExpression)
                    {
                        if (varSpec.First)
                            result.Append("{");

                        result.Append(varSpec.ToString());
                    }
                    else
                    {
                        result.Append("{");
                        result.Append(varSpec.ToString());
                        result.Append("}");
                    }

                    return false;
                }

                return false;
            }

            if (varSpec.First)
                result.Append(varSpec.OperatorInfo.First);
            else
                result.Append(varSpec.OperatorInfo.Seperator);

            object value = _Parameters[varname];

            // Handle Strings
            if (value is string val)
            {
                string stringValue = val;

                if (varSpec.OperatorInfo.Named)
                    result.AppendName(varname, varSpec.OperatorInfo, string.IsNullOrEmpty(stringValue));

                result.AppendValue(stringValue, varSpec.PrefixLength, varSpec.OperatorInfo.AllowReserved);
            }
            else
            {
                // Handle Lists
                var list = value as IList;

                if (list == null && value is IEnumerable<string>)
                    list = ((IEnumerable<string>)value).ToList();

                if (list != null)
                {
                    if (varSpec.OperatorInfo.Named && !varSpec.Explode)  // exploding will prefix with list name
                        result.AppendName(varname, varSpec.OperatorInfo, list.Count == 0);

                    result.AppendList(varSpec.OperatorInfo, varSpec.Explode, varname, list);
                }
                else
                {
                    // Handle associative arrays
                    if (value is IDictionary<string, string> dictionary)
                    {
                        if (varSpec.OperatorInfo.Named && !varSpec.Explode)  // exploding will prefix with list name
                            result.AppendName(varname, varSpec.OperatorInfo, dictionary.Count == 0);

                        result.AppendDictionary(varSpec.OperatorInfo, varSpec.Explode, dictionary);
                    }
                    else
                    {
                        // If above all fails, convert the object to string using the default object.ToString() implementation
                        string stringValue = value.ToString();

                        if (varSpec.OperatorInfo.Named)
                            result.AppendName(varname, varSpec.OperatorInfo, string.IsNullOrEmpty(stringValue));

                        result.AppendValue(stringValue, varSpec.PrefixLength, varSpec.OperatorInfo.AllowReserved);
                    }
                }
            }

            return true;
        }

        private static bool IsVarNameChar(char c)
            => (c >= 'A' && c <= 'z') //Alpha
                || (c >= '0' && c <= '9') // Digit
                || c == '_'
                || c == '%'
                || c == '.';

        private static OperatorInfo GetOperator(char operatorIndicator)
        {
            switch (operatorIndicator)
            {
                case '+':
                case ';':
                case '/':
                case '#':
                case '&':
                case '?':
                case '.':
                    return _Operators[operatorIndicator];
                default:
                    return _Operators['\0'];
            }
        }
    }
}
