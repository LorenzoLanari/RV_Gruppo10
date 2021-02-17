using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{


    public float shootRate;
    [SerializeField]
    private int Damage = 1;
    public GameObject m_shotPrefab;

    private float m_shootRateTimeStamp;
    private TPC_Rob _tpc;
    private AudioSource _src_audio_laser;
    RaycastHit hit;
    float range = 1000.0f;
    void Start()
    {
       _tpc = GetComponentInParent<TPC_Rob>();
       _src_audio_laser = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetMouseButton(0) && _tpc.shooting)
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f));
        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, Quaternion.Euler(0f,90f,0f)) as GameObject;
            _src_audio_laser.PlayOneShot(_src_audio_laser.clip);
         
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);

            var health = hit.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(Damage);

        }

    }


}
