using System.Collections;
using UnityEngine;
using Zenject;
public class CompassInit : MonoBehaviour
{
    public static bool compassInitialized = false;


    [Inject] SignalBus _signalBus;
    [Inject]
    private void OnInject()
    {

        _signalBus.Subscribe<TestSignal>(OnTest);
    }

    private void OnTest(TestSignal test)
    {
        Debug.Log("Texted " + test.testText);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _signalBus.Fire(new TestSignal("this is texted"));
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
        _signalBus.Fire(new CompassInitializedSignal());
        Debug.Log("Initialized location, compass");
    }

}
