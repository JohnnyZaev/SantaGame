using Game.Runtime.Services;
using Game.Runtime.Systems;
using Game.Runtime.Utils;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;

namespace Game.Runtime {
    internal sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private EcsUguiEmitter _ecsUguiEmitter;
        [SerializeField] private SceneDataService _sceneDataService;
        
        private EcsWorld _world;
        private IEcsSystems _systems;

        private void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
                .Add(new MainMenuInputSystem())
                .AddWorld(new EcsWorld(), Idents.Worlds.Events)
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .InjectUgui(_ecsUguiEmitter, Idents.Worlds.Events)
                .Inject(_sceneDataService)
                .Init ();
        }

        private void Update () {
            _systems?.Run ();
        }

        private void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }

            if (_world == null) return;
            _world.Destroy ();
            _world = null;
        }
    }
}