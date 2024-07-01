using UnityEngine;
using UnityEngine.iOS;

public class Rate : MonoBehaviour
{
    public void RateGame()
    {
        Device.RequestStoreReview();
    }
}
