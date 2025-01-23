using UnityEngine;
using System.Collections.Generic;

public class ParticleSystem : MonoBehaviour
{
    [Header("Particle Settings")]
    public int maxParticles = 3000000; // Anzahl der Partikel
    public float particleSize = 0.1f;  // Größe der Partikel
    public Mesh particleMesh;         // Partikel-Mesh für die Partikelverarbeitung
    public Material particleMaterial; // Material für die Partikel

    [Header("Compute Shader Settings")]
    public ComputeShader computeShader;

    private ComputeBuffer particleBuffer;
    private ComputeBuffer argsBuffer;

    private uint[] args = new uint[5] { 0, 0, 0, 0, 0 };
    private int kernelHandle;

    struct Particle
    {
        public Vector3 position;
        public Vector3 velocity;
        public Color color;
    }

    void Start()
    {
        InitializeBuffers();
    }

    void Update()
    {
        UpdateParticles();
        DrawParticles();
    }

    void InitializeBuffers()
    {
        // Compute Shader Kernel
        kernelHandle = computeShader.FindKernel("CSMain");

        // Particle Buffer
        particleBuffer = new ComputeBuffer(maxParticles, sizeof(float) * 10);

        Particle[] particles = new Particle[maxParticles];
        for (int i = 0; i < maxParticles; i++)
        {
            particles[i] = new Particle()
            {
                position = Random.insideUnitSphere * 10.0f,
                velocity = Random.insideUnitSphere * 0.1f,
                color = new Color(Random.value, Random.value, Random.value, 1.0f)
            };
        }
        particleBuffer.SetData(particles);

        // Argument Buffer for DrawMeshInstancedIndirect
        argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        if (particleMesh != null)
        {
            args[0] = (uint)particleMesh.GetIndexCount(0);
            args[1] = (uint)maxParticles;
            args[2] = (uint)particleMesh.GetIndexStart(0);
            args[3] = (uint)particleMesh.GetBaseVertex(0);
        }
        argsBuffer.SetData(args);

        // Bind Buffers to Compute Shader
        computeShader.SetBuffer(kernelHandle, "particles", particleBuffer);
    }

    void UpdateParticles()
    {
        computeShader.SetFloat("deltaTime", Time.deltaTime);
        computeShader.Dispatch(kernelHandle, maxParticles / 1024, 1, 1);
    }

    void DrawParticles()
    {
        particleMaterial.SetBuffer("particles", particleBuffer);
        Graphics.DrawMeshInstancedIndirect(particleMesh, 0, particleMaterial, new Bounds(Vector3.zero, Vector3.one * 1000), argsBuffer);
    }

    void OnDestroy()
    {
        if (particleBuffer != null)
            particleBuffer.Release();

        if (argsBuffer != null)
            argsBuffer.Release();
    }
}