namespace TraktNet.Objects.Post.Builder
{
    using System;

    public class PostBuilderRatedObject<TObject>
    {
        public TObject Object { get; set; }

        public int Rating { get; set; }

        public DateTime? RatedAt { get; set; }
    }
}
