namespace TraktApiSharp.Modules
{
    using Objects.Get.Calendars;
    using Requests.Params;
    using Requests.WithOAuth.Calendars;
    using Requests.WithoutOAuth.Calendars;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktCalendarModule : TraktBaseModule
    {
        internal TraktCalendarModule(TraktClient client) : base(client) { }

        public async Task<IEnumerable<TraktCalendarShow>> GetUserShowsAsync(DateTime? startDate = null, int? days = null,
                                                                            TraktExtendedOption extended = null,
                                                                            TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarShow>> GetUserNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                               TraktExtendedOption extended = null,
                                                                               TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserNewShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarShow>> GetUserSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                      TraktExtendedOption extended = null,
                                                                                      TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserSeasonPremieresRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarMovie>> GetUserMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                              TraktExtendedOption extended = null,
                                                                              TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserMoviesRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarShow>> GetAllShowsAsync(DateTime? startDate = null, int? days = null,
                                                                           TraktExtendedOption extended = null,
                                                                           TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarShow>> GetAllNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                              TraktExtendedOption extended = null,
                                                                              TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllNewShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarShow>> GetAllSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                     TraktExtendedOption extended = null,
                                                                                     TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllSeasonPremieresRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        public async Task<IEnumerable<TraktCalendarMovie>> GetAllMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                             TraktExtendedOption extended = null,
                                                                             TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllMoviesRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extended,
                Filter = filter
            });
        }

        private void ValidateDays(int? days)
        {
            if (days.HasValue && (days.Value < 1 || days.Value > 31))
                throw new ArgumentOutOfRangeException(nameof(days), "days must have a value between 1 and 31");
        }
    }
}
