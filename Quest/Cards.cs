using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Cards : MonoBehaviour
{
    public SO_Cards _SOCards;
    public GroupInformation _GroupInformation;
    private GameManager _gameManager;
    [Header("BalancetheGame")]
    public float _ModificateurNumberParty;
    public float _ModificateurLevelParty;
    public float _ModificateurRequiredClass;
    public float _BaseSucces;

    

    [Header("Parameters Cards")]
    public TextMeshProUGUI _QuestNames;
    public TextMeshProUGUI _LevelQuest;
    public TextMeshProUGUI _NumberOfTheParty;
    public List<Image> _ThePartyImages;
    private List<Sprite> _SpritesOfClass;

    private List<string> _ClassRequire;


    public TextMeshProUGUI _QuestGoldRewards;
    public TextMeshProUGUI _SuccesRate;
    public TextMeshProUGUI _PriceForTheGroupe;

    public TextMeshProUGUI _QuestReputationRewards;
    [Header("ToPass")]
    public float _MultiplierSize;
    public float _HeightForTheCards;
    private Transform _InitialPosition;

    public GameObject Grouptest;
    private float CurrentValue;
    private Vector3 OriginalScale;
    private DrawCards _ScriptDrawCards;
    private int SuccesRate;
    private int GoldToPay;
    private int GoldQuest;
    private int WinReput;
    //  public Transform _PositionToHave;
    private void Start()
    {
        OriginalScale = transform.localScale;
        _QuestNames.text = _SOCards._Questname;
        _LevelQuest.text = _SOCards._LevelQuest.ToString();
        _NumberOfTheParty.text = _SOCards._NumberOfTheParty.ToString();
        _ClassRequire = new List<string>();

        foreach (var item in _SOCards._Classrequire)
        {
            _ClassRequire.Add(item);
        }
        //  _QuestReputationRewards.text = _SOCards._QuestReputationRewards.ToString();
        //  _QuestGoldRewards.text = _SOCards._QuestGoldRewards.ToString();
        float Gold = _SOCards._LevelQuest * 100;
        float Reputation = Gold / 2;

        int FinalReputation = (int) Mathf.Round(Random.Range(Reputation, Reputation * 1.5f));
        int FinalGold = (int)Mathf.Round(Random.Range(Gold*1.1f, Gold * 1.2f));
        GoldQuest = FinalGold;
        WinReput = FinalReputation;
        _QuestReputationRewards.text = FinalReputation.ToString();

        _QuestGoldRewards.text = FinalGold.ToString();
        _SpritesOfClass = new List<Sprite>();
        //_PriceForTheGroupe.text = "lol";
       // GroupInformation scriptinfo = Grouptest.GetComponent<GroupInformation>();
        //InitializeCards(scriptinfo._GroupCount, scriptinfo._GroupLevel, scriptinfo._GroupsClass);
      /*  foreach (var item in _SOCards._SpritesOfClass)
        {
            _SpritesOfClass.Add(item);
        }
        for (int i = 0; i < _ThePartyImages.Count; i++)
        {
            if (_SpritesOfClass.Count == 0)
            {
                return;
            }
            if (_SpritesOfClass[i] == null)
            {
                return;
            }
            else
            {
                _ThePartyImages[i].sprite = _SpritesOfClass[i];
            }

        }*/


    }
    public void GiveMeInformation(DrawCards Script,GameManager GameManager)
    {
        _gameManager = GameManager;
        _ScriptDrawCards = Script;
    }
    public void InitilizePosition(Transform position)
    {
        _InitialPosition = position;
    }

    public void ActiveTheCard()
    {
        if (_ScriptDrawCards._CanILaunch && Time.timeScale==1)
        {
            transform.localScale *= _MultiplierSize;
            // transform.position = _PositionToHave.position;
            // transform.position = _InitialPosition.position + Vector3.up * 100;
            transform.position += Vector3.up * _HeightForTheCards;
          //  Debug.Log("Pass");
        }
        
    }
    public void DesactiveCard()
    {
        transform.localScale = OriginalScale;
        transform.position = _InitialPosition.position;
        // transform.position -= Vector3.up * _HeightForTheCards;
      //  Debug.Log("Pass");
    }

    public void InitializeCards(float NumberOfTheGroup, float LevelOfTheGroupe, List<string> NameOfTheGroup)
    {
        _PriceForTheGroupe.text = (LevelOfTheGroupe * 100).ToString();
        GoldToPay =(int) (LevelOfTheGroupe * 100);
        float SuccesBase = _BaseSucces + RequireNumber(NumberOfTheGroup) + RequireLevel(LevelOfTheGroupe) + RequireClass(NameOfTheGroup);
        SuccesRate =(int) SuccesBase;
        _SuccesRate.text = SuccesBase.ToString();

    }

    public void LaunchCards()
    {
        if (_ScriptDrawCards._CanILaunch && Time.timeScale == 1)
        {
            Destroy(this.gameObject);
            _ScriptDrawCards.AddNumber();
            _gameManager.UseThisCard(SuccesRate,GoldToPay/2, GoldQuest, WinReput);
            _ScriptDrawCards._CanILaunch = false;   
        }
      
    }


    #region Change The Succes and the Prince Number
    public float RequireNumber(float NumberOfTheGroup)
    {
        float Pourcentage = NumberOfTheGroup - _SOCards._NumberOfTheParty;
        Pourcentage *= _ModificateurNumberParty;
        return Pourcentage;
    }

    public float RequireLevel(float LevelGroup)
    {
        float Pourcentage = LevelGroup - _SOCards._LevelQuest;
        Pourcentage *= _ModificateurLevelParty;
        return Pourcentage;
    }

    private float LookIfIhaveSomething(string item, List<string> NameOfTheGroupe)
    {
        for (int i = 0; i < NameOfTheGroupe.Count; i++)
        {
            if (item == NameOfTheGroupe[i])
            {

                return 0;
            }


        }
        return _ModificateurRequiredClass;
    }
    public float RequireClass(List<string> NameOfTheGroupe)
    {
        float Pourcentage = 0;
        foreach (var item in _ClassRequire)
        {
            Pourcentage -= LookIfIhaveSomething(item, NameOfTheGroupe);
        }
       // Debug.Log(Pourcentage);
        return Pourcentage;
    }
    #endregion  
}
