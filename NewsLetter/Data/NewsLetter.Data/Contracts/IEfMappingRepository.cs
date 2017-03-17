using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Data.Contracts
{
    public interface IEfMappingRepository<T> : IEfGenericRepository<T> where T : class
    {
        TDestitanion GetFirstMapped<TDestitanion>(Expression<Func<T, bool>> filterExpression);

        IEnumerable<TDestination> GetAllMapped<TDestination>();

        IEnumerable<TDestination> GetAllMapped<TDestination>(Expression<Func<T, bool>> filterExpression);

        IEnumerable<TDestination> GetAllMapped<T1, TDestination>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sort);

        IEnumerable<TDestination> GetAllMapped<TDestination>(Expression<Func<T, bool>> filterExpression, int page, int size);

        IEnumerable<TDestination> GetAllMapped<T1, TDestination>(
                Expression<Func<T, bool>> filterExpression,
                Expression<Func<T, T1>> sort,
                int page, int size);
    }
}
