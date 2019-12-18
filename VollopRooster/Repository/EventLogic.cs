using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using VollopRooster.Models;
using VollopRooster.Repository.Interfaces;

namespace VollopRooster.Repository
{
    public class EventLogic : IEventLogic
    {
        private readonly IEventContext Context;

        public EventLogic(IEventContext Context)
        {
            this.Context = Context;
        }

        public void AddEvent(EventModel newEvent)
        {
            var modeltransfer = new EventDTO()
            {
                Name = newEvent.Name,
                Description = newEvent.Description,
                EndTime = newEvent.EndTime,
                Month = newEvent.Date,
                Nrbar =  newEvent.Nrbar,
                Nrevent = newEvent.Nrevent,
                Nriets = newEvent.Nriets
                   
            };
            Context.AddEvent(modeltransfer);
        }

        public IEnumerable<EventModel> GetAllEvents()
        {
            foreach(var dto in Context.GetAllEvents())
            {
                yield return new EventModel(dto);

            }
        }

        public EventModel GetEvent(int id)
        {   EventDTO dto = new EventDTO();
            dto = Context.GetEvent(id);
            var modeltransfer = new EventModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Date = dto.Month,
                Description = dto.Description,
                EndTime = dto.EndTime,
                StartTime = dto.StartTime,
                Nrbar = dto.Nrbar,
                Nrevent = dto.Nrevent,
                Nriets = dto.Nriets,
            };
            
            return modeltransfer;
        }

        public void RemoveEvent(int id)
        {
            Context.RemoveEvent(id);
        }

        public void UpdateEvent(EventModel model)
        {
            EventDTO dto = new EventDTO()
            {
                Id = model.Id,
                Description = model.Description,
                EndTime = model.EndTime,
                Month = model.Date,
                Name = model.Name,
                Nrbar = model.Nrbar,
                Nrevent = model.Nrevent,
                Nriets = model.Nriets,
                StartTime = model.StartTime
            };
            Context.ChangeEvent(dto);
        }
    }
}
