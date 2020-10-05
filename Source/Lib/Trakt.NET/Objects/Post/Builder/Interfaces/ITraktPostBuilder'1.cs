namespace TraktNet.Objects.Post.Builder.Interfaces
{
    public interface ITraktPostBuilder<out TPostObject>
    {
        TPostObject Build();
    }
}
