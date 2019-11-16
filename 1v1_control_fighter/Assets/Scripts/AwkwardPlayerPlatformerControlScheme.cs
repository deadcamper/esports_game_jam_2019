using UnityEngine;

using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

// Totally borrowed from the standard stuff and hacked together
[RequireComponent(typeof(PlatformerCharacter2D))]
public class AwkwardPlayerPlatformerControlScheme : MonoBehaviour
{
    public string jumpAxis = "Left Player Trigger";
    public string crouchButton = "Left Player Bumper";
    public string xAxis = "Left Player Horizontal";

    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    private bool m_midJump;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }


    private void Update()
    {
        bool testJump = CrossPlatformInputManager.GetAxis(jumpAxis) > 0.2f;

        if (!testJump)
        {
            m_midJump = false;
        }

        if (testJump && !m_Jump && !m_midJump)
        {
            m_Jump = true;
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetButton(crouchButton);
        float h = CrossPlatformInputManager.GetAxis(xAxis);
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        if (m_Jump)
        {
            m_Jump = false;
            m_midJump = true;
        }
    }
}
