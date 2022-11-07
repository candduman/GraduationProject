using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public interface BusinessModel<T> where T : IContract
    {
        GenericResponse<T> Get(T entity);
        
    }
}
