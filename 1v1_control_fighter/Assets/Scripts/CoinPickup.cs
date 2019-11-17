using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public Transform coinVisual;
    public int pointValue = 25;

    // Update is called once per frame
    void Update()
    {
        coinVisual.Rotate(new Vector3(0, 0, 10 * Time.timeScale));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (enabled)
        {
            if (collider.gameObject.tag == "Player")
            {
                GameObject playerObject = collider.gameObject;
                GameplaySession session = GameplaySession.Instance;

                AudioSingleton.Instance?.coinPickup?.Play();

                if (session)
                {
                    if (session.playerLeft == playerObject)
                    {
                        session.playerLeftPoints += pointValue;
                    }
                    else if (session.playerRight == playerObject)
                    {
                        session.playerRightPoints += pointValue;
                    }
                }

                enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
