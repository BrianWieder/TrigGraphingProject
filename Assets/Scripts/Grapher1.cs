using UnityEngine;

public class Grapher1 : MonoBehaviour {

    [SerializeField]
    [Range(10,1000)]
    private int resolution = 10;

    [SerializeField]
    private float visualLength = 10f;

    [SerializeField]
    private float zValue = 10f;

    private float currentVisualLength = 0;
    private int currentResolution;
    private ParticleSystem customParticleSystem;
    private ParticleSystem.Particle[] points;

    private void Start()
    {
        customParticleSystem = GetComponent<ParticleSystem>();
        CreatePoints();
    }

    private void CreatePoints()
    {
        currentResolution = resolution;

        points = new ParticleSystem.Particle[resolution * resolution];
        float increment = visualLength / (resolution - 1);
        float zIncrement = zValue / (resolution - 1);
        int i = 0;
        for (int x = 0; x < resolution; x++)
        {
            for (int z = 0; z < resolution; z++)
            {
                Vector3 p = new Vector3(x * increment, 0f, z * zIncrement);
                points[i].position = p;
                points[i].startColor = new Color(p.x, 0f, p.z);
                points[i++].startSize = 0.1f;
            }
        }
    }

    private void Update()
    {
        if(currentResolution != resolution || points == null)
        {
            CreatePoints();
        }
        
        if(currentVisualLength != visualLength)
        {
            currentVisualLength = visualLength;
            //Camera.main.transform.position = new Vector3(visualLength / 2, Camera.main.transform.position.y, Camera.main.transform.position.z);
            CreatePoints();
        }

        for (int i = 0; i < points.Length; i++)
        {
            Vector3 p = points[i].position;
            p.y = sine(p.x);
            points[i].position = p;
            Color c = points[i].GetCurrentColor(customParticleSystem);
            c.g = p.y;
            points[i].startColor = c;
        }
        customParticleSystem.SetParticles(points, points.Length);
    }

    private float sine(float x)
    {
        return (Manager.instance.getAValue() * Mathf.Sin((Manager.instance.getBValue() * x) - Manager.instance.getCValue())) + Manager.instance.getDValue();
    }

}
