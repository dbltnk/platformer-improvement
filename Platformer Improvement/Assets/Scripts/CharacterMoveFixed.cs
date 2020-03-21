using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMoveFixed : MonoBehaviour
{
    void FixedUpdate () {
        MoveHero();
        StartCoroutine("JumpHero");
    }

    void PlayAnimation (string AnimName) {
        if (!GetComponent<Animation>().IsPlaying(AnimName))
            GetComponent<Animation>().CrossFadeQueued(AnimName, 0.3f, QueueMode.PlayNow);
    }

    void CheckForIdle () {
        if (GetComponent<Animation>().IsPlaying("run")) PlayAnimation("idle");
        if (!GetComponent<Animation>().isPlaying) GetComponent<Animation>().Play("idle");
    }

    void MoveHero () {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2) {
            float y = 0f;
            if (Input.GetAxis("Horizontal") > 0.02) y = -90f;
            else if (Input.GetAxis("Horizontal") < -0.02) y = 90f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
            transform.Translate(Vector3.forward * Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime * 3.5f);
            if (!GetComponent<Animation>().IsPlaying("jump")) PlayAnimation("run");
        } else CheckForIdle();
    }

    float nextJump;

    IEnumerator JumpHero () {
        if (Input.GetButton("Jump") && nextJump < Time.time) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 25000);
            PlayAnimation("jump");
            nextJump = Time.time + 1;
            yield return new WaitForSeconds(0.7f);
            PlayAnimation("idle");
        }
    }

    void OnCollisionEnter (Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            if (contact.otherCollider.name == "GameFinish")
                SceneManager.LoadScene("gameFinish");
        }
    }
}
