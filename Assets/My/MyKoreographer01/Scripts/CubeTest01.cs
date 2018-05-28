using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class CubeTest01 : MonoBehaviour
{
    public string eventID;

    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    private void Awake()
    {
        Koreographer.Instance.RegisterForEventsWithTime(eventID, ChangeCube);
    }

    private void ChangeCube(KoreographyEvent koreoEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {

        if(koreoEvent.HasCurvePayload())
        {
            float curveValue = koreoEvent.GetValueOfCurveAtTime(sampleDelta);
            Debug.Log(curveValue);
            transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, curveValue);
        }
    }
}
