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

    public void GrabMove(Vector2 move) {
        rig.MovePosition(rig.position+ move);
        graber.MovePosition(graber.position+ move);
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
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
