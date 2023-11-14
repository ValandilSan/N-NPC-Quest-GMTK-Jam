using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest", menuName = "Quest")]
public class SO_Cards : ScriptableObject
{
    public string _Questname;

    [Range(0,9)]
    public int _LevelQuest;
    [Range(1,4)]
    public int _NumberOfTheParty;

    public List<Sprite> _SpritesOfClass;
    public List<string> _Classrequire;
    //public int _QuestGoldRewards;
    //public int _QuestReputationRewards;


}
