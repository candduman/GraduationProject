using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class GenericResponse<T>
    {
        public bool Result { get; set; }
        public string ResultMessage { get; set; }
        public T Value { get; set; }
    }
}
