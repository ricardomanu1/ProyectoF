using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPrecense : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void TryInitialize() 
    {
        List<InputDevice> devices = new List<InputDevice>();
        //InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        //InputDevices.GetDevices(devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        // Establecer el modelo de los mandos en base a su configuracion
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobacion del correcto funcionamiento de los botones de los controles 
        /*if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            Debug.Log("Pressing Primary Button - A");

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            Debug.Log("Trigger pressed" + triggerValue);

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary Touchpad" + primary2DAxisValue);
        */
        // Deteccion de los controles 
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            // Comprobacion de modelo mandos o modelo manos
            if (showController)
            {
                // Modelo mando
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                // Modelo mano
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                // Aplicamos animacion
                UpdateHandAnimation();
            }
        }
            
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger",triggerValue);            
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip",gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
}
