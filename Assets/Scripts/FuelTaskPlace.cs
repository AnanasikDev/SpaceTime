using UnityEngine;
using UnityEngine.UI;
public class FuelTaskPlace : TaskPlace
{
    [SerializeField] FuelTask _FuelTask;
    [SerializeField] private float Speed = 1.25f;

    [Tooltip("Debug Value")] public int PassedAmount = 0;
    [SerializeField] private int PassedAmountNeeded = 3;
    [SerializeField] private Image[] Statuses;

    private void Start()
    {
        OnOpened += SetParams;
    }
    private void SetParams()
    {
        _FuelTask.IsPassed = IsCompleted;
        _FuelTask.CursorSpeed = Speed;
        _FuelTask.PassedAmountNeeded = PassedAmountNeeded;
        _FuelTask.Statuses = Statuses;
    }
}
