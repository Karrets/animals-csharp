namespace animals_csharp.Talkable.Person;

public class Teacher(int age, string name) : Person(name), ITalkable
{
    public int Age { get; set; } = age;
    public string Talk => "Don't forget to do the assigned reading!";
}