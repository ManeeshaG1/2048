using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour {
    private bool gameIsOver = false;
    private bool gameHasStarted = false;
    public int score;

    // References to UI Text components for displaying scores
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;

    public UnityEvent OnGameStart;

    //public GameObject gameStartPanel;
    //public GameObject sliderInput;
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //gameStartPanel.SetActive(true);
        //sliderInput.SetActive(false);
    }



    private void Update() {
        scoreText.text = score.ToString();
        finalScoreText.text =  score.ToString();
    }

    public void ReloadGame() {
        if (gameIsOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }

    public void SetGameOver(bool isGameOver) {
        gameIsOver = isGameOver;
    }

    public void StartGame() {
        gameHasStarted = true;

        OnGameStart.Invoke();
    }

    public bool HasGameStarted() {
        return gameHasStarted;
    }

    public bool IsGameOver() {
        return gameIsOver;
    }

    public void GameOver() {
        gameIsOver = true;
        scoreText.enabled = false;
        //sliderInput.SetActive(false);
        Cube[] cubes = FindObjectsOfType<Cube>();
        foreach (Cube cube in cubes) {
            cube.SetCubeMovement(false);
        }
    }

    public void ResetScore() {
        score = 0;
    }
    
 
    public void OnStartButtonClicked()
    {
        GameManager.Instance.StartGame(); // Start the game when the button is clicked
        //gameStartPanel.SetActive(false); // Hide the game start panel
        //sliderInput.SetActive(true);// unHide the slider to play game
    }
    public void ReloadFromCheckpoint()
    {
        // Check if the game has started
        if (HasGameStarted())
        {
            // Reset the score
            ResetScore();

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
