namespace Algorithms;

public class Employees
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Number { get; set; }
    
    
    public Employees(string name, string position, int number)
    {
        Name = name;
        Position = position;
        Number = number;
    }
    
}