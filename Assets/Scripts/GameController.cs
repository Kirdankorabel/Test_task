using System;
using TrackScripts;
using UnityEngine;
using UIScripts;

public class GameController : MonoBehaviour
{
    public static GameController Singletone;
    [SerializeField] private LevelInstantiator _levelInstantiator;
    private int levelNumber;

    public event Action StartLevel;
    public event Action StartGame;

    private void Awake()
    {
        Singletone = this;
        levelNumber = 0;
    }

    void Start()
    {
        _levelInstantiator.CreateLevel(levelNumber);
        KnifeController.Singltone.EndLevel += () => levelNumber++;
        UIController.Singletone.NextLevelStart += StartNextLevel;
    }

    private void StartNextLevel()
    {
        StartLevel?.Invoke();
        _levelInstantiator.CreateLevel(levelNumber);
        StartGame?.Invoke();
    }
}
