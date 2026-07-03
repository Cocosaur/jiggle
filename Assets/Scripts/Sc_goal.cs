using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sc_goal : MonoBehaviour
{
    private int countPurple;
    private int countPink;
    private int countUnicorn;
    public bool winCondition;
    private string playerName = "Player";
    public GameObject restartButton;
    public GameObject winner;
    public S_PickUp pinkPlayer;
    public S_PickUp purplePlayer;
        
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countTextPrpl;
    public TextMeshProUGUI countTextPnk;
    public TextMeshProUGUI winnerText;
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("player-purple"))
        {
            countPink = countPink + 1;
            Debug.Log("player pink has scored" + countPink);
            
            SetCountText();
            CheckScores();
        }
        
        if (other.collider.CompareTag("player-pink"))
        { 
            countPurple = countPurple + 1;
           Debug.Log("player purple has scored" + countPurple);
           
           SetCountText();
           CheckScores();
        }
        
    }

    void Start()
    {
        SetCountText();
        restartButton.SetActive(false);
        winner.SetActive(false);

    }
    
    void SetCountText()
    {
        countTextPrpl.text = "Purple Score " + countPurple.ToString();
        countTextPnk.text = "Pink Score " + countPink.ToString();
    }

    void SetWinnerText()
    {
        winnerText.text = playerName + " has won!";
    }

 

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("the scene has restarted");
    }

    void CheckScores()
    {
        if (countPurple>=3)
        { 
            winCondition = true;
            
            playerName = "Purple";
            endOfRound();
        }
        
        if (countPink>=3)
        { 
            winCondition = true;
            
            playerName = "Pink";
            endOfRound();
        }
    }
    

    void endOfRound()
    {
            winner.SetActive(true);
            SetWinnerText();
            restartButton.SetActive(true);

            pinkPlayer.pickUpable = false;
            purplePlayer.pickUpable = false;
    }
}
