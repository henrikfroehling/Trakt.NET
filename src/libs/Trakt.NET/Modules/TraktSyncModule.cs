namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to sync.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/sync">"Trakt API Documentation - Sync"</a> section.
    /// </summary>
    public class TraktSyncModule(ITraktContext context) : BaseModule(context)
    {
    }
}
