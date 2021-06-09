namespace TraktNet.Objects.Basic
{
    using System;

    public class TraktRateLimitInfo : ITraktRateLimitInfo
    {
        public string Name { get; set; }
        
        public int? Period { get; set; }

        public int? Limit { get; set; }

        public int? Remaining { get; set; }

        public DateTime? Until { get; set; }
    }
}
