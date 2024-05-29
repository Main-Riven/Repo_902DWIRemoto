using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGS902.CATestApi.ApiClima
{
    public class RespuestaClima
    {
        public Ciudad Location { get; set; }
        public Clima Current { get; set; }
    }
}
