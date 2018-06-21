namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    public interface ITraktCertifications
    {
        IEnumerable<ITraktCertification> US { get; set; }
    }
}
