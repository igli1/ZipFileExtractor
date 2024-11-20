using nsoftware.IPWorksZip;

Console.WriteLine("Enter zip file path:");
Console.Write("> ");
string zipFilePath = Console.ReadLine()?.Trim();;

Console.WriteLine("Enter target file name:");
Console.Write("> ");
string targetFileName = Console.ReadLine()?.Trim();;

Console.WriteLine("Enter output directory:");
Console.Write("> ");
string outputDirectory = Console.ReadLine()?.Trim();

Console.WriteLine("Starting zip extraction:");

// Initialize the Zip component
Zip zip = new Zip();

try
{
    if (string.IsNullOrWhiteSpace(zipFilePath))
    {
        Console.WriteLine("Error: Zip file path cannot be empty.");
        return;
    }
    
    if (!File.Exists(zipFilePath))
    {
        Console.WriteLine($"Error: The file '{zipFilePath}' does not exist.");
        return;
    }

    if (!Directory.Exists(outputDirectory))
    {
        Directory.CreateDirectory(outputDirectory);
    }
    
    zip.RuntimeLicense = "";
    
    // Open the ZIP file
    zip.ArchiveFile = zipFilePath;
    
    zip.Scan();
    
    bool fileFound = false;
    foreach (var file in zip.Files)
    {
        string currentFileName = Path.GetFileName(file.CompressedName);

        if (string.Equals(currentFileName, targetFileName, StringComparison.OrdinalIgnoreCase))
        {
            // Override the decompressed name to place the file in the flat directory
            file.DecompressedName = Path.Combine(outputDirectory, currentFileName);

            // Extract the file
            zip.Extract(file.CompressedName);
            fileFound = true;

            Console.WriteLine($"File '{targetFileName}' extracted to '{outputDirectory}'.");
            break;
        }
    }
    
    if (!fileFound)
    {
        Console.WriteLine($"File '{targetFileName}' not found in the ZIP archive.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    zip.Dispose();
    Console.ReadLine();
}