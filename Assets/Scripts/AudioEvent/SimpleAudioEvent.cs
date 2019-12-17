using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName="Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    [Header("Ranged Float With Editable Limits")]
    [RangedFloat(0, 1, RangedFloatAttribute.RangeDisplayType.EditableRanges)]
    public RangedFloat volume;

    [Header("Ranged Float With Editable Limits")]
    [RangedFloat(0, 1, RangedFloatAttribute.RangeDisplayType.EditableRanges)]
    public RangedFloat pitch;

    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}
