using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public int LevelNumber;
        public int ChunkIndex;
        public float PlayerSpeed;
        public bool IsCameraRotatable;
    }
}