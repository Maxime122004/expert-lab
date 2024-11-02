using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    GameObject player;
    string nextLevel;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Debug.Log("Player found: " + player.name);
        }

        nextLevel = GameObject.FindWithTag("NextLevel").name;
        if (nextLevel != null)
        {
            Debug.Log("Next scene name found: " + nextLevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject == player)
        {
            Debug.Log("Next scene loaded: " + nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
