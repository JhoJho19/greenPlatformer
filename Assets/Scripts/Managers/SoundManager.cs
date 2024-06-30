using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceSounds;
    [SerializeField] AudioClip clickStartButton;
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartButtonSound()
    {
        audioSourceSounds.clip = clickStartButton;
        audioSourceSounds.Play();
    }
}
