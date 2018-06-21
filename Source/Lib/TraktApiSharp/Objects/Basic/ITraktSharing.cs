namespace TraktNet.Objects.Basic
{
    public interface ITraktSharing
    {
        bool? Facebook { get; set; }

        bool? Twitter { get; set; }

        bool? Google { get; set; }

        bool? Tumblr { get; set; }

        bool? Medium { get; set; }

        bool? Slack { get; set; }
    }
}
