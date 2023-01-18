using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Csv
{
    public interface ICsv
    {
        public string ContentSplit { set; get; }
        public string LineSplits { set; get; }
        public void Load(string source);
        public string UnLoad();
    }
}
