using Calculator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        public TMP_InputField inputField;
        public TMP_Text resultText;
        public Button resultBtn;
        public ErrorView _errorView;
        
        private CalculatorPresenter _presenter;
        private StateManager _stateManager = new();
        
        private void InitializeState()
        {
            var load = _stateManager.LoadState();
            inputField.text = load.Item1;
            resultText.text = load.Item2;
        }
        
        void Start()
        {
            _presenter = new CalculatorPresenter(this, new CalculatorUseCase());
            resultBtn.onClick.AddListener(OnResultButtonClick);

            _errorView.CloseDialog();;
            InitializeState();
        }

        public void OnResultButtonClick()
        {
            _presenter.OnCalculate(inputField.text);
        }

        public void ShowResult(string result)
        {
            resultText.text += result;
        }

        public void ShowError(string result)
        {
            resultText.text += result;
        }

        public void ShowMessageError(string message)
        {
            _errorView.ShowError(message);
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                _stateManager.SaveState(inputField.text, resultText.text);
            }
        }

        private void OnApplicationQuit()
        {
            _stateManager.SaveState(inputField.text, resultText.text);
        }
    }
}