using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource musicSource;
    private static BackgroundMusic instance = null;
    public static bool IsMusicOn;
    public static BackgroundMusic Instance
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

        LoadMusicSetting();
    }

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        SetMusicVolume();
    }

    private void SetMusicVolume()
    {
        musicSource.volume = IsMusicOn ? 1.0f : 0.0f;
    }

    public static void SaveMusicSetting()
    {
        PlayerPrefs.SetInt("IsMusicOn", IsMusicOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void LoadMusicSetting()
    {
        if (PlayerPrefs.HasKey("IsMusicOn"))
        {
            IsMusicOn = PlayerPrefs.GetInt("IsMusicOn") == 1;
        }
        else
        {
            IsMusicOn = true;
        }
    }

    public void ToggleMusic()
    {
        IsMusicOn = !IsMusicOn;
        SetMusicVolume();
        SaveMusicSetting();
    }
}
