using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.DbContext
{
    public class DbSet<TEntry, TContext> where TEntry : class where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet(Microsoft.EntityFrameworkCore.DbSet<TEntry> set, DbContext<TContext> context)
        {
            Set = set;
            Context = context;

        }

        protected Microsoft.EntityFrameworkCore.DbSet<TEntry> Set { get; }

        protected DbContext<TContext> Context { get; }

        public IEnumerable<TEntry> Query(Func<TEntry, bool> predicate)
            => Context.Invoke(s => Set.Where(predicate));

        public Task<List<TEntry>> QueryAsync(Func<TEntry, bool> predicate)
            => Context.InvokeAsync(s => Set.Where(predicate).ToList());

        public List<TEntry> ToList()
            => Context.Invoke(s => Set.ToList());

        public Task<List<TEntry>> ToListAsync()
            => Context.InvokeAsync(s => Set.ToList());
    }
}
