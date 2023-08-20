using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public static RootController Instane;

    public Material rootMat;
    [SerializeField] int frameRate;
    [SerializeField] float animDuration;
    public float flowerGlobalDelay;

    FlowerController[] flowerGroups;

    private void Awake()
    {
        Instane = this;
    }

    private void Start()
    {
        flowerGroups = FindObjectsOfType<FlowerController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartAnim();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            StopAnim();
        }
    }

    public void StartAnim()
    {
        StartCoroutine(DelayCo());
        StartCoroutine(DissolveAnimCo());
    }

    public void StopAnim()
    {
        foreach (FlowerController flowerGroup in flowerGroups)
        {
            flowerGroup.ResetFlower();
        }
    }

    IEnumerator DelayCo()
    {
        yield return new WaitForSeconds(flowerGlobalDelay);

        foreach(FlowerController flowerGroup in flowerGroups)
        {
            yield return new WaitForSeconds(flowerGroup.startDelay);
            flowerGroup.AnimFlower();
        }
    }

    IEnumerator DissolveAnimCo()
    {
        rootMat.SetFloat("_Dissolve_Value", 1);

        while (rootMat.GetFloat("_Dissolve_Value") >= -0.025)
        {
            float nextValue = rootMat.GetFloat("_Dissolve_Value") - 1.025f / (animDuration * frameRate);

            rootMat.SetFloat("_Dissolve_Value",  nextValue);

            yield return new WaitForSeconds(1f / frameRate);
        }

        yield return null;
    }
}
