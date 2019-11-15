using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VanChi.Utility
{
    public class FileAttachUtility
    {
        public static bool GetFileAttach(HttpPostedFileBase file, out string name, out string fileExt, out string fileSize, out byte[] fileContent)
        {
            name = String.Empty;
            fileExt = String.Empty;
            fileSize = String.Empty;
            fileContent = null;
            try
            {
                name = Path.GetFileName(file.FileName);
                fileExt = Path.GetExtension(file.FileName);
                fileSize = file.ContentLength.ToString();
                fileContent = new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
                //fileContent = new byte[file.InputStream.Length];
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
