using UnityEngine;

public class GhostCollectible : MonoBehaviour
{
    [SerializeField] int points = 5;
    [SerializeField] AudioClip takenSFX = null;
    bool wasTaken = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !wasTaken)
        {
            wasTaken = true;
            other.GetComponent<PlayerGhost>().AddPoints(points);
            Leave();
            SFXManager.PlaySFX(takenSFX);
        }
    }

    public void Leave()
    {
        gameObject.SetActive(false);
    }
    public void Enter()
    {
        wasTaken = false;
        gameObject.SetActive(true);
    }
}
