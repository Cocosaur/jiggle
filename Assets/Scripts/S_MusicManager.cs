using UnityEngine;
using System.Collections;
 
public class S_MusicManager : MonoBehaviour {
 
    public GameObject[] music;
 
    void Start(){
        music = GameObject.FindGameObjectsWithTag ("bgMusic");
    }
 	
    void Awake () {
        DontDestroyOnLoad (transform.gameObject);
    }
}