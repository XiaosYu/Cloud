using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Csv
{
    static public partial class Extension
    {
        static public void LoadStream(this ICsv csv, Stream stream)
        {
            using var file = new StreamReader(stream);
            csv.Load(file.ReadToEnd());
        }
        static public void LoadFile(this ICsv csv, string filename) 
            => csv.LoadStream(File.OpenRead(filename));
        static public void LoadString(this ICsv csv, string content)
            => csv.Load(content);
        static public Task LoadStreamAsync(this ICsv csv, Stream stream)
            => Task.Factory.StartNew(() => csv.LoadStream(stream));
        static public Task LoadFileAsync(this ICsv csv, string filename)
            => Task.Factory.StartNew(() => csv.LoadFile(filename));
        static public Task LoadStringAsync(this ICsv csv, string source)
            => Task.Factory.StartNew(() => csv.LoadString(source));
    }
}
