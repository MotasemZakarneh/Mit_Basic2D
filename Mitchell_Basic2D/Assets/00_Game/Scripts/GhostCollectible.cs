using UnityEngine;

public class GhostCollectible : MonoBehaviour
{
    [SerializeField] int points = 5;
    [SerializeField] AudioClip takenSFX = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerGhost>().AddPoints(points);
            Leave();
            SFXManager.PlayClip(takenSFX);
        }
    }

    public void Leave()
    {
        gameObject.SetActive(false);
    }
    public void Enter()
    {
        gameObject.SetActive(true);
    }
}
