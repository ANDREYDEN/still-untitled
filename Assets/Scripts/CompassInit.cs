using System.Collections;
using UnityEngine;
using Zenject;

public class CompassInit : MonoBehaviour
{
    public static bool compassInitialized = false;

    [Inject] private SignalBus _signalBus;
    [Inject]
    private void OnInject()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InitCompass();
         
    }
    public void InitCompass()
    {
        Input.location.Start();
        StartCoroutine(WaitFOrUsersAccept());
    }
 
    IEnumerator WaitFOrUsersAccept()
    {
        yield return new WaitUntil(() => Input.location.isEnabledByUser);
        Input.compass.enabled = true;
        compassInitialized = true;
        _signalBus.Fire(new CompassInitiated());
        Debug.Log("Initialized location, compass");
    }

}
