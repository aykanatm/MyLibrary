namespace CustomIO.ExtensionMethods
{
    public static class FolderExtensionMethods
    {
        public static void Empty(this System.IO.DirectoryInfo directory)
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
    }
}
