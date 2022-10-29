using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AutoFire))]
public class Enemy : MonoBehaviour
{
    public EnemyData stat;
    public AudioClip sound;

    private AutoFire autoFire;
    private int _health;

    void Start()
    {
        autoFire = GetComponent<AutoFire>();
        _health = stat.Health;
        autoFire.Aim(autoFire.FindPlayerShip());
    }

    void Update()
    {
        if (_health <= 0)
        {
            StartCoroutine(Dying());
        }

        if (stat.AutoLock) autoFire.Aim(autoFire.FindPlayerShip());
        autoFire.Fire();

        if (stat.RotateSpeed > 0) transform.Rotate(Vector3.forward, 45 * Time.deltaTime * stat.RotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser") _health -= 1;
        GameStat.Score += 10;
    }

    IEnumerator Dying()
    {
        Destroy(gameObject);
        GameStat.Score += stat.Score;
        GameStat.Kills += 1;
        UpdateMaxEnemy();
        GameObject _go = new GameObject();
        GameController.PlaySound(sound, _go);
        yield return new WaitForSeconds(1);
        Destroy(_go);
    }

    void UpdateMaxEnemy()
    {
        if(GameStat.MaxEnemy < 3) GameStat.MaxEnemy++;
    }
}