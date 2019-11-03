using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OSCSetter : MonoBehaviour
{

    public GameObject puertoInput, ipInput, camara;
    public OSC osc;


    // Start is called before the first frame update
    void Start()
    {
        osc = GetComponent<OSC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetearOSC()
    {
        osc.outIP = ipInput.GetComponent<Text>().text;
        osc.outPort = int.Parse(puertoInput.GetComponent<Text>().text);
        osc.Close();
        osc.Open();
        camara.GetComponent<OSCsender>().prendido = true;
    }
    public void Reiniciar()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
