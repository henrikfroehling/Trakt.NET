namespace TraktApiSharp.Requests.Certifications
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;

    internal abstract class ACertificationsRequest : AGetRequest<ITraktCertifications>
    {
        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate()
        {
        }
    }
}
