using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Context
{
    public class ShiftContext : IShiftContext
    {
        private readonly string _connectionstring = @"Server=mssql.fhict.local;Database=dbi386833_rooster;User Id=dbi386833_rooster;Password=Rooster";
        public void AddShift(ShiftDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("AddShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Date",dto.Date));
                command.Parameters.Add(new SqlParameter("@Details", dto.Details));
                command.Parameters.Add(new SqlParameter("@EndTime", dto.EndTime));
                command.Parameters.Add(new SqlParameter("@StartTime", dto.StartTime));
                command.Parameters.Add(new SqlParameter("@NrOfBar", dto.NrOfBar));
                command.Parameters.Add(new SqlParameter("@NrOfEvent", dto.NrOfEvent));
                command.Parameters.Add(new SqlParameter("@NrOfOther", dto.NrOfIets));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeShift(ShiftDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("ChangeShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", dto.Id));
                command.Parameters.Add(new SqlParameter("@Date", dto.Date));
                command.Parameters.Add(new SqlParameter("@Details", dto.Details));
                command.Parameters.Add(new SqlParameter("@EndTime", dto.EndTime));
                command.Parameters.Add(new SqlParameter("@StartTime", dto.StartTime));
                command.Parameters.Add(new SqlParameter("@NrOfBar", dto.NrOfBar));
                command.Parameters.Add(new SqlParameter("@NrOfEvent", dto.NrOfEvent));
                command.Parameters.Add(new SqlParameter("@NrOfOther", dto.NrOfIets));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ShiftDTO> GetAllShifts()
        {
            var shifts = new List<ShiftDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllShifts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    shifts.Add(new ShiftDTO
                    {
                      Id      = (int)reader["Id"],
                      Date     = (DateTime)reader["Date"],
                      StartTime =(TimeSpan)reader["StartTime"],
                      EndTime = (TimeSpan)reader["EndTime"],
                      Details = (string)reader["Details"],
                      NrOfBar = (int)reader["NrOfBar"],
                      NrOfEvent = (int)reader["NrOfEvent"],
                      NrOfIets = (int)reader["NrOfOther"],

                    });
                }
            }

            return shifts;
        }

        public IEnumerable<ShiftDTO> GetAllShiftsFromPeriod(DateTime startdate, DateTime enddate)
        {
            var shifts = new List<ShiftDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllShiftsFromPeriod", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StartDate", startdate));
                command.Parameters.Add(new SqlParameter("@EndDate", enddate));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shifts.Add(new ShiftDTO
                    {
                        Id = (int)reader["Id"],
                        Date = (DateTime)reader["Date"],
                        StartTime = (TimeSpan)reader["StartTime"],
                        EndTime = (TimeSpan)reader["EndTime"],
                        Details = (string)reader["Details"],
                        NrOfBar = (int)reader["NrOfBar"],
                        NrOfEvent = (int)reader["NrOfEvent"],
                        NrOfIets = (int)reader["NrOfOther"],

                    });
                }
            }

            return shifts;

        }

        public IEnumerable<string> GetRoles(int id)
        {
            throw new NotImplementedException();
        }

        public ShiftDTO GetShift(int id)
        {
            var shift = new ShiftDTO();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shift.Id = (int) reader["Id"];
                    shift.Date = (DateTime)reader["Date"];
                    shift.StartTime = (TimeSpan)reader["StartTime"];
                    shift.EndTime = (TimeSpan)reader["EndTime"];
                    shift.Details = (string) reader["Details"];
                    shift.NrOfBar = (int) reader["NrOfBar"];
                    shift.NrOfEvent = (int) reader["NrOfEvent"];
                    shift.NrOfIets = (int) reader["NrOfOther"];
                }
            }

            return shift;
        }

        public void RemoveShift(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("DeleteShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
