using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightgunStudio.Core.Dtos
{
    public class FolderDto
    {
        public string Name { get; set; }
        public FolderDto Parent { get; set; }
        public List<FolderDto> Children { get; set; }
    }
}
