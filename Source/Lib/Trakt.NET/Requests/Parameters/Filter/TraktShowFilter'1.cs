namespace TraktNet.Requests.Parameters.Filter
{
    using Enums;

    public class TraktShowFilter<T> : TraktShowAndMovieFilter<TraktShowFilter<T>> where T : TraktShowFilter<T>
    {
        public string[] Networks { get; protected set; }

        public TraktShowStatus[] States { get; protected set; }

        public T AddNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        public T WithNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        public T ClearNetworks()
        {
            throw new System.NotImplementedException();
        }

        public T AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        public T WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        public T ClearStates()
        {
            throw new System.NotImplementedException();
        }
    }
}
