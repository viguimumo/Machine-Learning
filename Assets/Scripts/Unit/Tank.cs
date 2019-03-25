using System;

public class Tank : Unit 
{	
	public Tank() : base()
	{
		base.rol = Rol.Tank;

		base.movement = 3;
		base.abilityRange = -1;

		base.r_lifePoints = new int[2]{ 60, 80 };
		base.r_damage = new int[2]{ 15, 20 };
		base.r_velocity = new int[2]{ 20, 25 };

		base.CalculateAtributes ();
	}

	public override void Ability(){

	}
}

