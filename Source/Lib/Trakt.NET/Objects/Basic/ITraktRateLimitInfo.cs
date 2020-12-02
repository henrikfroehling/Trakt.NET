namespace TraktNet.Objects.Basic
{
    using System;

    public interface ITraktRateLimitInfo
    {
        string Name { get; set; }

        int? Period { get; set; }

        int? Limit { get; set; }

        int? Remaining { get; set; }

        DateTime? Until { get; set; }
    }
}
