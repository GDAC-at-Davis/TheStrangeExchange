using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class SimpleAnimator : MonoBehaviour, IAnimationClipSource
{
    [SerializeField]
    private AnimationClip animationClip;

    [SerializeField]
    private bool playOnAwake;

    public PlayableGraph PlayablePlayableGraph => playableGraph;
    private Animator animator;

    private PlayableGraph playableGraph;

    private bool graphCreated;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (playOnAwake)
        {
            Play();
        }
    }

    private void OnDestroy()
    {
        if (playableGraph.IsValid())
        {
            playableGraph.Destroy();
        }
    }

    public void GetAnimationClips(List<AnimationClip> results)
    {
        results.Add(animationClip);
    }

    public void Play()
    {
        // Lazy instatiation
        if (!graphCreated)
        {
            graphCreated = true;
            CreateGraph();
        }

        if (playableGraph.IsValid())
        {
            playableGraph.Play();
        }
    }

    public void Stop()
    {
        playableGraph.Stop();
    }

    private void CreateGraph()
    {
        playableGraph = PlayableGraph.Create($"{gameObject.name}.SimpleAnimator");

        var output = AnimationPlayableOutput.Create(playableGraph, string.Empty, animator);

        var animationClipPlayable = AnimationClipPlayable.Create(playableGraph, animationClip);

        output.SetSourcePlayable(animationClipPlayable);
    }
}