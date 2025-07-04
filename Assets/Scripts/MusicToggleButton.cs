using UnityEngine;
using UnityEngine.UI;

public class MusicToggleButton : MonoBehaviour {
    public Button toggleButton;
    public AudioManager audioManager;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isSoundOn = true;

    private void Start() {
        toggleButton.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound() {
        isSoundOn = !isSoundOn;
        
        if (isSoundOn) {
            toggleButton.image.sprite = soundOnSprite;
            audioManager.TurnOnMusic();
        } else {
            toggleButton.image.sprite = soundOffSprite;
            audioManager.TurnOffMusic();
        }
    }
}
