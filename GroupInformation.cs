using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupInformation: MonoBehaviour
{
    public int _GroupLevel;
    public List<string> _GroupsClass = new List<string>();
    public int _GroupCount;
    public int _QuestRewards;
    private groupedisplacement _groupDisplacement;
    public int _SuccessRate;
    public int _GoldRate;
    public int _RewardsReput;
    private void Start()
    {
        _groupDisplacement = this.GetComponent<groupedisplacement>();
        _GroupCount = _GroupsClass.Count;   
    }


    public void LookIfWeSucces(GameManager gameManager)
    {
        int SuccesOrNot = Random.Range(0,101);
        Debug.Log(SuccesOrNot);
        if (SuccesOrNot < _SuccessRate)
        {
            gameManager.GoldLose(_GoldRate);
            gameManager.GoldWin(_QuestRewards);
            gameManager.ReputWin(_RewardsReput);

        } else
        {
            gameManager.GoldLose(0);    
            gameManager.GoldWin(0);
            gameManager.ReputLose(_RewardsReput);
            return;
        }

    }

}
