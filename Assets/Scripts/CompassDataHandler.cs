using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CompassDataHandler : MonoBehaviour
{
    private bool once;
    private bool reached;
    public float prevAngle;
    private Compass compass;
    private const int CheckTimestilldirection = 5;
    public float deltaAngle;

    private Vector3 angle;

    private float speed;

    private float prev;

    public GameObject player;

    private bool compassInit;
    public TMP_Text textComponent;
    private float dest;
    private float curPos;
    public Vector3 startPos;
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
        prev = compass.trueHeading;
        compassInit = true;
        StartCoroutine(checkMovement());


        //StartCoroutine(findDirection());
    }

    IEnumerator checkMovement()
    {

            while (Mathf.Abs(compass.trueHeading - prev) < 1)
            {

                yield return new WaitForSeconds(0.3f);

            }
            
            deltaAngle = compass.trueHeading - prev;
            textComponent.text = " heading " + deltaAngle.ToString();
            startPos = player.transform.eulerAngles;
            dest = player.transform.eulerAngles.y + deltaAngle;
            yield return new WaitUntil(() => Mathf.Abs(dest - startPos.y) < 10);

        }
        /*
        textComponent.text = " heading " + deltaAngle.ToString();

        deltaAngle = compass.trueHeading - prev;
        if (Mathf.Abs(deltaAngle) >  1.5f)
        {
            
            prev = compass.trueHeading;
        }
        textComponent.text = " heading " + deltaAngle.ToString();
        deltaAngle = 0;
        dest = compass.headingAccuracy;
        prev = compass.trueHeading;
        return false;*/
    }
    /*IEnumerator changePrev()
    {
        yield return new WaitForSeconds(0.1f);
        prev = compass.trueHeading;
    }/*
    /*IEnumerator findDirection()
    {
        float dirSpeed;
        float[] allAngles = new float[CheckTimestilldirection];
        while (compassInit)
        {
            dirSpeed = 0;
            if (checkMovement())
            {
                for (int i = 0; i < CheckTimestilldirection; i++)
                {
                    if(Mathf.Abs(compass.trueHeading - prevAngle) < 3)
                    {
                        allAngles[i] = 0;
                    }
                    else
                    {
                        allAngles[i] = compass.trueHeading;
                    }
                    
                    dirSpeed += compass.trueHeading - prevAngle;
                    textComponent.text = " heading " + (compass.trueHeading - prevAngle).ToString();
                    yield return new WaitForEndOfFrame();


                }
                speed = allAngles[0];
                for (int i = 1; i < allAngles.Length; i++)
                {
                    if(speed < Mathf.Abs(allAngles[i] - prevAngle)){
                        speed = Mathf.Abs(allAngles[i] - prevAngle);
                    }
                    
                }
                if(dirSpeed == 0)
                {
                    speed = 0;
                }

                angle = new Vector3(0, dirSpeed, 0);


                //StartCoroutine(StartCameraMovement(angle, speed));
                
            }
            else
            {
                speed = 0;
                angle = Vector3.zero;
            }
            prevAngle = compass.trueHeading;
            yield return new WaitForSeconds(0.2f);
        }
            
           
        
    }*/
 
    // Start is called before the first frame update
    void Start()
    {
        dest = player.transform.eulerAngles.y;
    }
    IEnumerator translate()
    {
        while (compassInit)
        {
            curPos += (dest - curPos) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }







    // Update is called once per frame
    void Update()
    {
        if (CompassInit.compassInitialized)
        {



            player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles, Vector3.up * dest, Time.deltaTime);
            
            //player.transform.eulerAngles += angle.normalized * speed * Time.deltaTime;

        }
    }
}
