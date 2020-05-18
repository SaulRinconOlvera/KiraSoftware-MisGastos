using Microsoft.EntityFrameworkCore;
using MisGastos.Infrastructure.DAL.Contexts;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using System;
using System.Threading.Tasks;

namespace MisGastos.Infrastructure.Repository.Base
{
    public partial class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork() {
            Context = new Application_Context();
            InitRepositories();
        }

        public UnitOfWork(DbContext context) { Context = context; }

        public DbContext Context { get; private set; }

        public int Commit()
        {
            try { return Context.SaveChanges(); }
            catch (Exception e)
            {
                if (e.InnerException != null) throw e.InnerException;
                else throw e;
            }
        }

        public Task<int> CommitAsync()
        {
            try { return Context.SaveChangesAsync(); }
            catch (Exception e)
            {
                if (e.InnerException != null) throw e.InnerException;
                else throw e;
            }
        }

        public void Dispose()
        {
            if(Context != null) Context.Dispose();
        }
    }
}
