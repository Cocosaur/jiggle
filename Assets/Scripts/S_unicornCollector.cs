using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class S_unicornCollector : MonoBehaviour
{

    private int unicornCount;
    public int unicornObjective = 3;
    
    public TextMeshProUGUI countText;

    public GameObject Win;
    public GameObject TooMany;
    public GameObject RestartButton;

    public List<GameObject> unicornsInTrigger = new List<GameObject>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("unicornObject"))
        {
            if (!unicornsInTrigger.Contains(other.gameObject))
            {
                unicornsInTrigger.Add(other.gameObject);

                unicornCount++;
                SetCountText();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (unicornsInTrigger.Contains(other.gameObject))
        {
            unicornsInTrigger.Remove(other.gameObject);
            unicornCount--;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "in basket " + unicornCount.ToString() + "/" + unicornObjective;
        CheckCount();
    }
    

    void CheckCount()
    {
        if (unicornCount == unicornObjective)
        {
            Win.SetActive(true);
            TooMany.SetActive(false);
            RestartButton.SetActive(true);
        }

        if (unicornCount > unicornObjective)
        {
            Win.SetActive(false);
            TooMany.SetActive(true);
        }
        
        if (unicornCount < unicornObjective)
        {
            Win.SetActive(false);
            TooMany.SetActive(false);
        } 
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        SetCountText();
        Win.SetActive(false);
        TooMany.SetActive(false);
        RestartButton.SetActive(false);
    }
    
}
