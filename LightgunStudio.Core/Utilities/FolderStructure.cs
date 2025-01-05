using LightgunStudio.Core.Dtos;
using Newtonsoft.Json;

namespace LightgunStudio.Core.Utilities
{
    public class FolderStructure
    {
        public static void CreateFolderStructure()
        {
            var dllDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (dllDirectory == null) return;
            var root = Directory.GetParent(dllDirectory);
            if (root == null) return;
            using (var r = new StreamReader(dllDirectory + @"\Templates\FolderStructure.json"))
            {
                string json = r.ReadToEnd();
                if (json == null) return;
                var folders = JsonConvert.DeserializeObject<List<FolderDto>>(json);
                if (folders == null || folders.Count == 0) return;
                CreateFoldersFromTree(folders, root.FullName);
            }
        }
        private static void CreateFoldersFromTree(List<FolderDto> nodes, string parentFullPath)
        {
            foreach (var node in nodes)
            {
                var folder = parentFullPath + @"\" + node.Name;
                Directory.CreateDirectory(folder);
                if (node.Children != null && node.Children.Count != 0)
                {
                    CreateFoldersFromTree(node.Children, folder);
                }
            }
        }
    }
}
