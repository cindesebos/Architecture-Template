using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Gameplay.Runtime
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.Instance.Register(new TestService());
        }
    }
}
