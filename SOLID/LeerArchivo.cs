using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class LeerArchivo
    {
        public string[] ObtenerArchivo(string _cPath)
        {            
            return System.IO.File.ReadAllLines(_cPath);            
        }
    }
}
