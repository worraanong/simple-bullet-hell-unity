using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("TxtScore").GetComponent<Text>().text = $"Score   {GameStat.Score}";
        GameObject.Find("TxtHighScore").GetComponent<Text>().text = $"High Score   {GetHighScore()}";
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public static void LoadMenu()
    {
        var currentHighScore = GetHighScore();
        if (GameStat.Score > currentHighScore) SaveHighScore(GameStat.Score);
        SceneManager.LoadScene("MenuScene");
    }

    public static void LoadGame()
    {
        GameStat.Score = 0;
        GameStat.Kills = 0;
        GameStat.MaxEnemy = 0;
        SceneManager.LoadScene("MainScene");
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public static void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("highScore", score);
    }

    public static void PlaySound(AudioClip sound, GameObject gameObject)
    {
        if (sound == null) return;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }
}
