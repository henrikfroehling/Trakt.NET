namespace TraktNet.Requests.Countries
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;

    internal abstract class ACountriesRequest : AGetRequest<ITraktCountry>
    {
        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
