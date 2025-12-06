using TapDash.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(GameObject at) =>
            _assets.Instantiate(AssetPath.PlayerPath, at.transform.position);
    }
}