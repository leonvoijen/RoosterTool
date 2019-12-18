using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using VollopRooster.Models;

namespace VollopRooster.Repository.Interfaces
{
    public interface IEventLogic
    {
        IEnumerable<EventModel> GetAllEvents();
        void AddEvent(EventModel newEvent);
        EventModel GetEvent(int id);
        void RemoveEvent(int id);
        void UpdateEvent(EventModel model);
    }
}
