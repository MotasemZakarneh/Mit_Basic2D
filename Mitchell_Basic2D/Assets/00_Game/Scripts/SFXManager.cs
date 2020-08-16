using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static void PlayClip(AudioClip clip)
    {
        if (!clip)
            return;

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}