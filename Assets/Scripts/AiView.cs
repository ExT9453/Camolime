using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiView : MonoBehaviour
{
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sight();
    }
    void sight()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);
        if (t_cols.Length > 0)
        {
            Transform t_tfPlayer = t_cols[0].transform;

            Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;
            float t_angle = Vector3.Angle(t_direction, transform.forward);
            if (t_angle < m_angle * 0.5f)
            {
                if (Physics.Raycast(transform.forward, t_direction, out RaycastHit t_hit, m_distance))
                {
                    if (t_hit.transform.name == "Player")
                    {
                        transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 0.02f);
                    }
                }
            }
        }
    }
}
