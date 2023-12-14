namespace ClassLibrary.Handin.Interfaces;

internal interface IFileService
{

    /// <summary>
    /// Save Content to file
    /// </summary>
    /// <param name="filepath">Enter the filepath with extension (eg. c:\projects\myfile.json)</param>
    /// <param name="content">Enter your Content as a string</param>
    /// <returns>Returns true if saved, else false if failed</returns>
    bool SaveContentToFile(string filepath, string content);

    /// <summary>
    /// Get content as string from a specified filepath
    /// </summary>
    /// <param name="filepath">Enter the filepath with extension (eg. c:\projects\myfile.json)</param>
    /// <returns>Returns file content as string if file exists, else returns null</returns>
    string GetContentFromFile(string filepath);
}
