using UnityEngine;

namespace TapDash.CodeBase.Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public Chunk Chunk;
        public int ChunkIndex;
        public float PlayerSpeed;
        public bool IsCameraRotatable;
    }
}