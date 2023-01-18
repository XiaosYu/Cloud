using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Compression
{
    abstract public class ZipContext
    {
        public ZipContext() { }

        public int BufferSize { get; set; } = 4096;
        public string Password { get; set; } = string.Empty;
        public int ZipLevel { get; set; } = 6;
        public abstract void Compress(string path);
        public virtual Task CompressAsync(string path)
        {
            Task task = new Task(() => Compress(path));
            task.Start();
            return task;
        }

    }
}
