using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    public bool IsGhost => isGhost;
    public float RemainingTimeAsPercent => ghostCounter;
    [SerializeField] int ghostCoinsRequirement = 5;
    [SerializeField] float ghostTime = 0.25f;
    [SerializeField] Color ghostColor = Color.blue;

    int ghostCoinsCounter = 0;
    float ghostCounter = 0;
    bool isGhost = false;

    SpriteRenderer sr = null;
    Color oldColor = new Color();
    Collider2D col = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        ghostCoinsCounter = ghostCoinsRequirement;
        oldColor = sr.color;
    }
    void Update()
    {
        if (isGhost)
        {
            GhostUpdate();
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && ghostCoinsCounter >= ghostCoinsRequirement)
        {
            ghostCounter = 1;
            isGhost = true;
            sr.color = ghostColor;
            col.enabled = false;
            ghostCoinsCounter -= ghostCoinsRequirement;
        }
    }

    private void GhostUpdate()
    {
        ghostCounter -= Time.deltaTime / ghostTime;
        if(ghostCounter<=0)
        {
            isGhost = false;
            col.enabled = true;
            sr.color = oldColor;
        }
    }
}
