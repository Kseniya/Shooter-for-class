using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject [] enemies;
    public Vector2 spawnValues;
    public float spawnTime;

    public GameObject gameOverUI;
    public Text scoreText;
    bool gameOver;
    int score = 0;

    void Start ()
    {
        StartCoroutine (SpawnEnemies());
    }

    IEnumerator SpawnEnemies ()
    {
        while (!gameOver) {
            GameObject enemie = enemies [Random.Range (0, enemies.Length)];
            Vector3 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate (enemie, spawnPosition, spawnRotation);

            yield return new WaitForSeconds (spawnTime);
        }
    }

    public void GameOver ()
    {
        gameOver = true;
        gameOverUI.SetActive (true);
    }

    public void Restart ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    public void AddScore ()
    {
        score++;
        scoreText.text = score.ToString ();
    }
}
