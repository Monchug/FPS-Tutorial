using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireController : MonoBehaviour
{
    public float distance;
    public float frequency;
    public float damage;
    float timer;
    public int bullet;
    public int mag;
    int total;
    int eksilenMermi = 0;
    public AudioSource sfx;
    public AudioClip aud;
    public Image crosshair;
    public ParticleSystem muzzleSystem;
    public Animation anim;
    public Animation rAnim;
    public TextMeshProUGUI txt;
    bool fire = true;

    void Start()
    {
        total = bullet * mag;
        txt.text = bullet + "" + '/' + total + "";
    }
    void FixedUpdate()
    {
        if (fire == true && Time.time>timer && (Input.GetMouseButton(0)))
        {
            OpenFire();
            timer = Time.time + frequency;
        }
        if(Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        RaycastHit hit;
        crosshair.color = Color.white;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.distance <= distance && hit.collider.gameObject.tag == "Enemy")
            {
                crosshair.color = Color.red;
            }
        }
    }
    public void OpenFire()
    {
        if(bullet>0)
        {
            bullet--;
            eksilenMermi++;
            muzzleSystem.Play();
            sfx.clip = aud;
            sfx.Play();
            anim.Play("tepme");
            txt.text = bullet + "" + '/' + total + "";
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                Enemy dusman = hit.transform.GetComponent<Enemy>();
                if (dusman != null)
                {
                    dusman.Damage(damage);
                }
            }
        }
    }
    public void Reload()
    {
        if(eksilenMermi != 0 && total>0) 
        {
            string a = txt.text;
            if(eksilenMermi>total)
            {
                eksilenMermi = total;
            }
            bullet = bullet + eksilenMermi;
            total = total - eksilenMermi;
            rAnim.Play("reload");
            txt.text = bullet + "" + '/' + total + "";
            eksilenMermi = 0;
        }
    }
}