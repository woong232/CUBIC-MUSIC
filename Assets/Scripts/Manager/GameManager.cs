﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
    public static GameManager instance;

    ComboManager theCombo;
    ScoreManager theScore;
    TimingManager theTiming;
    StatusManager theStatus;
    PlayerController thePlayer;
    StageManager theStage;
    NoteManager theNote;
    Result theResult;
    [SerializeField] CenterFlame theMusic = null; // 처음 비활성화 되어 있는 오브젝트라서 인스펙터 창에서 설정
    
    public bool isStartGame = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theNote = FindObjectOfType<NoteManager>();
        theCombo = FindObjectOfType<ComboManager>();
        theScore = FindObjectOfType<ScoreManager>();
        theTiming = FindObjectOfType<TimingManager>();
        theStatus = FindObjectOfType<StatusManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        theStage = FindObjectOfType<StageManager>();
        theResult = FindObjectOfType<Result>();
    }

    public void GameStart(int p_songNum, int p_bpm)
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
        theMusic.bgmName = "BGM" + p_songNum;
        theNote.bpm = p_bpm;
        theStage.RemoveStage();
        theStage.SettingStage(p_songNum);
        theCombo.ResetCombo();
        theScore.Initialized();
        theTiming.Initialized();
        theStatus.Initialized();
        thePlayer.Initialized();
        theResult.SetCurrentSong(p_songNum);
        AudioManager.instance.StopBGM();

        isStartGame = true;
    }

    public void MainMenu()
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);
    }
}
