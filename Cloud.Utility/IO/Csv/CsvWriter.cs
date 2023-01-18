using Cloud.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Csv
{
    public class CsvWriter<TEntity> : ICsv where TEntity : class, new()
    {
        public string ContentSplit { set; get; } = ",";
        public string LineSplits { set; get; } = "\n";

        public CsvWriter() { }
        
        protected List<TEntity> Sources { get; } = new List<TEntity>();

        public void Load(string content)
        {
            foreach (var line in content.Split(LineSplits))
            {
                var result = line.Split(ContentSplit).ToArray<object>().MapEntity<TEntity>();
                Sources.Add(result);
            }
        }
        public string UnLoad()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var entity in Sources) 
            {
                sb.Append(entity.MapString().Synthesize(ContentSplit));
                sb.Append(LineSplits);
            }
            sb.Remove(sb.Length - 1, 1); 
            return sb.ToString();
        }

        public CsvWriter<TEntity> AppendEntity(TEntity entity)
        {
            Sources.Add(entity);
            return this;
        }
        public CsvWriter<TEntity> AppendEntities(IEnumerable<TEntity> entities) 
        {
            Sources.AddRange(entities);
            return this;
        }
        public IEnumerable<TEntity> QueryAll(Func<TEntity, bool> predicate)
            => Sources.Where(predicate);
        public TEntity? Query(Func<TEntity, bool> predicate)
            => Sources.FirstOrDefault(predicate);
        public CsvWriter<TEntity> UpdateEntity(TEntity entity, Func<TEntity, bool> predicate)
        {
            var target = Sources.FirstOrDefault(predicate);
            if(target == null) throw new ObjectNotFoundException();
            var index = Sources.IndexOf(target);
            Sources[index] = entity;
            return this;
        }

        public void Save(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(UnLoad());
            sw.Close();
        }
        public async Task SaveAsync(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            await sw.WriteAsync(UnLoad());
            sw.Close();
        }
    }
}
