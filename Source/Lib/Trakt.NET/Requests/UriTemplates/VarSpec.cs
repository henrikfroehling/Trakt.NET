namespace UriTemplates
{
    using System.Text;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/VarSpec.cs" />
    /// </summary>
    internal class VarSpec
    {
        internal StringBuilder VarName = new StringBuilder();
        internal bool Explode;
        internal int PrefixLength;
        internal bool First = true;

        internal VarSpec(OperatorInfo operatorInfo)
        {
            OperatorInfo = operatorInfo;
        }

        internal OperatorInfo OperatorInfo { get; }

        public override string ToString()
            => (First ? OperatorInfo.First : "") +
                   VarName
                   + (Explode ? "*" : "")
                   + (PrefixLength > 0 ? ":" + PrefixLength : "");
    }
}
