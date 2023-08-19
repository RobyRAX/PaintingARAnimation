using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowerController : MonoBehaviour
{
    [SerializeField] int frameRate;
    [SerializeField] int frameStartDelay;
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
        StartCoroutine(BloomFlowerCo());
    }

    void InitFlower()
    {
        foreach (Transform child in transform)
        {
            ChildProp childProp = new ChildProp();
            childProp.obj = child.gameObject;
            childProp.scale = child.localScale;

            childs.Add(childProp);
            child.localScale = Vector3.zero;
        }
    }

    public IEnumerator BloomFlowerCo()
    {
        yield return new WaitForSeconds((1f / frameRate) * frameStartDelay);

        foreach(ChildProp childProp in childs)
        {
            childProp.obj.transform.DOScale(childProp.scale, bloomDuration).SetEase(Ease.InOutCirc);
            Debug.Log(childProp.obj.name + " Child of " + gameObject.name);
        }

        yield return null;
    }
}
