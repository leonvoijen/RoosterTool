using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;

namespace VollopRooster.Repository
{
    public class ScheduleCreator
    {
        private List<EmployeeDTO> EmployeeData;
        private List<AvailabilityDTO> AvailabilityData;
        private List<ShiftDTO> ShiftData;
        private List<EmployeeDTO> TempEmployees;
        private int TotalHours;

        public ScheduleCreator(List<EmployeeDTO> employeedata, List<AvailabilityDTO> availabilitydata, List<ShiftDTO> shiftdata, int TotalHours)
        {
            this.EmployeeData = employeedata;
            this.AvailabilityData = availabilitydata;
            this.ShiftData = shiftdata;
            this.TotalHours = TotalHours;
        }

        public Schedule GetSchedule()
        {
            Schedule schedule = new Schedule();
            foreach (var shift in ShiftData)
            {
                FilledShift tofill = new FilledShift();
                tofill.Date = shift.Date;
                tofill.StartTime = shift.StartTime;
                tofill.EndTime = shift.EndTime;
                tofill.Employees = FillShiftWithEmployees(shift);
                schedule.filledShifts.Add(tofill);
            }

            return schedule;
        }

        private List<EmployeeDTO> FillShiftWithEmployees(ShiftDTO shift)
        {
            List<EmployeeDTO> allEmployees = EmployeeData;
            List<EmployeeDTO> ShiftEmployees = new List<EmployeeDTO>();

            List<bool> GetAvailability = new List<bool>();

            for (int x = 0; x < shift.NrOfBar; x++)
            {
                List<EmployeeDTO> qualifiedEmployeesBar = GetQualifiedShiftRole(Role.Bar);

                GetAvailability = Available(qualifiedEmployeesBar, shift);
                for (int i = GetAvailability.Count - 1; i >= 0; i--)
                {
                    if (GetAvailability[i].Equals(false))
                    {
                        qualifiedEmployeesBar.Remove(qualifiedEmployeesBar[i]);
                        GetAvailability.Remove(GetAvailability[i]);
                    }
                }

                if (qualifiedEmployeesBar.Count != 0)
                {
                    //make sure the whole shift is filled
                    foreach (var employee in PickEmployee(qualifiedEmployeesBar,shift))
                    {
                        ShiftEmployees.Add(employee);
                    }
                    int index = 0;
                    index = qualifiedEmployeesBar.IndexOf(PickEmployee(qualifiedEmployeesBar));

                    var NewemployeeData = qualifiedEmployeesBar[index];
                    allEmployees.Remove(NewemployeeData);
                    ShiftEmployees[index] = NewemployeeData;

                    NewemployeeData.MaxHours -= DecreaseMaxHours(shift);
                    qualifiedEmployeesBar.RemoveAt(index);
                }

                GetAvailability.Clear();
            }

            for (int x = 0; x < shift.NrOfEvent; x++)
            {
                List<EmployeeDTO> qualifiedEmployeesEvent = GetQualifiedShiftRole(Role.Event);
                GetAvailability = Available(qualifiedEmployeesEvent, shift);

                for (int i = GetAvailability.Count - 1; i >= 0; i--)
                {
                    //availability aanpassen als er een record uit qualified wordt verwijderd
                    if (GetAvailability[i].Equals(false))
                    {
                        qualifiedEmployeesEvent.Remove(qualifiedEmployeesEvent[i]);
                        GetAvailability.Remove(GetAvailability[i]);
                    }
                }

                if (qualifiedEmployeesEvent.Count != 0)
                {
                    ShiftEmployees.Add(PickEmployee(qualifiedEmployeesEvent));

                    int index = 0;
                    index = qualifiedEmployeesEvent.IndexOf(PickEmployee(qualifiedEmployeesEvent));

                    var employee = qualifiedEmployeesEvent[index];
                    allEmployees.Remove(employee);
                    ShiftEmployees[index] = employee;

                    employee.MaxHours -= DecreaseMaxHours(shift);
                    qualifiedEmployeesEvent.RemoveAt(index);
                }
                GetAvailability.Clear();
            }

            for (int x = 0; x < shift.NrOfIets; x++)
            {
                List<EmployeeDTO> qualifiedEmployeesOther = GetQualifiedShiftRole(Role.Other);
                GetAvailability = Available(qualifiedEmployeesOther, shift);

                for (int i = GetAvailability.Count - 1; i >= 0; i--)
                {
                    //availability aanpassen als er een record uit qualified wordt verwijderd
                    if (GetAvailability[i].Equals(false))
                    {
                        qualifiedEmployeesOther.Remove(qualifiedEmployeesOther[i]);
                        GetAvailability.Remove(GetAvailability[i]);
                    }
                }

                if (qualifiedEmployeesOther.Count != 0)
                {
                    ShiftEmployees.Add(PickEmployee(qualifiedEmployeesOther));

                    int index = 0;
                    index = qualifiedEmployeesOther.IndexOf(PickEmployee(qualifiedEmployeesOther));

                    var employee = qualifiedEmployeesOther[index];
                    allEmployees.Remove(employee);
                    ShiftEmployees[index] = employee;

                    employee.MaxHours -= DecreaseMaxHours(shift);
                    qualifiedEmployeesOther.RemoveAt(index);
                }
                GetAvailability.Clear();
            }

            return ShiftEmployees;
        }

        private List<EmployeeDTO> PickEmployee(List<EmployeeDTO> employees,ShiftDTO shift)
        {
            List<EmployeeDTO> pickemployee = new List<EmployeeDTO>();
            List<double> factor = new List<double>();
            bool IsFilled = false;
            foreach (var employee in employees)
            {
                factor.Add(CalculateFactorA(employee));
            }

            var orderedfactor = factor.OrderByDescending(i => i);

            foreach (var employee in employees)
            {
                if (CalculateFactorA(employee) == orderedfactor.FirstOrDefault())
                {
                    pickemployee.Add(employee);
                }
            }

            ////check if shift is filled
            //TimeSpan ShiftStart = shift.StartTime;
            //TimeSpan ShiftEnd = shift.EndTime;
            //foreach (var employee in pickemployee)
            //{
            // //   
            //}

            if (IsFilled == false)
            {
                foreach (var employee in pickemployee)
                {
                    employees.Remove(employee);
                }           
                PickEmployee(employees, shift);
            }

            return pickemployee;
        }

        private List<EmployeeDTO> GetQualifiedEmployees(Role role)
        {
            List<EmployeeDTO> qualified = new List<EmployeeDTO>();
            if (role == Role.Bar)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Bar == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            if (role == Role.Bar)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Events == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            if (role == Role.Bar)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Overig == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            return qualified;
        }

        private double CalculateFactorA(EmployeeDTO employee)
        {
            double factora = 0;
            factora = EmployeeData.Count / TotalHours * employee.MaxHours;
            return factora;
        }

        private List<bool> Available(List<EmployeeDTO> employees, ShiftDTO shift)
        {
            List<bool> available = new List<bool>();
            var dayOfWeek = shift.Date.DayOfWeek;

            foreach (var employee in employees)
            {
                var availability = AvailabilityData.SingleOrDefault(i => i.UserId == employee.Id);

                //foreach (var leave in availability.Leave)
                //{
                //    //TODO: make a way to compare dates
                //    if (shift.Date == leave.Date)
                //    {
                //        available.Add(false);
                //        break;
                //    }
                //}

                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        if (availability.StartSunday <= shift.StartTime && availability.EndSunday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                            available.Add(false);
                            break;
                    case DayOfWeek.Monday:
                        if (availability.StartMonday <= shift.StartTime && availability.EndMonday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    case DayOfWeek.Tuesday:
                        if (availability.StartTuesday <= shift.StartTime && availability.EndTuesday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    case DayOfWeek.Wednesday:
                        if (availability.StartWednesday <= shift.StartTime &&
                            availability.EndWednesday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    case DayOfWeek.Thursday:
                        if (availability.StartThursday <= shift.StartTime && availability.EndThursday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    case DayOfWeek.Friday:
                        if (availability.StartFriday <= shift.StartTime && availability.EndFriday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    case DayOfWeek.Saturday:
                        if (availability.StartSaturday <= shift.StartTime && availability.EndSaturday >= shift.EndTime)
                        {
                            available.Add(true);
                            break;
                        }
                        available.Add(false);
                        break;
                    default:
                        available.Add(false);
                        break;
                }
            }
            return available;
        }

        private List<EmployeeDTO> GetQualifiedShiftRole(Role role)
        {
            List<EmployeeDTO> qualified = new List<EmployeeDTO>();
            if (role == Role.Bar)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Bar == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            if (role == Role.Event)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Events == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            if (role == Role.Other)
            {
                foreach (var employee in EmployeeData)
                {
                    if (employee.Overig == true)
                    {
                        qualified.Add(employee);
                    }
                }
            }

            return qualified;
        }

        private int DecreaseMaxHours(ShiftDTO shift)
        {
            int hours = 0;
            int NrOfHours = shift.EndTime.Hours - shift.StartTime.Hours;
            return hours;
        }
    }
}