﻿using ClassLibrary.Handin.Interfaces;
using System.Diagnostics;

namespace ClassLibrary.Handin.Services;

internal class FileService : IFileService
{
    public string GetContentFromFile(string filepath)
    {
        try
        {
            if (File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    public bool SaveContentToFile(string filepath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filepath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
