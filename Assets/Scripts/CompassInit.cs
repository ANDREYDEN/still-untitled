using System.Collections;
using UnityEngine;

public class CompassInit : MonoBehaviour
{
    public static bool compassInitialized = false;
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
        Debug.Log("Initialized location, compass");
    }

}
