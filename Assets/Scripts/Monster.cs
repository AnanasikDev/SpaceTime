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

    private void Update()
    {
        i = StressCurve.Evaluate(Time.realtimeSinceStartup * 2);
        Current = Random.Range(0, i);
        if (Current > Stress)   
        {
            Activate();
        }
    }
    private void Activate()
    {
        if (!IsRelaxed) return;

        AudioController.instance.Play(AudioController.instance.Screamer, 1.4f);
        AudioController.instance.Play(AudioController.instance.HeartBeating, 1.1f);

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
