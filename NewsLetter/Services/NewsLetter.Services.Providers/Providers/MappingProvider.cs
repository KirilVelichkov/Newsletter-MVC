using AutoMapper;
using Bytes2you.Validation;
using NewsLetter.Services.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Providers.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
