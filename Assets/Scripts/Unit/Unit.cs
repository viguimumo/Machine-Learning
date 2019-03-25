using System;
using System.Collections;
using UnityEngine;

public class Unit
{
	protected Rol rol;

	private 	int lifePoints;
	private 	int life;
	protected	int movement;
	protected 	int abilityRange;
	private 	int damage;
	private 	int velocity;

	protected int[] r_lifePoints = new int[2];
	protected int[] r_velocity = new int[2];
	protected int[] r_damage = new int[2];

	public Unit () {}

	public Rol GetRol()			{ return rol; }	
	public int GetMovement()	{ return movement; }
	public int GetDamage()		{ return damage; }

	public int Life{
		get{ return life; }
		set{ life = value; }
	}

	public enum Rol{ Healer, Tank, Distance, Mele }

	public void Attack(){
	}

	public void Move(){
	}

	public void None(){
	}

	public virtual void Ability() {}

	protected void CalculateAtributes(){
		lifePoints 	= UnityEngine.Random.Range (r_lifePoints[0], r_lifePoints[1]);
		velocity 	= UnityEngine.Random.Range (r_velocity [0],  r_velocity [1]);
		damage 		= UnityEngine.Random.Range (r_damage[0], 	 r_damage[1]);
	}
}