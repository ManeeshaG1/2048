using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour {
    public GameObject gameStartPanel;

    private void Start() {
        gameStartPanel.SetActive(true);
    }

    public void OnStartButtonClicked() {
        GameManager.Instance.StartGame(); // Start the game when the button is clicked
        gameStartPanel.SetActive(false); // Hide the game start panel
    }
}
