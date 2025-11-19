using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;            // clip sẽ phát khi animation event gọi
    [Range(0f,1f)] public float volume = 1f;

    void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // gọi từ Animation Event (không có tham số)
    public void PlayClip()
    {
        if (clip == null) return;
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        Debug.Log("running i'm running i’m running");    }
}
