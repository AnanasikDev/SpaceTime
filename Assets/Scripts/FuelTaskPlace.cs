using UnityEngine;

public class FuelTaskPlace : TaskPlace
{
    [SerializeField] FuelTask _FuelTask;
    [SerializeField] private float Speed = 1.25f;

    private void Start()
    {
        OnOpened += SetSpeed;
        _FuelTask.OnCompleted += Complete;
    }
    private void SetSpeed()
    {
        _FuelTask.CursorSpeed = Speed;
    }
    private void Complete() => IsCompleted = true;
}
