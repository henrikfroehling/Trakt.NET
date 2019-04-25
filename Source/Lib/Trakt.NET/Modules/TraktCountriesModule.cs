namespace TraktNet.Modules
{
    /// <summary>
    /// Provides access to data retrieving methods specific to countries.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/countries">"Trakt API Doc - Countries"</a> section.
    /// </para>
    /// </summary>
    public class TraktCountriesModule : ATraktModule
    {
        internal TraktCountriesModule(TraktClient client) : base(client)
        {
        }
    }
}
