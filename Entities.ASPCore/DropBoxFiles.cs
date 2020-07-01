using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ASPCore
{
    public class DropBoxFiles
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public bool IsShowable { get; set; }
    }
}
