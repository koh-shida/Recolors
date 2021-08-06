using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrabedObject : MonoBehaviour
{

    Rigidbody2D rig;
    Rigidbody2D graber;

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
    }

    public bool IsGrab { get; private set; }

    public void GrabMove(float move) {
        var g1 = rig.velocity;
        var g2 = graber.velocity;
        g1.x = move;
        g2.x = move;

        if (rig.position.x > graber.position.x && move < 0 ||
            rig.position.x < graber.position.x && move > 0) {
            g1.x *= 1.5f;
        }

        rig.velocity=g1;
        graber.velocity=g2;

    }
    public void GrabBegin(Rigidbody2D transform) {
        GrabEnd();

        graber = transform;
        IsGrab = true;

        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void GrabEnd() {
        IsGrab = false;
        graber = null;
        rig.constraints = RigidbodyConstraints2D.FreezeRotation|RigidbodyConstraints2D.FreezePositionX;
    }
}
