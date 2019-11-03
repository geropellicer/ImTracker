using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscGeroReceiver : MonoBehaviour
{
    public OSC osc;

    // Start is called before the first frame update
    void Start()
    {
        //osc.SetAddressHandler("/TSPS/personUpdated/", RecibirEscena);
        //osc.SetAddressHandler("/TSPS/scene/", RecibirNumPeople);
        osc.SetAddressHandler("/TSPS/personUpdated/", RecibirEscena);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirEscena(OscMessage m)
    {
        if (m.GetFloat(1) == 0)
        {
            float x = m.GetFloat(8);
            float y = m.GetFloat(9);
            transform.localPosition = new Vector3(x * 5, transform.localPosition.y, y * 5);
            Debug.Log(y);
            Debug.Log(x);
            Debug.Log("");
        }
    }

    public void RecibirNumPeople(OscMessage m)
    {
        float num0 = m.GetFloat(0);
        Debug.Log("Tiempo: " + num0);
        float num1 = m.GetFloat(1);
        Debug.Log("Porcentaje: " + num1);
        float num2 = m.GetFloat(2);
        Debug.Log("Persons: " + num2);
        float num3 = m.GetFloat(3);
        Debug.Log("average x: " + num3);
        float num4 = m.GetFloat(4);
        Debug.Log("average y: " + num4);
    }
}
