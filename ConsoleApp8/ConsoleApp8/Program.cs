using System;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
    static void EncryptFile(string filePath, char key)
    {
        string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
        StringBuilder encryptedContent = new StringBuilder();

        foreach (var ch in fileContent)
        {
            encryptedContent.Append((char)(ch ^ key));
        }


        string directory = Path.GetDirectoryName(filePath);
        string oldFileName = Path.GetFileNameWithoutExtension(filePath);
        string newFileName = $"{oldFileName}Encrypted.txt";
        string newFilePath = Path.Combine(directory, newFileName);

        File.WriteAllText(newFilePath, encryptedContent.ToString(), Encoding.UTF8);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the file path (.txt file):");
        var path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        Console.WriteLine("Enter the encryption key (single character):");
        var keyInput = Console.ReadLine();


        char key = keyInput[0];

        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                EncryptFile(path, key);
                Console.WriteLine("File Encrypted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during encryption: {ex.Message}");
            }
        });

        Console.WriteLine("Encryption process started");
        Console.ReadLine(); 
    }


}

