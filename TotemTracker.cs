using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TotemTracker : MonoBehaviour, ITrackableEventHandler
{
    TrackableBehaviour mTrackableBehaviour;
    TrackableBehaviour.Status m_PreviousStatus;
    TrackableBehaviour.Status m_NewStatus;

    [SerializeField]
    OSCsender oscs;

    void Start()
    {
        oscs = GameObject.Find("ARCamera").GetComponent<OSCsender>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }


    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    void OnTrackingFound()
    {
        oscs.EnviarMarcadorEncontrado(mTrackableBehaviour.TrackableName);
        Debug.Log("Marcador encontrado: " + mTrackableBehaviour.TrackableName);
    }

    void OnTrackingLost()
    {
        oscs.EnviarMarcadorPerdido(mTrackableBehaviour.TrackableName);
        Debug.Log("Marcador perdido: " + mTrackableBehaviour.TrackableName);
    }
}
