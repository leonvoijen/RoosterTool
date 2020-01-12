using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Context
{
    public class AvailabilityContext: IAvailabilityContext
    {
        private readonly string _connectionstring = @"Server=mssql.fhict.local;Database=dbi386833_rooster;User Id=dbi386833_rooster;Password=Rooster";


        public List<AvailabilityDTO> GetAllAvailability()
        {
            var availability = new List<AvailabilityDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllAvailability", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    availability.Add(new AvailabilityDTO
                    {
                        UserId = (int)reader["EmployeeUserId"],
                        StartMonday = (TimeSpan)reader["MondayStart"],
                        StartTuesday = (TimeSpan)reader["TuesdayStart"],
                        StartWednesday = (TimeSpan)reader["WednesdayStart"],
                        StartThursday = (TimeSpan)reader["ThursdayStart"],
                        StartFriday = (TimeSpan)reader["FridayStart"],
                        StartSaturday = (TimeSpan)reader["SaturdayStart"],
                        StartSunday = (TimeSpan)reader["SundayStart"],
                        EndMonday = (TimeSpan)reader["MondayEnd"],
                        EndTuesday = (TimeSpan)reader["TuesdayEnd"],
                        EndWednesday = (TimeSpan)reader["WednesdayEnd"],
                        EndThursday = (TimeSpan)reader["ThursdayEnd"],
                        EndFriday = (TimeSpan)reader["FridayEnd"],
                        EndSaturday = (TimeSpan)reader["SaturdayEnd"],
                        EndSunday = (TimeSpan)reader["SundayEnd"],
                    });
                }
            }

            return availability;
        }

        public AvailabilityDTO GetAvailability(int UserId)
        {
            var availability = new AvailabilityDTO();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAvailabilityByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", UserId));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    availability.UserId = (int) reader["UserId"];
                    availability.StartMonday = (TimeSpan) reader["MondayStart"];
                    availability.StartTuesday = (TimeSpan) reader["TuesdayStart"];
                    availability.StartWednesday = (TimeSpan) reader["WednesdayStart"];
                    availability.StartThursday = (TimeSpan) reader["ThursdayStart"];
                    availability.StartFriday = (TimeSpan) reader["FridayStart"];
                    availability.StartSaturday = (TimeSpan) reader["SaturdayStart"];
                    availability.StartSunday = (TimeSpan) reader["SundayStart"];
                    availability.EndMonday = (TimeSpan) reader["MondayEnd"];
                    availability.EndTuesday = (TimeSpan) reader["TuesdayEnd"];
                    availability.EndWednesday = (TimeSpan) reader["WednesdayEnd"];
                    availability.EndThursday = (TimeSpan) reader["ThursdayEnd"];
                    availability.EndFriday = (TimeSpan) reader["FridayEnd"];
                    availability.EndSaturday = (TimeSpan) reader["SaturdayEnd"];
                    availability.EndSunday = (TimeSpan) reader["SundayEnd"];

                }
            }

            return availability;
        }

        public void UpdateAvailability(AvailabilityDTO dtotransfer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("UpdateAvailabilityByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserId", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@MondayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@TuesdayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@WednesdayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@ThursdayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@FridayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@SaturdayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@SundayStart", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@MondayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@TuesdayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@wednesdayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@ThursdayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@FridayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@SaturdayEnd", dtotransfer.UserId));
                command.Parameters.Add(new SqlParameter("@SundayEnd", dtotransfer.UserId));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<DateTime> GetLeave()
        {
            throw new NotImplementedException();
        }
    }
}
