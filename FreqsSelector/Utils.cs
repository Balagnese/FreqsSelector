using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreqsSelector
{
    class Utils
    {
        public static void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        
        public static string JoinPathParts(string part1, string part2, params string[] pathParts)
        {
            string res = part1 + (part1.EndsWith("\\")?"":"\\")+part2;
            for(int i = 0; i < pathParts.Length; i++)
            {
                res += (res.EndsWith("\\") ? "" : "\\") + pathParts[i];
            }
            return res;
        }

        public static string GetBaseDir(string filePath)
        {
            return filePath.Substring(0, filePath.LastIndexOf('\\'));
        }

        public static string GetFilename(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf('\\') + 1);
        }

        public static Dictionary<string, List<string>> GroupFilesByFolders(string[] paths)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            foreach(var p in paths)
            {
                string dir = GetBaseDir(p);
                if (!d.ContainsKey(dir))
                {
                    d[dir] = new List<string>();
                }
                d[dir].Add(p);
            }
            return d;
        }
    }
}
