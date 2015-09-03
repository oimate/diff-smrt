using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace diff_smrt.core.Items
{
    public class File : Item
    {
        public override string Name { get { return info.Name; } }

        private FileInfo info;

        public File(FileInfo info, Item parent)
        {
            this.info = info;
            this.Parent = parent;
        }

        public override void CalculateHash()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = new BufferedStream(System.IO.File.OpenRead(info.FullName), 1200000))
                {
                    this.hashlist = md5.ComputeHash(stream).ToList();
                    if (Parent.hashlist == null) Parent.hashlist = new List<byte>();
                    Parent.hashlist.AddRange(this.hashlist);
                    this.Hash = BitConverter.ToString(this.hashlist.ToArray()).Replace("-", string.Empty);
                }
            }
        }
    }
}
