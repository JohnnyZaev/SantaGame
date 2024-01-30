using Game.Runtime.Utils;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;
using UnityEngine.Scripting;

namespace Game.Runtime.Systems {
    internal sealed class MainMenuInputSystem : EcsUguiCallbackSystem 
    {
        [Preserve]
        [EcsUguiClickEvent(Idents.Ui.Play, Idents.Worlds.Events)]
        private void OnClickStart(in EcsUguiClickEvent e)
        {
            Debug.Log("Start");
        }
        
        [Preserve]
        [EcsUguiClickEvent(Idents.Ui.Settings, Idents.Worlds.Events)]
        private void OnClickSettings(in EcsUguiClickEvent e)
        {
            Debug.Log("Settings");
        }
    }
}