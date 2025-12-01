namespace Lecture1.Models;

public class Calculator
{
    private static Dictionary<Operators, Func<double, double, double>> _calc = new()
    {
        { Operators.Add, (a, b) => a + b },
        { Operators.Sub, (a, b) => a - b },
        { Operators.Mul, (a, b) => a * b },
        { Operators.Div, (a, b) => a / b },
    };
    public static double Calculate(CalculatorViewModel model)
    {
        return _calc[model.Operator](model.X , model.Y);
    }
}