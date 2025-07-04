using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    public GameObject gameStartPanel;

    private void Start() {
        gameStartPanel.SetActive(true);
    }

    public void OnStartButtonClick() {
        GameManager.Instance.StartGame();
        gameStartPanel.SetActive(false);
    }
}
