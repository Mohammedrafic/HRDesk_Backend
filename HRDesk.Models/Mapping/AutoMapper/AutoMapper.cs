using AutoMapper;
using HRDesk.Models.mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.Models.Mapping.AutoMapper
{
    public static class AutoMapper
    {
        public static void RegisterMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfiles(new Profile[] { new EmployeeMap() });
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
