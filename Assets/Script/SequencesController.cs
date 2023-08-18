using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SequencesController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public TextureSequence[] textureSequences;

    private void Awake()
    {
        videoPlayer.started += OnVideoLoop;
        videoPlayer.loopPointReached += OnVideoLoop;
    }

    void OnVideoLoop(VideoPlayer source)
    {
        foreach(TextureSequence seq in textureSequences)
        {
            StartCoroutine(seq.AnimateImageSequence());
        }
    }
}
