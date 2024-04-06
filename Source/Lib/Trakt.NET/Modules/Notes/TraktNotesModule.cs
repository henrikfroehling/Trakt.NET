namespace TraktNet.Modules
{
    /// <summary>
    /// Provides access to data retrieving methods specific to notes.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/notes">"Trakt API Doc - Notes"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktNotesModule : ATraktModule
    {
        internal TraktNotesModule(TraktClient client) : base(client)
        {
        }
    }
}
