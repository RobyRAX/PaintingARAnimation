using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowerController : MonoBehaviour
{
    [SerializeField] int frameRate;
    public float startDelay;
    [SerializeField] float bloomDuration;

    [System.Serializable]
    public class ChildProp
    {
        public GameObject obj;
        public Vector3 scale;
    }

    [SerializeField] List<ChildProp> childs;

    private void Start()
    {
        InitFlower();
    }

    void InitFlower()
    {
        foreach (Transform child in transform)
        {
            ChildProp childProp = new ChildProp();
            childProp.obj = child.gameObject;
            childProp.scale = child.localScale;

            childs.Add(childProp);
        }
        ResetFlower();
    }

    public void ResetFlower()
    {
        foreach (Transform child in transform)
        {
            child.localScale = Vector3.zero;
        }
    }

    public void AnimFlower()
    {
        foreach (ChildProp childProp in childs)
        {
            childProp.obj.transform.DOScale(childProp.scale, bloomDuration).SetEase(Ease.InOutCirc);
            Debug.Log(childProp.obj.name + " Child of " + gameObject.name);
        }
    }
}
