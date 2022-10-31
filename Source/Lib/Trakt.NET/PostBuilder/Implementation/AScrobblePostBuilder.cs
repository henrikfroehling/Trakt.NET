namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Post.Scrobbles;

    internal abstract class AScrobblePostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktScrobblePostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktScrobblePost
    {
        protected float? _progress;
        protected string _appVersion;
        protected string _appDate;

        protected AScrobblePostBuilder()
        {
            _progress = null;
            _appVersion = null;
            _appDate = null;
        }

        public TPostBuilder WithProgress(float progress)
        {
            if (progress.CompareTo(0.0f) < 0 || progress.CompareTo(100.0f) > 0)
                throw new ArgumentOutOfRangeException(nameof(progress), "progress value not valid - value must be between 0 and 100");

            _progress = progress;
            return GetBuilder();
        }

        public TPostBuilder WithAppVersion(string appVersion)
        {
            _appVersion = appVersion ?? throw new ArgumentNullException(nameof(appVersion));
            return GetBuilder();
        }

        public TPostBuilder WithAppDate(string appDate)
        {
            _appDate = appDate ?? throw new ArgumentNullException(nameof(appDate));
            return GetBuilder();
        }

        public abstract TPostObject Build();

        protected abstract TPostBuilder GetBuilder();
    }
}
