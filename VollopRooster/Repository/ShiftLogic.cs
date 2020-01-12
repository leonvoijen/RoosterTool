using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;
using Logic.Interfaces;
using Microsoft.Extensions.DependencyModel.Resolution;
using VollopRooster.Models;

namespace Logic
{
    public class ShiftLogic : IShiftLogic
    {
        private readonly IShiftContext Context;
        public ShiftLogic(IShiftContext Context)
        {
            this.Context = Context;
        }

        public void AddShift(ShiftModel newShift)
        {
            var dtotransfer = new ShiftDTO()
            {
                Id = newShift.Id,
                Details = newShift.Description,
                Date = newShift.Date,
                EndTime = newShift.EndTime,
                NrOfBar = newShift.NrOfBar,
                NrOfEvent = newShift.NrOfEvent,
                NrOfIets = newShift.NrOfExtra
            };

            Context.AddShift(dtotransfer);
        }

        public IEnumerable<ShiftModel> GetAllShifts()
        {
            foreach (var dto in Context.GetAllShifts())
            {
                yield return new ShiftModel(dto);
            }
        }

        public IEnumerable<ShiftDTO> GetAllShiftDtos(DateTime startdate, DateTime enddate)
        { 
            return Context.GetAllShiftsFromPeriod(startdate,enddate);
        }

        public ShiftModel GetShift(int id)
        {
            ShiftDTO dto = Context.GetShift(id);
            var modeltransfer = new ShiftModel(dto.Id,dto.StartTime,dto.EndTime,dto.Date,dto.Details,dto.NrOfBar,dto.NrOfEvent,dto.NrOfIets);
            return modeltransfer;
        }

        public void RemoveShift(int id)
        {
            Context.RemoveShift(id);
        }

        public void UpdateShift(ShiftModel model)
        {
            ShiftDTO dto = new ShiftDTO()
            {
                Id = model.Id,
                Date = model.Date,
                Details = model.Description,
                EndTime = model.EndTime,
                NrOfBar = model.NrOfBar,
                NrOfEvent = model.NrOfEvent,
                NrOfIets = model.NrOfExtra,
                StartTime = model.StartTime
            };
            Context.ChangeShift(dto); ;
        }
    }
}
