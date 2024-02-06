using Dropbox.Api;
using Entities.ASPCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.DropBox
{
    public class DropBoxProcess
    {
        internal static DropboxClient Connect()
        {
            IConfiguration config = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json")
                      .Build();

            string DropBoxtoken = config["DropBoxToken"];
            return new DropboxClient(DropBoxtoken);
        }

        async public Task<DropBoxResult> GetFiles(int FolderId)
        {
            DropBoxResult result = new DropBoxResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                DropboxClient dbx = Connect();
                var response = await dbx.Files.ListFolderAsync("/" + FolderId + "/430");

                result.CountFiles = response.Entries.Count;
                List<DropBoxFiles> Files = new List<DropBoxFiles>();

                for (int i = 0; i < result.CountFiles; i++)
                {
                    //SEPARATE FILES BY EXTENSION
                    DropBoxFiles dropBoxFile = new DropBoxFiles();
                    var Extension = response.Entries[i].PathDisplay.Split(new string[] { "." }, StringSplitOptions.None);
                    if (Extension[1] == "jpg" || Extension[1] == "png" || Extension[1] == "jpeg")
                    {
                        //ONLY DOWNLOAD IMAGE TYPE FILES
                        var downloadResponse = await dbx.Files.DownloadAsync(response.Entries[i].PathDisplay);
                        dropBoxFile.FileName = downloadResponse.Response.Name;
                        dropBoxFile.File = await downloadResponse.GetContentAsByteArrayAsync();
                        dropBoxFile.FilePath = response.Entries[i].PathDisplay;
                        dropBoxFile.Extension = Extension[1];
                        dropBoxFile.IsShowable = true;

                    }
                    else
                    {
                        dropBoxFile.FileName = response.Entries[i].Name;
                        dropBoxFile.File = null;
                        dropBoxFile.FilePath = response.Entries[i].PathDisplay;
                        dropBoxFile.IsShowable = false;
                    }
                    Files.Add(dropBoxFile);
                }
                result.DropBoxFiles = Files;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }

        async public Task<DropBoxResult> DownloadFile(string FilePath)
        {
            DropBoxResult result = new DropBoxResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                DropboxClient dbx = Connect();
                using (var response = await dbx.Files.DownloadAsync(FilePath))
                {
                    result.Image_Name = response.Response.Name;
                    result.Image = await response.GetContentAsByteArrayAsync();
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }

        public async static void Add_Voucher(string Filename, MemoryStream Mem)
        {
            DropBoxResult result = new DropBoxResult();
            try
            {
                Mem.Position = 0;
                result.dbpath = "/PaymentsVouchers";
                var folderarg = new CreateFolderArg(result.dbpath);
                Dropbox.Api.DropboxClient dbx = DropBoxProcess.Connect();
                var addlogo = await dbx.Files.UploadAsync(result.dbpath + "/" + Filename, WriteMode.Overwrite.Instance, body: Mem);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
        }
    }
}
