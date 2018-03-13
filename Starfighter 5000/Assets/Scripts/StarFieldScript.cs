using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldScript : MonoBehaviour {

    private Transform thisTransform;
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1f;
    public float starDistance = 10f;
    public float starClipDistance = 1f;

        private float starDistanceSqr;
    private float starClipDistanceSqr;

    // Use this for initialization
	void Start () {
        thisTransform = transform;  //caching transform for this obj
        starClipDistanceSqr = starClipDistance * starClipDistance;
	}
	
    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for(int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
            points[i].startColor = new Color(1, 1, 1, 1);
            points[i].startSize = starSize;
        }
    }

	// Update is called once per frame
	void Update () {
        if(points == null)
        {
            CreateStars();
        }
        for(int i = 0; i < starsMax; i++)
        {
            if((points[i].position - thisTransform.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
            }
            if((points[i].position - thisTransform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(1, 1, 1, percent);
                points[i].startSize = percent * starSize;
            }
            GetComponent<ParticleSystem>().SetParticles(points, points.Length);
        }
	}
}
