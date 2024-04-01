using animals_csharp.Talkable;
using animals_csharp.Talkable.Person;
using animals_csharp.Talkable.Pet;

namespace animals_csharp.IO;

public class UserSourceTalkableFactory() {
    private Teacher MakeTeacher(string name) {
        while (true) {
            Console.Write("What is their age?\n> ");
            if (int.TryParse(Console.ReadLine(), out var age))
                return new Teacher(age, name);
        }
    }

    private Cat MakeCat(string name) {
        while (true) {
            Console.Write("How many mice have they killed?\n> ");
            if (int.TryParse(Console.ReadLine(), out var mice))
                return new Cat(mice, name);
        }
    }

    private Dog MakeDog(string name) {
        while (true) {
            Console.Write("Are they friendly? (True/False)\n> ");
            if (bool.TryParse(Console.ReadLine(), out var friendly))
                return new Dog(friendly, name);
        }}

    private string GetName() {
        var name = "";
        while (name.Trim().Length == 0) {
            Console.Write("What is their name:\n> ");
            name = Console.ReadLine() ?? "";
        }

        return name.Trim();
    }

    public ITalkable GetTalkable() {
        while (true) {
            Console.Write("Enter the type: (Teacher/Cat/Dog)\n> ");
            switch (Console.ReadLine()?.ToUpper().Trim()) {
                case "TEACHER":
                    return MakeTeacher(GetName());
                case "CAT":
                    return MakeCat(GetName());
                case "DOG":
                    return MakeDog(GetName());
            }
        }
    }

    public void AddTalkable(in List<ITalkable> list) {
        list.Add(GetTalkable());
    }
}