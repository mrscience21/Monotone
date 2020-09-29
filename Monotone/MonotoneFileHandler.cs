using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Monotone
{
    public static class MonotoneFileHandler
    {
        
        public static void WriteFile(string FilePath, List<EntryLine> EntryLines)
        {
            string FileName = Path.GetFileNameWithoutExtension(FilePath);
            string PathOnly = FilePath.Substring(0, FilePath.Length - Path.GetFileName(FilePath).Length);

            StreamWriter transcriptWriter = new StreamWriter($"{PathOnly}~{FileName}\\transcript.tsv");
            
            foreach(EntryLine entryLine in EntryLines)
            {
                transcriptWriter.WriteLine(entryLine.TimeStamp.ToString(@"hh\:mm\:ss") + "\t" + entryLine.Text);
            }

            transcriptWriter.Close();
            transcriptWriter.Dispose();

            ZipFile.CreateFromDirectory($"{PathOnly}~{FileName}", FilePath);
        }

        /// <summary>
        /// Creates a Working Directory for file operations hidden from the user
        /// </summary>
        /// <param name="FilePath">Full path including file name and extension for Monotone output file</param>
        /// <returns>Temporary Directory File Path</returns>
        public static string CreateTempDirectory(string FilePath)
        {
            string FileName = Path.GetFileNameWithoutExtension(FilePath);
            string PathOnly = FilePath.Substring(0, FilePath.Length - Path.GetFileName(FilePath).Length);

            Directory.CreateDirectory($"{PathOnly}~{FileName}");

            DirectoryInfo directoryInfo = new DirectoryInfo($"{PathOnly}~{FileName}");
            directoryInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            return $"{PathOnly}~{FileName}";
        }

        /// <summary>
        /// Deletes the hidden Working Directory used for file operations, if it exists
        /// </summary>
        /// <param name="FilePath">Full path including file name and extension for Monotone output file</param>
        public static void DeleteTempDirectory(string FilePath)
        {
            string FileName = Path.GetFileNameWithoutExtension(FilePath);
            string PathOnly = FilePath.Substring(0, FilePath.Length - Path.GetFileName(FilePath).Length);

            if (Directory.Exists($"{PathOnly}~{FileName}"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo($"{PathOnly}~{FileName}");

                // Delete all files from directory before deleting
                foreach (FileInfo file in directoryInfo.EnumerateFiles())
                {
                    File.Delete(file.FullName);
                }

                Directory.Delete($"{PathOnly}~{FileName}");
            }
        }
    }
}
