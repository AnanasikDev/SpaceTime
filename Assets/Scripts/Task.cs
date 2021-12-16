using UnityEngine;
using UnityEngine.UI;
public abstract class Task : MonoBehaviour
{
    [SerializeField] protected GameObject WindowPanel;
    [SerializeField, Tooltip("Debug Value")] protected bool IsOpened = false;

    [SerializeField] protected Image StatusImage;
    [SerializeField] protected Color PassColor;
    [SerializeField] protected Color FailColor;
    [SerializeField, Tooltip("Debug Value")] protected bool IsPassed;

    protected abstract void Pass();
    protected abstract void Fail();
    public abstract void Open();
    public abstract void Close();
}
