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
        Debug.Log("score endlevel");
        Cannon cannon = FindAnyObjectByType<Cannon>();
        Debug.Log(cannon);
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;
            Debug.Log("CANNON");

            if (numProjectiles < threeStars)
            {
                Debug.Log("THREESTARS");
                scoreDisplay.text = "Three Stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles < twoStars)
            {
                Debug.Log("2STARS");
                scoreDisplay.text = "Two Stars!";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else
            {
                Debug.Log("1STARS");
                scoreDisplay.text = "One Star!";
                scoreAnimator.SetInteger("Stars", 1);
            }

            Invoke("NextLevel",2);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
