using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.EntityFramework
{
    public class DbSet<TEntry, TContext> where TEntry : class where TContext : DbContext, new()
    {
        public DbSet(DbSet<TEntry> set, DbContext<TContext> context)
        {
            Set = set;
            Context = context;
        }

        protected DbSet<TEntry> Set { get; }

        protected DbContext<TContext> Context { get; }

        public IEnumerable<TEntry> Where(Func<TEntry, bool> predicate)
            => Context.Invoke(s => Set.Where(predicate));

        public List<TEntry> Query(Func<TEntry, bool> predicate)
            => Context.Invoke(s => Set.Where(predicate).ToList());
        public Task<List<TEntry>> QueryAsync(Func<TEntry, bool> predicate)
            => Context.InvokeAsync(s => Set.Where(predicate).ToList());

        public IEnumerable<IGrouping<TKey, TEntry>> GroupBy<TKey>(Func<TEntry, TKey> keySelector)
            => Context.Invoke(s => Set.GroupBy(keySelector));

        public Task<IEnumerable<IGrouping<TKey, TEntry>>> GroupByAsync<TKey>(Func<TEntry, TKey> keySelector)
            => Context.InvokeAsync(s => Set.GroupBy(keySelector));

        public IOrderedEnumerable<TEntry> OrderBy<TKey>(Func<TEntry, TKey> keySelector)
            => Context.Invoke(s => Set.OrderBy(keySelector));

        public TEntry? FirstOrDefault()
            => Context.Invoke(s => Set.FirstOrDefault());

        public Task<TEntry?> FirstOrDefaultAsync()
            => Context.InvokeAsync(s => Set.FirstOrDefault());

		public TEntry? FirstOrDefault(Func<TEntry, bool> predicate)
			=> Context.Invoke(s => Set.FirstOrDefault(predicate));

		public Task<TEntry?> FirstOrDefaultAsync(Func<TEntry, bool> predicate)
			=> Context.InvokeAsync(s => Set.FirstOrDefault(predicate));

		public void ForEach(Action<TEntry> action)
            => Context.Invoke(s => Set.ToList().ForEach(action));

        public void ForEachAsync(Action<TEntry> action)
            => Context.InvokeAsync(s => Set.ToList().ForEach(action));

        public List<TEntry> ToList()
            => Context.Invoke(s => Set.ToList());

        public Task<List<TEntry>> ToListAsync()
            => Context.InvokeAsync(s => Set.ToList());
    }
}
