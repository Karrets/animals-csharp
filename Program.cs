using animals_csharp.IO;
using animals_csharp.Talkable;
using animals_csharp.Talkable.Person;
using animals_csharp.Talkable.Pet;

namespace animals_csharp;

internal static class Program {
    private static readonly FileInput _input = new FileInput("animals.txt");
    private static readonly FileOutput _output = new FileOutput("animals.txt");

    private static void Main(string[] args) {
        var zoo = new List<ITalkable>();
        var userInput = new UserSourceTalkableFactory();

        userInput.AddTalkable(zoo);
        userInput.AddTalkable(zoo);
        userInput.AddTalkable(zoo);

        foreach (var talkable in zoo) {
            printOut(talkable);
        }

        _output.CloseFile();
        _input.ReadFile();
        _input.CloseFile();

        var newInput = new FileInput("animals.txt");
        string? line;
        do {
            line = newInput.ReadLine();
            Console.WriteLine(line);
        } while (line is not null);
    }

    private static void printOut(ITalkable t) {
        Console.WriteLine($"{t.Name} says={t.Talk}");
        _output.Write($"{t.Name} | {t.Talk}");
    }
}