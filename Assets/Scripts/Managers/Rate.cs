using UnityEngine;
using UnityEngine.iOS;

public class RateGame : MonoBehaviour
{
    public void RequestReview()
    {
#if UNITY_IOS
        Device.RequestStoreReview();
#endif
    }
}
