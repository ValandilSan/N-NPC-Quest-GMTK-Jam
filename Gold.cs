using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int _TotalTreasure;
    public ResumeManager _ResumeManager;
    //public int _Rewards;
    private List<int> _ListOfPayement;
    private List<int> _ListOfRewards;
    private int _TotelRent;
   // public int m_payment;
    void Start()
    {
        _ListOfPayement = new List<int>();
        _ListOfRewards = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NumberToPay(int Payement)
    {
        _ListOfPayement.Add(Payement);
        _ResumeManager.InformationForTheList(Payement);
    }
    public void NumberToRewards(int Rewards)
    {
        _ListOfRewards.Add(Rewards);
        _ResumeManager.InformationReward(Rewards);
    }

    public void GoldRecoverQuest()
    {
        //_TotalTreasure = _TotalTreasure + _Rewards;
    }
    public void PaymentAdventure()
    {
        /* if (m_tresure >= Payement)
         {
             m_tresure = m_tresure - Payement;
         }
         if (m_tresure < Payement)
         {
             // you lose
         }*/

        for (int i = 0; i < _ListOfPayement.Count; i++)
        {
            if (_ListOfPayement[i]>  0) 
            {
                _TotalTreasure -= _ListOfPayement[i];
                _TotalTreasure += _ListOfRewards[i];
                _TotelRent = _TotalTreasure;
                _ResumeManager.InfoTotalGold(_TotelRent);
               
            }
                
            
            
        }
    }

    public void ClearTheList()
    {
        _ListOfPayement.Clear();
        _ListOfRewards.Clear();
    }
}
