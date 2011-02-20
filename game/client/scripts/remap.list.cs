//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

// These link a description to a function in remap.functions.cs.
// To recreate these from scratch do something like:
// #!/bin/rc
// i = 1
// for(cmd in `{9 grep '^function ' < remap.functions.cs \
//     | 9 sed 's/function //g;s/\(.*//g'})
// {
//   echo '$RemapName['$i'] = "";'
//   echo '$RemapCmd['$i'] = "'$cmd'";'
//   i = `{expr $i + 1}
// }

$RemapName[1] = "Toggle in-game shell";
$RemapCmd[1] = "toggleShellDlg";
$RemapName[2] = "Free look";
$RemapCmd[2] = "freeLook";
$RemapName[3] = "Toggle first person";
$RemapCmd[3] = "toggleFirstPerson";
$RemapName[4] = "Strafe left";
$RemapCmd[4] = "moveleft";
$RemapName[5] = "Strafe right";
$RemapCmd[5] = "moveright";
$RemapName[6] = "Move forward";
$RemapCmd[6] = "moveforward";
$RemapName[7] = "Move backward";
$RemapCmd[7] = "movebackward";
$RemapName[8] = "Move up";
$RemapCmd[8] = "moveup";
$RemapName[9] = "Move down";
$RemapCmd[9] = "movedown";
$RemapName[10] = "Turn left";
$RemapCmd[10] = "turnLeft";
$RemapName[11] = "Turn right";
$RemapCmd[11] = "turnRight";
$RemapName[12] = "Look up";
$RemapCmd[12] = "panUp";
$RemapName[13] = "Look down";
$RemapCmd[13] = "panDown";
$RemapName[14] = "";
$RemapCmd[14] = "yaw";
$RemapName[15] = "";
$RemapCmd[15] = "pitch";
$RemapName[16] = "Trigger #0 (Fire)";
$RemapCmd[16] = "trigger0";
$RemapName[17] = "Trigger #1 (Disc)";
$RemapCmd[17] = "trigger1";
$RemapName[18] = "Trigger #2 (Jump)";
$RemapCmd[18] = "trigger2";
$RemapName[19] = "Trigger #3 (Grenade)";
$RemapCmd[19] = "trigger3";
$RemapName[20] = "Trigger #4 (Walk)";
$RemapCmd[20] = "trigger4";
$RemapName[21] = "Trigger #5 (Slide)";
$RemapCmd[21] = "trigger5";
$RemapName[22] = "Toggle zoom level";
$RemapCmd[22] = "toggleZoomLevel";
$RemapName[23] = "Zoom";
$RemapCmd[23] = "zoom";
$RemapName[24] = "";
$RemapCmd[24] = "mouseZoom";
$RemapName[25] = "Global chat";
$RemapCmd[25] = "toggleMessageHud";
$RemapName[26] = "Team chat";
$RemapCmd[26] = "teamMessageHud";
$RemapName[27] = "Messages scroll up";
$RemapCmd[27] = "pageMessageHudUp";
$RemapName[28] = "Messages scroll down";
$RemapCmd[28] = "pageMessageHudDown";
$RemapName[29] = "Resize message box";
$RemapCmd[29] = "resizeMessageHud";
$RemapName[30] = "Grow minimap";
$RemapCmd[30] = "biggerMiniMap";
$RemapName[31] = "Activate commander screen";
$RemapCmd[31] = "activateCmdrScreen";
$RemapName[32] = "Toggle demo recording";
$RemapCmd[32] = "toggleRecordingDemo";
$RemapName[33] = "Take screenshot";
$RemapCmd[33] = "takeScreenshot";
$RemapName[34] = "Action #0 (Switch Form)";
$RemapCmd[34] = "action0";
$RemapName[35] = "Action #1 (Weapon 1)";
$RemapCmd[35] = "action1";
$RemapName[36] = "Action #2 (Weapon 2)";
$RemapCmd[36] = "action2";
$RemapName[37] = "Action #3 (Weapon 3)";
$RemapCmd[37] = "action3";
$RemapName[38] = "Action #4 (Weapon 4)";
$RemapCmd[38] = "action4";
$RemapName[39] = "Action #5 (Weapon 5)";
$RemapCmd[39] = "action5";
$RemapName[40] = "Action #6 (Weapon 6)";
$RemapCmd[40] = "action6";
$RemapName[41] = "Action #7 (Weapon 7)";
$RemapCmd[41] = "action7";
$RemapName[42] = "Action #8 (Weapon 8)";
$RemapCmd[42] = "action8";
$RemapName[43] = "Action #9 (Weapon 9)";
$RemapCmd[43] = "action9";
$RemapName[44] = "Action #10 (Weapon 10)";
$RemapCmd[44] = "action10";
$RemapName[45] = "Action #11 (Cycle Weapons)";
$RemapCmd[45] = "action11";
$RemapName[46] = "Action #12 (Max. force grenade throw)";
$RemapCmd[46] = "action12";
$RemapName[47] = "Action #13 (Temp. use Sniper ROFL)";
$RemapCmd[47] = "action13";
$RemapName[48] = "Action #14";
$RemapCmd[48] = "action14";
$RemapName[49] = "Action #15";
$RemapCmd[49] = "action15";
$RemapName[50] = "Action #16";
$RemapCmd[50] = "action16";
$RemapName[51] = "Action #17";
$RemapCmd[51] = "action17";
$RemapName[52] = "Action #18";
$RemapCmd[52] = "action18";
$RemapName[53] = "Action #19";
$RemapCmd[53] = "action19";
$RemapName[54] = "Action #20";
$RemapCmd[54] = "action20";
$RemapName[55] = "Action #21";
$RemapCmd[55] = "action21";
$RemapName[56] = "Action #22";
$RemapCmd[56] = "action22";
$RemapName[57] = "Action #23";
$RemapCmd[57] = "action23";
$RemapName[58] = "Action #24";
$RemapCmd[58] = "action24";
$RemapName[59] = "Action #25";
$RemapCmd[59] = "action25";
$RemapName[60] = "Action #26";
$RemapCmd[60] = "action26";
$RemapName[61] = "Action #27";
$RemapCmd[61] = "action27";
$RemapName[62] = "Action #28";
$RemapCmd[62] = "action28";
$RemapName[63] = "Action #29";
$RemapCmd[63] = "action29";
$RemapName[64] = "Action #30";
$RemapCmd[64] = "action30";
$RemapName[65] = "Action #31";
$RemapCmd[65] = "action31";
$RemapName[66] = "Action #32";
$RemapCmd[66] = "action32";
$RemapName[67] = "Action #33";
$RemapCmd[67] = "action33";
$RemapName[68] = "Action #34";
$RemapCmd[68] = "action34";
$RemapName[69] = "Action #35";
$RemapCmd[69] = "action35";
$RemapName[70] = "Action #36";
$RemapCmd[70] = "action36";
$RemapName[71] = "Action #37";
$RemapCmd[71] = "action37";
$RemapName[72] = "Action #38";
$RemapCmd[72] = "action38";
$RemapName[73] = "Action #39";
$RemapCmd[73] = "action39";

$RemapCount = 74;