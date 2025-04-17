using UnityEngine;

namespace App.Common.Camera
{
    public class _AudioHolder
    {
        private List<AudioClip> audioClips = new List<AudioClip>();

        public void SetAudioClips(List<AudioClip> clips)
        {
            audioClips = clips;
        }
        public AudioClip GetAudioClip(int index)
        {
            if (index >= 0 && index < audioClips.Count)
            {
                return audioClips[index];
            }
            return null;
        }
    }
}
