using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using TestPodologyApi.Interfaces;
using TestPodologyModel.DTOs;
using TestPodologyModel.Search;
using TestPodologyRepository.Data;
using TestPodologyRepository.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestPodologyApi.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly TimeOnly StartDayParam = new TimeOnly(8, 0);
        private readonly TimeOnly EndDayParam = new TimeOnly(18, 0);
        private readonly TimeSpan slotDuration = TimeSpan.FromMinutes(60);

        public async Task<List<Consultation>> Get(ConsultationSearch oSearch)
        {
            try
            {
                using (var db = new TestPodologyDBContext())
                {
                    var locationPRedicate = PredicateBuilder.New<Consultation>(true);

                    if (!string.IsNullOrEmpty(oSearch.HealthCheckProviderId))
                    {
                        locationPRedicate = locationPRedicate.And(x => x.HealthCareProviderId == oSearch.HealthCheckProviderId);
                    }

                    if (!string.IsNullOrEmpty(oSearch.PatientId))
                    {
                        locationPRedicate = locationPRedicate.And(x => x.PatientId == oSearch.PatientId);
                    }

                    if (oSearch.StartDateBefore.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.StartConsultation <= oSearch.StartDateBefore.Value);
                    }

                    if (oSearch.StartDateAfter.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.StartConsultation >= oSearch.StartDateAfter.Value);
                    }

                    if (oSearch.EndDateBefore.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.EndConsultation <= oSearch.EndDateBefore.Value);
                    }

                    if (oSearch.EndDateAfter.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.EndConsultation >= oSearch.EndDateAfter.Value);
                    }

                    if (oSearch.Id.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.Id == oSearch.Id.Value);
                    }

                    if (oSearch.Location.HasValue)
                    {
                        locationPRedicate = locationPRedicate.And(x => x.LocationId == oSearch.Location.Value);
                    }

                    var result = await db.Consultations
                        .Include(x => x.Patient)
                        .Where(locationPRedicate)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AvailableDatesDto>> GetFirstsAvailableDates(FirstsAvailableDatesSearch oSearch)
        {
            var initialDate = DateTime.Today.AddDays(1);

            try
            {
                var locationPRedicate = PredicateBuilder.New<Consultation>(x => x.StartConsultation >= initialDate && x.EndConsultation < initialDate.AddMonths(1));

                if (oSearch.LocationId.HasValue)
                {
                    locationPRedicate = locationPRedicate.And(x => x.LocationId == oSearch.LocationId.Value);
                }

                var availableDates = new List<AvailableDatesDto>();

                using (var db = new TestPodologyDBContext())
                {
                    //var initialDate = DateTime.Today.AddHours(StartDayParam.Hour).AddMinutes(StartDayParam.Minute);
                    

                    var consultationsDb = await db.Consultations
                        .Where(locationPRedicate)
                        .OrderBy(x => x.StartConsultation)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    while (availableDates.SelectMany(x => x.Slots).ToList().Count <= 30)
                    {
                        var availableDatesDto = new AvailableDatesDto()
                        {
                            Date = initialDate.Date.ToString("dd/MM/yyyy"),
                            Slots = new List<DateTime>()
                        };
                        var availableSlots = new List<DateTime>();

                        var consultations = consultationsDb.Where(x => x.StartConsultation.Date == initialDate.Date).ToList();

                        for (var date = initialDate.Add(StartDayParam.ToTimeSpan()); date < initialDate.Add(EndDayParam.ToTimeSpan()); date = date.Add(slotDuration))
                        {
                            if (!consultations.Any(x => x.StartConsultation >= date && x.EndConsultation <= date.Add(slotDuration)))
                            {
                                availableDatesDto.Slots.Add(date);
                            }
                        }

                        availableDates.Add(availableDatesDto);

                        initialDate = initialDate.AddDays(1);

                    }

                }
                    return availableDates;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Consultation> AddNewConsultationAsync(Consultation newConsultation)
        {
            try
            {
                newConsultation.StatusId = 1;
                newConsultation.EndConsultation = newConsultation.StartConsultation.Add(slotDuration);

                using (var db = new TestPodologyDBContext())
                {
                    var result = await db.AddAsync(newConsultation).ConfigureAwait(false);

                    db.SaveChanges();

                    return result.Entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
