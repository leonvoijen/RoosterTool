using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEventContext
    {
        List<EventDTO> GetAllEvents();
        void AddEvent(EventDTO dto);
        EventDTO GetEvent(int id);
        void RemoveEvent(int id);
        void ChangeEvent(EventDTO dto);
    }
}
