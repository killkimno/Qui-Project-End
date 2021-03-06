﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {


    public UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject endVideoObject;
    public GameObject uiObject;
    public GameObject closeButton;

    public List<GameObject> winnerIconList = new List<GameObject>();

    public List<UILabel> scoreLabelList1 = new List<UILabel>();
    public List<UILabel> scoreLabelList2 = new List<UILabel>();
    public List<UILabel> scoreLabelList3 = new List<UILabel>();
    public List<UILabel> scoreLabelList4 = new List<UILabel>();
    public List<UILabel> scoreLabelList5 = new List<UILabel>();
    public List<UILabel> scoreLabelList6 = new List<UILabel>();


    public List<UILabel> resultScoreLabelList = new List<UILabel>();
    public List<int> totalScoreList = new List<int>();

    private List<List<int>> scoreList = new List<List<int>>();


    private List<List<UILabel>> totalLabelList = new List<List<UILabel>>();
    public void Show(List<QuizSlot> slotList, bool isResult)
    {
        if(this.gameObject.activeSelf)
        {
            return;
        }

        closeButton.SetActive(true);
        this.gameObject.SetActive(true);
        uiObject.SetActive(true);
        endVideoObject.SetActive(false);
        totalLabelList.Clear();

        totalLabelList.Add(scoreLabelList1);
        totalLabelList.Add(scoreLabelList2);
        totalLabelList.Add(scoreLabelList3);
        totalLabelList.Add(scoreLabelList4);
        totalLabelList.Add(scoreLabelList5);
        totalLabelList.Add(scoreLabelList6);

        scoreList.Clear();

        for(int i = 0; i < 6; i++)
        {
            scoreList.Add(new List<int>());
        }

       

        for(int i = 0; i < totalScoreList.Count;i++)
        {
            totalScoreList[i] = 0;
        }

        for(int i = 0; i < totalLabelList.Count; i++)
        {
            for(int j = 0; j  < totalLabelList[i].Count; j++)
            {
                totalLabelList[i][j].text = "";
            }
        }

        for(int i = 0; i < slotList.Count; i++)
        {
            for(int j = 0; j < slotList[i].answerList.Count; j++)
            {
                if(slotList[i].answerList[j])
                {
                    totalScoreList[j] = totalScoreList[j] + slotList[i].score;
                    scoreList[j].Add(slotList[i].score);
                }
            }
        }

        for(int i = 0; i < scoreList.Count; i++)
        {
            for(int j = 0; j < scoreList[i].Count; j++)
            {
                if(totalLabelList[i].Count > j)
                {
                    totalLabelList[i][j].text = "+" + scoreList[i][j].ToString();
                }
                else
                {
                    totalLabelList[i][totalLabelList[i].Count -1].text = "...";
                }
            }
        }


        for(int i = 0; i < resultScoreLabelList.Count; i++)
        {
            resultScoreLabelList[i].text = totalScoreList[i].ToString();
        }

        for (int i = 0; i < winnerIconList.Count; i++)
        {
            winnerIconList[i].SetActive(false);
        }

        if(isResult)
        {
            closeButton.SetActive(false);
            uiObject.SetActive(false);
            int highScoreIndex = -1;
            int highScore = 0;

            for(int i = 0; i < totalScoreList.Count; i++)
            {
                if(highScore < totalScoreList[i])
                {
                    highScoreIndex = i;
                    highScore = totalScoreList[i];
                }
            }

            if(highScoreIndex != -1)
            {
                winnerIconList[highScoreIndex].SetActive(true);
            }

            endVideoObject.SetActive(true);
            videoPlayer.loopPointReached += EndReached;

        }

    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(ProcessEndVideo());
    }

    IEnumerator ProcessEndVideo()
    {
        yield return null;
        yield return null;
        endVideoObject.SetActive(false);
        uiObject.SetActive(true);

    }

    public void ClickClose()
    {
        this.gameObject.SetActive(false);
    }

    public void ClickCloseVideo()
    {
        //endVideoObject.SetActive(false);
        //uiObject.SetActive(true);
    }
}
