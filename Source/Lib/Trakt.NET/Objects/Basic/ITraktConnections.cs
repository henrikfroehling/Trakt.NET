namespace TraktNet.Objects.Basic
{
    /// <summary>Represents Trakt connection options.</summary>
    public interface ITraktConnections
    {
        /// <summary>Gets or sets, whether Twitter connection is enabled.</summary>
        bool? Twitter { get; set; }

        /// <summary>Gets or sets, whether Google connection is enabled.</summary>
        bool? Google { get; set; }

        /// <summary>Gets or sets, whether Tumblr connection is enabled.</summary>
        bool? Tumblr { get; set; }

        /// <summary>Gets or sets, whether Medium connection is enabled.</summary>
        bool? Medium { get; set; }

        /// <summary>Gets or sets, whether Slack connection is enabled.</summary>
        bool? Slack { get; set; }

        /// <summary>Gets or sets, whether Facebook connection is enabled.</summary>
        bool? Facebook { get; set; }

        /// <summary>Gets or sets, whether Apple connection is enabled.</summary>
        bool? Apple { get; set; }

        /// <summary>Gets or sets, whether Mastodon connection is enabled.</summary>
        bool? Mastodon { get; set; }

        /// <summary>Gets or sets, whether Microsoft connection is enabled.</summary>
        bool? Microsoft { get; set; }

        /// <summary>Gets or sets, whether Dropbox connection is enabled.</summary>
        bool? Dropbox { get; set; }
    }
}
