using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class ParticleTest01 : MonoBehaviour
{
    public string eventID;
    public float particlePerBeat = 100;


    private ParticleSystem particle;
    private int particleCount;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        Koreographer.Instance.RegisterForEvents(eventID, CreateParticle);
    }

    private void CreateParticle(KoreographyEvent kevent)
    {
        particleCount = (int)(Koreographer.Instance.GetMusicBeatTimeDelta()* particlePerBeat);
        particle.Emit(particleCount);
    }
}
