namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests.Params;
    using Requests.WithoutOAuth.People;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<IEnumerable<TraktPerson>> GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams personsQueryParams)
        {
            if (personsQueryParams == null || personsQueryParams.Count <= 0)
                return new List<TraktPerson>();

            var tasks = new List<Task<TraktPerson>>();

            foreach (var queryParam in personsQueryParams)
            {
                Task<TraktPerson> task = GetPersonAsync(queryParam.Id, queryParam.ExtendedOption);
                tasks.Add(task);
            }

            var people = await Task.WhenAll(tasks);
            return people.ToList();
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
