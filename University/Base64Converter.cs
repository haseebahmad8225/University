using System;
using System.IO;

public class Base64Converter
{
    public static void SaveBase64ToFile(string base64String, string filePath, string filename)
    {
        //filename = "Test";
        // Check if the Base64 string is empty or null
        if (string.IsNullOrEmpty(base64String))
        {
            throw new ArgumentException("Base64 string cannot be null or empty.", nameof(base64String));
        }

        try
        {
            // Convert Base64 string to byte array
            byte[] fileBytes = Convert.FromBase64String(base64String);

            // Write the byte array to the specified file path
            //File.WriteAllBytes(filePath,filename, fileBytes);
            File.WriteAllBytes(@"C:\Data\" + filename, fileBytes);

            Console.WriteLine("File saved successfully at: " + filePath);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid Base64 string format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the file: " + ex.Message);
        }
    }
}