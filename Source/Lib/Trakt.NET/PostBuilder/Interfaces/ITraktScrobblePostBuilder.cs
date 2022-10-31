namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Post.Scrobbles;

    public interface ITraktScrobblePostBuilder<TPostBuilder, out TPostObject>
        where TPostBuilder : ITraktScrobblePostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktScrobblePost
    {
        /// <summary>Sets the progress of a scrobble post.</summary>
        /// <param name="progress">The progress of a scrobble post. The value should be between 0 and 100.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="progress"/> is not between 0 and 100.</exception>
        TPostBuilder WithProgress(float progress);

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

        /// <summary>Creates a new <typeparamref name="TPostObject"/> instance.</summary>
        /// <returns>A new <typeparamref name="TPostObject"/> instance.</returns>
        TPostObject Build();
    }
}
