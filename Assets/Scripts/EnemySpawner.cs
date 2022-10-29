using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTypes;

    private int hardest = 0;

    private readonly float xMin = -8.4f;
    private readonly float xMax = 8.4f;
    private readonly float yMin = 1f;
    private readonly float yMax = 3.8f;

    void Start()
    {
        RandomPlace(enemyTypes[hardest]);
    }

    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length < GameStat.MaxEnemy)
        {
            if (hardest != 5) hardest = GameStat.Kills / 3;
            var t = Random.Range(0, hardest);

            RandomPlace(enemyTypes[t]);
        }
    }

    void RandomPlace(GameObject enemy)
    {
        var xPos = Random.Range(xMin, xMax);
        var yPos = Random.Range(yMin, yMax);
        var pos = new Vector3(xPos, yPos, 0);
        Instantiate(enemy, pos, transform.rotation);
    }

    IEnumerator AddSpawnGap()
    {
        yield return new WaitForSeconds(1);

    }

}
