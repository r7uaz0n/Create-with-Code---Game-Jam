using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int score;
    public TextMeshProUGUI StarCounter;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.score = score;
        GlobalControl.Instance.StarCounter = StarCounter;
    }
}