using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CompassDataHandler : MonoBehaviour
{
    public float prevAngle;
    private Compass compass;
    private const int CheckTimestilldirection = 5;
    public float deltaAngle;
    private Vector3 angle;
    private float speed;

    [Inject] Player player;
    [Inject] SignalBus _signalBus;
    [Inject] 
    private void OnInject()
    {
        _signalBus.Subscribe<CompassInitiated>(OnCompassInitialized);
    }

    
    private void OnCompassInitialized()
    {
        compass = Input.compass;
        prevAngle = compass.trueHeading;

        StartCoroutine(findDirection());
    }


    IEnumerator findDirection()
    {
        float dirSpeed;
        float[] allAngles = new float[CheckTimestilldirection];
        while (CompassInit.compassInitialized)
        {
            dirSpeed = 0;
            for (int i = 0; i < CheckTimestilldirection; i++)
            {
                if(compass.trueHeading - prevAngle > 3 || compass.trueHeading - prevAngle < -3)             // neglects litle changes
                {
                    allAngles[i] = compass.trueHeading;
                    dirSpeed += compass.trueHeading - prevAngle;
                    yield return new WaitForEndOfFrame();
                }
                
            }
            speed = allAngles[0];
            for(int i = 1; i < allAngles.Length; i++)
            {
                if (dirSpeed > 0)
                {
                    if (allAngles[i] - prevAngle > speed)
                    {
                        speed = allAngles[i] - prevAngle;
                        prevAngle = allAngles[i];
                    }
                }
                else if (dirSpeed < 0)
                {
                    if (allAngles[i] - prevAngle < speed)
                    {
                        speed = allAngles[i] - prevAngle;
                        prevAngle = allAngles[i];
                    }
                }
                else
                {
                    speed = 0;
                }
            }
            
            angle = new Vector3(0, dirSpeed, 0);
            //StartCoroutine(StartCameraMovement(angle, speed));
            yield return new WaitForEndOfFrame();
        }
           
        
    }
    IEnumerator StartCameraMovement(Vector3 angle, float speed)
    {
        while ((player.transform.eulerAngles.y < angle.y + deltaAngle) && (player.transform.eulerAngles.y > angle.y - deltaAngle))
        {
            player.transform.eulerAngles += angle.normalized * speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompassInit.compassInitialized)
        {
            if((player.transform.eulerAngles.y < player.transform.eulerAngles.y + angle.y + deltaAngle) && (player.transform.eulerAngles.y > player.transform.eulerAngles.y + angle.y - deltaAngle))
            {
                player.transform.eulerAngles += angle.normalized * speed * Time.deltaTime;
            }
        }
    }
}
