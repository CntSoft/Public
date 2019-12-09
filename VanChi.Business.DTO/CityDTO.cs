using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.DTO
{
    public class CityDTO
    {
       public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CountryXid { get; set; }
    }
}
