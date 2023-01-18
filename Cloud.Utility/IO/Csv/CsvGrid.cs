using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Csv
{
    public class CsvGrid: ICsv
    {
        public CsvGrid() { }
        public CsvGrid(ICsv csv)
        {
            Load(csv.UnLoad());
        }


        public string ContentSplit { set; get; } = ",";
        public string LineSplits { set; get; } = "\n";

        protected List<List<string>> Sources = new List<List<string>>();

        public void Load(string source)
        {
            foreach (var item in source.Split(LineSplits))
            {
                List<string> line = new List<string>();
                line.AddRange(item.Split(ContentSplit));
            }
        }

        public string UnLoad()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var line in Sources) 
            {
                foreach(var cell in line) 
                {
                    sb.Append(cell);
                    sb.Append(ContentSplit);
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(LineSplits);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public int LinesCount => Sources.Count;

        public List<string> this[int line]
        {
            get => Sources[line];
            set => Sources[line] = value;
        }
        public string this[int line, int row]
        {
            get => Sources[line][row];
            set => Sources[line][row] = value;
        }
        

        public void AppendLine(params object[] contents) 
        {
            Sources.Add(contents.Select(s=>s.ToString()).ToList());
        }

    }
}
