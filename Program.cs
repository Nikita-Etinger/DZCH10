using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFilePath = "source.jpg";

        if (File.Exists(sourceFilePath))
        {

            FileInfo sourceFileInfo = new FileInfo(sourceFilePath);

            long fileSize = sourceFileInfo.Length;

            //string targetFilePath = Path.Combine(полный путь к папке с исходным фаилом, получение только название фаила+"-копия"получение расширения фаила");
            string targetFilePath = Path.Combine(sourceFileInfo.Directory.FullName, $"{Path.GetFileNameWithoutExtension(sourceFileInfo.Name)}-копия{sourceFileInfo.Extension}");

            Console.WriteLine($"Размер исходного файла: {fileSize} байт");

            using (FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open))
            using (FileStream targetFileStream = new FileStream(targetFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[fileSize];

                int bytesRead;

                while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    targetFileStream.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine($"Файл успешно скопирован в {targetFilePath}");
        }
        else
        {
            Console.WriteLine("Исходный файл не найден");
        }
    }
}