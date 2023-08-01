namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Basic;
    using Objects.Post.Checkins;
    using System;

    public interface ITraktCheckinPostBuilder<TPostBuilder, out TPostObject>
        where TPostBuilder : ITraktCheckinPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCheckinPost
    {
        /// <summary>Adds the given <paramref name="message"/> to the builder.</summary>
        /// <param name="message">The message which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="message"/> is null.</exception>
        TPostBuilder WithMessage(string message);

        /// <summary>Adds the given <paramref name="appVersion"/> to the builder.</summary>
        /// <param name="appVersion">The app version which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="appVersion"/> is null.</exception>
        TPostBuilder WithAppVersion(string appVersion);

        /// <summary>Adds the given <paramref name="appDate"/> to the builder.</summary>
        /// <param name="appDate">The app date which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="appDate"/> is null.</exception>
        TPostBuilder WithAppDate(string appDate);

        /// <summary>Adds the given <paramref name="foursquareVenueId"/> to the builder.</summary>
        /// <param name="foursquareVenueId">The foursquare venue id which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="foursquareVenueId"/> is null.</exception>
        TPostBuilder WithFoursquareVenueId(string foursquareVenueId);

        /// <summary>Adds the given <paramref name="foursquareVenueName"/> to the builder.</summary>
        /// <param name="foursquareVenueName">The foursquare venue name which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="foursquareVenueName"/> is null.</exception>
        TPostBuilder WithFoursquareVenueName(string foursquareVenueName);

        /// <summary>Adds the given <paramref name="sharing"/> to the builder.</summary>
        /// <param name="sharing">The <see cref="ITraktConnections"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="sharing"/> is null.</exception>
        TPostBuilder WithSharing(ITraktConnections sharing);

        /// <summary>Creates a new <typeparamref name="TPostObject"/> instance.</summary>
        /// <returns>A new <typeparamref name="TPostObject"/> instance.</returns>
        /// <exception cref="TraktPostValidationException">Thrown, if the post object is empty.</exception>
        TPostObject Build();
    }
}
