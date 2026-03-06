using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int threeStars = 3;
    public int twoStars = 5;
    public Text scoreDisplay;
    public Animator scoreAnimator;
    public int nextLevel = 0;

    public void EndLevel()
    {
        Cannon cannon = FindAnyObjectByType<Cannon>();
        Debug.Log(cannon);
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;

            if (numProjectiles < threeStars)
            {
                scoreDisplay.text = "Three Stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles < twoStars)
            {
                scoreDisplay.text = "Two Stars!";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else
            {
                scoreDisplay.text = "One Star!";
                scoreAnimator.SetInteger("Stars", 1);
            }

            Invoke("LoadNextSceneInBuild",2);
        }
    }

    //void NextLevel()
    //{
    //    SceneManager.LoadScene(nextLevel);
    //}
    public void LoadNextSceneInBuild()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
