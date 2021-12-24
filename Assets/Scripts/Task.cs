using UnityEngine;
using UnityEngine.UI;
using System;
public abstract class Task : MonoBehaviour
{
    [SerializeField] protected GameObject WindowPanel;
    [SerializeField, Tooltip("Debug Value")] protected bool IsOpened = false;

    public TaskPlace _TaskPlace;

    [SerializeField] protected Image StatusImage;
    [SerializeField] protected Color PassColor;
    [SerializeField] protected Color FailColor;
    [Tooltip("Debug Value")] public bool IsPassed;

    [Tooltip("Debug Value")] public int Key = 1;

    public Action OnCompleted;

    protected abstract void Pass();
    protected abstract void Fail();
    public abstract void Open();
    public abstract void Close();
}
