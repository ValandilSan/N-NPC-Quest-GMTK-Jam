using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject m_canvasPause;
    [SerializeField] private GameObject m_canvasResume;
    [SerializeField] private GameObject m_canvasLose;
    [SerializeField] private GameObject _CanvasCredit;
    public GameObject _CanvasWin;
    public TextMeshProUGUI _ScoringLose;
    public TextMeshProUGUI _NotationLose;

    public TextMeshProUGUI _ScoringWin;
    public TextMeshProUGUI _NotationWin;

    public LosePartie _LosePartie;
    public Gold _Gold;
    public reputation _Reputation;
    public GameManager _gameManager;
    public int _CurrentGold;
    public int _CurrentRep;

    public TextMeshProUGUI _CurrentHUDGold;
    public TextMeshProUGUI _CurrentHUDRep;
    private bool m_pause;
    private float _FinalScoring;
    private string _FinalNotation;
    void Start()
    {
        m_pause = false;
        _FinalScoring = 0.0f;
    }

    void OnEnable()
    {
        m_pause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            m_pause = !m_pause;
            if (m_pause == true)
            {
                PauseTime();
                m_canvasPause.SetActive(true);
            }
            if (m_pause == false)
            {
                NormalTime();
                if (m_canvasPause != null)
                {
                    m_canvasPause.SetActive(false);
                }


            }

        }
      
        if (_Gold != null)
        {
            _CurrentGold = _Gold._TotalTreasure;
            _CurrentHUDGold.text = _CurrentGold.ToString();
        }
        if (_Reputation != null)
        {
            _CurrentRep = _Reputation._BaseReputation;

            _CurrentHUDRep.text = _CurrentRep.ToString();
        }

    }
    public void Resume()
    {
        m_pause = !m_pause;
        m_canvasPause.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void PlayGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(1);
    }

    public void AppQuit()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(0);
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    public void NormalTime()
    {
        Time.timeScale = 1;
    }
    public void NextDay()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        if (m_canvasResume != null)
        {
            m_canvasResume.SetActive(false);
        }
        if (_gameManager._Day > 12)
        {
            if (_CurrentGold <= 0 || _CurrentRep <= 0)
            {
                NotationForTheEndGame(0);
                ActiveLoseScree();
                _LosePartie.LaunchASong();
                return;
            }
            else
            {
                NotationForTheEndGame(1500);
                ActiveWinScreen();

                return;
            }

        }
        if (_CurrentGold <= 0 || _CurrentRep <= 0)
        {
            NotationForTheEndGame(0);
            ActiveLoseScree();
            _LosePartie.LaunchASong();
            return;
        }
        else
        {
            _gameManager.LaunchanewDay();
        }

    }
    public void ActiveResume()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        if (m_canvasResume != null)
        {
            m_canvasResume.SetActive(true);
        }
    }

    public void ActiveLoseScree()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        _NotationLose.text = _FinalNotation.ToString();
        _ScoringLose.text = _FinalScoring.ToString();
        m_canvasLose.SetActive(true);
    }
    public void ActiveWinScreen()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        _NotationWin.text = _FinalNotation.ToString();
        _ScoringWin.text = _FinalScoring.ToString();
        _CanvasWin.SetActive(true);
    }


    private void NotationForTheEndGame(float bonus)
    {
        _FinalScoring = _CurrentRep + _CurrentGold / 2 + bonus;

        if (_FinalScoring > 10000)
        {
            _FinalNotation = "S";
            return;
        }
        if (_FinalScoring > 8500)
        {
            _FinalNotation = "A";
            return;
        }
        if (_FinalScoring > 7000)
        {
            _FinalNotation = "B";
            return;
        }
        if (_FinalScoring > 5500)
        {
            _FinalNotation = "C";
            return;
        }
        if (_FinalScoring > 4000)
        {
            _FinalNotation = "D";
            return;
        }
        if (_FinalScoring < 4000)
        {
            _FinalNotation = "E";
            return;
        }

    }


    public void OpenCredits()
    {
        _CanvasCredit.SetActive(true);
    }

    public void CloseCredits()
    {
        _CanvasCredit.SetActive(false);
    }
}
