using ETicaretAPI.Infrastructure.Operations;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService
    {
        async Task<string> FileRenameASync(string path, string fileName, bool first = true)
        {
          return await Task.Run<string>(() =>

            {

                string oldName = Path.GetFileNameWithoutExtension(fileName);

                string extension = Path.GetExtension(fileName);

                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";

                bool fileIsExists = false;

                int fileIndex = 0;

                do

                {

                    if (File.Exists($"{path}\\{newFileName}"))

                    {

                        fileIsExists = true;

                        fileIndex++;

                        newFileName = $"{NameOperation.CharacterRegulatory(oldName + "-" + fileIndex)}{extension}";

                    }

                    else

                    {

                        fileIsExists = false;

                    }

                } while (fileIsExists);



                return newFileName;



           });
        }
    }
}