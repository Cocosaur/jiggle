using System;
using UnityEngine;
using TMPro;

public class Sc_goal : MonoBehaviour
{
    private int countPurple;
    private int countPink;
    private int countUnicorn;
    public bool winCondition;
        
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countTextPrpl;
    public TextMeshProUGUI countTextPnk;
    
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

    }
    
    void SetCountText()
    {
        //countText.text = "Dummy Score " + countUnicorn.ToString();
        countTextPrpl.text = "Purple Score " + countPurple.ToString();
        countTextPnk.text = "Pink Score " + countPink.ToString();
    }

    void Update()
    {
        if (countUnicorn.Equals(3))
        { 
            winCondition = true;
            Debug.Log("Player has won");
        }
        
        if (countPurple.Equals(3))
        { 
            winCondition = true;
            Debug.Log("Pink has won");
        }
        
        if (countPink.Equals(3))
        { 
            winCondition = true;
            Debug.Log("Purple has won");
        }
    }
}
