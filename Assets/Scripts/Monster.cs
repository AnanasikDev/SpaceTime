using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    [SerializeField] private AnimationCurve StressCurve;
    [SerializeField] private Animator _Animator;
    [SerializeField] private float Stress = 1f;
    [SerializeField] private float StressUnitDuration = 3f;
    [SerializeField, Tooltip("Debug Value")] private bool IsRelaxed = true;
    [SerializeField, Tooltip("Debug Value")] float i;
    [SerializeField, Tooltip("Debug Value")] float Current;

    private void Start()
    {
        Stress = Stress / 100f;
    }
    private void Update()
    {
        i = StressCurve.Evaluate(Time.realtimeSinceStartup);
        float max = 200f;
        Current = Random.Range(0, i * max);
        if (Current > max - Stress)
        {
            Activate();
        }
    }
    private void Activate()
    {
        if (!IsRelaxed) return;

        _Animator.SetTrigger("light");
        StartCoroutine("Wait");
    }
    private IEnumerator Wait()
    {
        IsRelaxed = false;
        yield return new WaitForSeconds(StressUnitDuration);
        IsRelaxed = true;
    }
}
