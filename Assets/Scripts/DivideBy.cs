public class DivideBy : IConditionChecker
{
    private int number;
    public DivideBy(int number) 
    { 
        this.number = number;
    }

    public bool CheckCondition(int number)
    {
        if (number == 0) return false;
        return (number % this.number == 0);
    }

    public string GetConditionView()
    {
        return "% " + number + " = 0";
    }
}