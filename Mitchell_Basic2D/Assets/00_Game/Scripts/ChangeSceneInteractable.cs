using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInteractable : MonoBehaviour
{
    [SerializeField] string targetScene = "";
    [SerializeField] bool goToNextScene = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(!goToNextScene)
            {
                SceneManager.LoadScene(targetScene);
            }
            else
            {
                int curr = SceneManager.GetActiveScene().buildIndex;
                if(curr == SceneManager.sceneCountInBuildSettings-1)
                {
                    curr = 0;
                }
                else
                {
                    curr = curr + 1;
                }
                SceneManager.LoadScene(curr);
            }

        }
    }
}