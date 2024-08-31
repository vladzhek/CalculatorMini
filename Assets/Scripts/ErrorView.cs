using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ErrorView : MonoBehaviour
    {
        public TMP_Text messageText;

        [SerializeField] private Button CloseBtn;

        private void OnEnable()
        {
            CloseBtn.onClick.AddListener(CloseDialog);
        }

        private void OnDisable()
        {
            CloseBtn.onClick.RemoveListener(CloseDialog);
        }

        public void ShowError(string message)
        {
            messageText.text = message;
            gameObject.SetActive(true);
        }

        public void CloseDialog()
        {
            gameObject.SetActive(false);
        }
    }
}