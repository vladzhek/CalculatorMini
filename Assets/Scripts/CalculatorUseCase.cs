using System.Text.RegularExpressions;

namespace Calculator
{
    public class CalculatorUseCase
    {
        public string Calculate(string input)
        {
            if (IsValidInput(input))
            {
                var parts = input.Split('+');
                if (int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
                {
                    return (num1 + num2).ToString();
                }
            }

            return "Error";
        }

        private bool IsValidInput(string input)
        {
            input.Replace(" ","");
            return Regex.IsMatch(input, @"^\d+\+\d+$");
        }
    }
}
