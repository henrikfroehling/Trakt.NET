namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using Get.Users.Lists;

    /// <summary>Represents a Trakt comment object item.</summary>
    public interface ITraktCommentItem
    {
        /// <summary>Gets or sets the object type of the comment item.</summary>
        TraktObjectType Type { get; set; }

        /// <summary>Gets or sets the comment movie item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Movie" />.</summary>
        ITraktMovie Movie { get; set; }

        /// <summary>Gets or sets the comment show item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Show" />.</summary>
        ITraktShow Show { get; set; }

        /// <summary>Gets or sets the comment season item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Season" />.</summary>
        ITraktSeason Season { get; set; }

        /// <summary>Gets or sets the comment episode item, if <see cref="Type" /> is set to <see cref="TraktObjectType.Episode" />.</summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>Gets or sets the comment list item, if <see cref="Type" /> is set to <see cref="TraktObjectType.List" />.</summary>
        ITraktList List { get; set; }
    }
}
