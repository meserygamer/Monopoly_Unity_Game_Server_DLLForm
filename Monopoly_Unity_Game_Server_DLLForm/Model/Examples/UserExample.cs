namespace Monopoly_Unity_Game_Server;

public class SimpleNumberAsExample : Example
{
    public SimpleNumberAsExample(double number)
    {
        _number = number;
    }


    private double _number;


    public override string GetExampleResult() => _number.ToString();

    public override string ExampleInString() => _number.ToString();
}
