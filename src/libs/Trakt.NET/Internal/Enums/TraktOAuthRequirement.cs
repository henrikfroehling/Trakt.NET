namespace TraktNET
{
    ///<summary>Specifies the OAuth requirement for Trakt requests.</summary>
    internal enum TraktOAuthRequirement
    {
        NotRequired,
        Optional,
        OptionalButMightBeRequired,
        Required
    }
}
