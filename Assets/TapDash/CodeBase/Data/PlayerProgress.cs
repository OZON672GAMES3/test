using System;

namespace TapDash.CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public string LevelName;
        public int LevelData;

        public PlayerProgress(string initialLevel)
        {
            LevelName = initialLevel;
        }
    }
}