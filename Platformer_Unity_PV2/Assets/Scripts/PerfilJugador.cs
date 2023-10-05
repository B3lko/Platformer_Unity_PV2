using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador" )]
public class PerfilJugador : ScriptableObject
{


    [Header("Movimiento Horizontal")]
    [SerializeField] float WalkSpeed = 5f;
    public float WalkSpeed1 { get => WalkSpeed; set => WalkSpeed = value; }
    [SerializeField] float RunSpeed = 10f;
    public float RunSpeed1 { get => RunSpeed; set => RunSpeed = value; }



    [Header("Jump")]
    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }
    [SerializeField] private AudioClip JumpSFX;
    public AudioClip JumpSFX1 { get => JumpSFX; set => JumpSFX = value; }
    [SerializeField] private AudioClip CollisionSFX;
    public AudioClip CollisionSFX1 { get => CollisionSFX; set => CollisionSFX = value; }




    [Header("Lifes")]
    [SerializeField] private float vida = 5f;
    public float Vida { get => vida; set => vida = value; }
    [SerializeField] private float InmortalTime;
    public float InmortalTime1 { get => InmortalTime; set => InmortalTime = value; }
    [SerializeField] private  float intervaloParpadeo = 0.5f;
    public float IntervaloParpadeo { get => intervaloParpadeo; set => intervaloParpadeo = value; }



    [Header("Progresion")]
    [SerializeField] private int xPNextLevel;
    public int XPNextLevel { get => xPNextLevel; set => xPNextLevel = value; }
    [SerializeField] private int scaleXp;
    public int ScaleXp { get => scaleXp; set => scaleXp = value; }
    private int Level;
    public int level { get => Level; set => Level = value;}
    private int xP;
    public int XP { get => xP; set => xP = value; }
}