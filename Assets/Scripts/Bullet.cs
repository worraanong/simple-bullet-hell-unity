using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    public float Damage = 1f;
    public bool IsDestroyable = true;
    public AudioClip sound;

    private void Start()
    {
        GameController.PlaySound(sound, gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsDestroyable) Destroy(gameObject);
    }
}
