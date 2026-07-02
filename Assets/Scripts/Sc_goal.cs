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

        }
        
        if (other.collider.CompareTag("player-pink"))
        { 
            countPurple = countPurple + 1;
           Debug.Log("player purple has scored" + countPurple);
           
           SetCountText();
        }
        
        if (other.collider.CompareTag("unicorn"))
        {
            countUnicorn = countUnicorn + 1;
            Debug.Log("player has scored" + countUnicorn);
            
            SetCountText();

        }
        
    }

    void Start()
    {
        SetCountText();
        winCondition = false;
        restartButton.SetActive(false);
        winner.SetActive(false);

    }
    
    void SetCountText()
    {
        //countText.text = "Dummy Score " + countUnicorn.ToString();
        countTextPrpl.text = "Purple Score " + countPurple.ToString();
        countTextPnk.text = "Pink Score " + countPink.ToString();
    }

    void SetWinnerText()
    {
        winnerText.text = playerName + " has won!";
    }

    void Update()
    {
        if (countUnicorn>=3)
        { 
            winCondition = true;
            Debug.Log("Player has won");
        }
        
        if (countPurple>=3)
        { 
            winCondition = true;
            
            playerName = "Purple";
            
            winner.SetActive(true);
            SetWinnerText();
            restartButton.SetActive(true);
        }
        
        if (countPink>=3)
        { 
            winCondition = true;
            playerName = "Pink";
            
            winner.SetActive(true);
            SetWinnerText();
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("the scene has restarted");
    }
}
