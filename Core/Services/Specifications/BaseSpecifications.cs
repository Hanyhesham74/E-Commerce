using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)     
        {
            Criteria = criteria;
        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; } 

        public List<Expression<Func<TEntity, object>>> IncludeExperssions { get; } = new();



        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExperssions.Add(includeExpression);
        }

        public Expression<Func<TEntity, object>> OrderBy  { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int PageSize, int PageIndex)
        {
            
            IsPaginated = true;
            Take = PageSize;
            Skip = PageSize * (PageIndex - 1);
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}
