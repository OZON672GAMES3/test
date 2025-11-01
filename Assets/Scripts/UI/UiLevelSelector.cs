using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiLevelSelector : MonoBehaviour
    {
        public event Action<int> OnLevelSelected;
        
        private int _index;
        private Button _levelIndexButton;
        private TMP_Text _levelText;
        
        private void Start()
        {
            _levelIndexButton = GetComponent<Button>();
            _levelText = GetComponentInChildren<TMP_Text>();
            
            Match match = Regex.Match(name, @"\((\d+)\)");
            if (match.Success)
            {
                _index = int.Parse(match.Groups[1].Value);
                _levelText.text = _index.ToString();
                _index--;
            }

            _levelIndexButton.onClick.AddListener(() => OnLevelSelected?.Invoke(_index));
        }
    }
}