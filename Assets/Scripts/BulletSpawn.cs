using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Coroutine m_crGenerateBullet;
    public float m_SpawnTime = 0.5f;
    public float m_BulletSpeed = 300;
    public float m_AttackRange = 10f;
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
        yield return new WaitForSeconds(m_SpawnTime);
        BulletGenerate();
        m_crGenerateBullet = null;
    }
    void BulletGenerate()
    {
        GameObject tempBulletgo = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
        tempBulletgo.GetComponent<Rigidbody>().AddForce(Vector3.forward * m_BulletSpeed, ForceMode.Force);

    }
    void InvokePrefab()
    {
        BulletGenerate();
    }
}
