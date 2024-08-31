namespace Calculator
{
    public class CalculatorPresenter
    {
        private readonly ICalculatorView _view;
        private readonly CalculatorUseCase _calculatorUseCase;

        public CalculatorPresenter(ICalculatorView view, CalculatorUseCase calculatorUseCase)
        {
            _view = view;
            _calculatorUseCase = calculatorUseCase;
        }

        public void OnCalculate(string input)
        {
            string result = _calculatorUseCase.Calculate(input);
            if (result == "Error")
            {
                _view.ShowError($"\n{input} = Error");
                _view.ShowMessageError("Please check the expression you just entered");
            }
            else
            {
                var text = $"\n{input} = {result}";
                _view.ShowResult(text);
            }
        }
    }
}
