using UnityEngine;
using System;
public class TaskPlace : MonoBehaviour
{
    [SerializeField] protected Task _Task;

    [SerializeField] protected float ActiveDistance = 1f;
    private bool IsPlayerNere()
    {
        return (transform.position - PlayerMovement.instance.transform.position).sqrMagnitude <= ActiveDistance;
    }
    private void GetEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!IsPlayerNere()) return;

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
