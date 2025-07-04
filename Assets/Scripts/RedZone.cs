using UnityEngine;

public class RedZone : MonoBehaviour {
    public GameObject gameOverMenu;
    //public GameObject cubeSpawner;
    private bool gameIsOver = false;

    private void OnTriggerStay(Collider other) {
        if (gameIsOver) return;

        Cube cube = other.GetComponent<Cube>();
        if (cube != null) {
            if (!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < 0.1f) {
                Debug.Log("Game Over");
                //cubeSpawner.SetActive(false);
                Time.timeScale = 0f;
                gameIsOver = true;
                GameManager.Instance.GameOver();
                if (gameOverMenu != null) {
                    gameOverMenu.SetActive(true);
                }
            }
        }
    }
}
