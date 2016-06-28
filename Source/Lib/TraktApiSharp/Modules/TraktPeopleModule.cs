namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Basic;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests;
    using Requests.WithoutOAuth.People;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktPeopleModule : TraktBaseModule
    {
        internal TraktPeopleModule(TraktClient client) : base(client) { }

        public async Task<TraktPerson> GetPersonAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktPersonSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktPerson>> GetPersonsAsync(string[] ids, TraktExtendedOption extended = null)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var persons = new List<TraktPerson>(ids.Length);

            for (int i = 0; i < ids.Length; i++)
            {
                var show = await GetPersonAsync(ids[i], extended);

                if (show != null)
                    persons.Add(show);
            }

            return new TraktListResult<TraktPerson> { Items = persons };
        }

        public async Task<TraktPersonMovieCredits> GetPersonMovieCreditsAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktPersonMovieCreditsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPersonShowCredits> GetPersonShowCreditsAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktPersonShowCreditsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("person id not valid", nameof(id));
        }
    }
}
