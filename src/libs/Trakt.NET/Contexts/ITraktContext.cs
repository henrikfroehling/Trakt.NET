namespace TraktNET
{
    public interface ITraktContext
    {
        string ID { get; }
        
        string ClientID { get; set; }

        string ClientSecret { get; set; }

        Uri BaseUri { get; }

        Uri BaseAuthorizationUri { get; }
    }
}
