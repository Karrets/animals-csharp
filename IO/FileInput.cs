namespace animals_csharp.IO;

public class FileInput {
    private readonly string _file;
    private readonly StreamReader? _fileBuffer;

    public FileInput(string file) {
        _file = file;
        try {
            _fileBuffer = new StreamReader(
                                           new FileStream(file, FileMode.Open)
                                          );
        }
        catch (Exception e) {
            Console.Error.WriteLine($"Failed to open file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }

    public string? ReadFile() {
        if (_fileBuffer is null) return null;

        try {
            var fileContent = _fileBuffer.ReadToEnd();
            Console.WriteLine(fileContent);
            return fileContent;
        }
        catch (Exception e) {
            Console.Error.WriteLine($"Failed to read file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }

        return null;
    }

    public string? ReadLine() {
        if (_fileBuffer is null) return null;

        try {
            if (!_fileBuffer.EndOfStream)
                return _fileBuffer.ReadLine() ?? "";
        }
        catch (Exception e) {
            Console.Error.WriteLine($"Failed to read file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }

        return null;
    }

    public void CloseFile() {
        if (_fileBuffer is null) return;

        try {
            _fileBuffer.Close();
        }
        catch (Exception e) {
            Console.Error.WriteLine($"Failed to close file ({_file}) due to internal error: {e.Message}\n" +
                                    $"\t{e.StackTrace}");
        }
    }
}