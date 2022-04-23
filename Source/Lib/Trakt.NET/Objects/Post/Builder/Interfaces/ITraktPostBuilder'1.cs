namespace TraktNet.Objects.Post
{
    public interface ITraktPostBuilder<out TPostObject>
    {
        TPostObject Build();
    }
}
