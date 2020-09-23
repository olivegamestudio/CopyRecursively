using System;
using System.IO;

namespace CopyRecursively
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            string target = args[1];
            string pattern = "*.*";
            if (args.Length > 2)
                pattern = args[2];

            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            foreach (string filename in Directory.GetFiles(path, pattern, SearchOption.AllDirectories))
            {
                string sourceFilename = Path.GetFileName(filename);
                string sourcePath = Path.GetDirectoryName(filename);

                if (sourcePath.ToLowerInvariant() != target.ToLowerInvariant())
                {
                    string destPath = Path.Combine(target,sourceFilename);
                    File.Copy(filename, destPath, true);
                    Console.WriteLine(filename +" copied to " + destPath);
                }
            }
        }
    }
}
