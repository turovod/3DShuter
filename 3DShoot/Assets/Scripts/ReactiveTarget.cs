using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if (behavior != null) behavior.SetAlive(false);

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(75, 0, 0);

        for (float i = 1; i < 2; i += 0.05f)
        {
            transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }

        float shakyScale = 0.1f;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                transform.localScale = new Vector3(transform.localScale.x + shakyScale, transform.localScale.y
                + shakyScale, transform.localScale.z + shakyScale);

                yield return new WaitForSeconds(0.01f);
            }
            

            shakyScale *= -1;

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
