using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour {
    public GameManager gameManager;

    public void ReloadFromCheckpoint() {
        // Check if the game has started
        if (gameManager != null && gameManager.HasGameStarted()) {
            // Reset the score
            gameManager.ResetScore();
            
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
