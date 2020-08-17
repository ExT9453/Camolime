using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiView1 : MonoBehaviour
{
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;

    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;

    public float movePower = 1f;
    int movementFlag = 0; // 0:Idle, 1:left, 2:right

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void Update()
    {
        //sight();
        //moveAI();
        Move();

        target = GameObject.Find("1").transform;
        direction = (target.position - transform.position).normalized;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 10.0f)
        {
            moveAI();
        }


    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;


    }

    public void moveAI()
    {

        target = GameObject.Find("1").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
        accelaration = 0.01f;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        velocity = 0.05f; /*(velocity + accelaration * Time.deltaTime);*/
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (distance <= 10.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                    transform.position.y,
                                                    transform.position.z + (direction.z * velocity)
                                                    );
        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            velocity = 0.0f;

            movementFlag = Random.Range(0, 3);
            yield return new WaitForSeconds(3f);
            StartCoroutine("ChangeMovement");

        }

    }

    IEnumerator ChangeMovement()
    {

        movementFlag = Random.Range(0, 3);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }


    //void sight()
    //{
    //    Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);
    //    if (t_cols.Length > 0)
    //    {
    //        Transform t_tfPlayer = t_cols[0].transform;

    //        Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;
    //        float t_angle = Vector3.Angle(t_direction, transform.forward);
    //        if (t_angle < m_angle * 0.5f)
    //        {
    //            if (Physics.Raycast(transform.forward, t_direction, out RaycastHit t_hit, m_distance))
    //            {
    //                if (t_hit.transform.name == "Player")
    //                {
    //                    transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 0.02f);
    //                }
    //            }
    //        }
    //    }
    //}
}
