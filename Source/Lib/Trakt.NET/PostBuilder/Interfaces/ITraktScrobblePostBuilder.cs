namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Post.Scrobbles;

    public interface ITraktScrobblePostBuilder<TPostBuilder, out TPostObject>
        where TPostBuilder : ITraktScrobblePostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktScrobblePost
    {
        TPostBuilder WithProgress(float progress);

        TPostBuilder WithAppVersion(string appVersion);

        TPostBuilder WithAppDate(string appDate);

        TPostObject Build();
    }
}
