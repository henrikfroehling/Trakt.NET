namespace TraktNet.Modules
{
    /// <summary>
    /// Provides access to data retrieving methods specific to languages.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/languages">"Trakt API Doc - Languages"</a> section.
    /// </para>
    /// </summary>
    public class TraktLanguagesModule : ATraktModule
    {
        internal TraktLanguagesModule(TraktClient client) : base(client)
        {
        }
    }
}
