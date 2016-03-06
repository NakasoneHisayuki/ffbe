using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class unitStatus {
	
	public enum unitType {
		//		fighter,
		//		lancer,
		//		samurai,
		//		rider,
		//		archer,
		blueknight,
		redknight,
		priest,
		knight,
		elf,
		magician
	}
	public unitType unit_type;
	public string name;
	public int max_hp;
	public int power;
	public int moving_distance;
	public int attack_distance;
	public int attack_range;
	public int attack_direction;
	public GameObject bodyPlayer1;
	public GameObject bodyPlayer2;
	public Sprite unit_img_player1;
	public Sprite unit_img_player2;
}

public class TestModel : ScriptableObject {
	
	public List<unitStatus> unitModelList;
}
