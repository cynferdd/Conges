using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.Web.Abstraction
{
    public interface IMapper<TSource, TDest>
    {
        TDest Map(TSource sourceData);

        TSource Map(TDest destData);
    }
}
