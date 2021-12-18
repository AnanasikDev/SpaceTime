using UnityEngine;

public class Door : MonoBehaviour
{
    public int ID;

    public void Tp()
    {
        int dir = PlayerMovement.instance.transform.position.y > transform.position.y ? -1 : 1;
        PlayerMovement.instance.transform.position += Vector3.up * dir * 1.6f;
        PlayerMovement.instance._Rigidbody2D.position = PlayerMovement.instance.transform.position;
        PlayerMovement.instance._Rigidbody2D.velocity = Vector2.zero;
    }
}
