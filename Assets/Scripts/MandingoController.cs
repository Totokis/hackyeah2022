using UnityEngine;
using FMODUnity;
using Cysharp.Threading.Tasks;

public class MandingoController : MonoBehaviour
{
    [SerializeField] private MandingoData _serwus;
    [SerializeField] private MandingoData _proschem;
    [SerializeField] private MandingoData _pivo;
    [SerializeField] private MandingoData _vino;
    [SerializeField] private MandingoData _riba;
    [SerializeField] private MandingoData _dzie;
    [SerializeField] private MandingoData _eee;
    [SerializeField] private MandingoData _thx;

    private StudioEventEmitter _emitter;

    private void Start()
    {
        _emitter = GetComponent<StudioEventEmitter>();
        Test();
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
    }

    public async UniTask PlayEvent(MandingoData data)
    {
        _emitter.Stop();
        _emitter.EventReference = data.EventReference;
        _emitter.Play();

        await UniTask.Delay(data.Duration);
    }
}
