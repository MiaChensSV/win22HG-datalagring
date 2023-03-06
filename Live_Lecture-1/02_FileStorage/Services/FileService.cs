namespace _02_FileStorage.Services;

internal class FileService
{
    private string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(content);
        }
    }

    public string Read()
    {
        if (File.Exists(_filePath))
        {
            using var sr = new StreamReader(_filePath);
            return sr.ReadToEnd();
        }

        return null!;
    }

}
