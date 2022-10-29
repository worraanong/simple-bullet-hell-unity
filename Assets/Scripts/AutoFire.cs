using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoFire : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Transform gun;
    public float fireRate;
    private float _cooldown;

    void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    public void Fire()
    {
        if (_cooldown > 0) return;
        Instantiate(bullet, gun.position, gun.rotation);

        _cooldown = fireRate;
    }

    public void Aim(GameObject target)
    {
        if (target == null) return;
        var vec = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, vec);
    }

    public GameObject FindTarget()
    {
        float minDist = float.MaxValue;
        var targets = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closestTarget = null;

        foreach (var target in targets)
        {
            float dist = Vector2.SqrMagnitude(transform.position - target.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closestTarget = target;
            }
        }
        return closestTarget;
    }

    public GameObject FindPlayerShip()
    {
        var ship = GameObject.Find("Ship");
        if (ship == null) SceneManager.LoadScene("MenuScene");
        return GameObject.Find("Ship");
    }
}
