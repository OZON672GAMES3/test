using TapDash.CodeBase.InputSystem;
using UnityEngine;

namespace TapDash.CodeBase.Player
{
    public class PlayerTurnHandler : MonoBehaviour
    {
        private TurnTrigger _currentTurnZone;
        private readonly PlayerMove _playerMove;

        public PlayerTurnHandler(PlayerMove playerMove)
        {
            _playerMove = playerMove;
        }

        public void SetTurnZone(TurnTrigger zone)
        {
            _currentTurnZone = zone;
        }

        public void ClearTurnZone()
        {
            _currentTurnZone = null;
        }

        public void TryTurn()
        {
            if (_currentTurnZone == null)
                return;

            _playerMove.Turn(_currentTurnZone.TurnDirection);
            // _playerMove.AlignTo(_currentTurnZone.AlignPoint);

            _currentTurnZone = null;
        }
    }
}