using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TextureSequence : MonoBehaviour
{
    [SerializeField] Material imageSequenceMaterial;
    [SerializeField] Texture2D[] imageSequenceFrames;
    [SerializeField] int frameRate;
    [SerializeField] int frameStartDelay;

    //private MaterialPropertyBlock propertyBlock;
    private int textureIndex = 0;

    //private Renderer objectRenderer;
    bool startSequence;

    private void Start()
    {
        //objectRenderer = GetComponent<Renderer>();
        //propertyBlock = new MaterialPropertyBlock();
        //propertyBlock.SetTexture("_MainTex", imageSequenceFrames[textureIndex]);
    }

    public IEnumerator AnimateImageSequence()
    {
        yield return new WaitForSeconds((1f / frameRate) * frameStartDelay);

        startSequence = true;
        while (startSequence)
        {
            textureIndex = (textureIndex + 1) % imageSequenceFrames.Length;

            imageSequenceMaterial.SetTexture("_BaseMap", imageSequenceFrames[textureIndex]);
            //propertyBlock.SetTexture("_MainTex", imageSequenceFrames[textureIndex]);
            //objectRenderer.SetPropertyBlock(propertyBlock);

            if(textureIndex == imageSequenceFrames.Length - 1)
            {
                startSequence = false;
            }

            yield return new WaitForSeconds(1f / frameRate);
        }

        yield return null;
    }
}
