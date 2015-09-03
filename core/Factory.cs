using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace diff_smrt.core
{
    public static class Factory
    {
        public static List<Item> AnalyzeDirectory(string path)
        {
            if (!Directory.Exists(path))
                return null;

            var currend_di = new DirectoryInfo(path);

            var dirs = currend_di.EnumerateDirectories("*", SearchOption.AllDirectories);

            var itemlist = new List<Item>();

            foreach (var dir in dirs)
            {
                var item = Item.Create(dir);
                if (item != null)
                    itemlist.Add(item);
            }

            return itemlist;
        }

        public static List<Item> Compare(List<Item> left, List<Item> right)
        {
            var duplicates = new List<Item>();

            var cmpr = new Eqcmpr();

            var test = from x in left
                       where right.Contains(x, cmpr)
                       select x;

            duplicates = test.ToList();

            return duplicates;
        }

        public static IEqualityComparer<Item> comparer { get; set; }
    }

    class Eqcmpr : IEqualityComparer<Item>
    {

        public bool Equals(Item x, Item y)
        {
            return x.Name == y.Name && x.Filecount == y.Filecount;
        }

        public int GetHashCode(Item obj)
        {
            return obj.GetHashCode();
        }
    }
}
