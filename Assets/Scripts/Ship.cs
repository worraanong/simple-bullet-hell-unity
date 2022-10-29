using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(AutoFire))]
public class Ship : MonoBehaviour
{
    public AudioClip sound;

    private Movement movement;
    private AutoFire autoFire;
    private readonly float horizontalSize = 8f;
    private bool die;

    void Start()
    {
        movement = GetComponent<Movement>();
        autoFire = GetComponent<AutoFire>();
    }

    void Update()
    {
        if (die) return;
        ControllShip();
        autoFire.Aim(autoFire.FindTarget());
        autoFire.Fire();
    }

    void ControllShip()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement.Move(new Vector2(horizontal, 0));

        if (transform.position.x < -horizontalSize) transform.position = new Vector3(-horizontalSize, transform.position.y, transform.position.z);
        if (transform.position.x > horizontalSize) transform.position = new Vector3(horizontalSize, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        die = true;
        StartCoroutine(Dying());
    }

    IEnumerator Dying()
    {
        GameController.PlaySound(sound, gameObject);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        GameController.LoadMenu();
    }

}