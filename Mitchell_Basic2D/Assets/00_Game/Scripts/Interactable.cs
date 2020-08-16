using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent calls = null;
    [SerializeField] int maxInteractions = -1;

    int interactionsCount = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && IsGoodInteractionsCount())
        {
            calls.Invoke();
            interactionsCount++;
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
