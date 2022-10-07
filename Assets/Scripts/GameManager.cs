using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    private float spawnRate = 1;
    private int score;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    //SpawnTarget is used to spawn objects randomly
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    //RestartGame is used to restart the game after it has ended
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //StartGame is used to start the game upon clicking on a difficulty
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;

        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
