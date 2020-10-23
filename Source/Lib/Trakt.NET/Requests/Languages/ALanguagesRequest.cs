namespace TraktNet.Requests.Languages
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;

    internal abstract class ALanguagesRequest : AGetRequest<ITraktLanguage>
    {
        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
