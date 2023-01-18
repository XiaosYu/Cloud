using Cloud.Utility.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Csv
{
    public class CsvReader<TEntity>: IEnumerable, IEnumerable<TEntity>, ICsv where TEntity : class, new()
    {
        public string ContentSplit { set; get; } = ",";
        public string LineSplits { set; get; } = "\n";

        protected List<TEntity> Sources { get; } = new List<TEntity>();

        public CsvReader() { }

        public void Load(string source)
        {
            var content = source;
            foreach (var line in content.Split(LineSplits))
            {
                var result = line.Split(ContentSplit).ToArray<object>().MapEntity<TEntity>();
                Sources.Add(result);
            }
        }

        public string UnLoad()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entity in Sources)
            {
                sb.Append(entity.MapString().Synthesize(ContentSplit));
                sb.Append(LineSplits);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public CsvGrid ToGrid()
            => new CsvGrid(this);

        
        public int Count => Sources.Count;
        

        public IEnumerator GetEnumerator()
        {
            return Sources.GetEnumerator();
        }
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return Sources.GetEnumerator();
        }
    }

   
}
