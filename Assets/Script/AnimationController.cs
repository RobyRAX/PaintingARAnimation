using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class AnimationController : MonoBehaviour
{
    private PlayableDirector director;
    public VideoPlayer vp;

    private void Awake()
    {
        vp.loopPointReached += OnVideoLoop;
    }

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void OnVideoLoop(VideoPlayer source)
    {
        director.Play();
    }
}
