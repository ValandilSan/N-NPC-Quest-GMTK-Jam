using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupedisplacement : MonoBehaviour
{
    private GroupInformation _GroupInformation;
    private GameManager _GameManager;
    private Transform _Bar;
    private Transform _Start;
    private Transform _Intermediate, _Intermediate2;
    private Transform _End;
    public float _Speed;
    public float _SpeedRotation;

    public List<Animator> _AnimatorList;

    public bool goOnQuest;
    public bool onEnable;
    public bool onEnable1;
    public bool _IsOnTheQuest;
    public bool gotobar;
    public bool _IsWaitingforaquest;
    private Vector3 _InitialPos;
    private bool _GiveInformationForRewards;
    void Start()
    {
        _GiveInformationForRewards = true;
        _GroupInformation = this.GetComponent<GroupInformation>();
       
        goOnQuest = false;
        onEnable = false;
        _IsWaitingforaquest = false;
        gameObject.transform.Rotate(Vector3.up * 90);
        _InitialPos =new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
        foreach (var item in _AnimatorList)
        {
            item.SetBool("Walk", true);

        }
    }
    public void GiveInformation(Transform bar, Transform Start, Transform Intermediate, Transform end, GameManager gameManager, Transform Intermediaire2)
    {
        _Bar = bar;
        _Start = Start; 
        _Intermediate = Intermediate;
        _End = end;
        _GameManager = gameManager;
        _Intermediate2 = Intermediaire2;
    }
    void Update()
    {
        
        if (!_IsOnTheQuest)
        {
            if (onEnable == false && _Intermediate !=null)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _Intermediate.position, _Speed * Time.deltaTime);
             
            }
            if (gameObject.transform.position == _Intermediate.position && onEnable == false)
            {
                
               
                gotobar = true;
                onEnable = true;
            }
            if (gotobar == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _Bar.position, _Speed * Time.deltaTime);
                _InitialPos = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                transform.Rotate(Vector3.Lerp(_InitialPos, Vector3.up * -90, Time.deltaTime * 1.35f));
            }
            if (gameObject.transform.position == _Bar.position && gotobar == true)
            {
                _IsWaitingforaquest = true;
                gotobar = false;
                foreach (var item in _AnimatorList)
                {
                    item.SetBool("Walk", false);
                    
                }
            }
            if (goOnQuest == true)
            {
                foreach (var item in _AnimatorList)
                {
                    item.SetBool("Walk", true);

                }
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _Intermediate2.position, _Speed * Time.deltaTime);
                _InitialPos = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                transform.Rotate(Vector3.Lerp(_InitialPos, Vector3.up * 90, Time.deltaTime * 1.25f));
            }
            if (gameObject.transform.position == _Intermediate2.position)
            {
                onEnable1 = true;
                goOnQuest = false;
            }
            if (onEnable1 == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _End.position, _Speed * Time.deltaTime);
                
            }
            if (transform.position == _End.position)
            {
               
                _IsOnTheQuest = true;
                GiveInformForReward();
            }
        }
     

    }
    public void GiveInformForReward()
    {
        if (_GiveInformationForRewards)
        {_GiveInformationForRewards = false;
            _GroupInformation.LookIfWeSucces(_GameManager);

        }
    }

    public void HaveAQuest()
    {
        goOnQuest = true;
    }
}
