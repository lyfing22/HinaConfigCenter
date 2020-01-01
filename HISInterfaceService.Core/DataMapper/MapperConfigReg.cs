using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HinaConfigCenter.Core.DataMapper
{
   public   class MapperConfigReg
    {
        public static void Register()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MapperConfig>();
            });
        }
    }
}
