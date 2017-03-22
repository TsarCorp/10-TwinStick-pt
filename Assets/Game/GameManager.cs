using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class GameManager : MonoBehaviour
{

    public static bool Recording;
    public static bool isPaused = false;
    private float InitialfixedDeltaTime;

    // Use this for initialization
    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        InitialfixedDeltaTime = Time.fixedDeltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            Recording = false;
        }
        else
        {
            Recording = true;
        };

        if (Input.GetKeyDown (KeyCode.P) && !isPaused) {
            Paused();


        } else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            unPaused();
        };
    }

    public void Paused() {
        isPaused = true;
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    public void unPaused()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = InitialfixedDeltaTime;
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    } 


}
