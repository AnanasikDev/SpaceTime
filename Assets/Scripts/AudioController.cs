using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource Source;

    public AudioClip AmbientMusic;
    public AudioClip CorrectAnswer;
    public AudioClip WrongAnswer;

    public static AudioController instance;

    public void Play(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }
}
