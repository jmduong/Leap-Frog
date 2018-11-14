/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phidget22;
using Phidget22.Events;

//Equilibrium

public class Player : MonoBehaviour
{
    public Transform trs;
    public Rigidbody2D rigid;
    public float moveSpeed;
    VoltageRatioInput[] inputs = new VoltageRatioInput[4];
    static double[] defaultInputs;
    static bool initializedInputs;
    public static Player instance;
    Vector2 move;
    public float moveMultiplier;
    public int waitMillis;

    void OnEnable()
    {
        instance = this;
        if (!initializedInputs)
            StartCoroutine(InitInputs(waitMillis));
    }

    IEnumerator InitInputs(int waitMillis)
    {
        defaultInputs = new double[this.inputs.Length];
        for (int i = 0; i < this.inputs.Length; i++)
        {
            this.inputs[i] = new VoltageRatioInput();
            this.inputs[i].Channel = i;
            this.inputs[i].Open(waitMillis);
            yield return new WaitForSecondsRealtime(waitMillis / 1000);
            defaultInputs[i] = this.inputs[i].VoltageRatio;
        }
        initializedInputs = true;
    }

    void Update()
    {
        if (!initializedInputs)
            return;
        this.move = new Vector2(-1, -1) * GetInput(2);
        this.move += new Vector2(-1, 1) * GetInput(3);
        this.move += new Vector2(1, -1) * GetInput(1);
        this.move += new Vector2(1, 1) * GetInput(0);
        this.move = Vector2.ClampMagnitude(this.move * this.moveMultiplier, this.moveSpeed);
        this.rigid.velocity = this.move;
    }

    float GetInput(int channel)
    {
        if (this.inputs[channel].Attached)
            return (float)(this.inputs[channel].VoltageRatio - defaultInputs[channel]);
        else
            throw new UnityException("The code is trying to get the voltage ratio of a non-connected sensor");
    }

    void OnDisable()
    {
        for (int i = 0; i < this.inputs.Length; i++)
            this.inputs[i].Close();
    }
}*/
