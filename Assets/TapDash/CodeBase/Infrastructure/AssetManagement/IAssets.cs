using TapDash.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}