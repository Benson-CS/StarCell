using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowingTitleScreen : MonoBehaviour
{
    public void GoToMenu()
    {   
        Debug.Log("testing that it was sent to new script");
        SceneManager.LoadScene("titleMenuTest");
    }
}
