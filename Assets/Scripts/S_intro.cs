using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class S_intro : MonoBehaviour
{
    public TextMeshProUGUI phrase1;
    public TextMeshProUGUI phrase2;

    public GameObject phrase1object;
    public GameObject phrase2object;
    public GameObject playButton;

    private bool menuActivated;
    
    
    void Start()
    {
        phrase1object.SetActive(true);
        phrase2object.SetActive(false);
        playButton.SetActive(false);
    }
    
    void Update()
    {
        if (menuActivated)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            menuActivated = true;
            phrase1object.SetActive(false);
            phrase2object.SetActive(true);
            playButton.SetActive(true);
        }
    }
    
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
