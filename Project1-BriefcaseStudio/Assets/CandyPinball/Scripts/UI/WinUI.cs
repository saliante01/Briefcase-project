using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JSG.Project_Pinball.Gameplay;
using JSG.Project_Pinball.ScriptableObjects;

namespace JSG.Project_Pinball.UI
{
    public class WinUI : MonoBehaviour
    {

        [SerializeField]
        private Button m_Continue;


        [SerializeField]
        private Text m_CoinAmount;
        [SerializeField]
        private Text m_Level;

        [SerializeField]
        private ParticleSystem[] m_Particles;

        [SerializeField, Space]
        private DataStorage m_DataStorage;


        void Start()
        {

        }

        void Update()
        {
            m_Level.text = "Level " + (m_DataStorage.LevelNumber + 1).ToString();

            m_CoinAmount.text = (m_DataStorage.Coin).ToString();
        }



        public void Continue()
        {
            if (m_DataStorage.CheckInternet())
            {
                Invoke("LoadNextScene", 1);
            }
            else
            {
                LoadNextScene();
            }

        }
        private void LoadNextScene()
        {
            // Genera un índice aleatorio entre 0 y 4
            int randomSceneIndex = Random.Range(0, 3);
            m_DataStorage.LevelNumber++;

            m_DataStorage.SaveData();
            // Carga la escena correspondiente sin modificar el LevelNumber
            SceneManager.LoadScene(randomSceneIndex + 1);  // Se suma 1 porque la escena es indexada de 1 en adelante (por ejemplo: "Scene 1", "Scene 2")
        }


        public void Restart()
        {
            foreach (ParticleSystem p in m_Particles)
            {
                p.Play();
            }
        }

        public void WatchVideo()
        {
            //SoundGallery.PlaySound("Click");
            if (m_DataStorage.CheckInternet())
            {
                //    YodaMainControl.MainYodoControl.m_RewardCoin = 1;
                //    YodaMainControl.MainYodoControl.ShowRewardedVideo();
            }
            else
            {
                //message no internet
                //  UIControl.Current.m_NoNetworkUI.gameObject.SetActive(true);
                Invoke("HideNetworkErrorDelayed", 3);
            }

            //WatchVideoAndGet100MoreCoins
        }

        public void HideNetworkErrorDelayed()
        {
            //   UIControl.Current.m_NoNetworkUI.gameObject.SetActive(false);
        }



    }

}
