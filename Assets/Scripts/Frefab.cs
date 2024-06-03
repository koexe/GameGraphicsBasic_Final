using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class Frefab : MonoBehaviour
{
    public float Enemy_Hp = 10; //몬스터 체력
    public float Enemy_Speed = 10; // 몬스터 스피드
    public float Enemy_Size = 1; // 몬스터 사이즈
    public GameObject healthObject; // HP를 표시할 새로운 게임 오브젝트
    public TextMesh healthText; // 메쉬 텍스트 프로
    private bool Walk_bool = true;
    public GameObject Enemy;
    public Animator EnemyAnimator; //게임오브젝트의 애니메이터 컴포너트를 자겨오고
    public float Play_Time = 0.0f;
    public LevelManager levelManager;

    // 몬스터가 despawn 충돌처리
    void Start()
    {
        // HP를 표시할 새로운 게임 오브젝트 생성
        
        healthObject.transform.position = transform.position + Vector3.up * 2.0f; // 몬스터의 상단에 배치

        // 메쉬 텍스트 프로 추가
        healthText = healthObject.AddComponent<TextMesh>();

        EnemyAnimator = Enemy.GetComponent<Animator>();
        //Timer = null;
        //this.PlayTime();
        levelManager = FindObjectOfType<LevelManager>();
        int fTime = levelManager.Time;

        //Enemy_Hp += 1+ fTime * Random.Range(0, 5);
        Enemy_Hp = 5;
        UpdateHealthText(); // 초기 체력 설정


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("despawner"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Enemy_Hp -= 5; // HP를 5 감소시킴
            UpdateHealthText(); // 텍스트 업데이트
            if (Enemy_Hp <= 0)
            {
                Destroy(gameObject,1.5f); // HP가 0 이하면 게임 오브젝트를 삭제
                GameMNG.Instance.getLvlMNG().KillCheck();
                Walk_bool=false;//죽는 모션
                EnemyAnimator.SetTrigger("Dead");
            }
        }
    }
   

    void Update()
    {
        if (Walk_bool==true)
        {
            Walk();
        }
    }

    void Walk() // 몬스터 이동
    {
        transform.Translate(Vector3.forward * -Enemy_Speed * Time.deltaTime);
    }

    // 체력 텍스트 업데이트 함수
    void UpdateHealthText()
    {
        healthText.text = Enemy_Hp.ToString(); // 체력 업데이트
        healthText.characterSize = 1.0f; // 텍스트 크기 설정
        healthText.anchor = TextAnchor.UpperCenter; // 텍스트 위치 설정
        healthText.color = Color.red; // 텍스트 색상 설정     
    }
}
