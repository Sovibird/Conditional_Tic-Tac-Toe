using System;
public class DigitsAmount : IConditionChecker
{
    private int number;
    private int digitCount;
    public DigitsAmount(int number)
    {
        this.number = number;
    }

    public bool CheckCondition(int number)
    {
        digitCount = (int)Math.Log10(number) + 1;
        if (digitCount == this.number) return true;
        else return false;
    }

    public string GetConditionView()
    {
        return "Number has " + number + " digits";
    }
}