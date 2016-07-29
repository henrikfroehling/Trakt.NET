namespace TraktApiSharp.Requests.Params
{
    using System.Collections.Generic;

    /// <summary>
    /// A boolean flag container representing the possible extended options for Trakt requests, allowing retrieving of
    /// additional data, such as images.<para />
    /// This class has an fluent interface.
    /// <para>See <a href ="http://docs.trakt.apiary.io/#introduction/extended-info">"Trakt API Doc - Extended Info"</a> for more information.</para>
    /// </summary>
    public class TraktExtendedOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktExtendedOption" /> class.
        /// All flags are disabled by default.
        /// </summary>
        public TraktExtendedOption()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
        }

        /// <summary>
        /// Gets or sets, whether minimal information should be retrieved.
        /// <para>See also <see cref="SetMinimal()" /> and <see cref="ResetMinimal()" />.</para>
        /// </summary>
        public bool Minimal { get; set; }

        /// <summary>
        /// Gets or sets, whether metadata information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSyncModule.GetCollectionMoviesAsync(TraktExtendedOption)" />,
        /// <see cref="Modules.TraktSyncModule.GetCollectionShowsAsync(TraktExtendedOption)" />,
        /// <see cref="Modules.TraktUsersModule.GetCollectionMoviesAsync(string, TraktExtendedOption)" /> and
        /// <see cref="Modules.TraktUsersModule.GetCollectionShowsAsync(string, TraktExtendedOption)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetMetadata()" /> and <see cref="ResetMetadata()" />.</para>
        /// </summary>
        public bool Metadata { get; set; }

        /// <summary>
        /// Gets or sets, whether images information should be retrieved.
        /// <para>See also <see cref="SetImages()" /> and <see cref="ResetImages()" />.</para>
        /// </summary>
        public bool Images { get; set; }

        /// <summary>
        /// Gets or sets, whether full information should be retrieved.
        /// <para>See also <see cref="SetFull()" /> and <see cref="ResetFull()" />.</para>
        /// </summary>
        public bool Full { get; set; }

        /// <summary>
        /// Gets or sets, whether no seasons information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSyncModule.GetWatchedShowsAsync(TraktExtendedOption)" /> and
        /// <see cref="Modules.TraktUsersModule.GetWatchedShowsAsync(string, TraktExtendedOption)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetNoSeasons()" /> and <see cref="ResetNoSeasons()" />.</para>
        /// </summary>
        public bool NoSeasons { get; set; }

        /// <summary>
        /// Gets or sets, whether episodes information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedOption)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetEpisodes()" /> and <see cref="ResetEpisodes()" />.</para>
        /// </summary>
        public bool Episodes { get; set; }

        /// <summary>Returns, whether any flag is enabled.</summary>
        public bool HasAnySet => Minimal || Metadata || Images || Full || NoSeasons || Episodes;

        /// <summary>
        /// Enables the minimal information flag.
        /// <para>See also <see cref="Minimal" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetMinimal()
        {
            Minimal = true;
            return this;
        }

        /// <summary>
        /// Disables the minimal information flag.
        /// <para>See also <see cref="Minimal" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetMinimal()
        {
            Minimal = false;
            return this;
        }

        /// <summary>
        /// Enables the metadata information flag.
        /// <para>See also <see cref="Metadata" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetMetadata()
        {
            Metadata = true;
            return this;
        }

        /// <summary>
        /// Disables the metadata information flag.
        /// <para>See also <see cref="Metadata" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetMetadata()
        {
            Metadata = false;
            return this;
        }

        /// <summary>
        /// Enables the images information flag.
        /// <para>See also <see cref="Images" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetImages()
        {
            Images = true;
            return this;
        }

        /// <summary>
        /// Disables the images information flag.
        /// <para>See also <see cref="Images" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetImages()
        {
            Images = false;
            return this;
        }

        /// <summary>
        /// Enables the full information flag.
        /// <para>See also <see cref="Full" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetFull()
        {
            Full = true;
            return this;
        }

        /// <summary>
        /// Disables the full information flag.
        /// <para>See also <see cref="Full" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetFull()
        {
            Full = false;
            return this;
        }

        /// <summary>
        /// Enables the no seasons information flag.
        /// <para>See also <see cref="NoSeasons" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetNoSeasons()
        {
            NoSeasons = true;
            return this;
        }

        /// <summary>
        /// Disables the no seasons information flag.
        /// <para>See also <see cref="NoSeasons" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetNoSeasons()
        {
            NoSeasons = false;
            return this;
        }

        /// <summary>
        /// Enables the episodes information flag.
        /// <para>See also <see cref="Episodes" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption SetEpisodes()
        {
            Episodes = true;
            return this;
        }

        /// <summary>
        /// Disables the episodes information flag.
        /// <para>See also <see cref="Episodes" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption ResetEpisodes()
        {
            Episodes = false;
            return this;
        }

        /// <summary>Disables all flags.</summary>
        /// <returns>The current <see cref="TraktExtendedOption" /> instance.</returns>
        public TraktExtendedOption Reset()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
            return this;
        }

        /// <summary>
        /// Creates a string representation list of all enabled flags.
        /// <para>See also <see cref="ToString()" />.</para>
        /// </summary>
        /// <returns>A list containing string representations of each enabled flag.</returns>
        public IEnumerable<string> Resolve()
        {
            var options = new List<string>();

            if (Minimal)
                options.Add("min");

            if (Metadata)
                options.Add("metadata");

            if (Images)
                options.Add("images");

            if (Full)
                options.Add("full");

            if (NoSeasons)
                options.Add("noseasons");

            if (Episodes)
                options.Add("episodes");

            return options;
        }

        /// <summary>
        /// Creates a string containing string representations of all enabled flags separated by a comma.
        /// <para>See also <see cref="Resolve()" />.</para>
        /// </summary>
        /// <returns>A string containing string representations of all enabled flags separated by a comma.</returns>
        public override string ToString()
        {
            var options = Resolve();
            return string.Join(",", options);
        }
    }
}
