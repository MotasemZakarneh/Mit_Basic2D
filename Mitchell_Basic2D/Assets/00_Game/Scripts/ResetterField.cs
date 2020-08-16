using UnityEngine;

public class ResetterField : MonoBehaviour
{
    [SerializeField] Transform lastCheckpoint = null;

    public void UpdateCheckPoint(Transform toPos)
    {
        lastCheckpoint = toPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = lastCheckpoint.position;
        }
    }
}
