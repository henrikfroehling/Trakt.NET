namespace TraktNet.Objects.Basic
{
    /// <summary>Represents Trakt connection options.</summary>
    public interface ITraktSharing
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
    }
}
