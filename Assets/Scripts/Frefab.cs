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
    public bool isBoss = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if(Walk_bool == true)
            {
                Destroy(other.gameObject);
                Enemy_Hp -= other.gameObject.GetComponent<Bullet>().Damage;
                UpdateHealthText(); // �ؽ�Ʈ ������Ʈ
            }
            if (Enemy_Hp <= 0 && Walk_bool)
            {
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<BoxCollider>());//�ߺ� �浹 ����
                Destroy(gameObject,1.5f); // HP�� 0 ���ϸ� ���� ������Ʈ�� ����
                GameMNG.Instance.getLvlMNG().KillCheck();
                Walk_bool=false;//�״� ���
                EnemyAnimator.SetTrigger("Dead");
                if(isBoss)
                {
                    GameMNG.Instance.ShowSelectButton();
                }
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

    public void Init()
    {
        // HP�� ǥ���� ���ο� ���� ������Ʈ ����
        healthObject.transform.position = transform.position + Vector3.up * 2.0f; // ������ ��ܿ� ��ġ

        // �޽� �ؽ�Ʈ ���� �߰�
        healthText = healthObject.AddComponent<TextMesh>();

        EnemyAnimator = Enemy.GetComponent<Animator>();
        //Timer = null;
        //this.PlayTime();

        //Enemy_Hp += 1+ fTime * Random.Range(0, 5);
        Enemy_Hp = 5;
        UpdateHealthText(); // �ʱ� ü�� ����
        isBoss = false;
    }
    public void BossInit()
    {
        // HP�� ǥ���� ���ο� ���� ������Ʈ ����
        healthObject.transform.position = transform.position + Vector3.up * 7.0f; // ������ ��ܿ� ��ġ

        // �޽� �ؽ�Ʈ ���� �߰�
        healthText = healthObject.AddComponent<TextMesh>();

        EnemyAnimator = Enemy.GetComponent<Animator>();
        //Timer = null;
        //this.PlayTime();
        Enemy.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        //Enemy_Hp += 1+ fTime * Random.Range(0, 5);
        Enemy_Hp = (int)(10 + GameMNG.Instance.g_fGameTime * Random.Range(0, 5));
        UpdateHealthText(); // �ʱ� ü�� ����
        isBoss = true;
    }
}
