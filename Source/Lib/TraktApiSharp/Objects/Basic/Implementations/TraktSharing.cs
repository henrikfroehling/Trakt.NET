namespace TraktApiSharp.Objects.Basic
{
    /// <summary>Represents Trakt connection options.</summary>
    public class TraktSharing : ITraktSharing
    {
        /// <summary>Gets or sets, whether Facebook connection is enabled.</summary>
        public bool? Facebook { get; set; }

        /// <summary>Gets or sets, whether Twitter connection is enabled.</summary>
        public bool? Twitter { get; set; }

        /// <summary>Gets or sets, whether Google connection is enabled.</summary>
        public bool? Google { get; set; }

        /// <summary>Gets or sets, whether Tumblr connection is enabled.</summary>
        public bool? Tumblr { get; set; }

        /// <summary>Gets or sets, whether Medium connection is enabled.</summary>
        public bool? Medium { get; set; }

        /// <summary>Gets or sets, whether Slack connection is enabled.</summary>
        public bool? Slack { get; set; }
    }
}
