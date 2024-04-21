namespace TraktNET
{
    /// <summary>
    /// Provides access to OAuth and device authentication and authorization.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/authentication-oauth">"Trakt API Documentation - Authentication - OAuth"</a> section
    /// and the <a href="https://trakt.docs.apiary.io/#reference/authentication-devices">"Trakt API Documentation - Authentication - Devices"</a> section.
    /// </summary>
    public class TraktAuthModule(ITraktContext context) : BaseModule(context)
    {
    }
}
