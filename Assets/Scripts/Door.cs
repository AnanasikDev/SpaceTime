using UnityEngine;

public class Door : MonoBehaviour
{
    public int ID;
    [SerializeField] private Dir Direction;
    [SerializeField] private float Distance = 1.6f;
    [SerializeField, Tooltip("Debug Value")] private Vector3 dir;
    public void Tp()
    {
        if (Direction == Dir.Vertical)
            dir = Vector3.up *
                (PlayerMovement.instance.transform.position.y > transform.position.y ? -1 : 1) * Distance;

        if (Direction == Dir.Horizontal)
            dir = Vector3.right *
                (PlayerMovement.instance.transform.position.x > transform.position.x ? -1 : 1) * Distance;

        PlayerMovement.instance.transform.position += dir;
        PlayerMovement.instance._Rigidbody2D.position = PlayerMovement.instance.transform.position;
        PlayerMovement.instance._Rigidbody2D.velocity = Vector2.zero;
    }
    public enum Dir
    {
        Vertical,
        Horizontal
    }
}
