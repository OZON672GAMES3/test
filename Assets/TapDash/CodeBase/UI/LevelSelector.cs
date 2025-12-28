using System.Collections.Generic;
using TapDash.CodeBase.Infrastructure;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace TapDash.CodeBase.UI
{
    public class LevelSelector : MonoBehaviour
    {
        private const int ChunksCount = 12;

        [SerializeField] private Transform _parent;
        [SerializeField] private SelectorButton _buttonPrefab;
        
        private readonly List<SelectorButton> _buttons = new();

        private LevelStartService _levelStart;
        private IPersistentProgressService _progressService;

        public void Construct(LevelStartService levelStart, IPersistentProgressService progressService)
        {
            _levelStart = levelStart;
            _progressService = progressService;
            
            for (int i = 0; i < ChunksCount; i++)
            {
                SelectorButton button = Instantiate(_buttonPrefab, _parent);
                _buttons.Add(button);

                int index = i;
                button.Initialize(index, () => _levelStart.StartGame(index));
            }

            int unlockedCount = _progressService.Progress.LastCompletedChunkIndex;

            for (int i = 0; i < unlockedCount && i < _buttons.Count; i++)
                _buttons[i].SetUnlocked(true);
        }
    }
}