using System;
using Core.Utilities.Helpers.GuidHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        

        public string Update(IFormFile file, string filePath, string root)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (File.Exists(filePath)) ;
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

       

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);

                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }

            return null;
        }
    }
}
