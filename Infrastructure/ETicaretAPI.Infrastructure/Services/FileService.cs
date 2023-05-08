using ETicaretAPI.Application.Services;
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
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameASync(uploadPath, file.FileName);

                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true)))
                return datas;

            return null;
        }
    }
}