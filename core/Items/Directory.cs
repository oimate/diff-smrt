using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace diff_smrt.core.Items
{
    public class Directory : Item
    {
        public override string Name { get { return info.Name; } }

        private DirectoryInfo info;

        public Directory(DirectoryInfo info)
        {
            this.info = info;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", base.ToString());
        }

        public override void CalculateHash()
        {
            using (var md5 = MD5.Create())
            {
                this.hashlist = md5.ComputeHash(this.hashlist.ToArray()).ToList();
                if (Parent != null)
                {
                    if (Parent.hashlist == null) Parent.hashlist = new List<byte>();
                    Parent.hashlist.AddRange(this.hashlist);
                }
                this.Hash = BitConverter.ToString(this.hashlist.ToArray()).Replace("-", string.Empty);
            }
        }
    }
}
