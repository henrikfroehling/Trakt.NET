namespace TraktNet.Objects.Basic
{
    public interface ITraktSharing
    {
        bool? Twitter { get; set; }

        bool? Google { get; set; }

        bool? Tumblr { get; set; }

        bool? Medium { get; set; }

        bool? Slack { get; set; }
    }
}
