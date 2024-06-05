using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Coroutine m_crGenerateBullet;
    public float m_BulletSpeed = 300;
    public float m_AttackRange = 10f;
    public float m_fAttackRate = 0.5f;
    public int m_iAttackDamage = 5;
    public int m_iAttackAmount = 1;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(m_crGenerateBullet == null)
        {
            m_crGenerateBullet = StartCoroutine(Generate());
        }
    }
    IEnumerator Generate()
    {
        yield return new WaitForSeconds(m_fAttackRate);
        BulletGenerate();
        m_crGenerateBullet = null;
    }
    void BulletGenerate()
    {
        for (int i = 0; i<m_iAttackAmount; i++)
        {
            GameObject tempBulletgo = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
            tempBulletgo.GetComponent<Rigidbody>().AddForce(Vector3.forward * m_BulletSpeed, ForceMode.Force);
            tempBulletgo.GetComponent<Bullet>().Damage = m_iAttackDamage;
            Vector3 pos = tempBulletgo.transform.position;
            if(m_iAttackAmount % 2 == 0)
            {
                pos.x += (i - m_iAttackAmount / 2) * (1.0f / m_iAttackAmount) + 0.2f;
                pos.z += Random.Range(0,0.5f);
                Debug.Log((1 / m_iAttackAmount));
            }
            else
            {
                pos.x += (i - m_iAttackAmount / 2) * (1.0f / m_iAttackAmount);
                pos.z += Random.Range(0, 0.5f);
            }
            tempBulletgo.transform.position = pos;

        }
    }
    void InvokePrefab()
    {
        BulletGenerate();
    }
}
