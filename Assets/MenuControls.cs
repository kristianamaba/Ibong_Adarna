using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{

    public AudioSource bgM;
    public Button soundB;
    public Sprite soundOn, soundOff;



    public void returnToStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void MusicB() {
        PlayerPrefs.SetInt("BGM", (PlayerPrefs.GetInt("BGM", 1) == 1 ? 0 : 1));
        MusicOnOff();
    }

    void MusicOnOff() {
        if (PlayerPrefs.GetInt("BGM", 1) == 1){
            soundB.GetComponent<Image>().sprite = soundOn;
            playBGM(true);
        }
        else {
            soundB.GetComponent<Image>().sprite = soundOff;
            playBGM(false);
        }

       
    }

    void Start() {
        int n = PlayerPrefs.GetInt("level", 1);
        PlayerPrefs.SetInt("currentlevel", (n >= 10 ? 10 : n));
        MusicOnOff();


    }

    void playBGM(bool b) {
        if (b)
        {
            bgM.loop = true;
            bgM.Play();
        }
        else
            bgM.Stop();
    }



    public void goToQuiz()
    {
        if (PlayerPrefs.GetInt("level", 1) >= getTarget())
        {
            SceneManager.LoadScene("Quiz");
        }
        else {
            unlockF(true);
            Debug.Log("UNlock level first");
        }
            
    }

    public static void unlockF(bool b)
    {
        GameObject.Find("unlockFirstP").gameObject.transform.localScale = (b == true ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0));
    }

    public void Next() {
        int n = getTarget();
        if (n+1 > PlayerPrefs.GetInt("level", 1))
            unlockF(true);
        setTarget((n >= 10 ? 10 : n+1));
    }

    public void Prev()
    {
        int n = getTarget();
        if (n-1 <= PlayerPrefs.GetInt("level", 1))
             unlockF(false);
        
        setTarget((n <= 1 ? 1 : n - 1));
    }

    public void setTarget(int i)
    {
        PlayerPrefs.SetInt("currentlevel", i);
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().CTarget = i;
    }

    public int getTarget()
    {
        return GameObject.Find("Main Camera").GetComponent<CameraMovement>().CTarget;
    }


}
