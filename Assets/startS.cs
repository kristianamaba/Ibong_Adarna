using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startS : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void purposeClick() {
        purposeShow(true);
    }

    public void purposeClose()
    {
        purposeShow(false);
    }

    public static void purposeShow(bool b)
    {
        GameObject.Find("purposeP").gameObject.transform.localScale = (b == true ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0));
    }


}
