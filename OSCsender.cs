using UnityEngine;
using System.Collections;
using Vuforia;

public class OSCsender : MonoBehaviour {

	public OSC osc;
    [SerializeField]
    public ImTracker it;
    public bool prendido = false;

    public enum WEBCAM {
        WEBCAM1,
        WEBCAM2
    }
    public WEBCAM webcam;


    int webcamInt = 0;

	// Use this for initialization
	void Start () {
        it = GetComponent<ImTracker>();

        if(webcam == WEBCAM.WEBCAM1)
        {
            webcamInt = 1;
        } else if (webcam == WEBCAM.WEBCAM2)
        {
            webcamInt = 2;
        } else if(webcamInt == 0)
        {
            Debug.LogError("ERROR: No se seteo qué webcam es correctamente");
        }

	}

    [SerializeField]
    bool Totem1Visible, Totem2Visible, Totem3Visible, Totem4Visible;
	
	// Update is called once per frame
	void Update () {
        if (prendido)
        {
            OscMessage message = new OscMessage();

            if(Totem1Visible)
            {
                message.address = "/Totem1/Update/";
                message.values.Add(it.valorFX1);
                message.values.Add(it.valorFY1);
                message.values.Add(webcamInt);
                osc.Send(message);
            }

            if(Totem2Visible)
            {
                message = new OscMessage();
                message.address = "/Totem2/Update/";
                message.values.Add(it.valorFX2);
                message.values.Add(it.valorFY2);
                message.values.Add(webcamInt);
                osc.Send(message);
            }

            if(Totem3Visible)
            {
                message = new OscMessage();
                message.address = "/Totem3/Update/";
                message.values.Add(it.valorFX3);
                message.values.Add(it.valorFY3);
                message.values.Add(webcamInt);
                osc.Send(message);
            }

            if(Totem4Visible)
            {
                message = new OscMessage();
                message.address = "/Totem4/Update/";
                message.values.Add(it.valorFX4);
                message.values.Add(it.valorFY4);
                message.values.Add(webcamInt);
                osc.Send(message);
            }
        }
    }

    public void EnviarMarcadorEncontrado(string name)
    {
        if(it != null)
        {
            string totem = "";
            float x = -1;
            float y = 1;

            if(name == "tracker1"){
                totem = "Totem1";
                x = it.valorFX1;
                y = it.valorFY1;
                Totem1Visible = true;
            } else if(name == "tracker2"){
                totem = "Totem2";
                x = it.valorFX2;
                y = it.valorFY2;
                Totem2Visible = true;
            } else if(name == "tracker3"){
                totem = "Totem3";
                x = it.valorFX3;
                y = it.valorFY3;
                Totem3Visible = true;
            } else if(name == "tracker4"){
                totem = "Totem4";
                x = it.valorFX4;
                y = it.valorFY4;
                Totem4Visible = true;
            }
            
            if (prendido)
            {
                OscMessage message = new OscMessage();

                message.address = "/" + totem + "/Entered/";
                message.values.Add(totem);
                message.values.Add(x);
                message.values.Add(y);
                message.values.Add(webcamInt);
                osc.Send(message);
                Debug.Log("marcador encontrado enviado mensaje con tag: '" + message.address + "'");
            }
        }
    }

    public void EnviarMarcadorPerdido(string name)
    {
        if(it != null)
        {
            string totem = "";
            float x = -1;
            float y = 1;

            if(name == "tracker1"){
                totem = "Totem1";
                x = it.valorFX1;
                y = it.valorFY1;
                Totem1Visible = false;
            } else if(name == "tracker2"){
                totem = "Totem2";
                x = it.valorFX2;
                y = it.valorFY2;
                Totem2Visible = false;
            } else if(name == "tracker3"){
                totem = "Totem3";
                x = it.valorFX3;
                y = it.valorFY3;
                Totem3Visible = false;
            } else if(name == "tracker4"){
                totem = "Totem4";
                x = it.valorFX4;
                y = it.valorFY4;
                Totem4Visible = false;
            }

            if (prendido)
            {
                OscMessage message = new OscMessage();

                message.address = "/" + totem + "/Leave/";
                message.values.Add(totem);
                message.values.Add(x);
                message.values.Add(y);
                message.values.Add(webcamInt);
                osc.Send(message);
            }
        }
    }

}
