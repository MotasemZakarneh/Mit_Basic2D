using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResetterField : MonoBehaviour
{
    [SerializeField] Transform lastCheckpoint = null;
    [SerializeField] bool resetCollectiables = true;

    List<GhostCollectible> collectibles = null;
    void Start()
    {
        collectibles = FindObjectsOfType<GhostCollectible>().ToList();
    }
    public void UpdateCheckPoint(Transform toPos)
    {
        lastCheckpoint = toPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = lastCheckpoint.position;
            other.GetComponent<Player>().ResetPlayer();
            if(resetCollectiables)
            {
                foreach (var c in collectibles)
                {
                    c.Enter();
                }
            }
        }
    }
}
