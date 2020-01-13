using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Context
{
    public class EmployeeContext : IEmployeeContext
    {
        private readonly string _connectionstring = @"Server=mssql.fhict.local;Database=dbi386833_rooster;User Id=dbi386833_rooster;Password=Rooster";
        public void AddEmployee(EmployeeDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                int UserId = GetAllEmployees().Count + 1;
                SqlCommand command = new SqlCommand("AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserId", UserId));
                command.Parameters.Add(new SqlParameter("@IsBar", dto.Bar));
                command.Parameters.Add(new SqlParameter("@IsEvent", dto.Events));
                command.Parameters.Add(new SqlParameter("@IsOther", dto.Overig));
                command.Parameters.Add(new SqlParameter("@MaxHours", dto.MaxHours));
                command.Parameters.Add(new SqlParameter("@Name", dto.Name));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", dto.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@PicUrl", dto.PicUrl));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeEmployee(EmployeeDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("ChangeEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", dto.Id));
                command.Parameters.Add(new SqlParameter("@IsBar", dto.Bar));
                command.Parameters.Add(new SqlParameter("@IsEvent", dto.Events));
                command.Parameters.Add(new SqlParameter("@IsOther", dto.Overig));
                command.Parameters.Add(new SqlParameter("@Name", dto.Name));
                command.Parameters.Add(new SqlParameter("@MaxHours", dto.MaxHours));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", dto.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@PicUrl", dto.PicUrl));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DecreaseHours(int id, int hours)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("ChangeEmployeeHours", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Hours", hours));
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", id));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new EmployeeDTO
                    {
                        Id = (int)reader["UserId"],
                        Bar = (bool)reader["IsBar"],
                        Events = (bool)reader["IsEvent"],
                        Overig = (bool)reader["IsOther"],
                        MaxHours = (int)reader["MaxHours"],
                        Name = (string)reader["Name"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        PicUrl = (string)reader["PicUrl"]
                    });
                }
            }

            return employees;
        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = new EmployeeDTO();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee.Id = (int) reader["UserId"];
                    employee.Bar = (bool) reader["IsBar"];
                    employee.Events = (bool) reader["IsEvent"];
                    employee.Overig = (bool) reader["IsOther"];
                    employee.MaxHours = (int) reader["MaxHours"];
                    employee.Name = (string) reader["Name"];
                    employee.PhoneNumber = (string) reader["PhoneNumber"];
                    employee.PicUrl = (string) reader["PicUrl"];
                }
            }

            return employee;
        }

        public int GetMaxHours(int id)
        {
            int hours = 0;

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetMaxHours", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    hours = (int)reader["MaxHours"];
                }
            }

            return hours;
        }

        public IEnumerable<string> GetRoles(int id)
        {
            throw new NotImplementedException();
        }

        public int GetTotalAvailabeHours()
        {
            int hours = 0;

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetTotalAvailableHours", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    hours = (int) reader["Totalhours"];
                }
        }

            return hours;
        }

        public int GetTotalEmployees()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("CountEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    count = (int)reader["TotalEmployees"];
                }
            }
            return count;
        }

        public void RemoveEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("RemoveEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeUserId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
