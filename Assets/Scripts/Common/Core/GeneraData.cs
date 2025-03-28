using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

public class ExcelFileHandler
{
    public static void CompressAndEncrypt(string inputFilePath, string outputFilePath, string password)
    {
        byte[] fileBytes = File.ReadAllBytes(inputFilePath);
        byte[] compressedBytes;

        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                gzipStream.Write(fileBytes, 0, fileBytes.Length);
            }
            compressedBytes = memoryStream.ToArray();
        }

        byte[] encryptedBytes = Encrypt(compressedBytes, password);
        File.WriteAllBytes(outputFilePath, encryptedBytes);
    }

    private static byte[] Encrypt(byte[] data, string password)
    {
        using (Aes aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, new byte[16]);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }
    }
      public static void DecryptAndDecompress(string inputFilePath, string outputFilePath, string password)
    {
        byte[] encryptedBytes = File.ReadAllBytes(inputFilePath);
        byte[] decryptedBytes = Decrypt(encryptedBytes, password);

        using (MemoryStream memoryStream = new MemoryStream(decryptedBytes))
        {
            using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            {
                using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Create))
                {
                    gzipStream.CopyTo(fileStream);
                }
            }
        }
    }

    private static byte[] Decrypt(byte[] data, string password)
    {
        using (Aes aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, new byte[16]);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }
    }
}