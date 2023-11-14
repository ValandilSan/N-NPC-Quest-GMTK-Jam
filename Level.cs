using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string m_class;
    public int m_Level;
    public int m_LevelMin;
    public int m_LevelMax;

    public int m_price;

    void Start()
    {
        m_LevelMax = 10; // 1 à 9 tkt
        m_LevelMin = 1 ;
    }

    void OnEnable()
    {
        m_Level = Random.Range(m_LevelMin, m_LevelMax);
    }

    void Update()
    {
        m_price = 100 * m_Level;   // valuer a récup ici
    }
}
