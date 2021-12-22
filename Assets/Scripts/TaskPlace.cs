using UnityEngine;
using System;
public class TaskPlace : MonoBehaviour
{
    [SerializeField] private Task _Task;

    [SerializeField] private float ActiveDistance = 1f;
    [SerializeField] private bool IsPlayerNear = false;

    [HideInInspector] public Action OnOpened;

    [SerializeField] private int Key = 1;
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

            OnOpened?.Invoke();
            _Task.Key = Key;
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
    public enum TaskType {
        Fuel
    }
}
