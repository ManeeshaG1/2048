using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    public AudioClip mergeclip;
    private float musicVolume = 1f; // Default music volume
    public Button toggleButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public GameObject Camera;
    private bool isSoundOn = true;
    private bool muteValid;

    // Key to store sound state in PlayerPrefs
    private string soundStateKey = "SoundState";

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;

        // Load sound state from PlayerPrefs
        isSoundOn = PlayerPrefs.GetInt(soundStateKey, 1) == 1;

        // Set initial button sprite based on sound state
        toggleButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;

        // Set initial music state based on sound state
        if (isSoundOn) {
            TurnOnMusic();
        } else {
            TurnOffMusic();
        }

        toggleButton.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound() {
        isSoundOn = !isSoundOn;

        if (isSoundOn) {
            toggleButton.image.sprite = soundOnSprite;
            TurnOnMusic();
        } else {
            toggleButton.image.sprite = soundOffSprite;
            TurnOffMusic();
        }

        // Save sound state to PlayerPrefs
        PlayerPrefs.SetInt(soundStateKey, isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume) {
        musicVolume = volume;
        audioSource.volume = musicVolume;
    }

    public float GetMusicVolume() {
        return musicVolume;
    }

    public void TurnOnMusic() {
        audioSource.volume = musicVolume; // Restore previous volume
        audioSource.Play();
        muteValid = false;
    }

    public void TurnOffMusic() {
        audioSource.Pause();
        muteValid = true;
    }

    public void mergeSound() {
        if (!muteValid) {
            audioSource.PlayOneShot(mergeclip);
            Camera.GetComponent<CameraShake>().ShakeCamera();
        }
    }
}
