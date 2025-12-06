using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(GameObject at);
    }
}