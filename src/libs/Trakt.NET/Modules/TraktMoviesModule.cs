namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to movies.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/movies">"Trakt API Documentation - Movies"</a> section.
    /// </summary>
    public class TraktMoviesModule(ITraktContext context) : BaseModule(context)
    {
    }
}
