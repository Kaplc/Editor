using System;
using UnityEditor;
using UnityEngine;

namespace Editor.LearnAssetPostprocessor
{
    public class LearnAssetPostprocessor : AssetPostprocessor
    {
        // 当纹理资源导入完成前调用
        private void OnPreprocessTexture()
        {
            Debug.Log("OnPreprocessTexture");
        }

        // 当资源导入完成时调用
        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("OnPostprocessTexture");
        }


        // 当模型资源导入完成前调用
        private void OnPreprocessModel()
        {
            Debug.Log("OnPreprocessModel");
        }

        // 当模型资源导入完成时调用
        private void OnPostprocessModel(GameObject go)
        {
            Debug.Log("OnPostprocessModel");
        }


        // 当音频资源导入完成前调用
        private void OnPreprocessAudio()
        {
            Debug.Log("OnPreprocessAudio");
        }

        // 当音频资源导入完成时调用
        private void OnPostprocessAudio(AudioClip audioClip)
        {
            Debug.Log("OnPostprocessAudio");
        }
    }
}