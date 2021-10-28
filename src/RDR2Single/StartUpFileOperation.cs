using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDR2Single
{
    class StartUpFileOperation
    {
        public static string GetStartUpFilePath(string input)
        {
            if (!Common.CheckIsGamePath(input))
            {
                return null;
            }
            string path = Path.Combine(input, Common.DataPath, "startup.meta");
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.FullName;
        }

        public static string GetCodeFromStartUpFile(string fileContent)
        {
            try
            {
                if (string.IsNullOrEmpty(fileContent))
                {
                    return null;
                }
                string findStr = "CDataFileMgr__ContentsOfDataFileXml";
                int index = fileContent.LastIndexOf(findStr);
                if (index < 0)
                {
                    return null;
                }
                string codePreStr = fileContent.Substring(index + findStr.Length + 1);
                if (string.IsNullOrEmpty(codePreStr))
                {
                    return null;
                }
                codePreStr = codePreStr.Replace("\r", "").Replace("\n", "").Trim();
                if (codePreStr.Length > Common.CodeMaxLength)
                {
                    codePreStr = codePreStr.Substring(0, Common.CodeMaxLength);
                }
                return codePreStr;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteCodeFromStartUpFile(string input)
        {
            try
            {
                string filePath = GetStartUpFilePath(input);
                if (string.IsNullOrEmpty(filePath))
                {
                    return InitializeStartUpFile(input);
                }
                if (!File.Exists(filePath))
                {
                    return InitializeStartUpFile(input);
                }
                string fileContent = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(fileContent))
                {
                    return InitializeStartUpFile(input);
                }
                string findStr = "CDataFileMgr__ContentsOfDataFileXml";
                int index = fileContent.LastIndexOf(findStr);
                if (index < 0)
                {
                    return false;
                }
                index = index + findStr.Length + 1;
                fileContent = fileContent.Substring(0, fileContent.Length - (fileContent.Length - index));
                if (string.IsNullOrEmpty(fileContent))
                {
                    return false;
                }
                File.WriteAllText(filePath, fileContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteCodeAndRewriteCodeToStartUpFile(string input, string code)
        {
            try
            {
                string filePath = GetStartUpFilePath(input);
                if (string.IsNullOrEmpty(filePath) && !InitializeStartUpFile(input))
                {
                    return false;
                }
                if (!File.Exists(filePath) && !InitializeStartUpFile(input))
                {
                    return false;
                }
                string fileContent = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(fileContent))
                {
                    if (!InitializeStartUpFile(input))
                    {
                        return false;
                    }
                    fileContent = File.ReadAllText(filePath);
                    if (string.IsNullOrEmpty(fileContent))
                    {
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(code))
                {
                    return false;
                }
                string findStr = "CDataFileMgr__ContentsOfDataFileXml";
                int index = fileContent.LastIndexOf(findStr);
                if (index < 0)
                {
                    return false;
                }
                index = index + findStr.Length + 1;
                fileContent = fileContent.Substring(0, fileContent.Length - (fileContent.Length - index));
                if (string.IsNullOrEmpty(fileContent))
                {
                    return false;
                }
                File.WriteAllText(filePath, fileContent + code);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool InitializeStartUpFile(string input)
        {
            try
            {
                string filePath = GetStartUpFilePath(input);
                if (string.IsNullOrEmpty(filePath))
                {
                    return false;
                }
                string fileContent = @"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4NCjxDRGF0YUZpbGVNZ3JfX0NvbnRlbnRzT2ZEYXRhRmlsZVhtbD4NCiA8ZGlzYWJsZWRGaWxlcyAvPg0KIDxpbmNsdWRlZFhtbEZpbGVzIGl0ZW1UeXBlPSJDRGF0YUZpbGVNZ3JfX0RhdGFGaWxlQXJyYXkiIC8+DQogPGluY2x1ZGVkRGF0YUZpbGVzIC8+DQogPGRhdGFGaWxlcyBpdGVtVHlwZT0iQ0RhdGFGaWxlTWdyX19EYXRhRmlsZSI+DQogIDxJdGVtPg0KICAgPGZpbGVuYW1lPnBsYXRmb3JtOi9kYXRhL2NkaW1hZ2VzL3NjYWxlZm9ybV9wbGF0Zm9ybV9wYy5ycGY8L2ZpbGVuYW1lPg0KICAgPGZpbGVUeXBlPlJQRl9GSUxFPC9maWxlVHlwZT4NCiAgPC9JdGVtPg0KICA8SXRlbT4NCiAgIDxmaWxlbmFtZT5wbGF0Zm9ybTovZGF0YS91aS92YWx1ZV9jb252ZXJzaW9uLnJwZjwvZmlsZW5hbWU+DQogICA8ZmlsZVR5cGU+UlBGX0ZJTEU8L2ZpbGVUeXBlPg0KICA8L0l0ZW0+DQogIDxJdGVtPg0KICAgPGZpbGVuYW1lPnBsYXRmb3JtOi9kYXRhL3VpL3dpZGdldHMucnBmPC9maWxlbmFtZT4NCiAgIDxmaWxlVHlwZT5SUEZfRklMRTwvZmlsZVR5cGU+DQogIDwvSXRlbT4NCiAgPEl0ZW0+DQogICA8ZmlsZW5hbWU+cGxhdGZvcm06L3RleHR1cmVzL3VpL3VpX3Bob3RvX3N0aWNrZXJzLnJwZjwvZmlsZW5hbWU+DQogICA8ZmlsZVR5cGU+UlBGX0ZJTEU8L2ZpbGVUeXBlPg0KICA8L0l0ZW0+DQogIDxJdGVtPg0KICAgPGZpbGVuYW1lPnBsYXRmb3JtOi90ZXh0dXJlcy91aS91aV9wbGF0Zm9ybS5ycGY8L2ZpbGVuYW1lPg0KICAgPGZpbGVUeXBlPlJQRl9GSUxFPC9maWxlVHlwZT4NCiAgPC9JdGVtPg0KICA8SXRlbT4NCiAgIDxmaWxlbmFtZT5wbGF0Zm9ybTovZGF0YS91aS9zdHlsZXNDYXRhbG9nPC9maWxlbmFtZT4NCiAgIDxmaWxlVHlwZT5hV2VhcG9uaXplRGlzcHV0YW50czwvZmlsZVR5cGU+IDwhLS0gY29sbGlzaW9uIC0tPg0KICA8L0l0ZW0+DQogIDxJdGVtPg0KICAgPGZpbGVuYW1lPnBsYXRmb3JtOi9kYXRhL2NkaW1hZ2VzL3NjYWxlZm9ybV9mcm9udGVuZC5ycGY8L2ZpbGVuYW1lPg0KICAgPGZpbGVUeXBlPlJQRl9GSUxFX1BSRV9JTlNUQUxMPC9maWxlVHlwZT4NCiAgPC9JdGVtPg0KICA8SXRlbT4NCiAgIDxmaWxlbmFtZT5wbGF0Zm9ybTovdGV4dHVyZXMvdWkvdWlfc3RhcnR1cF90ZXh0dXJlcy5ycGY8L2ZpbGVuYW1lPg0KICAgPGZpbGVUeXBlPlJQRl9GSUxFPC9maWxlVHlwZT4NCiAgPC9JdGVtPg0KICA8SXRlbT4NCiAgIDxmaWxlbmFtZT5wbGF0Zm9ybTovZGF0YS91aS9zdGFydHVwX2RhdGEucnBmPC9maWxlbmFtZT4NCiAgIDxmaWxlVHlwZT5SUEZfRklMRTwvZmlsZVR5cGU+DQogIDwvSXRlbT4NCgk8SXRlbT4NCgkJPGZpbGVuYW1lPnBsYXRmb3JtOi9ib290X2xhdW5jaGVyX2Zsb3cuI210PC9maWxlbmFtZT4NCgkJPGZpbGVUeXBlPlNUUkVBTUlOR19GSUxFPC9maWxlVHlwZT4NCgkJPHJlZ2lzdGVyQXM+Ym9vdF9mbG93L2Jvb3RfbGF1bmNoZXJfZmxvdzwvcmVnaXN0ZXJBcz4NCgkJPG92ZXJsYXkgdmFsdWU9ImZhbHNlIiAvPg0KCQk8cGF0Y2hGaWxlIHZhbHVlPSJmYWxzZSIgLz4NCgk8L0l0ZW0+DQogPC9kYXRhRmlsZXM+DQogPGNvbnRlbnRDaGFuZ2VTZXRzIGl0ZW1UeXBlPSJDRGF0YUZpbGVNZ3JfX0NvbnRlbnRDaGFuZ2VTZXQiIC8+DQogPHBhdGNoRmlsZXMgLz4NCjwvQ0RhdGFGaWxlTWdyX19Db250ZW50c09mRGF0YUZpbGVYbWw+";
                byte[] decodeByte = Convert.FromBase64String(fileContent);
                File.WriteAllBytes(filePath, decodeByte);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
