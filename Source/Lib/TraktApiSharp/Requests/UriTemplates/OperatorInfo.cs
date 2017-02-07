namespace UriTemplates
{
    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/OperatorInfo.cs" />
    /// </summary>
    internal class OperatorInfo
    {
        internal bool Default { get; set; }
        internal string First { get; set; }
        internal char Seperator { get; set; }
        internal bool Named { get; set; }
        internal string IfEmpty { get; set; }
        internal bool AllowReserved { get; set; }
    }
}
