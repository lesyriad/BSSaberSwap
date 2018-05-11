using IllusionPlugin;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace BSSaberSwap
{
    public class Plugin : IEnhancedPlugin, IPlugin
    {
        public string Name
        {
            get { return "Saber Swap Plugin"; }
        }

        public string Version
        {
            get { return "0.0.1"; }
        }

        public string[] Filter => throw new NotImplementedException();

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += this.SceneManagerOnActiveSceneChanged;
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= this.SceneManagerOnActiveSceneChanged;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            this._playerController = UnityEngine.Object.FindObjectOfType<PlayerController>();
            if(this._playerController == null)
            {
                return;
            }
            Saber tempSaber = this._playerController.leftSaber;
            ReflectionUtil.SetPrivateField(this._playerController,"leftSaber",this._playerController.rightSaber);
            ReflectionUtil.SetPrivateField(this._playerController, "rightSaber", tempSaber);
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
            
        }

        public void OnUpdate()
        {

        }

        public void OnFixedUpdate()
        {

        }

        public void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        private PlayerController _playerController;
    }
}
