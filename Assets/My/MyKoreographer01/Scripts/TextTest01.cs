using SonicBloom.Koreo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest01 : MonoBehaviour
{
    public string eventID;

    private Text text;

    private KoreographyEvent curKoreoEvent;

    private void Awake()
    {
        text = GetComponent<Text>();
        Koreographer.Instance.RegisterForEventsWithTime(eventID, UpdateText);

    }

    private void UpdateText(KoreographyEvent koreoEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        if (koreoEvent.HasTextPayload())
        {
            if (curKoreoEvent == null || (koreoEvent != curKoreoEvent && koreoEvent.StartSample > curKoreoEvent.StartSample))
            {
                text.text = koreoEvent.GetTextValue();
                curKoreoEvent = koreoEvent;
            }

            if (koreoEvent.StartSample < curKoreoEvent.StartSample)
            {
                text.text = string.Empty;
                curKoreoEvent = null;
            }
        }
    }

}
