﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class StageManager : MonoBehaviour {

	public List<int[,]> Stage1;
	public int[ , ] TempStage;

	private int[ , ] Stage1_1 =
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 13, 2, 2, 2, 0},
	{0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 12, 0, 0, 0, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};

	private int[ , ] Stage1_2 = 
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 13, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 1, 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 12, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 12, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};

	private int[ , ] Stage1_3 = 
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
	{0, 13, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 13, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 13, 2, 2, 2, 2, 2, 2, 2, 2, 13, 0},
	{0, 12, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 12, 0, 0, 2, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 12, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 14, 0, 12, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 0, 0, 0, 0, 0, 12, 0},
	{0, 2, 2, 13, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 13, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 13, 2, 2, 2, 13, 2, 2, 2, 2, 2, 0},
	{0, 0, 0, 12, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 12, 0, 0, 0, 0, 0, 0},
	{0, 1, 0, 12, 2, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 12, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 12, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 2, 0, 12, 0, 0, 5, 0, 6, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};

	private int[ , ] Stage1_4 = 
	{{03, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 03},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 05, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 13, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 01, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 0, 00, 00, 00, 06, 00},
	{00, 02, 02, 02, 00, 00, 02, 00, 00, 02, 00, 00, 02, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 02, 00, 02, 02, 02, 00}};

	private int[ , ] Stage1_5 = 
	{{03, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 03},
	{00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 04, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00},
	{00, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 06, 00, 00},
	{00, 02, 13, 02, 02, 02, 13, 02, 02, 02, 13, 02, 02, 02, 13, 02, 02, 02, 02, 02, 02, 02, 13, 02, 02, 02, 13, 02, 02, 02, 13, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 13, 02, 00},
	{00, 00, 12, 00, 00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 02, 00, 12, 00, 00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 12, 00, 00},
	{00, 00, 12, 00, 00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 02, 00, 12, 00, 05, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 12, 00, 00},
	{00, 00, 12, 00, 02, 00, 12, 00, 02, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 02, 00, 12, 00, 02, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 00, 12, 00, 00},
	{00, 02, 13, 02, 02, 02, 13, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 13, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 13, 02, 02, 02, 13, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 13, 02, 00},
	{00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00},
	{00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00},
	{00, 01, 12, 00, 02, 00, 12, 00, 05, 00, 00, 00, 04, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 12, 00, 02, 00, 12, 00, 00, 00, 00, 00, 02, 00, 00, 02, 14, 12, 05, 00},
		{00, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 02, 00}};

	private int[ , ] Stage1_6 = 
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0},
	{0, 0, 0, 0, 13, 0, 0, 0, 13, 0, 0, 0, 13, 0, 0, 0},
	{0, 0, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0},
	{0, 1, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0},
	{0, 0, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0, 12, 0, 0, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};

	private int[ , ] Stage1_7 = 
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 9, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};

	private int[ , ] Stage1_8 = 
	{{3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0},
	{0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 1, 0, 12, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 5, 0, 0},
	{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};


	private int[ , ] Stage1_9 = 
	{{03, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 15, 03},
	{00, 00, 01, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00},
	{00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00},
	{00, 02, 02, 02, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 05, 00, 00, 00, 00, 12, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 02, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 02, 02, 02, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 16, 00, 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 00},
	{00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00}};

	void Start()
	{
		Stage1 = new List<int[,]>();
		Stage1.Add ( Stage1_1 );
		Stage1.Add ( Stage1_2 );
		Stage1.Add ( Stage1_3 );
		Stage1.Add ( Stage1_4 );
		Stage1.Add ( Stage1_5 );
		Stage1.Add ( Stage1_6 );
		Stage1.Add ( Stage1_7 );
		Stage1.Add ( Stage1_8 );
		Stage1.Add ( Stage1_9 );
	}
}