using NewsLetter.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using System.Data.Entity;
using Bytes2you.Validation;

namespace NewsLetter.Data.Repositories
{
    public class EfMappingRepository<T> : EfGenericRepository<T>, IEfMappingRepository<T> where T : class
    {
        private readonly IMapper mapper;

        public EfMappingRepository(DbContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public TDestitanion GetFirstMapped<TDestitanion>(Expression<Func<T, bool>> filterExpression)
        {
            var result = this.All.Where(filterExpression).ProjectToFirstOrDefault<TDestitanion>(this.mapper.ConfigurationProvider);

            return result;
        }

        public IEnumerable<TDestination> GetAllMapped<TDestination>()
        {
            var result = this.All.ProjectToList<TDestination>(this.mapper.ConfigurationProvider);

            return result;
        }

        public IEnumerable<TDestination> GetAllMapped<TDestination>(Expression<Func<T, bool>> filterExpression)
        {
            var result = this.All.Where(filterExpression).ProjectToList<TDestination>(this.mapper.ConfigurationProvider);

            return result;
        }

        public IEnumerable<TDestination> GetAllMapped<TDestination>(
            Expression<Func<T, bool>> filterExpression,
            int page, int size)
        {
            var result = this.All
                .Where(filterExpression)
                .Skip(page * size)
                .Take(size)
                .ProjectToList<TDestination>(this.mapper.ConfigurationProvider);

            return result;
        }

        public IEnumerable<TDestination> GetAllMapped<T1, TDestination>(
             Expression<Func<T, bool>> filterExpression,
             Expression<Func<T, T1>> sort,
             int page, int size)
        {
            var result = this.All
                .Where(filterExpression)
                .OrderByDescending(sort)
                .Skip(page * size)
                .Take(size)
                .ProjectToList<TDestination>(this.mapper.ConfigurationProvider);

            return result;
        }

        public IEnumerable<TDestination> GetAllMapped<T1, TDestination>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sort)
        {
            var result = this.All
                .Where(filterExpression)
                .OrderByDescending(sort)
                .ProjectToList<TDestination>(this.mapper.ConfigurationProvider);

            return result;
        }
    }
}
