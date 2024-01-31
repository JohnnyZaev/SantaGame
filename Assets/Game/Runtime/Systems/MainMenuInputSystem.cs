using DG.Tweening;
using Game.Runtime.Services;
using Game.Runtime.Utils;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;
using UnityEngine.Scripting;

namespace Game.Runtime.Systems 
{
    internal sealed class MainMenuInputSystem : EcsUguiCallbackSystem
    {
        private EcsCustomInject<SceneDataService> _sceneDataService;
        
        [Preserve]
        [EcsUguiClickEvent(Idents.Ui.Play, Idents.Worlds.Events)]
        private void OnClickStart(in EcsUguiClickEvent e)
        {
            _sceneDataService.Value.MainMenuCanvas.gameObject.SetActive(false);
            _sceneDataService.Value.GameCanvas.gameObject.SetActive(true);
            _sceneDataService.Value.GameCanvasText.transform.DOScale(Vector3.one * 1.5f, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBack);
        }
        
        [Preserve]
        [EcsUguiClickEvent(Idents.Ui.Settings, Idents.Worlds.Events)]
        private void OnClickSettings(in EcsUguiClickEvent e)
        {
            Debug.Log("Settings");
        }
    }
}