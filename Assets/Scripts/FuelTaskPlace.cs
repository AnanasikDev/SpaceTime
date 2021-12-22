using UnityEngine;

public class FuelTaskPlace : TaskPlace
{
    [SerializeField] private float Speed = 1.25f;

    private void Start()
    {
        OnOpened += SetSpeed;
    }
    private void SetSpeed()
    {
        FuelTask.instance.CursorSpeed = Speed;
    }
}
