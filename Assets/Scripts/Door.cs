using UnityEngine;
public class Door : MonoBehaviour
{
    public int ID;
    [SerializeField] private Dir Direction;
    [SerializeField] private float Distance = 1.6f;
    [SerializeField, Tooltip("Debug Value")] private Vector3 dir;

    private SpriteRenderer _SpriteRenderer;
    [SerializeField] private Sprite OpenableDoorSprite;
    //[SerializeField] private Sprite NotOpenableDoorSprite;

    [SerializeField] private Sprite[] DoorSprites; // Спрайты двери для каждого ID
    private void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().sprite = DoorSprites[ID];
    }
    public void Tp()
    {
        if (!KeyContains())
        {
            AudioController.instance.Play(AudioController.instance.WrongAnswer);
            return;
        }

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
    private bool KeyContains()
    {
        return DoorController.ContainsKey(ID);
    }
    public void SetImage()
    {
        bool openable = KeyContains();

        _SpriteRenderer.sprite = openable ? OpenableDoorSprite : DoorSprites[ID];
    }
    public enum Dir
    {
        Vertical,
        Horizontal
    }
}
