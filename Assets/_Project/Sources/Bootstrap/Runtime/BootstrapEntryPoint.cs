using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Gameplay.Runtime
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.Instance.Register(new TestService());
        }
    }
}
