namespace animals_csharp.Talkable.Pet;

public class Dog(bool friendly, string name) : Pet(name), ITalkable
{
    public bool Friendly { get; init; } = friendly;
    public string Talk => "Bark!";

    public override string ToString()
    {
        return $"Dog: name=${Name} friendly=${Friendly}";
    }
}