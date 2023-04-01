using System.Collections.Generic;
using System.IO;

namespace UnityTools.Runtime.Save
{
    public class BinaryDataReader
    {
        public static void Read(string fileName, out List<string> data)
        {
            data = new List<string>();
            using var reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                data.Add(line);
            }
        }
    }
}