using Ebboy.Core;
using Ebboy.Web.Framework.Models.KindEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Ebboy.Web.Framework.Controllers
{
    [UserAuthorize]
    public class FileManagerController : BaseController
    {
        #region Fields
        private readonly IWorkContext _workContext;
        #endregion

        #region Ctor
        public FileManagerController(
            IWorkContext workContext)
        {
            _workContext = workContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 编辑器文件上传
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public ActionResult EditorUpload()
        {
            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("avartar", "gif,jpg,jpeg,png,bmp");
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //最大文件大小
            int maxSize = 1000000;

            var imgFile = HttpContext.Request.Files["imgFile"];
            if (imgFile == null)
            {
                return Json(GetResultHash(1, "请选择文件。"), JsonRequestBehavior.AllowGet);
            }

            var dirName = HttpContext.Request.QueryString["dir"]; //自定义目录
            if (string.IsNullOrEmpty(dirName))
            {
                dirName = "file";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return Json(GetResultHash(1, "目录名不正确。"), JsonRequestBehavior.AllowGet);
            }

            var fileName = imgFile.FileName;
            var fileExt = Path.GetExtension(fileName).ToLower(); //文件扩展名

            var fileSize = imgFile.InputStream.Length;

            if (imgFile.InputStream == null || fileSize > maxSize)
            {
                 return Json(GetResultHash(1, "上传文件大小超过限制。"), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(fileExt) || 
                Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                return Json(GetResultHash(1, "上传文件扩展名是不允许的扩展名。\n只允许" + ((string)extTable[dirName]) + "格式。"), JsonRequestBehavior.AllowGet);
            }

            var fileInfo = GetFullFileName(dirName, fileExt); //自定义文件名和目录

            imgFile.SaveAs(fileInfo[0]); //保存文件

            var FileServerDomain = "";
            if (ConfigurationManager.AppSettings["FileServerDomain"] != null)
            {
                FileServerDomain = ConfigurationManager.AppSettings["FileServerDomain"]; //获取配置文件
            }
            
            var fileUrl = FileServerDomain + fileInfo[1];

            return Json(GetResultHash(0,"",fileUrl) , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑器文件管理器
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public ActionResult EditorFileManger()
        {
            //文件保存目录路径
            var rootUrl = string.Format("/Uploads/{0}/",
                _workContext.CurrentUser.UserNo); //用户上传目录

            //图片扩展名
            var fileTypes = "gif,jpg,jpeg,png,bmp";

            var currentPath = "";
            var currentUrl = "";
            var currentDirPath = "";
            var moveupDirPath = "";

            var dirPath = HttpContext.Server.MapPath(rootUrl);
            var dirName = HttpContext.Request.QueryString["dir"];
            if (!string.IsNullOrEmpty(dirName))
            {
                if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
                {
                    HttpContext.Response.Write("Invalid Directory name.");
                    HttpContext.Response.End();
                }
                dirPath += dirName + "/";
                rootUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            //根据path参数，设置各路径和URL
            var path = HttpContext.Request.QueryString["path"];
            path = string.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            var order = HttpContext.Request.QueryString["order"];
            order = string.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                HttpContext.Response.Write("Access is not allowed.");
                HttpContext.Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                HttpContext.Response.Write("Parameter is not valid.");
                HttpContext.Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                HttpContext.Response.Write("Directory does not exist.");
                HttpContext.Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// 创 建 者：Loamen.com
        private string[] GetFullFileName(string dir,  string fileExt)
        {
            var result = new string[] { "", "" };

            //文件保存目录路径
            var dirPath = string.Format("/Uploads/{0}/{1}/{2}/",
                _workContext.CurrentUser.UserNo,
                dir,DateTime.Now.ToString("yyyyMMdd",
                DateTimeFormatInfo.InvariantInfo)); //用户上传目录

            var directory = HttpContext.Server.MapPath(dirPath); //获取目录屋里路径

            var dirInfo = new DirectoryInfo(directory);
            if (!dirInfo.Exists)
            {
                dirInfo.Create(); //如果文件夹不存在则创建
            }

            var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

            result[0] = dirInfo.FullName + newFileName; //物理存储路径
            result[1] = dirPath + newFileName; //网页根相对路径

            return result;
        }

        /// <summary>
        /// 获取返回结果HASHTABLE
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        private Hashtable GetResultHash(int code, string message, string url = null)
        {
            var resultHash = new Hashtable();
            resultHash["error"] = code;
            resultHash["message"] = message;
            resultHash["url"] = url;

            return resultHash;
        }
        #endregion
    }
}
