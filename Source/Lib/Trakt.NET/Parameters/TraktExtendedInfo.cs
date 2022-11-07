namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// A boolean flag container representing the possible extended options for Trakt requests, allowing retrieving of
    /// additional data, such as images.<para />
    /// This class has an fluent interface.
    /// <para>See <a href ="http://docs.trakt.apiary.io/#introduction/extended-info">"Trakt API Doc - Extended Info"</a> for more information.</para>
    /// </summary>
    public class TraktExtendedInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktExtendedInfo" /> class.
        /// All flags are disabled by default.
        /// </summary>
        public TraktExtendedInfo()
        {
            Metadata = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
            GuestStars = false;
        }

        /// <summary>
        /// Gets or sets, whether metadata information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSyncModule.GetCollectionMoviesAsync(TraktExtendedInfo, CancellationToken)" />,
        /// <see cref="Modules.TraktSyncModule.GetCollectionShowsAsync(TraktExtendedInfo, CancellationToken)" />,
        /// <see cref="Modules.TraktUsersModule.GetCollectionMoviesAsync(string, TraktExtendedInfo, CancellationToken)" /> and
        /// <see cref="Modules.TraktUsersModule.GetCollectionShowsAsync(string, TraktExtendedInfo, CancellationToken)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetMetadata()" /> and <see cref="ResetMetadata()" />.</para>
        /// </summary>
        public bool Metadata { get; set; }

        /// <summary>
        /// Gets or sets, whether full information should be retrieved.
        /// <para>See also <see cref="SetFull()" /> and <see cref="ResetFull()" />.</para>
        /// </summary>
        public bool Full { get; set; }

        /// <summary>
        /// Gets or sets, whether no seasons information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSyncModule.GetWatchedShowsAsync(TraktExtendedInfo, CancellationToken)" /> and
        /// <see cref="Modules.TraktUsersModule.GetWatchedShowsAsync(string, TraktExtendedInfo, CancellationToken)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetNoSeasons()" /> and <see cref="ResetNoSeasons()" />.</para>
        /// </summary>
        public bool NoSeasons { get; set; }

        /// <summary>
        /// Gets or sets, whether episodes information should be retrieved.
        /// <para>
        /// Only supported by <see cref="Modules.TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedInfo, string, CancellationToken)" />.
        /// Will be ignored otherwise.
        /// </para>
        /// <para>See also <see cref="SetEpisodes()" /> and <see cref="ResetEpisodes()" />.</para>
        /// </summary>
        public bool Episodes { get; set; }

        /// <summary>
        /// Gets or sets, whether guest_stars information should be retrieved.
        /// <para>See also <see cref="SetGuestStars()" /> and <see cref="ResetGuestStars()" />.</para>
        /// </summary>
        public bool GuestStars { get; set; }

        /// <summary>Returns, whether any flag is enabled.</summary>
        public bool HasAnySet => Metadata || Full || NoSeasons || Episodes || GuestStars;

        /// <summary>
        /// Enables the metadata information flag.
        /// <para>See also <see cref="Metadata" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo SetMetadata()
        {
            Metadata = true;
            return this;
        }

        /// <summary>
        /// Disables the metadata information flag.
        /// <para>See also <see cref="Metadata" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo ResetMetadata()
        {
            Metadata = false;
            return this;
        }

        /// <summary>
        /// Enables the full information flag.
        /// <para>See also <see cref="Full" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo SetFull()
        {
            Full = true;
            return this;
        }

        /// <summary>
        /// Disables the full information flag.
        /// <para>See also <see cref="Full" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo ResetFull()
        {
            Full = false;
            return this;
        }

        /// <summary>
        /// Enables the no seasons information flag.
        /// <para>See also <see cref="NoSeasons" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo SetNoSeasons()
        {
            NoSeasons = true;
            return this;
        }

        /// <summary>
        /// Disables the no seasons information flag.
        /// <para>See also <see cref="NoSeasons" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo ResetNoSeasons()
        {
            NoSeasons = false;
            return this;
        }

        /// <summary>
        /// Enables the episodes information flag.
        /// <para>See also <see cref="Episodes" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo SetEpisodes()
        {
            Episodes = true;
            return this;
        }

        /// <summary>
        /// Disables the episodes information flag.
        /// <para>See also <see cref="Episodes" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo ResetEpisodes()
        {
            Episodes = false;
            return this;
        }

        /// <summary>
        /// Enables the guest_stars information flag.
        /// <para>See also <see cref="GuestStars" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo SetGuestStars()
        {
            GuestStars = true;
            return this;
        }

        /// <summary>
        /// Disables the guest_stars information flag.
        /// <para>See also <see cref="GuestStars" />.</para>
        /// </summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo ResetGuestStars()
        {
            GuestStars = false;
            return this;
        }

        /// <summary>Disables all flags.</summary>
        /// <returns>The current <see cref="TraktExtendedInfo" /> instance.</returns>
        public TraktExtendedInfo Reset()
        {
            Metadata = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
            GuestStars = false;
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

            if (Metadata)
                options.Add("metadata");

            if (Full)
                options.Add("full");

            if (NoSeasons)
                options.Add("noseasons");

            if (Episodes)
                options.Add("episodes");

            if (GuestStars)
                options.Add("guest_stars");

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
