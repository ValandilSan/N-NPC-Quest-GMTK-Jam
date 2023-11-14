using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameManager _GameManager; 


    public List<Transform> _CardsPosition;
  public  List<GameObject> _CardsInPosition;
    public Transform _Canvas;
    [Header("Mission < 3 day")]
    public List<GameObject> _CardsBeforeday3;


    [Header("Mission < 6 day")]
    public List<GameObject> _CardsBeforeDay6;

    [Header("Mission < 9 day")]
    public List<GameObject> _CardsBeforeDay9;

    [Header("Mission < Last Day")]
    public List<GameObject> _CardsBeforeDay12;

    public bool _IsBefore3Day;
    public bool _IsBefore6Day;
    public bool _IsBefore9Day;
    public bool _IsBefore12Day;



    public bool _CanILaunch;
    public float _TimeBeforeTheNextGroup;
    private float _TimeBeforeNextDraw;
    private float _TimerBeforeNextMission;
    void Start()
    {

        _CardsInPosition.Capacity = 5;
       // _CanILaunch = true;
        InitializeCards();
    }
    IEnumerator TimerBetweenCard(float timer, int index, List<GameObject> ListDayQuest)
    {
        yield return new WaitForSeconds(timer/2);
        GameObject PrefabCard = Instantiate(ListDayQuest[Random.Range(0, ListDayQuest.Count)], _CardsPosition[index].position, Quaternion.identity, _Canvas);
        Cards ScriptCard = PrefabCard.GetComponent<Cards>();

        ScriptCard.InitilizePosition(_CardsPosition[index]);
        _CardsInPosition[index] = PrefabCard;
        ScriptCard.GiveMeInformation(this.GetComponent<DrawCards>(),_GameManager);
    }
    
    public void InitializeCards()
    {
       
        
        for (int i = 0; i < _CardsPosition.Count; i++)
        {
            if (_CardsInPosition[i] == null && _IsBefore3Day)
            {
             StartCoroutine(TimerBetweenCard(i, i, _CardsBeforeday3));
                
            }
            if (_CardsInPosition[i] == null && _IsBefore6Day)
            {
                /*GameObject PrefabCard = Instantiate(_CardsBeforeDay6[Random.Range(0, _CardsBeforeDay6.Count)], _CardsPosition[i].position, Quaternion.identity, _Canvas);
                Cards ScriptCard = PrefabCard.GetComponent<Cards>();
                ScriptCard.InitilizePosition(_CardsPosition[i]);
                _CardsInPosition[i] = PrefabCard;
                ScriptCard.GiveMeInformation(this.GetComponent<DrawCards>());*/
                StartCoroutine(TimerBetweenCard(i, i,_CardsBeforeDay6));
            }
            if (_CardsInPosition[i] == null && _IsBefore9Day)
            {
                StartCoroutine(TimerBetweenCard(i, i, _CardsBeforeDay9));
                /* GameObject PrefabCard = Instantiate(_CardsBeforeDay9[Random.Range(0, _CardsBeforeDay9.Count)], _CardsPosition[i].position, Quaternion.identity, _Canvas);
                 Cards ScriptCard = PrefabCard.GetComponent<Cards>();
                 ScriptCard.InitilizePosition(_CardsPosition[i]);
                 _CardsInPosition[i] = PrefabCard;
                 ScriptCard.GiveMeInformation(this.GetComponent<DrawCards>());*/
            }
            if (_CardsInPosition[i] == null && _IsBefore12Day)
            {
                StartCoroutine(TimerBetweenCard(i, i, _CardsBeforeDay12));
                /* GameObject PrefabCard = Instantiate(_CardsBeforeDay12[Random.Range(0, _CardsBeforeDay12.Count)], _CardsPosition[i].position, Quaternion.identity, _Canvas);
                 Cards ScriptCard = PrefabCard.GetComponent<Cards>();
                 ScriptCard.InitilizePosition(_CardsPosition[i]);
                 _CardsInPosition[i] = PrefabCard;
                 ScriptCard.GiveMeInformation(this.GetComponent<DrawCards>());*/
            }
        }


    }


   
    IEnumerator TimerForNewCards()
    {
       /* if (_TimerBeforeNextMission == 3)
        {
            

           
            _TimerBeforeNextMission = 0;
        }*/
        yield return new WaitForSecondsRealtime(_TimeBeforeTheNextGroup*2);
        
        InitializeCards();
      //  _CanILaunch = true;
    }

    public void Reinitializethehand()
    {
      //  StartCoroutine(TimerForNewCards());
    }
    public void AddNumber()
    {

       /* _TimeBeforeNextDraw++;
        if (_TimeBeforeNextDraw == 3)
        {
            _TimeBeforeNextDraw = 0;
            _TimerBeforeNextMission++;
            
            return;
        }
        StartCoroutine(Timer());*/
        
    }
    public void ChangeDay(int day)
    {
        if (day>12)
        {
            // EndGame
            // Calcul du score
            return;
        }
        if (day>9)
        {
            _IsBefore9Day = false;
            _IsBefore12Day = true;
            return;
        }
        if (day>6)
        {
            _IsBefore6Day = false;
            _IsBefore9Day = true;
            return;
        }

        if (day >3)
        {
            _IsBefore3Day = false;
            _IsBefore6Day = true;
            return;

        }
    }
    void Update()
    {
        
    }
}
