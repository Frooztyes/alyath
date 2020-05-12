using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    public GameObject impactEffect;
    public LayerMask cantCollide;
    // Start is called before the first frame update
    void Start()
    {
        int playerLayer = LayerMask.NameToLayer("Pellet");
        uint bitstring = (uint)cantCollide.value;
        for (int i = 31; bitstring > 0; i--)
            if ((bitstring >> i) > 0)
            {
                bitstring = ((bitstring << 32 - i) >> 32 - i);
                Physics.IgnoreLayerCollision(playerLayer, i);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject impactGO = Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
            Destroy(impactGO, 2f);
        }
        
    }
}
