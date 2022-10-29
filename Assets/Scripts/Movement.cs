using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5;
    public void Move(Vector2 movement)
    {
        transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime * Speed;
    }
}