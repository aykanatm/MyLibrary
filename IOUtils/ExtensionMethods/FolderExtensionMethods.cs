using System;

namespace IOUtils.ExtensionMethods
{
    public static class FolderExtensionMethods
    {
        public static void Empty(this System.IO.DirectoryInfo directory)
        {
            try
            {
                foreach (var file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (var subDirectory in directory.GetDirectories())
                {
                    subDirectory.Delete(true);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while deleting files. " + e.Message;
                throw new Exception(errorMessage);
            }
        }
    }
}
