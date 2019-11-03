using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImTracker : MonoBehaviour
{

    public GameObject cubo1, cubo2, cubo3, cubo4;
    public GameObject tValorX1, tValorY1, tValorX2, tValorY2, tValorX3, tValorY3, tValorX4, tValorY4;
    [SerializeField]
    Camera cam;
    float screenW, screenH;
    float valorX1, valorY1, valorX2, valorY2, valorX3, valorY3, valorX4, valorY4;
    public float valorFX1, valorFY1, valorFX2, valorFY2, valorFX3, valorFY3, valorFX4, valorFY4;
    public Text x1, y1, x2, y2, x3, y3, x4, y4;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        x1 = tValorX1.GetComponent<Text>();
        y1 = tValorY1.GetComponent<Text>();
        x2 = tValorX2.GetComponent<Text>();
        y2 = tValorY2.GetComponent<Text>();
        x3 = tValorX3.GetComponent<Text>();
        y3 = tValorY3.GetComponent<Text>();
        x4 = tValorX4.GetComponent<Text>();
        y4 = tValorY4.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        screenW = Screen.width;
        screenH = Screen.height;
        if(cubo1 != null && cubo1.activeInHierarchy)
        { 
            valorX1 = cam.WorldToScreenPoint(cubo1.transform.position).x;
            valorY1 = cam.WorldToScreenPoint(cubo1.transform.position).y;
            valorFX1 = valorX1.Remap(0, screenW, 0, 1);
            valorFY1 = valorY1.Remap(0, screenH, 0, 1);
        } else
        {
            valorFX1 = -1;
            valorFY1 = -1;
        }
        if (cubo2 != null && cubo2.activeInHierarchy)
        {
            valorX2 = cam.WorldToScreenPoint(cubo2.transform.position).x;
            valorY2 = cam.WorldToScreenPoint(cubo2.transform.position).y;
            valorFX2 = valorX2.Remap(0, screenW, 0, 1);
            valorFY2 = valorY2.Remap(0, screenH, 0, 1);
        } else
        {
            valorFX2 = -1;
            valorFY2 = -1;
        }
        if (cubo3 != null && cubo3.activeInHierarchy)
        {
            valorX3 = cam.WorldToScreenPoint(cubo3.transform.position).x;
            valorY3 = cam.WorldToScreenPoint(cubo3.transform.position).y;
            valorFX3 = valorX3.Remap(0, screenW, 0, 1);
            valorFY3 = valorY3.Remap(0, screenH, 0, 1);
        } else
        {
            valorFX3 = -1;
            valorFY3 = -1;
        }
        if (cubo4 != null && cubo4.activeInHierarchy)
        {
            valorX4 = cam.WorldToScreenPoint(cubo4.transform.position).x;
            valorY4 = cam.WorldToScreenPoint(cubo4.transform.position).y;
            valorFX4 = valorX4.Remap(0, screenW, 0, 1);
            valorFY4 = valorY4.Remap(0, screenH, 0, 1);
        }
        else
        {
            valorFX4 = -1;
            valorFY4 = -1;
        }

        x1.text = valorFX1.ToString("#.###");
        y1.text = valorFY1.ToString("#.###");
        x2.text = valorFX2.ToString("#.###");
        y2.text = valorFY2.ToString("#.###");
        x3.text = valorFX3.ToString("#.###");
        y3.text = valorFY3.ToString("#.###");
        x4.text = valorFX4.ToString("#.###");
        y4.text = valorFY4.ToString("#.###");
    }
}

