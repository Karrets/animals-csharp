namespace animals_csharp.Talkable.Pet;

public class Cat(int mousesKilled, string name) : Pet(name), ITalkable
{
    public int MiceKilled { get; private set; } = mousesKilled;
    public string Talk => "Meow!";

    public void AddMouse()
    {
        MiceKilled++;
    }

    public override string ToString()
    {
        return $"Cat: name=${Name} mousesKilled=${MiceKilled}";
    }
}