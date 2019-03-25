﻿using System;

public class Distance : Unit
{
	public Distance() : base()
	{
		base.rol = Rol.Distance;

		base.movement 		= 4;
		base.abilityRange 	= 3;

		base.r_lifePoints 	= new int[2]{ 60, 80 };
		base.r_damage 		= new int[2]{ 15, 20 };
		base.r_velocity 	= new int[2]{ 20, 25 };

		base.CalculateAtributes ();
	}

	public override void Ability(){

	}
}