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
            Debug.Log(m_DataStorage.LevelNumber);
        }

        void Update()
        {
            m_Level.text = "Nivel " + (m_DataStorage.LevelNumber).ToString();

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
            if (m_DataStorage.LevelNumber < 4)
            {
                int randomSceneIndex = Random.Range(0,3);
                m_DataStorage.LevelNumber++;

                m_DataStorage.SaveData();

                SceneManager.LoadScene(randomSceneIndex + 1);
            }

            else {

                int randomSceneIndex = Random.Range(0, 3);
                m_DataStorage.LevelNumber=0;

                m_DataStorage.SaveData();

                SceneManager.LoadScene("4");

            }


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
