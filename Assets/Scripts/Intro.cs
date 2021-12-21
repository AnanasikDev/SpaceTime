using UnityEngine;
using System.Collections;
using TMPro;
public class Intro : MonoBehaviour
{
    [SerializeField] private float ReadingTime = 1f; // Время текста на экране
    [SerializeField] private float DelayTime = 1f; // Время между текстами
    [SerializeField] private float SignDelay = 0.03f;
    [SerializeField] private GameObject[] Objs;
    [SerializeField] private Animator Window;
    private void Start() => Init();
    private void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine("Wait");
    }
    private IEnumerator Wait()
    {
        foreach (GameObject obj in Objs)
        {
            obj.gameObject.SetActive(true);
            yield return AnimateText(obj.GetComponent<TextMeshProUGUI>());
            yield return new WaitForSeconds(ReadingTime);
            obj.gameObject.SetActive(false);
            yield return new WaitForSeconds(DelayTime);
        }
        Window.SetTrigger("fadeout");
    }
    private bool GetSkipInput()
    {
        return Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
    }
    private IEnumerator AnimateText(TextMeshProUGUI _Text)
    {
        string text = _Text.text;

        _Text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            if (GetSkipInput())
            {
                _Text.text = text;
                yield break;
            }
            yield return new WaitForSeconds(SignDelay);
            _Text.text += text[i];
        }
    }
}
