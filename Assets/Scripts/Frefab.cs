using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class Frefab : MonoBehaviour
{
    public float Enemy_Hp = 10; //���� ü��
    public float Enemy_Speed = 10; // ���� ���ǵ�
    public float Enemy_Size = 1; // ���� ������
    public GameObject healthObject; // HP�� ǥ���� ���ο� ���� ������Ʈ
    public TextMesh healthText; // �޽� �ؽ�Ʈ ����
    private bool Walk_bool = true;
    public GameObject Enemy;
    public Animator EnemyAnimator; //���ӿ�����Ʈ�� �ִϸ����� ������Ʈ�� �ڰܿ���
    public float Play_Time = 0.0f;
    public LevelManager levelManager;

    // ���Ͱ� despawn �浹ó��
    void Start()
    {
        // HP�� ǥ���� ���ο� ���� ������Ʈ ����
        
        healthObject.transform.position = transform.position + Vector3.up * 2.0f; // ������ ��ܿ� ��ġ

        // �޽� �ؽ�Ʈ ���� �߰�
        healthText = healthObject.AddComponent<TextMesh>();
        UpdateHealthText(); // �ʱ� ü�� ����
        EnemyAnimator = Enemy.GetComponent<Animator>();
        //Timer = null;
        //this.PlayTime();
        levelManager = FindObjectOfType<LevelManager>();
        int fTime = levelManager.Time;

        Enemy_Hp += 1+ fTime * Random.Range(0, 5);
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("despawner"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Attack"))
        {
            Enemy_Hp -= 5; // HP�� 5 ���ҽ�Ŵ
            UpdateHealthText(); // �ؽ�Ʈ ������Ʈ
            if (Enemy_Hp <= 0)
            {
                Destroy(gameObject,1.5f); // HP�� 0 ���ϸ� ���� ������Ʈ�� ����
                Walk_bool=false;//�״� ���
                EnemyAnimator.SetTrigger("Dead");
            }
        }
    }
    /*void Enemy_Kill()
    {
        
    }

    void PlayTime()
    {
        if(Timer != null) StopCoroutine(Timer);
        Timer = StartCoroutine(Timerr());
    }
    IEnumerator Timerr()
    {
        yield return null;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Play_Time = Play_Time + 0.1f;
        }
    }
    */
   

    void Update()
    {
        
        if (Walk_bool==true)
        {
            Walk();
        }
        // PlayTime();
       
        
    }

    void Walk() // ���� �̵�
    {
        transform.Translate(Vector3.forward * -Enemy_Speed * Time.deltaTime);
    }

    // ü�� �ؽ�Ʈ ������Ʈ �Լ�
    void UpdateHealthText()
    {
            healthText.text = Enemy_Hp.ToString(); // ü�� ������Ʈ
            healthText.characterSize = 1.0f; // �ؽ�Ʈ ũ�� ����
            healthText.anchor = TextAnchor.UpperCenter; // �ؽ�Ʈ ��ġ ����
            healthText.color = Color.red; // �ؽ�Ʈ ���� ����     
    }
}