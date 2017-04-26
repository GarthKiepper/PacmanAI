using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

    string up;
    string down;
    string left;
    string right;

    // Array of positions used to contain position of super pellets, pellets (Not using Linked List due to performance)
    public Vector3[] pelletPos;
    public Vector3[] superPelletPos;
    public Vector3 startPos;
    private int pelletTotal;
    private int superPelletTotal;






	// Use this for initialization
	void Start () {


        //startPos = new Vector3() -- Pacman Start Pos

        superPelletTotal = 4;
        pelletTotal = 237;

        pelletPos = new Vector3[pelletTotal];
        superPelletPos = new Vector3[superPelletTotal];

        //Super Pellet Pos
        superPelletPos[0] = new Vector3(-12.5f, 0.5f, 12);
        superPelletPos[1] = new Vector3(12.5f, 0.5f, 12);
        superPelletPos[2] = new Vector3(-12.5f, 0.5f, -8);
        superPelletPos[3] = new Vector3(-12.5f, 0.5f, -8);


        // Pellet through Pellet 23 -- Top line horizontal
        pelletPos[0] = new Vector3(-12.5f, 0.5f, 14);
        pelletPos[1] = new Vector3(-11.5f, 0.5f, 14);
        pelletPos[2] = new Vector3(-9.5f, 0.5f, 14);
        pelletPos[3] = new Vector3(-8.5f, 0.5f, 14);
        pelletPos[4] = new Vector3(-7.5f, 0.5f, 14);
        pelletPos[5] = new Vector3(-6.5f, 0.5f, 14);
        pelletPos[6] = new Vector3(-5.5f, 0.5f, 14);
        pelletPos[7] = new Vector3(-4.5f, 0.5f, 14);
        pelletPos[8] = new Vector3(-3.5f, 0.5f, 14);
        pelletPos[9] = new Vector3(-2.5f, 0.5f, 14);
        pelletPos[10] = new Vector3(-1.5f, 0.5f, 14);
        pelletPos[11] = new Vector3(1.5f, 0.5f, 14);
        pelletPos[12] = new Vector3(2.5f, 0.5f, 14);
        pelletPos[13] = new Vector3(3.5f, 0.5f, 14);
        pelletPos[14] = new Vector3(4.5f, 0.5f, 14);
        pelletPos[15] = new Vector3(6.5f, 0.5f, 14);
        pelletPos[16] = new Vector3(7.5f, 0.5f, 14);
        pelletPos[17] = new Vector3(8.5f, 0.5f, 14);
        pelletPos[18] = new Vector3(9.5f, 0.5f, 14);
        pelletPos[19] = new Vector3(10.5f, 0.5f, 14);
        pelletPos[20] = new Vector3(11.5f, 0.5f, 14);
        pelletPos[21] = new Vector3(12.5f, 0.5f, 14);

        // Pellet 24 through Pellet 29 -- Right Side Top Right
        pelletPos[22] = new Vector3(12.5f, 0.5f, 13);
        pelletPos[23] = new Vector3(12.5f, 0.5f, 11);
        pelletPos[24] = new Vector3(12.5f, 0.5f, 10);
        pelletPos[25] = new Vector3(12.5f, 0.5f, 9);
        pelletPos[26] = new Vector3(12.5f, 0.5f, 8);
        pelletPos[27] = new Vector3(12.5f, 0.5f, 7);

        // Pellet 30 through Pellet 34 -- Top Right Side
        pelletPos[28] = new Vector3(11.5f, 0.5f, 7);
        pelletPos[29] = new Vector3(10.5f, 0.5f, 7);
        pelletPos[30] = new Vector3(9.5f, 0.5f, 7);
        pelletPos[31] = new Vector3(8.5f, 0.5f, 7);
        pelletPos[32] = new Vector3(7.5f, 0.5f, 7);

        // Pellet 35 through Pellet 40 -- Top Right Side
        pelletPos[33] = new Vector3(7.5f, 0.5f, 8);
        pelletPos[34] = new Vector3(7.5f, 0.5f, 9);
        pelletPos[35] = new Vector3(7.5f, 0.5f, 10);
        pelletPos[36] = new Vector3(7.5f, 0.5f, 11);
        pelletPos[37] = new Vector3(7.5f, 0.5f, 12);
        pelletPos[38] = new Vector3(7.5f, 0.5f, 13);

        //Pellet 41 through Pellet 50 -- Top Right Side
        pelletPos[39] = new Vector3(11.5f, 0.5f, 10);
        pelletPos[40] = new Vector3(10.5f, 0.5f, 10);
        pelletPos[41] = new Vector3(9.5f, 0.5f, 10);
        pelletPos[42] = new Vector3(8.5f, 0.5f, 10);
        pelletPos[43] = new Vector3(6.5f, 0.5f, 10);
        pelletPos[44] = new Vector3(5.5f, 0.5f, 10);
        pelletPos[45] = new Vector3(4.5f, 0.5f, 10);
        pelletPos[46] = new Vector3(3.5f, 0.5f, 10);
        pelletPos[47] = new Vector3(2.5f, 0.5f, 10);
        pelletPos[48] = new Vector3(1.5f, 0.5f, 10);

        //Pellet 51 through Pellet 53 -- Middle Top Right
        pelletPos[49] = new Vector3(1.5f, 0.5f, 11);
        pelletPos[50] = new Vector3(1.5f, 0.5f, 12);
        pelletPos[51] = new Vector3(1.5f, 0.5f, 13);

        //Pellet 54 through Pellet 56 -- Middle Top Right
        pelletPos[52] = new Vector3(4.5f, 0.5f, 9);
        pelletPos[53] = new Vector3(4.5f, 0.5f, 8);
        pelletPos[54] = new Vector3(4.5f, 0.5f, 7);

        //Pellet 57 through Pellet 59 -- Middle Top Right
        pelletPos[55] = new Vector3(3.5f, 0.5f, 7);
        pelletPos[56] = new Vector3(2.5f, 0.5f, 7);
        pelletPos[57] = new Vector3(1.5f, 0.5f, 7);

        //Pellet 60 through Pellet 65 -- Right Side Above Warp
        pelletPos[58] = new Vector3(7.5f, 0.5f, 6);
        pelletPos[59] = new Vector3(7.5f, 0.5f, 5);
        pelletPos[60] = new Vector3(7.5f, 0.5f, 4);
        pelletPos[61] = new Vector3(7.5f, 0.5f, 3);
        pelletPos[62] = new Vector3(7.5f, 0.5f, 2);
        pelletPos[63] = new Vector3(7.5f, 0.5f, 1);

        //Pellet 65 through Pellet 69 -- Top Left Side
        pelletPos[64] = new Vector3(-1.5f, 0.5f, 13);
        pelletPos[65] = new Vector3(-1.5f, 0.5f, 12);
        pelletPos[66] = new Vector3(-1.5f, 0.5f, 11);
        pelletPos[67] = new Vector3(-1.5f, 0.5f, 10);

        //Pellet 70 through Pellet 74 -- Middle top
        pelletPos[68] = new Vector3(-0.5f, 0.5f, 10);
        pelletPos[69] = new Vector3(0.5f, 0.5f, 10);
        pelletPos[70] = new Vector3(-2.5f, 0.5f, 10);
        pelletPos[71] = new Vector3(-3.5f, 0.5f, 10);
        pelletPos[72] = new Vector3(-4.5f, 0.5f, 10);

        //Pellet 75 through Pellet 77 -- Middle left
        pelletPos[73] = new Vector3(-4.5f, 0.5f, 9);
        pelletPos[74] = new Vector3(-4.5f, 0.5f, 8);
        pelletPos[75] = new Vector3(-4.5f, 0.5f, 7);

        //Pellet 78 through Pellet 80 -- Middle left
        pelletPos[76] = new Vector3(-3.5f, 0.5f, 7);
        pelletPos[77] = new Vector3(-2.5f, 0.5f, 7);
        pelletPos[78] = new Vector3(-1.5f, 0.5f, 7);

        //Pellet 81 through Pellet 83 -- Top Left
        pelletPos[79] = new Vector3(-5.5f, 0.5f, 10);
        pelletPos[80] = new Vector3(-6.5f, 0.5f, 10);
        pelletPos[81] = new Vector3(-7.5f, 0.5f, 10);

        //Pellet 84 through Pellet 86 -- Top Left
        pelletPos[82] = new Vector3(-7.5f, 0.5f, 11);
        pelletPos[83] = new Vector3(-7.5f, 0.5f, 12);
        pelletPos[84] = new Vector3(-7.5f, 0.5f, 13);

        //Pellet 87 through Pellet 90 -- Top Left Side
        pelletPos[85] = new Vector3(-12.5f, 0.5f, 13);
        pelletPos[86] = new Vector3(-12.5f, 0.5f, 11);
        pelletPos[87] = new Vector3(-12.5f, 0.5f, 10);

        //Pellet 91 through Pellet 94 -- Top Left
        pelletPos[88] = new Vector3(-11.5f, 0.5f, 10);
        pelletPos[89] = new Vector3(-10.5f, 0.5f, 10);
        pelletPos[90] = new Vector3(-9.5f, 0.5f, 10);
        pelletPos[91] = new Vector3(-8.5f, 0.5f, 10);

        //Pellet 95 through Pellet 97 -- Top Left Side
        pelletPos[92] = new Vector3(-12.5f, 0.5f, 9);
        pelletPos[93] = new Vector3(-12.5f, 0.5f, 8);
        pelletPos[94] = new Vector3(-12.5f, 0.5f, 7);

        //Pellet 98 through Pellet 101 -- Top Left Side
        pelletPos[95] = new Vector3(-11.5f, 0.5f, 7);
        pelletPos[96] = new Vector3(-10.5f, 0.5f, 7);
        pelletPos[97] = new Vector3(-8.5f, 0.5f, 7);   // This is marked as pellet 100 but its 1 ahead of pellet 101
        pelletPos[98] = new Vector3(-9.5f, 0.5f, 7);

        //Pellet 102 through Pellet 116 -- Left Side Along the Warp wall
        pelletPos[99] = new Vector3(-7.5f, 0.5f, 9);
        pelletPos[100] = new Vector3(-7.5f, 0.5f, 8);
        pelletPos[101] = new Vector3(-7.5f, 0.5f, 7);
        pelletPos[102] = new Vector3(-7.5f, 0.5f, 6);
        pelletPos[103] = new Vector3(-7.5f, 0.5f, 5);
        pelletPos[104] = new Vector3(-7.5f, 0.5f, 4);
        pelletPos[105] = new Vector3(-7.5f, 0.5f, 3);
        pelletPos[106] = new Vector3(-7.5f, 0.5f, 2);
        pelletPos[107] = new Vector3(-7.5f, 0.5f, 1);
        pelletPos[108] = new Vector3(-7.5f, 0.5f, 0);
        pelletPos[109] = new Vector3(-7.5f, 0.5f, -1);
        pelletPos[110] = new Vector3(-7.5f, 0.5f, -2);
        pelletPos[111] = new Vector3(-7.5f, 0.5f, -3);
        pelletPos[112] = new Vector3(-7.5f, 0.5f, -4);
        pelletPos[113] = new Vector3(-7.5f, 0.5f, -5);

        //Pellet 117 through Pellet 122 -- Bottom Left Middle
        pelletPos[114] = new Vector3(-6.5f, 0.5f, -5);
        pelletPos[115] = new Vector3(-5.5f, 0.5f, -5);
        pelletPos[116] = new Vector3(-4.5f, 0.5f, -5);
        pelletPos[117] = new Vector3(-3.5f, 0.5f, -5);
        pelletPos[118] = new Vector3(-2.5f, 0.5f, -5);
        pelletPos[119] = new Vector3(-1.5f, 0.5f, -5);

        //Pellet 123 through Pellet 127 -- Bottom Left Side
        pelletPos[120] = new Vector3(-8.5f, 0.5f, -5);
        pelletPos[121] = new Vector3(-9.5f, 0.5f, -5);
        pelletPos[122] = new Vector3(-10.5f, 0.5f, -5);
        pelletPos[123] = new Vector3(-11.5f, 0.5f, -5);
        pelletPos[124] = new Vector3(-12.5f, 0.5f, -5);

        //Pellet 128 through Pellet  139 -- Bottom Right Middle
        pelletPos[125] = new Vector3(1.5f, 0.5f, -5);
        pelletPos[126] = new Vector3(2.5f, 0.5f, -5);
        pelletPos[127] = new Vector3(3.5f, 0.5f, -5);
        pelletPos[128] = new Vector3(4.5f, 0.5f, -5);
        pelletPos[129] = new Vector3(5.5f, 0.5f, -5);
        pelletPos[130] = new Vector3(6.5f, 0.5f, -5);
        pelletPos[131] = new Vector3(7.5f, 0.5f, -5);
        pelletPos[132] = new Vector3(8.5f, 0.5f, -5);
        pelletPos[133] = new Vector3(10.5f, 0.5f, -5); // this marked as Pellet 136 and is ahead of 134 in the array
        pelletPos[134] = new Vector3(9.5f, 0.5f, -5);
        pelletPos[135] = new Vector3(11.5f, 0.5f, -5);
        pelletPos[136] = new Vector3(12.5f, 0.5f, -5);

        //Pellet 140 through Pellet 144 -- Right Side Below Warp
        pelletPos[137] = new Vector3(7.5f, 0.5f, 0);
        pelletPos[138] = new Vector3(7.5f, 0.5f, -1);
        pelletPos[139] = new Vector3(7.5f, 0.5f, -2);
        pelletPos[140] = new Vector3(7.5f, 0.5f, -3);
        pelletPos[141] = new Vector3(7.5f, 0.5f, -4);

        //Pellet 145 through Pellet 175 -- Bottom Right
        pelletPos[142] = new Vector3(12.5f, 0.5f, -6);
        pelletPos[143] = new Vector3(12.5f, 0.5f, -7);
        pelletPos[144] = new Vector3(11.5f, 0.5f, -8);
        pelletPos[145] = new Vector3(10.5f, 0.5f, -8);
        pelletPos[146] = new Vector3(10.5f, 0.5f, -9);
        pelletPos[147] = new Vector3(10.5f, 0.5f, -10);
        pelletPos[148] = new Vector3(10.5f, 0.5f, -11);
        pelletPos[149] = new Vector3(9.5f, 0.5f, -11);
        pelletPos[150] = new Vector3(8.5f, 0.5f, -11);
        pelletPos[151] = new Vector3(7.5f, 0.5f, -11);
        pelletPos[152] = new Vector3(7.5f, 0.5f, -10);
        pelletPos[153] = new Vector3(7.5f, 0.5f, -9);
        pelletPos[154] = new Vector3(7.5f, 0.5f, -8);
        pelletPos[155] = new Vector3(7.5f, 0.5f, -7);
        pelletPos[156] = new Vector3(7.5f, 0.5f, -6);
        pelletPos[157] = new Vector3(6.5f, 0.5f, -8);
        pelletPos[158] = new Vector3(5.5f, 0.5f, -8);
        pelletPos[159] = new Vector3(4.5f, 0.5f, -8);
        pelletPos[160] = new Vector3(3.5f, 0.5f, -8);
        pelletPos[161] = new Vector3(2.5f, 0.5f, -8);
        pelletPos[162] = new Vector3(1.5f, 0.5f, -8);
        pelletPos[163] = new Vector3(1.5f, 0.5f, -7);
        pelletPos[164] = new Vector3(1.5f, 0.5f, -6);
        pelletPos[165] = new Vector3(4.5f, 0.5f, -9);
        pelletPos[166] = new Vector3(4.5f, 0.5f, -10);
        pelletPos[167] = new Vector3(4.5f, 0.5f, -11);
        pelletPos[168] = new Vector3(3.5f, 0.5f, -11);
        pelletPos[169] = new Vector3(2.5f, 0.5f, -11);
        pelletPos[170] = new Vector3(1.5f, 0.5f, -11);
        pelletPos[171] = new Vector3(1.5f, 0.5f, -12);
        pelletPos[172] = new Vector3(1.5f, 0.5f, -13);

        //Pellet 176 through 211 -- Bottom Right
        pelletPos[173] = new Vector3(-12.5f, 0.5f, -6);
        pelletPos[174] = new Vector3(-12.5f, 0.5f, -7);
        pelletPos[175] = new Vector3(-11.5f, 0.5f, -8);
        pelletPos[176] = new Vector3(-10.5f, 0.5f, -8);
        pelletPos[177] = new Vector3(-10.5f, 0.5f, -9);
        pelletPos[178] = new Vector3(-10.5f, 0.5f, -10);
        pelletPos[179] = new Vector3(-10.5f, 0.5f, -11);
        pelletPos[180] = new Vector3(-11.5f, 0.5f, -11);
        pelletPos[181] = new Vector3(-12.5f, 0.5f, -11);
        pelletPos[182] = new Vector3(-12.5f, 0.5f, -12);
        pelletPos[183] = new Vector3(-12.5f, 0.5f, -13);
        pelletPos[184] = new Vector3(-12.5f, 0.5f, -14);
        pelletPos[185] = new Vector3(-9.5f, 0.5f, -11);
        pelletPos[186] = new Vector3(-7.5f, 0.5f, -11);
        pelletPos[187] = new Vector3(-8.5f, 0.5f, -11);
        pelletPos[188] = new Vector3(-7.5f, 0.5f, -9);
        pelletPos[189] = new Vector3(-7.5f, 0.5f, -10);
        pelletPos[190] = new Vector3(-7.5f, 0.5f, -8);
        pelletPos[191] = new Vector3(-7.5f, 0.5f, -6);
        pelletPos[192] = new Vector3(-7.5f, 0.5f, -7);
        pelletPos[193] = new Vector3(-6.5f, 0.5f, -8);
        pelletPos[194] = new Vector3(-5.5f, 0.5f, -8);
        pelletPos[195] = new Vector3(-4.5f, 0.5f, -8);
        pelletPos[196] = new Vector3(-3.5f, 0.5f, -8);
        pelletPos[197] = new Vector3(-2.5f, 0.5f, -8);
        pelletPos[198] = new Vector3(-1.5f, 0.5f, -6);
        pelletPos[199] = new Vector3(-1.5f, 0.5f, -7);
        pelletPos[200] = new Vector3(-1.5f, 0.5f, -8);
        pelletPos[201] = new Vector3(-4.5f, 0.5f, -9);
        pelletPos[202] = new Vector3(-4.5f, 0.5f, -10);
        pelletPos[203] = new Vector3(-4.5f, 0.5f, -11);
        pelletPos[204] = new Vector3(-3.5f, 0.5f, -11);
        pelletPos[205] = new Vector3(-2.5f, 0.5f, -11);
        pelletPos[206] = new Vector3(-1.5f, 0.5f, -11);
        pelletPos[207] = new Vector3(-1.5f, 0.5f, -12);
        pelletPos[208] = new Vector3(-1.5f, 0.5f, -13);

        //Pellet 212 through Pellet 216 -- Bottom Right
        pelletPos[209] = new Vector3(11.5f, 0.5f, -11);
        pelletPos[210] = new Vector3(12.5f, 0.5f, -11);
        pelletPos[211] = new Vector3(12.5f, 0.5f, -12);
        pelletPos[212] = new Vector3(12.5f, 0.5f, -13);
        pelletPos[213] = new Vector3(12.5f, 0.5f, -14);

        //Pellet 217 through Pellet 240 -- Bottom Row of Pellets
        pelletPos[214] = new Vector3(11.5f, 0.5f, -14);
        pelletPos[215] = new Vector3(10.5f, 0.5f, -14);
        pelletPos[216] = new Vector3(9.5f, 0.5f, -14);
        pelletPos[217] = new Vector3(8.5f, 0.5f, -14);
        pelletPos[218] = new Vector3(7.5f, 0.5f, -14);
        pelletPos[219] = new Vector3(6.5f, 0.5f, -14);
        pelletPos[220] = new Vector3(5.5f, 0.5f, -14);
        pelletPos[221] = new Vector3(4.5f, 0.5f, -14);
        pelletPos[222] = new Vector3(3.5f, 0.5f, -14);
        pelletPos[223] = new Vector3(2.5f, 0.5f, -14);
        pelletPos[224] = new Vector3(1.5f, 0.5f, -14);
        pelletPos[225] = new Vector3(0.5f, 0.5f, -14);
        pelletPos[226] = new Vector3(-0.5f, 0.5f, -14);
        pelletPos[227] = new Vector3(-1.5f, 0.5f, -14);
        pelletPos[228] = new Vector3(-2.5f, 0.5f, -14);
        pelletPos[229] = new Vector3(-3.5f, 0.5f, -14);
        pelletPos[230] = new Vector3(-4.5f, 0.5f, -14);
        pelletPos[231] = new Vector3(-5.5f, 0.5f, -14);
        pelletPos[232] = new Vector3(-6.5f, 0.5f, -14);
        pelletPos[233] = new Vector3(-7.5f, 0.5f, -14);
        pelletPos[234] = new Vector3(-8.5f, 0.5f, -14);
        pelletPos[235] = new Vector3(-9.5f, 0.5f, -14);
        pelletPos[236] = new Vector3(-10.5f, 0.5f, -14);
        pelletPos[237] = new Vector3(-11.5f, 0.5f, -14);




    }

	// Update is called once per frame
	void Update () {

	}
}
