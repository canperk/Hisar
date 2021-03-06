﻿using System.IO;
using System.Linq;

namespace NetCoreStack.Hisar
{
    internal static class PathUtility
    {
        public static void CopyToFiles(string source, string destination)
        {
            Directory.CreateDirectory(destination);

            foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly)
                .Where(file => file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("nupkg")))
            {
                File.Copy(newPath, newPath.Replace(source, destination), true);
            }
        }

        public static string TryGetComponentsJson(string externalComponentsDirectory)
        {
            var componentsJsonfile = Path.Combine(externalComponentsDirectory, "components.json");
            var fullPath = Path.GetFullPath(componentsJsonfile);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }

            return string.Empty;
        }
    }
}
