using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        //private static string CurrentPathDirectory = Directory.GetCurrentDirectory();
        private static string sourcePath = Environment.CurrentDirectory + "\\wwwroot";
        private static string folderName = "\\CarImages\\";



        public static IResult Add(IFormFile file)
        {
            var fileExist = CheckFileExist(file);
            if (fileExist == null)
            {
                return new ErrorResult(fileExist.Message);
            }
            string extension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid().ToString() + "_" + extension;
            CreateImageFile(sourcePath + folderName + imageName, file);
            return new SuccessResult((folderName + imageName).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path.Replace("\\", "/"));

            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }


        public static IResult Update(IFormFile file, string path)
        {
            var fileExist = CheckFileExist(file);
            if (file == null)
            {
                return new ErrorResult(fileExist.Message);
            }
            File.Delete(sourcePath+path);
            string extension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid().ToString() + "_" + extension;
            CreateImageFile(sourcePath + folderName + imageName, file);
            return new SuccessResult((folderName + imageName).Replace("\\", "/"));

        }
        public static void CreateImageFile(string path, IFormFile file)
        {
            using (FileStream fileStream = File.Create(path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();  //Clears buffers for this stream and causes any buffered data to be written to the file.
            }
        }

        public static IResult CheckFileExist(IFormFile file)
        {
            if (file != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doen't exist.");
        }
        

    }
   
}
