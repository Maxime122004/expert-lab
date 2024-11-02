using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    GameObject player;
    string nextLevel;
    [SerializeField] Animator transitionAnim;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        nextLevel = GameObject.FindWithTag("NextLevel").name;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            transitionAnim.SetTrigger("End");
            StartCoroutine(LoadNextSceneAfterDelay(1f)); // Start a coroutine with a 1-second delay
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(nextLevel);
        transitionAnim.SetTrigger("Start"); // Optionally trigger the "Start" animation after loading the scene
    }


}
