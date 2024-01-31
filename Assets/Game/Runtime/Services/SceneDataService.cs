using TMPro;
using UnityEngine;

namespace Game.Runtime.Services
{
    public class SceneDataService : MonoBehaviour
    {
        [field: SerializeField] public Canvas MainMenuCanvas { get; private set; }
        [field: SerializeField] public Canvas GameCanvas { get; private set; }
        [field: SerializeField] public TMP_Text GameCanvasText { get; private set; }
        public bool GameStarted { get; set; }
    }
}
