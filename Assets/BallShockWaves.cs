using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShockwave : MonoBehaviour
{
    public int pointscount;
    public float maxradious;
    public float speed;
    public float startWidth;
    public GameObject ballobject;

    public GameObject particleeffect;
    public AudioSource theaudiosource;
    public AudioClip ExplosionSound;



    private IEnumerator Blast()
    {
        float currentradius = 0f;

        while (currentradius < maxradious)
        {
            currentradius += Time.deltaTime * speed;
            Draw(currentradius);
            yield return null;

        }

    }
    private void Draw(float currentradius)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall")) // if the ball hits a wall
        {
            theaudiosource.PlayOneShot(ExplosionSound);
            StartCoroutine(Blast());
            StartCoroutine(instanteparticle());
            StartCoroutine(BallDestroy());

        }

    }
    private IEnumerator BallDestroy()
    {

        Destroy(ballobject, 0.1f);

        yield return null;
    }
    private IEnumerator instanteparticle()
    {
        Instantiate(particleeffect, transform.position, Quaternion.identity);
        DestroyImmediate(particleeffect);
        yield return null;
    }
}
