// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

Console.Write("Enter file path to calculate MD5 hash for: ");
Console.WriteLine(CalculateMd5HashForFile(Console.ReadLine().Replace("\"", string.Empty).Trim()));

string? CalculateMd5HashForFile(string filePath)
{
    if (!File.Exists(filePath))
    {
        return null;
    }

    using (var md5 = MD5.Create())
    {
        using (var stream = File.OpenRead(filePath))
        {
            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}