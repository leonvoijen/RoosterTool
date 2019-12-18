using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Memory
{
    public class EventMemory : IEventContext
    {
        private List<EventDTO> events = new List<EventDTO>();

        public EventMemory()
        {
            events = new List<EventDTO>()
            {

                new EventDTO(0, "Bruiloft", "Piet en Petra", new DateTime(1, 2, 1),
                    new DateTime(1, 1, 1, 16, 0, 0), new DateTime(1, 1, 1, 23, 59, 0), 2,2,2),
                new EventDTO(1, "Borrel", "Eetclub", new DateTime(1, 2, 1),
                    new DateTime(1, 1, 1, 16, 0, 0), new DateTime(1, 1, 1, 23, 59, 0), 0,2,0),
                new EventDTO(2, "Leesclub", " ", new DateTime(1, 2, 1),
                    new DateTime(1, 1, 1, 16, 0, 0), new DateTime(1, 1, 1, 23, 59, 0), 2,0,0),
                new EventDTO(3, "Presentatie", " ", new DateTime(1, 2, 1),
                    new DateTime(1, 1, 1, 16, 0, 0), new DateTime(1, 1, 1, 23, 59, 0), 1,1,1),
            };
        }

        public List<EventDTO> GetAllEvents()
        {
            return events;
        }
        public EventDTO GetEvent(int id)
        {
            return events[id];
        }
        public void AddEvent(EventDTO _event)
        {
            events.Add(_event);
        }

        public void RemoveEvent(int id)
        {
            events.RemoveAll(i => i.Id == id);
        }
        public void ChangeEvent(EventDTO dto)
        {
            events.RemoveAt(dto.Id);
            events.Add(dto);
        }
    }
}
