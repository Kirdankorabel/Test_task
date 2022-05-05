using GateScripts;
using KnifeScripts;
using System;
using TrackScripts;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public static KnifeController Singltone; 

    [SerializeField] private PointsCounter _pointsCounter;
    [SerializeField] private KnifePrise _knifePrise;
    [SerializeField] private KnifeMover _mover;
    [SerializeField] private KnifeChanger _knifeChanger;
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 2, -11f);
    [SerializeField] private GameObject _knife;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particleSystem;

    public event Action PointsCountChanged;
    public event Action EndLevel;
    public event Action PlayerFinished;
    public event Action PriseChanged;
    private float _multipler = 0;
    private int _pointsCount = 0;

    public int TotalPointsCount => _pointsCounter.PointsCount;
    public int PointsCount => _pointsCount;
    public float Multipler => _multipler;
    public int Prise => _knifePrise.Prise;

    private void Awake()
    {
        Singltone = this;
        _particleSystem.enableEmission = false;
    }

    private void Start()
    {
        _knifePrise.LevelEnded += LevelEnded;
        GameController.Singletone.StartGame += InitializePlayer;
        _knifePrise.PriseChanged += () => PriseChanged?.Invoke();
        ChangeKnife();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pass>() != null)
        {
            var pass = collision.gameObject.GetComponent<Pass>();
            _knifePrise.ChangePrise(pass.Value, pass.IsMultipler);
            ChangeKnife();
        }
        else if (collision.gameObject.GetComponent<Target>() != null)
        {
            _pointsCount += 10;
            _animator.SetTrigger("TargetSlisedTrigger");
        }
        else if (collision.gameObject.tag == "Finish")
        {
            PlayerFinished?.Invoke();
        }
        else if (collision.gameObject.tag == "FinishTarget")
        {
            _multipler = collision.gameObject.GetComponent<FinishScaleTarget>().Multipler;
            Destroy(collision.gameObject);
        }
    }

    private void ChangeKnife()
    {
        var knife = _knifeChanger.ChangeKnife(_knifePrise.Prise);
        if(knife != _knife)
        {
            if (_knife != null)
                _knife.gameObject.SetActive(false);
            knife.gameObject.SetActive(true);
            _knife = knife;
        }
    }

    private void InitializePlayer()
    {
        _knifePrise.Prise = 1;
        this.transform.position = _startPosition;
        _mover.enabled = true;
        PointsCountChanged?.Invoke();
        _multipler = 0;
        _pointsCount = 0;
        _particleSystem.enableEmission = false;
    }

    private void LevelEnded()
    {
        var pointsCount = (int)(_pointsCount * _multipler);
        _pointsCounter.AddPoints(pointsCount);
        _mover.enabled = false;
        EndLevel?.Invoke();
        _particleSystem.enableEmission = true;
    }
}
