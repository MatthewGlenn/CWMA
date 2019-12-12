﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioEventHandler : MonoBehaviour
{
    public AudioManager amPrefab;

    private AudioManager am;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        if (am == null)
        {
            am = Instantiate(amPrefab);
            am.name = "AudioManager";
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("Pause", Pause);
        EventManager.StartListening("Unpause", Unpause);
        EventManager.StartListening("SceneChange", SceneChange);

        if (SceneManager.GetActiveScene().name == "02_1stCar")
        {
            Setup_1stCar();
        }
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "03_Theater")
        {
            Setup_Theater();
        }
        if (SceneManager.GetActiveScene().name == "04_2ndCar")
        {
            Setup_2ndCar();
        }
        if (SceneManager.GetActiveScene().name == "05_Resturant")
        {
            Setup_Resturant();
        }
        if (SceneManager.GetActiveScene().name == "06_Ending_SecondDate")
        {
            Setup_SecondDate();
        }
        if (SceneManager.GetActiveScene().name == "07_Ending_Jordy")
        {
            Setup_Jordy();
        }
        if (SceneManager.GetActiveScene().name == "08_Ending_Alone")
        {
            Setup_Alone();
        }
    }

    void OnDisable()
    {
        EventManager.StopListening("Pause", Pause);
        EventManager.StopListening("Unpause", Unpause);
        EventManager.StopListening("Car_go", Car_go);
        EventManager.StopListening("Car_stop", Car_stop);
        EventManager.StopListening("EnterBrainRoom", EnterBrainRoom);
        EventManager.StopListening("ExitBrainRoom", ExitBrainRoom);
        EventManager.StopListening("brainOpen", BrainOpen);
        EventManager.StopListening("brainClose", BrainClose);
    }

    private void Setup_1stCar()
    {
        am.FadeInSFX("car_loop");
        EventManager.StartListening("Car_go", Car_go);
        EventManager.StartListening("Car_stop", Car_stop);
        EventManager.StartListening("EnterBrainRoom", EnterBrainRoom);
        EventManager.StartListening("ExitBrainRoom", ExitBrainRoom);
        EventManager.StartListening("brainOpen", BrainOpen);
        EventManager.StartListening("brainClose", BrainClose);
    }

    private void Setup_Theater()
    {
        am.FadeInSFX("theater_lobby_loop");
    }

    private void Setup_2ndCar()
    {
        am.FadeInSFX("car_loop");
        EventManager.StartListening("Car_go", Car_go);
        EventManager.StartListening("Car_stop", Car_stop);
        EventManager.StartListening("EnterBrainRoom", EnterBrainRoom);
        EventManager.StartListening("ExitBrainRoom", ExitBrainRoom);
        EventManager.StartListening("brainOpen", BrainOpen);
        EventManager.StartListening("brainClose", BrainClose);
    }

    private void Setup_Alone()
    {
    }

    private void Setup_Jordy()
    {
    }

    private void Setup_SecondDate()
    {
    }

    private void Setup_Resturant()
    {
        am.FadeInSFX("restaurant_loop");
    }

    private void SceneChange()
    {
        am.SceneEnd();
    }

    private void Car_go()
    {
        am.PlayFX("car_go");
        am.FadeInSFX("car_loop");
    }

    private void Car_stop()
    {
        am.PlayFX("car_slowdown");
        am.FadeOutSFX("car_loop");
    }

    private void BrainOpen()
    {
        am.Play("brain_open");
    }
    private void BrainClose()
    {
        am.Play("brain_close");
    }

    private void EnterBrainRoom()
    {
        am.SetBrainroomSnapshot(true, 2f);
        am.SetSourceOutput("blip", "Headroom");
    }
    private void ExitBrainRoom()
    {
        am.SetBrainroomSnapshot(false, 2f);
        am.SetSourceOutput("blip", "SFX");
    }

    private void Pause()
    {
        AudioListener.pause = true;
        am.Play("pause");
        am.PlayMusic("PauseMusic");
    }

    private void Unpause()
    {
        AudioListener.pause = false;
        am.Stop("PauseMusic");
        
    }


}