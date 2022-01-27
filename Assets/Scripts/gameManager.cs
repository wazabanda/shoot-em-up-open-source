using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool paused = false, canBePaused = true;
    public Animator Transition;
    public string trigger;
    public float transitionTime;
    private void Awake()
    {
        paused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            reload();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;

            loadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.P) && canBePaused)
        {
            if (paused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
            paused = !paused;
        }
    }
    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void loadScene(int scene)
    {
        StartCoroutine(transition(scene));
    }

    IEnumerator transition(int index)
    {
        Transition?.SetTrigger(trigger);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }

    public  void quit()
    {
        Application.Quit();
    }
}
