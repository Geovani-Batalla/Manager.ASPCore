using Entities.ASPCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ASPCore.DropBox
{
    public class DropBoxResult : Result
    {
        public DropBoxResult()
        {
            List<DropBoxFiles> DropBoxFiles = new List<DropBoxFiles>();
        }

        public List<DropBoxFiles> DropBoxFiles { get; set; }
        public List<byte[]> Images { get; set; }
        public int CountFiles { get; set; }
        public List<string> Files { get; set; }
        public byte[] Image { get; set; }
        public string Image_Name { get; set; }
    }
}
