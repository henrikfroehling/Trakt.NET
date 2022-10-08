namespace TraktNet.PostBuilder
{
    public interface ITraktPostBuilder<out TPostObject>
    {
        TPostObject Build();
    }
}
