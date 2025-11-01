using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    internal class SpecificationsEvluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity,TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            //apply criteria
            if (specifications.Criteria != null)
            {
                query = query.Where(specifications.Criteria);
            }
            //apply includes
            if(specifications.IncludeExperssions != null && specifications.IncludeExperssions.Any())
            {
                foreach (var includeExpression in specifications.IncludeExperssions)
                {
                    query = query.Include(includeExpression);
                }
            }

            if(specifications.OrderBy != null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            if(specifications.OrderByDescending != null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }
            return query;
        }
    }
}
