namespace TraktNet.Objects.Post.Syncs.Responses
{
    public interface ITraktSyncPostResponseGroup
    {
        int? Movies { get; set; }

        int? Shows { get; set; }

        int? Seasons { get; set; }

        int? Episodes { get; set; }
    }
}
