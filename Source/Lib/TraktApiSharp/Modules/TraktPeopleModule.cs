namespace TraktApiSharp.Modules
{
    using Objects.Basic;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests;
    using Requests.WithoutOAuth.People;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktPeopleModule : TraktBaseModule
    {
        public TraktPeopleModule(TraktClient client) : base(client) { }

        public async Task<TraktPerson> GetPersonAsync(string id, TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            return await QueryAsync(new TraktPersonSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktPerson>> GetPersonsAsync(string[] ids, TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var persons = new List<TraktPerson>();

            foreach (var id in ids)
            {
                var show = await GetPersonAsync(id, extended);

                if (show != null)
                    persons.Add(show);
            }

            return new TraktListResult<TraktPerson> { Items = persons };
        }

        public async Task<TraktPersonMovieCredits> GetPersonMovieCreditsAsync(string id, TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            return await QueryAsync(new TraktPersonMovieCreditsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended
            });
        }

        public async Task<TraktPersonShowCredits> GetPersonShowCreditsAsync(string id, TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            return await QueryAsync(new TraktPersonShowCreditsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended
            });
        }
    }
}
