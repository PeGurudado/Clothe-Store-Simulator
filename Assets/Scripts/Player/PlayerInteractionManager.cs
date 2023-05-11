using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] float interactionRadios = 2;

    [SerializeField] LayerMask interactionLayerMask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, interactionRadios, interactionLayerMask);
            if (collider == null) return;

            collider.GetComponent<DialogHandler>().InitiateDialog();
        }
    }
}
