using UnityEngine;
using System;
public class TaskPlace : MonoBehaviour
{
    [SerializeField] private Task _Task;

    [SerializeField] private float ActiveDistance = 1f;
    [SerializeField] private bool IsPlayerNear = false;

    [HideInInspector] public Action OnOpened;

    [SerializeField] private int Key = 1;

    public bool IsCompleted = false;
    //[SerializeField] private GameObject Prompt;
    private bool GetIsPlayerNear()
    {
        return (transform.position - PlayerMovement.instance.transform.position).sqrMagnitude <= ActiveDistance;
    }
    private void GetEnter()
    {
        IsPlayerNear = GetIsPlayerNear();

        //Prompt.SetActive(IsPlayerNear);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!IsPlayerNear) return;

            _Task.Key = Key;
            _Task.IsPassed = IsCompleted;
            OnOpened?.Invoke();
            _Task._TaskPlace = this;
            _Task.Open();
        }
    }
    private void Update()
    {
        GetEnter();
    }
    private void OnDrawGizmos()
    {
        try
        {
            Gizmos.color = new Color(0.1f, 0.6f, 0.1f);
            Gizmos.DrawWireSphere(transform.position, ActiveDistance);
            Gizmos.color = Color.white;
        }
        catch { }
    }
    public void Complete() => IsCompleted = true;
    public enum TaskType {
        Fuel
    }
}
