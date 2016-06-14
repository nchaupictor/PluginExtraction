using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class PluginExtraction
{
    static void Main()
    {
        string root =AppDomain.CurrentDomain.BaseDirectory;
        string sourcePath = System.IO.Path.Combine(root, @"PlugIns");
        string fileName = "";
        //string sourcePath = @"C:\Test";
        string localPath = @"Pictorial\\PlugIns";
        string targetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),localPath);

        // Use Path class to manipulate file and directory paths.
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);
        //string destFile = System.IO.Path.Combine(Application.CommonAppDataPath + "\\Pictorial\\PlugIns", fileName);

        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(s, destFile, true);
            }
        }
        else
        {
            Console.WriteLine("Source path does not exist!");
        }

        // Keep console window open in debug mode.
        Console.WriteLine("Plugins Transferred!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}