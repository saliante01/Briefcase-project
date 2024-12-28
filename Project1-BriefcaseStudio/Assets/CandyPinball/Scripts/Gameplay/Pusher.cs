using JSG.Project_Pinball.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSG.Project_Pinball.Gameplay
{
    public class Pusher : MonoBehaviour
    {
        public GameObject m_Ball;
        bool haveBall = true;
        public Transform ArrowBase;

        public Transform BallPoint;

        public static Pusher m_Current;

        public GameObject m_ShootParticlePrefab;
        public ParticleSystem[] m_Particles;
        [SerializeField, Space]
        private DataStorage m_DataStorage;

        public float velocidadRotacion;  // Controla la velocidad de la rotación

        public float shotavailable;
       
        // Start is called before the first frame update

        private void Awake()
        {
            m_Current = this;


        }
        void Start()
        {

            shotavailable = m_DataStorage.Shots_available;

            if (m_DataStorage == null)
            {
                Debug.LogError("m_DataStorage no está asignado.");
                return;
            }

            m_Particles[0].Stop();
            m_Particles[1].Stop();
            Debug.Log(m_DataStorage.LevelNumber);  // Deberías ver esto si m_DataStorage no es null

            // Ajustar la velocidad de rotación según el valor de nextlevel
            switch (m_DataStorage.LevelNumber)
            {
                case 0:
                    velocidadRotacion = 1.5f;  // Nivel 1, velocidad 1
                    break;
                case 1:
                    velocidadRotacion = 3f;  // Nivel 2, velocidad 2
                    break;
                case 2:
                    velocidadRotacion = 4f;  // Nivel 3, velocidad 3
                    break;
                case 3:
                    velocidadRotacion = 5f;  // Nivel 2, velocidad 2
                    break;
                case 4:
                    velocidadRotacion = 6f;  // Nivel 2, velocidad 2
                    break;
                case 5:
                    velocidadRotacion = 7f;  // Nivel 2, velocidad 2
                    break;
            }
        }


        // Update is called once per frame
        void Update()
        {


            if (haveBall)
            {
                m_Ball.GetComponent<Rigidbody>().isKinematic = true;
                m_Ball.transform.position = BallPoint.position;
                
                ArrowBase.localRotation = Quaternion.Euler(0, 0, 55 * Mathf.Sin(Time.time * velocidadRotacion));
            }
            else
            {
                if (m_Ball.transform.position.y < transform.position.y)
                {
                    m_Particles[0].Play();
                    m_Particles[1].Play();
                    haveBall = true;
                   
                }


            }

            bool hit = false;

            if (Input.GetMouseButtonDown(0))
            {
                hit = true;
            }
            if (Input.touchCount > 0)
            {
                hit = true;
            }

            if (hit && shotavailable!=0)
            {
                if (GameControl.m_Current.m_State == GameControl.State_Gameplay)
                {
                    if (haveBall)
                    {
                        m_Ball.GetComponent<Rigidbody>().isKinematic = false;
                        m_Ball.GetComponent<Rigidbody>().velocity = 50 * (ArrowBase.rotation * Vector3.up);
                        m_Ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 0, 200);
                        haveBall = false;
                        shotavailable --;
                        GameObject obj = Instantiate(m_ShootParticlePrefab);
                        obj.transform.position = BallPoint.position;
                        obj.transform.forward = ArrowBase.rotation * Vector3.up;
                        Destroy(obj, 4);

                        m_Particles[0].Stop();
                        m_Particles[1].Stop();

                        CameraControl.Current.StartShake(0.4f, 0.2f);

                    }
                }
            }

            // Aquí puedes agregar más lógica si es necesario
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, 3);
        }
    }
}