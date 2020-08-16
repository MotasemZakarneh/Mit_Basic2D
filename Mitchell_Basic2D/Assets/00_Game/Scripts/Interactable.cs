using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent calls = null;
    [SerializeField] int maxInteractions = -1;
    [SerializeField] bool refreshCollectibles = false;

    int interactionsCount = 0;
    List<GhostCollectible> collectibles = null;

    void Start()
    {
        collectibles = FindObjectsOfType<GhostCollectible>().ToList();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && IsGoodInteractionsCount())
        {
            calls.Invoke();
            interactionsCount++;
            if(refreshCollectibles)
            {
                foreach (var c in collectibles)
                {
                    c.Enter();
                }
            }
        }
    }

    private bool IsGoodInteractionsCount()
    {
        if (interactionsCount <= maxInteractions)
            return true;
        if (maxInteractions == -1)
            return true;
        return false;
    }
}