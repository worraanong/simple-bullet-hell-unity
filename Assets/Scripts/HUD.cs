using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Score").GetComponent<Text>().text = $"Score   {GameStat.Score}";
        GameObject.Find("Combo").GetComponent<Text>().text = $"KILLS : {GameStat.Kills}";
    }
}
