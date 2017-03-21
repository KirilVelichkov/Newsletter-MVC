using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Providers.Contracts
{
    public interface IMappingProvider
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
