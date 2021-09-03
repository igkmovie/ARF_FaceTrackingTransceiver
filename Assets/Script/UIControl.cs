using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class UIControl : MonoBehaviour
{
    public InputField inputField;
    public Button button;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "192.168.10.";
        if (PlayerPrefs.HasKey("ip"))
        {
            inputField.text = PlayerPrefs.GetString("ip");
            Debug.Log("ip");
        }
       
        button.onClick.AddListener(() =>
        {
            PlayerPrefs.SetString("ip", inputField.text);
            var blendShapeTransmitter = FindObjectOfType<BlendShapeTransmitter>();
            if (blendShapeTransmitter == null) return;
            blendShapeTransmitter.SetClient(inputField.text);
            canvas.SetActive(false);
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
