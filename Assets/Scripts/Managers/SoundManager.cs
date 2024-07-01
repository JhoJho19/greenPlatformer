using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceSounds;
    [SerializeField] AudioClip clickStartButton;
    private static SoundManager instance = null;
    public static bool IsSoundOn;
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


    private void Start()
    {
        SetSoundVolume();
    }

    private void SetSoundVolume()
    {
        audioSourceSounds.volume = IsSoundOn ? 1.0f : 0.0f;
    }

    public static void SaveMusicSetting()
    {
        PlayerPrefs.SetInt("IsMusicOn", IsSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void LoadMusicSetting()
    {
        if (PlayerPrefs.HasKey("IsMusicOn"))
        {
            IsSoundOn = PlayerPrefs.GetInt("IsSoundOn") == 1;
        }
        else
        {
            IsSoundOn = true;
        }
    }

    public void ToggleSounds()
    {
        IsSoundOn = !IsSoundOn;
        SetSoundVolume();
        SaveMusicSetting();
    }


    public void StartButtonSound()
    {
        audioSourceSounds.clip = clickStartButton;
        audioSourceSounds.Play();
    }
}
