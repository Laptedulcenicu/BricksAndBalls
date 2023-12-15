using Modules.Common;
using UnityEngine;

namespace Modules.Services.FactoryService
{
    public class SceneFactory : ISceneFactory
    {
        private readonly IAssetProviderService _assetProvider;

        public SceneFactory(IAssetProviderService assetProviderService)
        {
            _assetProvider = assetProviderService;
        }

        public GameObject CreatePlayer() => _assetProvider.Instantiate(AssetPath.PlayerPath);

        public GameObject CreateGate() => _assetProvider.Instantiate(AssetPath.GatePath);

        public GameObject CreateLineView() => _assetProvider.Instantiate(AssetPath.LineViewPath);

        public GameObject CreateEnemy() => _assetProvider.Instantiate(AssetPath.EnemyPath);
    }
}