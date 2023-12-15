using UnityEngine;

namespace Modules.Common
{
    public interface ISceneFactory
    {
        GameObject CreatePlayer();

        GameObject CreateGate();

        GameObject CreateLineView();

        GameObject CreateEnemy();
    }
}