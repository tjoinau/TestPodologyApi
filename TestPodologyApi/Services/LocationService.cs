using TestPodologyModel.DTOs;
using TestPodologyRepository.Data;

namespace TestPodologyApi.Services
{
    public class LocationService
    {
        //public async Task Get()
        //{
        //    try
        //    {
        //        var availableDates = new List<AvailableDatesDto>();

        //        using (var db = new TestPodologyDBContext())
        //        {
        //            var locationsDb = await db.Locations
        //                .Where(x => x.)
        //                .OrderBy(x => x.StartConsultation)
        //                .ToListAsync()
        //                .ConfigureAwait(false);

        //            while (availableDates.SelectMany(x => x.Slots).ToList().Count <= 30)
        //            {
        //                var availableDatesDto = new AvailableDatesDto()
        //                {
        //                    Date = initialDate.Date.ToString("dd/MM/yyyy"),
        //                    Slots = new List<DateTime>()
        //                };
        //                var availableSlots = new List<DateTime>();

        //                var consultations = consultationsDb.Where(x => x.StartConsultation.Date == initialDate.Date).ToList();

        //                for (var date = initialDate.Add(StartDayParam.ToTimeSpan()); date < initialDate.Add(EndDayParam.ToTimeSpan()); date = date.Add(slotDuration))
        //                {
        //                    if (!consultations.Any(x => x.StartConsultation >= date && x.EndConsultation <= date.Add(slotDuration)))
        //                    {
        //                        availableDatesDto.Slots.Add(date);
        //                    }
        //                }

        //                availableDates.Add(availableDatesDto);

        //                initialDate = initialDate.AddDays(1);

        //            }

        //        }
        //        return availableDates;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
