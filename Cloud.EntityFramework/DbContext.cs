using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Cloud.EntityFramework
{
    abstract public class DbContext<TContext> where TContext : DbContext, new()
    {
        protected TContext Context { get; }
        protected DbContext(TContext context)
        {
            Context = context;
            Reflecta();
        }

        protected DbContext()
        {
            Context = new TContext();
            Reflecta();
        }

        protected TaskFactory Factory { get; } = new TaskFactory();
        protected object Lock { get; } = new object();

        private void Reflecta()
        {
            var type = Context.GetType();
            foreach (var tb in GetType().GetProperties().Where(s => s.Name.Contains("Tb")))
            {
                var target = tb.PropertyType.GetGenericArguments()[0];
                var rtype = type.GetProperties()
                    .FirstOrDefault(s => s.PropertyType.GetGenericArguments()[0] == target);
                if (rtype is not null)
                {
                    tb.SetValue(this, Activator.CreateInstance(type: tb.PropertyType, args: new object[] { rtype.GetValue(Context), this }));
                }

            }
        }

        public Task<TResult> InvokeAsync<TResult>(Func<TContext, TResult> method)
            => Factory.StartNew(() =>
            {
                TResult? result = default;
                lock (Lock)
                {
                    result = method(Context);
                }
                return result;
            });
        public TResult Invoke<TResult>(Func<TContext, TResult> method)
        {
            TResult? result = default;
            lock (Lock)
            {
                result = method(Context);
            }
            return result;
        }
        public Task InvokeAsync(Action<TContext> method)
            => Factory.StartNew(() =>
            {
                lock (Lock)
                {
                    method(Context);
                }
            });
        public void Invoke(Action<TContext> method)
        {
            lock (Lock)
            {
                method(Context);
            }
        }

        public void Add<TEntry>(TEntry entry) where TEntry : class
            => Invoke(s => s.Add(entry));
        public Task AddAsync<TEntry>(TEntry entry) where TEntry : class
            => InvokeAsync(s => s.Add(entry));
        public void AddRange<TEntry>(IEnumerable<TEntry> entries) where TEntry : class
            => Invoke(s => s.AddRange(entries));
        public Task AddRangeAsync<TEntry>(IEnumerable<TEntry> entries) where TEntry : class
            => InvokeAsync(s => s.AddRange(entries));

        public void Remove<TEntry>(TEntry entry) where TEntry : class
            => Invoke(s => s.Remove(entry));
        public Task RemoveAsync<TEntry>(TEntry entry) where TEntry : class
            => InvokeAsync(s => s.Remove(entry));
        public void RemoveRange<TEntry>(IEnumerable<TEntry> entries) where TEntry : class
            => Invoke(s => s.RemoveRange(entries));

        public EntityEntry<TEntry> Update<TEntry>(TEntry entry) where TEntry : class
            => Invoke(s => s.Update(entry));
        public Task<EntityEntry<TEntry>> UpdateAsync<TEntry>(TEntry entry) where TEntry : class
            => InvokeAsync(s => s.Update(entry));

        public int SaveChanges()
            => Invoke(s => s.SaveChanges());
        public Task<int> SaveChangesAsync()
            => InvokeAsync(s => s.SaveChanges());
    }
}