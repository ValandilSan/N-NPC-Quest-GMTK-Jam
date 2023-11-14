using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reputation : MonoBehaviour
{

    public ResumeManager _ResumeManager;
    //public int m_reputationMax;
    private int m_reputationMin;
    public int _BaseReputation;
    private int _KeepTheReputation;
    //public int m_reputationOfQuest;
    // Start is called before the first frame update
    void Start()
    {
        m_reputationMin = 0;
      _KeepTheReputation = 0;
    }

    
    void Update()
    {
        
    }

    public void AddReputation(int Reput)
    {
       _KeepTheReputation += Reput;
    }
    public void LessReputation(int Reput)
    {
       _KeepTheReputation -= Reput;
        
    }

    public void MathReputation()
    {
        _BaseReputation += _KeepTheReputation;
        if (_BaseReputation < 0)
        {
            //Lose
        }else
        {
            _KeepTheReputation = 0;
        }
    }
}
