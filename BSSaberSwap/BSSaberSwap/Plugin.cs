using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
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
            get { return "0.0.2"; }
        }
        private Plugin Instance = null;
        public string[] Filter {get; }

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
                return;
            if(Instance == null)
            {
                Material[] source = Resources.FindObjectsOfTypeAll<Material>();
                this._blueSaberMat = source.FirstOrDefault((Material x) => x.name == "BlueSaber");
                this._redSaberMat = source.FirstOrDefault((Material x) => x.name == "RedSaber");
                this.red = this._redSaberMat.GetColor("_Color");
                this.blue = this._blueSaberMat.GetColor("_Color");
                Instance = this;
            }
            this._left = this._playerController.leftSaber;
            this._right = this._playerController.rightSaber;
            ReflectionUtil.SetPrivateField(_left, "_saberType", Saber.SaberType.SaberB);
            ReflectionUtil.SetPrivateField(_right, "_saberType", Saber.SaberType.SaberA);
            this._redSaberMat.SetColor("_Color", this.blue);
            this._redSaberMat.SetColor("_EmissionColor", this.blue);
            this._blueSaberMat.SetColor("_Color", this.red);
            this._blueSaberMat.SetColor("_EmissionColor", this.red);
            /*this._playerController = UnityEngine.Object.FindObjectOfType<PlayerController>();
            if (this._playerController != null)
            {
                if (_left == null)
                {
                    this._left = this._playerController.leftSaber;
                    this._right = this._playerController.rightSaber;
                    Material[] source = Resources.FindObjectsOfTypeAll<Material>();
                    this._blueSaberMat = source.FirstOrDefault((Material x) => x.name == "BlueSaber");
                    this._redSaberMat = source.FirstOrDefault((Material x) => x.name == "RedSaber");
                    this.red = this._redSaberMat.GetColor("_Color");
                    this.blue = this._blueSaberMat.GetColor("_Color");
                }

                //swap once and forget
               
                
                
                



            }
            

            //ReflectionUtil.SetPrivateField(_left, "_saberType", Saber.SaberType.SaberB);
            //ReflectionUtil.SetPrivateField(_right, "_saberType", Saber.SaberType.SaberA);*/


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
           
           
            
        }

        private PlayerController _playerController;
        private Saber _left;
        private Saber _right;
        private Material _blueSaberMat;
        private Material _redSaberMat;
        private Color red;
        private Color blue;
    }
}
