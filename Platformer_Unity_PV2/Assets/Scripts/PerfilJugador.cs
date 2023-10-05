using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador" )]
public class PerfilJugador : ScriptableObject
{
    //[SerializeField]
    [Header("Movimiento Horizontal")]
   // [Header("Movimiento Horizontal")]
    [SerializeField] float WalkSpeed = 5f;
    public float WalkSpeed1 { get => WalkSpeed; set => WalkSpeed = value; }

    [SerializeField] float RunSpeed = 10f;
    public float RunSpeed1 { get => RunSpeed; set => RunSpeed = value; }

    //[SerializeField]
    //[Tooltip("Experiencia y Nivel")] 
    //[Header("Experiencia y Nivel")]
    private int Level;
    public int level { get => Level; set => Level = value;}
    private int xP;
    public int XP { get => xP; set => xP = value; }

    [SerializeField] private int xPNextLevel;
    public int XPNextLevel { get => xPNextLevel; set => xPNextLevel = value; }
    [SerializeField] private int scaleXp;
    public int ScaleXp { get => scaleXp; set => scaleXp = value; }
}