using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Adventurier", menuName = "Adventurier")]

public class Adventurer : ScriptableObject
{
   public string m_type;
   public GameObject m_prefabs;
}
