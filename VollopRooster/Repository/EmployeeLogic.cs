using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using VollopRooster.Models;
using DAL.Interfaces;
using DAL.DTO;

namespace Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeContext EmployeeContext;

        public EmployeeLogic(IEmployeeContext Context)
        {
            this.EmployeeContext = Context;
        }
        public void RemoveEmployee(int id)
        {
            EmployeeContext.RemoveEmployee(id);
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            EmployeeDTO dto = new EmployeeDTO()
            {
                Id = model.Id,
                Availability = model.Availability,
                Bar = model.Bar,
                Events = model.Event,
                MaxHours = model.MaxHours,
                Name = model.Name,
                Overig = model.Iets,
                PhoneNumber = model.Phone,
                PicUrl = model.PicUrl
            };
            EmployeeContext.ChangeEmployee(dto);
        }

        public IEnumerable<EmployeeDTO>GetAllEmployeeDtos()
        {
            return EmployeeContext.GetAllEmployees();
        }

        public EmployeeModel GetEmployee(int id)
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto = EmployeeContext.GetEmployee(id);

            var modeltransfer = new EmployeeModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Availability = dto.Availability,
                Bar = dto.Bar,
                Event = dto.Events,
                Iets = dto.Overig,
                MaxHours = dto.MaxHours,
                Phone = dto.PhoneNumber,
                PicUrl = dto.PicUrl
                
            };
            return modeltransfer;
        }

        public void AddEmployee(EmployeeModel model)
        {
            var dtotransfer = new EmployeeDTO()
            {
                Name = model.Name,
                Bar = model.Bar,
                Events = model.Event,
                Id = model.Id,
                MaxHours = model.MaxHours,
                Overig = model.Iets,
                PhoneNumber = model.Phone,
                PicUrl = model.PicUrl
            };

            EmployeeContext.AddEmployee(dtotransfer);
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            foreach (var dto in EmployeeContext.GetAllEmployees())
            {
                yield return new EmployeeModel(dto);
            }
        }
    }
}
