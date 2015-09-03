using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace diff_smrt.core
{
    public class Item
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public DirectoryInfo Directory { get; set; }
        public List<FileInfo> Files { get; set; }

        public int Filecount { get; set; }

        public Item(DirectoryInfo info)
        {
            this.Directory = info;
            this.Name = info.Name;
        }

        public static Item Create(DirectoryInfo info)
        {
            byte[] bytearr;
            List<byte> hashlist = new List<byte>();

            var item = new Item(info);
            item.Files = info.EnumerateFiles().ToList();

            if (item.Files.Count == 0) return null;

            item.Filecount = item.Files.Count;

            //using (var md5 = MD5.Create())
            //{
            //    foreach (var file in item.Files)
            //    {
            //        using (var stream = new BufferedStream(System.IO.File.OpenRead(file.FullName), 1200000))
            //        {
            //            bytearr = md5.ComputeHash(stream);
            //            System.Diagnostics.Debug.WriteLine("{0}\t{1}", file.Name, BitConverter.ToString(bytearr).Replace("-", string.Empty));
            //            hashlist.AddRange(bytearr);
            //        }
            //    }
            //    bytearr = md5.ComputeHash(hashlist.ToArray());
            //}

            //item.Hash = BitConverter.ToString(bytearr).Replace("-", string.Empty);
            return item;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
