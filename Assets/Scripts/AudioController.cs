using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource Source;

    public AudioClip AmbientMusic;
    public AudioClip CorrectAnswer;
    public AudioClip WrongAnswer;
    public AudioClip Screamer;
    public AudioClip HeartBeating;

    public static AudioController instance;

    public void Play(AudioClip clip, float volume = 1f)
    {
        Source.PlayOneShot(clip, volume);
    }
}
