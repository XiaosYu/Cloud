namespace Cloud.Utility.IO.Compression
{
    public class SingleZipContext : ZipContext
    {
        public SingleZipContext() { }
        private List<(string, string)> _paths { get; } = new List<(string, string)>();

        public void Add(string path, string id)
        {
            if(File.Exists(path)) _paths.Add((path, id));
            else throw new FileNotFoundException();
        }
        public void AddRange(IEnumerable<string> paths, IEnumerable<string> ids)
        {
            foreach(var (path, id) in paths.Zip(ids)) 
            {
                Add(path, id);
            }
        }
        public void AddRange(IEnumerable<(string, string)> datas)
        {
            foreach(var data in datas) 
            {
                Add(data.Item1, data.Item2);
            }
        }
        public void AddDirectory(string path, Func<string, string>? convert=null)
        {
            if(Directory.Exists(path))
            {
                if(convert is null)
                {
                    foreach (var f in Directory.GetFiles(path))
                    {
                        Add(f, Path.GetFileName(f));
                    }
                }
                else
                {
                    foreach(var f in Directory.GetFiles(path))
                    {
                        Add(f, convert(f));
                    }
                }
            }
            else throw new DirectoryNotFoundException();
        }
        public void AddDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var f in Directory.GetFiles(path))
                {
                    Add(f, Path.GetFileName(f));
                }
            }
            else throw new DirectoryNotFoundException();
        }
        public void Remove(IEnumerable<string> datas)
            => _paths.RemoveAll(s => datas.Contains(s.Item1));
        public void Clear()
            => _paths.Clear();

        public override void Compress(string path)
        {
            using var stream = new ZipOutputStream(File.Create(path));
            stream.Password = Password;
            stream.SetLevel(ZipLevel);
            var name = Path.GetFileNameWithoutExtension(path);
            var buffer = new byte[BufferSize];
            
            foreach (var (p, id) in _paths)
            {
                var fs = $"{name}\\{id}";
                var entry = new ZipEntry(fs);
                stream.PutNextEntry(entry);
                using FileStream f = File.OpenRead(p);
                int len = 0;
                do
                {
                    len = f.Read(buffer, 0, BufferSize);
                    stream.Write(buffer, 0, len);
                } while (len > 0);
            }

            stream.Finish();
            stream.Close();
        }
        public override async Task CompressAsync(string path)
        {
            var task = new Task(async () =>
            {
                using var stream = new ZipOutputStream(File.Create(path));
                stream.Password = Password;
                stream.SetLevel(ZipLevel);
                var name = Path.GetFileNameWithoutExtension(path);
                var buffer = new byte[BufferSize];

                foreach (var (p, id) in _paths)
                {
                    var fs = $"{name}\\{id}";
                    var entry = new ZipEntry(fs);
                    await stream.PutNextEntryAsync(entry);
                    using FileStream f = File.OpenRead(p);
                    int len = 0;
                    do
                    {
                        len = f.Read(buffer, 0, BufferSize);
                        stream.Write(buffer, 0, len);
                    } while (len > 0);
                }
                stream.Finish();
                stream.Close();
            });
            task.Start();
            await task;
        }
    }
    
}
