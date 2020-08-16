using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ghostCoinsText = null;
    [SerializeField] Slider remainingTime = null;

    PlayerGhost playerGhost = null;

    void Start()
    {
        playerGhost = FindObjectOfType<PlayerGhost>();
    }
    void Update()
    {
        if(playerGhost.IsGhost)
        {
            if(!remainingTime.gameObject.activeSelf)
            {
                remainingTime.gameObject.SetActive(true);
            }
            remainingTime.value = playerGhost.RemainingTimeAsPercent;
        }
        else
        {
            if(remainingTime.gameObject.activeSelf)
            {
                remainingTime.gameObject.SetActive(false);
            }
        }
        ghostCoinsText.text = playerGhost.GhostCoinsCounter.ToString();
    }
}