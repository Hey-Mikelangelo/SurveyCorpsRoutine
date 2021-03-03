using UnityEngine;

namespace CoreSystems.ProjectSettings
{
    public class RefreshRateSetter : MonoBehaviour
    {
        private void Start()
        {
            Time.fixedDeltaTime = 1 / UnityEngine.XR.XRDevice.refreshRate;
        }
    }
}
