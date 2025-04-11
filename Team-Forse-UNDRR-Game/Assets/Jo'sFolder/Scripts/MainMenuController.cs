using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] slides;
    private int slideIndex;

    //          SCENE STUFF HERE

    public void GoToStartGame()
    {
        SceneManager.LoadScene("TJ Scene");
    }



    //          TUTORIAL STUFF HERE

    //loads slide 1
    public void LoadTutorialSlides()
    {
        foreach (GameObject slide in slides)
        {
            slide.SetActive(false);
        }
        slides[0].SetActive(true);
        slideIndex = 0;
    }
    /// <summary>
    /// Changes slide, goNextSlide checked for positive increase on array index
    /// </summary>
    /// <param name="goNextSlide"></param>
    public void ChangeSlide(bool goNextSlide)
    {
        if (goNextSlide)
        {
            slides[slideIndex].SetActive(false);
            if (slideIndex == 3)
            {
                slideIndex = 0;
            }
            else
            {
                slideIndex++;
            }
            slides[slideIndex].SetActive(true);
        }
        else
        {
            slides[slideIndex].SetActive(false);
            if (slideIndex == 0)
            {
                slideIndex = 3;
            }
            else
            {
                slideIndex--;
            }
            slides[slideIndex].SetActive(true);
        }
    }
}
