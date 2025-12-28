using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class SelectorButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        
        private Action _onClick;

        public void Initialize(int id, Action onClick)
        {
            _onClick = onClick;
            _button.onClick.AddListener(OnClick);
            _text.text = (id + 1).ToString();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void SetUnlocked(bool unlocked)
        {
            _button.interactable = unlocked;
        }

        public void OnClick()
        {
            _onClick?.Invoke();
        }
    }
}