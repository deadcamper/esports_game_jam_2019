using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCrate : MonoBehaviour
{
    public Animation animation;

    public float launchSpeed = 10;
    public int numberOfRewards = 10;

    public GameObject rewardTemplate;

    private Collider2D collide;

    private bool isGifting = false;

    public enum AimDirection
    {
        LEFT, RIGHT, FORWARD
    }

    public AimDirection facing;

    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GiftRewards()
    {
        AudioSingleton.Instance?.chestOpen?.Play();
        animation.Play();
        while (animation.isPlaying)
        {
            yield return null;
        }

        collide.enabled = false;
        for (int count = 0; count < numberOfRewards; count++)
        {
            GameObject reward = Instantiate(rewardTemplate, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            Rigidbody2D body = reward.GetComponent<Rigidbody2D>();

            if (body)
            {
                Vector2 velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0.25f, 1f));
                velocity.Normalize();
                velocity *= launchSpeed;

                if (facing == AimDirection.LEFT)
                {
                    velocity.x = -Mathf.Abs(velocity.x);
                }
                else if (facing == AimDirection.RIGHT)
                {
                    velocity.x = Mathf.Abs(velocity.x);
                }

                body.velocity = velocity;
            }
            else if (count == 0)
            {
                Debug.LogWarning("No Rigidbody2D found. Cannot launch reward object.");
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGifting && collision.collider.tag == "Player")
        {
            StartCoroutine(GiftRewards());
            isGifting = true;
        }
    }
}
