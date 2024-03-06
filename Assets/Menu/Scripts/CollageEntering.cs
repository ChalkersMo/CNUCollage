using DG.Tweening;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class CollageEntering : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] Light _enterLight;
    [SerializeField] AudioSource _themeAudio;
    [SerializeField] UnityEvent _event;
    [SerializeField] float _transitionTime;
    public IEnumerator Enter()
    {
        transform.DOMove(targetPos.position, _transitionTime);
        _enterLight.DOIntensity(1000, 4);
        _themeAudio.DOFade(0, _transitionTime);
        yield return new WaitForSeconds(_transitionTime);
        _event?.Invoke();
    }
   
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Enter());
        }
    }
}
