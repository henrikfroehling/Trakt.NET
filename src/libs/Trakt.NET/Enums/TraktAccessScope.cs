using System.Text.Json.Serialization;
using TraktNET.SourceGeneration;

namespace TraktNET
{
    /// <summary>Determines the access authorization for different resources.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktAccessScopeJsonConverter))]
    public enum TraktAccessScope
    {
        /// <summary>An invalid access scope.</summary>
        Unspecified,

        /// <summary>A resource can only be accessed by the user.</summary>
        Private,

        /// <summary>A resource can only be accessed by friends of an user.</summary>
        Friends,

        /// <summary>A resource can be accessed by all.</summary>
        Public
    }
}
