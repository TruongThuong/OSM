using Microsoft.AspNetCore.Mvc.Filters;
using OSM.Data;
using OSM.Data.Infrastructure;
using System;

namespace OSM.Data.Infrastructure
{
    public class UnitOfWork : ActionFilterAttribute, IUnitOfWork
    {
        private readonly AppsDbContext _dbContext;

        public UnitOfWork(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Request.Method.Equals("Post", StringComparison.OrdinalIgnoreCase))
                return;
            if (context.Exception == null && context.ModelState.IsValid)
            {
                _dbContext.Database.CommitTransaction();
            }
            else
            {
                _dbContext.Database.RollbackTransaction();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Method.Equals("Post", StringComparison.OrdinalIgnoreCase))
                return;
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}