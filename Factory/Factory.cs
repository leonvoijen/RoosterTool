using System;
using DAL;
using DAL.Memory;

namespace Factory
{
    public class Factory
    {
        private static readonly  EmployeeMemory memory = new EmployeeMemory();
    }
}
