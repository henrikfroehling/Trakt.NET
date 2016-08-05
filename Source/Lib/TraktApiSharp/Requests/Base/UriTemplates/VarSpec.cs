namespace UriTemplates
{
    using System.Text;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/VarSpec.cs" />
    /// </summary>
    internal class VarSpec
    {
        private readonly OperatorInfo _operatorInfo;
        internal StringBuilder VarName = new StringBuilder();
        internal bool Explode = false;
        internal int PrefixLength = 0;
        internal bool First = true;

        internal VarSpec(OperatorInfo operatorInfo)
        {
            _operatorInfo = operatorInfo;
        }

        internal OperatorInfo OperatorInfo
        {
            get { return _operatorInfo; }
        }

        public override string ToString()
        {
            return (First ? _operatorInfo.First : "") +
                   VarName.ToString()
                   + (Explode ? "*" : "")
                   + (PrefixLength > 0 ? ":" + PrefixLength : "");
        }
    }
}
