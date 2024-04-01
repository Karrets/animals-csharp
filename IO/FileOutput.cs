using System.Text;

namespace animals_csharp.IO;

public class FileOutput
{
    private readonly string _file;
    private readonly StreamWriter? _fileBuffer;

    public FileOutput(string file, bool explicitFlush = false)
    {
        _file = file;

        try
        {
            _fileBuffer = new StreamWriter(
                new FileStream(file, FileMode.OpenOrCreate)
            );

            _fileBuffer.AutoFlush = explicitFlush;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Failed to open file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }

    public void Write(string output)
    {
        if(_fileBuffer is null) return;

        try
        {
            _fileBuffer.Write(output);
        }
        catch(Exception e)
        {
            Console.Error.WriteLine($"Failed to write to file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }

    public void Flush()
    {
        if(_fileBuffer is null) return;

        try
        {
            _fileBuffer.Flush();
        }
        catch(Exception e)
        {
            Console.Error.WriteLine($"Failed to write to file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }

    public void CloseFile()
    {
        if(_fileBuffer is null) return;

        try
        {
            _fileBuffer.Flush();
            _fileBuffer.Close();
        }
        catch(Exception e)
        {
            Console.Error.WriteLine($"Failed to close file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }
}