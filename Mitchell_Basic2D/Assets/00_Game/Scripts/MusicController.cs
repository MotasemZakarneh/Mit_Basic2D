using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource = null;
    public static MusicController instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }
}
