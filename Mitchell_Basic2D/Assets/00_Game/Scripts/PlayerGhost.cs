using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    public int GhostCoinsCounter => ghostCoinsCounter;
    public bool IsGhost => isGhost;
    public float RemainingTimeAsPercent => ghostCounter;
    [SerializeField] int ghostCoinsRequirement = 5;
    [SerializeField] float ghostTime = 0.25f;
    [SerializeField] Color ghostColor = Color.blue;
    [SerializeField] BoxCollider2D collisionBody = null;
    [SerializeField] BoxCollider2D ghostBody = null;

    [SerializeField] AudioClip startGhostingSFX = null;
    [SerializeField] AudioClip endGhostingSFX = null;

    int ghostCoinsCounter = 0;
    float ghostCounter = 0;
    bool isGhost = false;

    SpriteRenderer sr = null;
    Color oldColor = new Color();
    LevelTimer levelTimer = null;

    void Start()
    {
        levelTimer = FindObjectOfType<LevelTimer>();
        sr = GetComponent<SpriteRenderer>();

        ghostCoinsCounter = ghostCoinsRequirement;
        oldColor = sr.color;
        ghostBody.enabled = false;
    }
    void Update()
    {
        if (levelTimer.IsTimeUp)
            return;

        if (isGhost)
        {
            GhostUpdate();
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && ghostCoinsCounter >= ghostCoinsRequirement)
        {
            StartGhosting();
        }
    }

    
    private void GhostUpdate()
    {
        ghostCounter -= Time.deltaTime / ghostTime;
        if(ghostCounter<=0)
        {
            StopGhosting();
            SFXManager.PlaySFX(endGhostingSFX);
        }
    }

    private void StartGhosting()
    {
        SFXManager.PlaySFX(startGhostingSFX);

        ghostCounter = 1;
        isGhost = true;
        sr.color = ghostColor;
        collisionBody.enabled = false;
        ghostCoinsCounter -= ghostCoinsRequirement;
        ghostBody.enabled = true;
    }

    private void StopGhosting()
    {
        isGhost = false;
        collisionBody.enabled = true;
        sr.color = oldColor;
        ghostBody.enabled = false;
    }

    public void ResetGhost()
    {
        StopGhosting();
    }
    public void AddPoints(int points)
    {
        ghostCoinsCounter += points;
    }
}
