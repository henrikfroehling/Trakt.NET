namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Lists;
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;

    /// <summary>Represents a Trakt comment object item.</summary>
    public class TraktCommentItem : ITraktCommentItem
    {
        /// <summary>Gets or sets the object type of the comment item.</summary>
        public TraktObjectType Type { get; set; }

        /// <summary>Gets or sets the comment movie item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Movie" />.</summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>Gets or sets the comment show item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Show" />.</summary>
        public ITraktShow Show { get; set; }

        /// <summary>Gets or sets the comment season item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Season" />.</summary>
        public ITraktSeason Season { get; set; }

        /// <summary>Gets or sets the comment episode item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Episode" />.</summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>Gets or sets the comment list item, if <see cref="Type" /> is set to <see cref="TraktObjectType.List" />.</summary>
        public ITraktList List { get; set; }
    }
}
