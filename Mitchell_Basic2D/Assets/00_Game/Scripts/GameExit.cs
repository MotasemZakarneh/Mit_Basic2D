using UnityEngine;

public class GameExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            return;
#endif
#if !UNITY_EDITOR
            Application.Quit();
#endif
        }
    }
}
