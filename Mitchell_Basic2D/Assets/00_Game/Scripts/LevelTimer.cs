using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 20;
    [SerializeField] float lostTime = 3;

    [SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] GameObject lostText = null;

    [SerializeField] AudioClip timeIsUpSFX = null;

    bool didChange = false;

    public bool IsTimeUp => levelTime <= 0;

    void Start()
    {
        lostText.gameObject.SetActive(false);
    }
    void Update()
    {
        levelTime -= Time.deltaTime;
        levelTime = Mathf.Clamp(levelTime, 0, int.MaxValue);
        timerText.text = Mathf.RoundToInt(levelTime).ToString();

        if(levelTime<=0)
        {
            if(!lostText.gameObject.activeSelf)
            {
                lostText.gameObject.SetActive(true);
                SFXManager.PlayClip(timeIsUpSFX);
            }
            lostTime -= Time.deltaTime;
            if(lostTime<=0 && !didChange)
            {
                didChange = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}