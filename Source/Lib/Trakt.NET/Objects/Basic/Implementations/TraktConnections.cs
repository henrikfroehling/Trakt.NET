namespace TraktNet.Objects.Basic
{
    /// <summary>Represents Trakt connection options.</summary>
    public class TraktConnections : ITraktConnections
    {
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

        /// <summary>Gets or sets, whether Facebook connection is enabled.</summary>
        public bool? Facebook { get; set; }

        /// <summary>Gets or sets, whether Apple connection is enabled.</summary>
        public bool? Apple { get; set; }

        /// <summary>Gets or sets, whether Mastodon connection is enabled.</summary>
        public bool? Mastodon { get; set; }

        /// <summary>Gets or sets, whether Microsoft connection is enabled.</summary>
        public bool? Microsoft { get; set; }

        /// <summary>Gets or sets, whether Dropbox connection is enabled.</summary>
        public bool? Dropbox { get; set; }
    }
}
