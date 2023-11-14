using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupe : MonoBehaviour
{
    public GameManager _GameManager;

    public List<GameObject> group;
    public Transform spawn;

    public float _MaxGroupDay;
    private List<GameObject> _groups = new List<GameObject>();
    public Transform _Bar;
    public Transform _Start;
    public Transform _Intermediate;
    public Transform _Intermediate2;
    public Transform _End;
    
    public bool _IsBefore3Day;
    public bool _IsBefore6Day;
    public bool _IsBefore9Day;
    public bool _IsBefore12Day;

    private Coroutine _Coroutine;
    void Start()
    {
       
       
    }

    
    void Update()
    {
        
    }
    IEnumerator TimerBeforeSpawning(float Time)
    {
        yield return new WaitForSecondsRealtime(Time);
        GameObject prefab = Instantiate(group[Random.Range(0, group.Count)], spawn.position, Quaternion.identity);
        GroupInformation scriptPrefab = prefab.GetComponent<GroupInformation>();
        groupedisplacement groupedisplacementscript = prefab.GetComponent<groupedisplacement>();
        groupedisplacementscript.GiveInformation(_Bar, _Start, _Intermediate, _End, _GameManager,_Intermediate2);
        _GameManager.GiveInformationonthegroup(prefab);
        if (_IsBefore3Day)
        {
            scriptPrefab._GroupLevel = Random.Range(1, 5);

        }

        if (_IsBefore6Day)
        {
            scriptPrefab._GroupLevel = Random.Range(3, 7);

        }
        if (_IsBefore9Day)
        {
            scriptPrefab._GroupLevel = Random.Range(5, 9);

        }
        if (_IsBefore12Day)
        {
            scriptPrefab._GroupLevel = Random.Range(6, 10);

        }
        _Coroutine = null;
    }

    public void ChangeDay(int day)
    {
        if (day > 12)
        {
            // EndGame
            // Calcul du score
            return;
        }
        if (day > 9)
        {
            _IsBefore9Day = false;
            _IsBefore12Day = true;
            return;
        }
        if (day > 6)
        {
            _IsBefore6Day = false;
            _IsBefore9Day = true;
            return;
        }

        if (day > 3)
        {
            _IsBefore3Day = false;
            _IsBefore6Day = true;
            return;

        }
    }
    public void SpawnGroupe()
    {
        // Instantiate(group[Random.Range(0, group.Count)], spawn.position, Quaternion.identity);
       if (!_GameManager._IsAnyoneToTheQuest)
        {
            _Coroutine = StartCoroutine(TimerBeforeSpawning(1));
        }
        
    }
}
