using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 5f;
    public Transform target;
    public Vector3 direction;
    public float velocity;

    private SpriteRenderer chrRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Camolime").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        velocity = 0.50f; /*(velocity + accelaration * Time.deltaTime);*/
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);

        this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                              transform.position.y,
                                              transform.position.z + (direction.z * velocity)
                                              );
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMove.instance.hp-=1;
            this.gameObject.SetActive(false);
        }

    }
}
