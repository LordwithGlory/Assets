using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyUnity
{
    public class Sound : MonoBehaviour
    {

        public AudioSource audiosource;
        public static Sound _instance;
        void Awake()
        {
            audiosource = gameObject.AddComponent<AudioSource>();
            audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用
            _instance = this;
        }

        //在指定位置播放音频 PlayClipAtPoint()
        public void PlayAudioByName()
        {
            //load the music
            AudioClip clip = Resources.Load<AudioClip>(@"H:\学习资料\GameDesign\unity\New Unity Project\Assets\yinF.mp3");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }

        //如果当前有其他音频正在播放，停止当前音频，播放下一个
        public void PlayMusicByName()
        {
            AudioClip clip = Resources.Load<AudioClip>(@"H:\学习资料\GameDesign\unity\New Unity Project\Assets\yinF.mp3");

            if (audiosource.isPlaying)
            {
                audiosource.Stop();
            }

            audiosource.clip = clip;
            audiosource.Play();
        }
    }
}