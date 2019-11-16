using UnityEngine;

public class InGameOverlay : MonoBehaviour
{
    public TMPro.TextMeshProUGUI countDownTimer;

    public TMPro.TextMeshProUGUI playerLeftPoints;
    public TMPro.TextMeshProUGUI playerRightPoints;

    // Update is called once per frame
    void Update()
    {
        GameplaySession session = GameplaySession.Instance;

        if (session)
        {
            float timeLeft = session.TimeLeft;

            if (timeLeft < 0)
            {
                countDownTimer.text = "00:00";
            }
            else
            {
                int seconds = Mathf.CeilToInt(timeLeft);
                float ms = timeLeft - seconds;
                int minutes = seconds / 60;
                seconds = seconds % 60;

                countDownTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

            playerLeftPoints.text = string.Format("{0:000000}", session.playerLeftPoints.ToString());
            playerRightPoints.text = string.Format("{0:000000}", session.playerRightPoints.ToString());
        }
    }
}
