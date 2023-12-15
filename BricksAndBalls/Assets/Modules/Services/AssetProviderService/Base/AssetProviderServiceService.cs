﻿using Modules.Common;
using UnityEngine;

namespace Modules.Services.AssetProviderService
{
    public class AssetProviderServiceService : IAssetProviderService
    {
        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}