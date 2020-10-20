namespace TraktNet.Objects.Post.Builder
{
    public interface ITraktPostBuilder<out TPostObject>
    {
        TPostObject Build();
    }
}
