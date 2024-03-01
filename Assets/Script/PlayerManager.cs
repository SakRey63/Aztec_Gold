using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerManager : MonoBehaviour
{
    public static int _playerHelth;
    public static bool _gameOver;
    public TextMeshProUGUI _playerHelthText;
    void Start()
    {
        _playerHelth = 100;
        _gameOver = false;
    }
    
    void Update()
    {
        _playerHelthText.text = "" + _playerHelth;
        if (_gameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        
    }

    public static void Damage(int damageCount)
    {
        _playerHelth -= damageCount;
        if (_playerHelth <= 0)
        {
            _gameOver = true;
        }
    }
}
