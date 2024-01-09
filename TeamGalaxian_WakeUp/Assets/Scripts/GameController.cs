using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum Lighting
    {
        Null,
        Dark,
        Dim,
        Lighter,
        Special
    }
    private GameObject player;
    private Lighting prevLightState;
    private Lighting lightState;
    private Material skybox;
    //private float time = 0;
    private Light mainLight;
    private Light playerLight;
    private float updateTime = 0f;
    private float time = 0f;
    private float timeChange = 2f;
    public bool specialLighting = false;
    private float intensity = 1f;
    private float decayFactor = 0.05f;



    // Start is called before the first frame update
    void Start()
    {
        skybox = RenderSettings.skybox;
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Error: Could not find GameObject called 'Player'.");
        } else
        {
            //Make sure that the GetChild(int) is set to whatever index the PlayerLight gameObject is under Player. 
            playerLight = player.transform.GetChild(2).gameObject.GetComponent<Light>();
        }
        mainLight = this.transform.GetChild(0).gameObject.GetComponent<Light>();
        if (mainLight == null)
        {
            Debug.Log("Error: mainLight is null.");
        }
        DimLightInstant();
        if (specialLighting)
        {
            lightState = Lighting.Special;
        } else
        {
            lightState = Lighting.Dim;
        }
        prevLightState = Lighting.Null;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime += Time.deltaTime;
        if (prevLightState != lightState)
        {
            changeLighting();
        }
        if (updateTime > 0.05f)
        {
            //Debug.Log(lightState);
            switch (lightState)
            {
                case Lighting.Dark:
                    NoLight();
                    break;
                case Lighting.Dim:
                    DimLight();
                    break;
                case Lighting.Lighter:
                    MoreLight();
                    break;
                case Lighting.Special:
                    if (time <= 0)
                    {
                        //time = Random.Range(1, 3);
                        time = timeChange;
                        mainLight.intensity = intensity;
                    } else
                    {
                        time -= updateTime;
                    }
                    DimLight();
                    break;
            }
            updateTime = 0f;
        }
    }

    void changeLighting()
    {
        switch (lightState) {
            case Lighting.Dark:
                lightState = Lighting.Dark;
                prevLightState = lightState;
                break;
            case Lighting.Dim:
                lightState = Lighting.Dim;
                prevLightState = lightState;
                break;
            case Lighting.Lighter:
                lightState = Lighting.Lighter;
                prevLightState = lightState;
                break;
            case Lighting.Special:
                lightState = Lighting.Special;
                prevLightState = lightState;
                break;
        }
    }

    void NoLightInstant()
    {
        skybox.SetFloat("_Exposure", 0f);
        mainLight.intensity = 0f;
        playerLight.intensity = 0f;
    }
    void DimLightInstant()
    {
        skybox.SetFloat("_Exposure", 0f);
        mainLight.intensity = 0f;
        playerLight.intensity = 200f;
    }

    void NoLight()
    {
        // Environment Light
        if (skybox.GetFloat("_Exposure") > 0f)
        {
            skybox.SetFloat("_Exposure", skybox.GetFloat("_Exposure") - 0.05f);
        }
        if (skybox.GetFloat("_Exposure") < 0f)
        {
            skybox.SetFloat("_Exposure", 0f);
        }
        if (mainLight.intensity > 0f)
        {
            mainLight.intensity -= 0.05f;
        }
        if (mainLight.intensity < 0f)
        {
            mainLight.intensity = 0f;
        }
        if (playerLight.intensity > 0f)
        {
            playerLight.intensity -= 0.05f;
        }
        if (playerLight.intensity < 0f)
        {
            playerLight.intensity = 0f;
        }
        //skybox.SetFloat("_Exposure", 0);
        //mainLight.intensity = 0;
        // Player Light
        //playerLight.intensity = 0;
    }

    void DimLight()
    {
        //Debug.Log(decayFactor);
        if (skybox.GetFloat("_Exposure") > 0f)
        {
            skybox.SetFloat("_Exposure", skybox.GetFloat("_Exposure") - decayFactor);
        }
        if (skybox.GetFloat("_Exposure") < 0f)
        {
            skybox.SetFloat("_Exposure", 0f);
        }
        if (mainLight.intensity > 0f)
        {
            mainLight.intensity -= decayFactor;
        }
        if (mainLight.intensity < 0f)
        {
            mainLight.intensity = 0f;
        }
        if (playerLight.intensity < 200f)
        {
            playerLight.intensity += 10f;
        }
        if (playerLight.intensity > 200f)
        {
            playerLight.intensity = 200f;
        }
        //skybox.SetFloat("_Exposure", 0);
        //mainLight.intensity = 0;
        // Player Light
        //playerLight.intensity = 0;
        // Player Light
        //playerLight.intensity = 200;
    }

    void MoreLight()
    {
        if (skybox.GetFloat("_Exposure") < 0.1f)
        {
            skybox.SetFloat("_Exposure", skybox.GetFloat("_Exposure") + 0.0005f);
        }
        if (skybox.GetFloat("_Exposure") > 0.1f)
        {
            skybox.SetFloat("_Exposure", 0.1f);
        }
        if (mainLight.intensity < 0.1f)
        {
            mainLight.intensity += 0.0005f;
        }
        if (mainLight.intensity > 0.1f)
        {
            mainLight.intensity = 0.1f;
        }
        if (playerLight.intensity > 0f)
        {
            playerLight.intensity -= 10f;
        }
        if (playerLight.intensity < 0f)
        {
            playerLight.intensity = 0f;
        }
    }
    /*
    void SpecialLight()
    {
        // Environment Light
        if (skybox.GetFloat("_Exposure") > 0f)
        {
            skybox.SetFloat("_Exposure", skybox.GetFloat("_Exposure") - 0.05f);
        }
        if (skybox.GetFloat("_Exposure") < 0f)
        {
            skybox.SetFloat("_Exposure", 0f);
        }
        if (mainLight.intensity > 0f)
        {
            mainLight.intensity -= 0.05f;
        }
        if (mainLight.intensity < 0f)
        {
            mainLight.intensity = 0f;
        }
        if (playerLight.intensity > 0f)
        {
            playerLight.intensity -= 0.05f;
        }
        if (playerLight.intensity < 0f)
        {
            playerLight.intensity = 0f;
        }
        //skybox.SetFloat("_Exposure", 0);
        //mainLight.intensity = 0;
        // Player Light
        //playerLight.intensity = 0;
    }
    */
    public void LightStateChange(int lightLevel)
    {
        if (!specialLighting)
        {
            switch (lightLevel)
            {
                case 0:
                    lightState = Lighting.Dark;
                    break;
                case 1:
                    lightState = Lighting.Dim;
                    break;
                case 2:
                    lightState = Lighting.Lighter;
                    break;
                case 3:
                    lightState = Lighting.Special;
                    break;
            }
        } else
        {
            Debug.Log("Else statement activated");
            switch (lightLevel)
            {
                case 10:
                    //intensity = 2f;
                    decayFactor = 0.01f;
                    timeChange = 7;
                    break;
                case 11:
                    mainLight.shadows = LightShadows.Soft;
                    //intensity = 3f;
                    break;
                case 12:
                    //intensity = 4f;
                    break;
            }
        }
        
    }
}
