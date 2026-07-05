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
    
    
    void Start()
    {
        phrase1object.SetActive(true);
        phrase2object.SetActive(false);
        playButton.SetActive(false);
    }

    private void OnMouseUp()
    {
        phrase1object.SetActive(false);
        phrase2object.SetActive(true);
        playButton.SetActive(true);

    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
