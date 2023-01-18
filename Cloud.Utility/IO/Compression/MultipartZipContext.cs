using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.IO.Compression
{
    public class MultipartZipContext: ZipContext
    {
        public MultipartZipContext() { }

        public Dictionary<string, List<(string, string)>> _entities { get; } = new Dictionary<string, List<(string, string)>>();

        public void Add(string block, string path, string id)
        {
            if(!File.Exists(path)) throw new FileNotFoundException();
            if(_entities.ContainsKey(block)) _entities[block].Add((path, id));
            else
            {
                _entities.Add(block, new List<(string, string)>()
                {
                    (path, id)
                });
            }
        }
        public void Add(string block, string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            var id = Path.GetFileName(path);
            if (_entities.ContainsKey(block)) _entities[block].Add((path, id));
            else
            {
                _entities.Add(block, new List<(string, string)>()
                {
                    (path, id)
                });
            }
        }
        public void AddRange(string block, IEnumerable<(string, string)> datas)
        {
            foreach(var data in datas)
                Add(block, data.Item1, data.Item2);
        }
        public void AddRange(string block, IEnumerable<string> datas)
        {
            foreach (var data in datas)
                Add(block, data);
        }
        public void AddDirectory(string path, Func<string, string>? convert = null)
        {
            if (Directory.Exists(path))
            {
                if (convert is null)
                {
                    var block = path.Split('\\').Reverse().First();
                    foreach (var f in Directory.GetFiles(path))
                    {
                        Add(block ,f, Path.GetFileName(f));
                    }
                }
                else
                {
                    var block = path.Split('\\').Reverse().First();
                    foreach (var f in Directory.GetFiles(path))
                    {
                        Add(block, f, convert(f));
                    }
                }
            }
            else throw new DirectoryNotFoundException();
        }
        public void Clear()
            => _entities.Clear();

        public override void Compress(string path)
        {
            using var stream = new ZipOutputStream(File.Create(path));
            stream.Password = Password;
            stream.SetLevel(ZipLevel);
            var name = Path.GetFileNameWithoutExtension(path);
            var buffer = new byte[BufferSize];
            foreach(var item in _entities)
            {
                foreach(var entity in item.Value)
                {
                    var p = $"{name}\\{item.Key}\\{entity.Item2}";
                    ZipEntry entry = new ZipEntry(p);
                    stream.PutNextEntry(entry);
                    using var fs = File.OpenRead(entity.Item1);
                    int len = 0;
                    do
                    {
                        len = fs.Read(buffer, 0, BufferSize);
                        stream.Write(buffer, 0, len);
                    } while (len > 0);
                }
            }
            stream.Finish();
            stream.Close();
        }
        
    }
}
