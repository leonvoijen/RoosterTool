using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;

namespace DAL.Context
{
    public class ScheduleContext : IScheduleContext
    {
        private readonly string _connectionstring = @"Server=mssql.fhict.local;Database=dbi386833_rooster;User Id=dbi386833_rooster;Password=Rooster";
    }
}
