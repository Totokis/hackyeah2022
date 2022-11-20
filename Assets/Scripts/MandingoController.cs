using UnityEngine;
using FMODUnity;
using Cysharp.Threading.Tasks;

public class MandingoController : MonoBehaviour
{
    [Header("Mordosklejacz"), SerializeField] private Transform _japaToControl;

    [SerializeField] private float _maxJapaPositionOffset;
    [SerializeField] private float _maxJapaRotationOffset;


    private float volume;
    private float finalVolume;
    private float _japaHeight = 0.0005f;
    private float _japaRotation = 114.75f;

    [SerializeField] private MandingoData _serwus;
    [SerializeField] private MandingoData _proschem;
    [SerializeField] private MandingoData _pivo;
    [SerializeField] private MandingoData _vino;
    [SerializeField] private MandingoData _riba;
    [SerializeField] private MandingoData _dzie;
    [SerializeField] private MandingoData _eee;
    [SerializeField] private MandingoData _thx;

    private StudioEventEmitter _emitter;

    [EasyButtons.Button]
    private void GetJapa()
    {
        _japaToControl = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Jaw);
    }

    private void Start()
    {
        _emitter = GetComponent<StudioEventEmitter>();
        Test();
    }

    private void Update()
    {
        _emitter.EventInstance.getParameterByName("Amplitude", out volume, out finalVolume);
    }

    private void LateUpdate()
    {
        _japaToControl.localRotation = Quaternion.Euler(_japaRotation + finalVolume * _maxJapaRotationOffset, 0, 0);
        _japaToControl.localPosition = new Vector3(0, _japaHeight - finalVolume * _maxJapaPositionOffset, 0.0006478744f);
    }

    private async UniTask Test()
    {
        await PlayEvent(_serwus);
        await PlayEvent(_proschem);
        await PlayEvent(_pivo);
        await PlayEvent(_vino);
        await PlayEvent(_riba);
        await PlayEvent(_dzie);
        await PlayEvent(_eee);
        await PlayEvent(_thx);
        Test();
    }

    public async UniTask PlayEvent(MandingoData data)
    {
        _emitter.Stop();
        _emitter.EventReference = data.EventReference;
        _emitter.Play();

        await UniTask.Delay(Random.Range(data.Duration, data.Duration * 2) );
    }
}
