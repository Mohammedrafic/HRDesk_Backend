using AutoMapper;
using HRDesk.DL.Models.DB;
using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.Models.mapper
{
    public class EmployeeMap : Profile
    {
        public EmployeeMap()
        {
            CreateMap<Employee, EmployeeResponse>();
        }
    }
}
