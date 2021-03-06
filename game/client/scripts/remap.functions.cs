//------------------------------------------------------------------------------
// Cat5
// Copyright notices are in the file named COPYING.
//------------------------------------------------------------------------------

// These are the functions that can be remapped to different controls
// using the "Controls" option dialog.

//------------------------------------------------------------------------------
// In-game shell overlay
//------------------------------------------------------------------------------

function toggleShellDlg(%val)
{
	if(%val)
		return;
		
	$ShellDlgActive = !$ShellDlgActive;

	updateShellDlg();
}

//------------------------------------------------------------------------------
// Camera
//------------------------------------------------------------------------------

function freeLook( %val )
{
   $mvFreeLook = %val;
}

function cAim( %val )
{
   if(HUD.zAimMode == 0)
   {
      $mvHorizontalPos = 0;
      $mvVerticalPos = 0;
      return;
   }

   %w = getWord(HUD.getExtent(), 0);
   %h = getWord(HUD.getExtent(), 1);
   %r = (%w > %h ? %h : %w);

   if(!%val)
   {
      $mvMapActive = false;
      $mvPosActive = true;
      HudRulerH.visible = true;
      HudRulerV.visible = true;
      %transform = ServerConnection.getControlObject().getTransform();
      %vec = MatrixGetColumn(%transform, 1);
      if(HUD.zAimMode == 1)
      {
         %ctrlPos = ServerConnection.getControlObject().getPosition();
         %mapPos = $mvMapX SPC $mvMapY SPC getWord(%ctrlPos, 2);
         switch(HUD.getZoom())
         {
            case 0.2: %scale = 0.0091;
            case 0.4: %scale = 0.0082;
            case 0.6: %scale = 0.0077;
            case 0.8: %scale = 0.0072;
            case 1.0: %scale = 0.0067;
            case 1.2: %scale = 0.0061;
            case 1.4: %scale = 0.0055;
            case 1.6: %scale = 0.0050;
            case 1.8: %scale = 0.0045;
            case 2.0: %scale = 0.0040;
            default: %scale = 0.0074;
         }
         //error(%scale);
         %vec = VectorScale(VectorSub(%mapPos, %ctrlPos), %scale);
         $mvHorizontalPos = getWord(%vec, 0);
         $mvVerticalPos = getWord(%vec, 1);
      }
      else if(HUD.zAimMode == 2)
      {
         //%vec = VectorScale(%vec, (($mvVerticalPos+1)/4));
         %vec = VectorScale(%vec, 0.1);
         $mvHorizontalPos = getWord(%vec, 0);
         $mvVerticalPos = getWord(%vec, 1);
      }
      else
      {
         %vec = VectorScale(%vec, 0.1);
         $mvHorizontalPos = getWord(%vec, 0);
         $mvVerticalPos = getWord(%vec, 1);
      }
      HUD.viewMode = 3;
      return;
   }

   if(HUD.zAimMode == 1)
   {
      //HUD.zOldHorizontalPos = $mvHorizontalPos;
      //HUD.zOldVerticalPos = $mvVerticalPos;

      // Freeze view
      %p = HUD.unproject(%w/2 SPC %h/2 SPC -1);
      HUD.pan(getWord(%p, 0), getWord(%p, 1));
      HUD.viewMode = 1;

      // Translate relative aim pos into absolute map pos
      %camPos = HUD.getCamPos();
      %ctrlPos = ServerConnection.getControlObject().getPosition();
      %dist = 9999;
      //%vec = VectorSub(%ctrlPos, %camPos);
      //%dist = VectorLen(%vec);
      %r = (%w > %h ? %h : %w);
      %x = %w/2 + ($mvHorizontalPos/2)*%r;
      %y = %h/2 - ($mvVerticalPos/2)*%r;
      %p = HUD.unproject(%x SPC %y SPC -1);
      %vec = VectorSub(%p, %camPos);
      %vec = VectorNormalize(%vec);
      %end = VectorAdd(%camPos, VectorScale(%vec, %dist));
      %d = PlaneIntersect("0 0" SPC getWord(%ctrlPos,2), "0 0 1", %camPos, %end);
      %p = VectorAdd(%camPos, VectorScale(%vec, %dist * %d));

      $mvMapX = getWord(%p, 0);
      $mvMapY = getWord(%p, 1);

      $mvMapActive = true;
      $mvPosActive = false;
      HudRulerH.visible = false;
      HudRulerV.visible = false;
   }
   else if(HUD.zAimMode == 2)
   {
      $mvMapActive = false;
      $mvPosActive = false;
      //$mvVerticalPos = 0.05;
      HudRulerH.visible = true;
      HudRulerV.visible = true;
      HUD.viewMode = 5;
   }
   else if(HUD.zAimMode == 3)
   {
      $mvMapActive = false;
      $mvPosActive = false;
      HudRulerH.visible = false;
      HudRulerV.visible = false;
      HUD.viewMode = 6;
   }
}

function toggleFirstPerson(%val)
{
	if (%val)
	{
		$firstPerson = !$firstPerson;
		ServerConnection.setFirstPerson($firstPerson);
	}
}

//------------------------------------------------------------------------------
// Movement
//------------------------------------------------------------------------------

function moveleft(%val)
{
	$mvLeftAction = %val;
}

function moveright(%val)
{
	$mvRightAction = %val;
}

function moveforward(%val)
{
	$mvForwardAction = %val;
}

function movebackward(%val)
{
	$mvBackwardAction = %val;
}

function moveup(%val)
{
	$mvUpAction = %val;
}

function movedown(%val)
{
	$mvDownAction = %val;
}

function turnLeft( %val )
{
	$mvYawRightSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function turnRight( %val )
{
	$mvYawLeftSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panUp( %val )
{
	$mvPitchDownSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panDown( %val )
{
	$mvPitchUpSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function yaw(%val)
{
	$mvYaw += getMouseAdjustAmount(%val);
}

function pitch(%val)
{
	$mvPitch += getMouseAdjustAmount(%val);
}

function mouseX(%val)
{
   if(!$mvPosActive && !$mvMapActive)
      $mvYaw += getMouseAdjustAmount(%val);
   //if($mvPosActive)
	   $mvHorizontalPos += getMouseAdjustAmount(%val);
    //  if($mvHorizontalPos > 1.0) $mvHorizontalPos = 1.0;
    //  else if($mvHorizontalPos < -1.0) $mvHorizontalPos = -1.0;
   //if($mvMapActive)
 	   $mvMapX += %val;
}

function mouseY(%val)
{
   //if(!$mvPosActive && !$mvMapActive)
   //   $mvPitch += getMouseAdjustAmount(%val);
   //if($mvPosActive)
	   $mvVerticalPos -= getMouseAdjustAmount(%val);
    //  if($mvVerticalPos > 1.0) $mvVerticalPos = 1.0;
    //  else if($mvVerticalPos < -1.0) $mvVerticalPos = -1.0;
   //if($mvMapActive)
      $mvMapY -= %val;
}

//------------------------------------------------------------------------------
// Triggers
//------------------------------------------------------------------------------

function trigger0(%val)
{
	// hack hack hack: players should really be able
    // to configure arbitrary chords.
	if($triggerDown[3] && %val)
	{
		// chord initiated
		$chording[0] = true;
		action12(1);
	}

	if($chording[0])
	{
		if(!%val)
		{
			// chord finished
			$chording[0] = false;
			action12(0);
		}			
	}
	else
	{
		$mvTriggerCount0++;
	}
}

function trigger1(%val)
{
	$mvTriggerCount1++;
}

function trigger2(%val)
{
	$mvTriggerCount2++;
}

function trigger3(%val)
{
	$mvTriggerCount3++;
	$triggerDown[3] = %val;
}

function trigger4(%val)
{
	$mvTriggerCount4++;
}

function trigger5(%val)
{
	$mvTriggerCount5++;
}

//------------------------------------------------------------------------------
// Zoom and FOV
//------------------------------------------------------------------------------

function toggleTempZoomLevel(%val)
{
	//echo("toggleTempZoomLevel(): %val =" SPC %val);

	if(%val)
	{
		%minFov = ServerConnection.getControlObject().getDataBlock().cameraMinFov;
		%step = ($Pref::Player::DefaultFov - %minFov)/$Pref::Player::MouseZoomSteps;

		$TempZoomValue += %step;

		if($TempZoomValue > $Pref::Player::DefaultFov)
			$TempZoomValue = %minFov;
						
		if($TempZoomOn)
			setFov($TempZoomValue);	
	}
}

// zoom to user defined value...
function tempZoom( %val )
{
	//echo("tempZoom(): %val =" SPC %val);

	if($TempZoomValue == 0)
		$TempZoomValue = 1;

	if(%val)
	{
		$TempZoomOn = true;
		setFov($TempZoomValue);
	}
	else
	{
		$TempZoomOn = false;
		setFov($MouseZoomValue == 0 ? $Pref::Player::DefaultFov : $MouseZoomValue);
	}
}

function mouseZoom(%val)
{
	if(Canvas.isCursorOn())
		return;

	%minZoom = 0.2;
   %maxZoom = 2;
	%step = %maxZoom/$Pref::Player::MouseZoomSteps;

	if($MouseZoomValue == 0)
		$MouseZoomValue = 0.5;

	if(%val > 0)
		$MouseZoomValue -= %step;
	else
		$MouseZoomValue += %step;
		
	if($MouseZoomValue < %minZoom)
		$MouseZoomValue = %minZoom;
	else if($MouseZoomValue > %maxZoom)
		$MouseZoomValue = %maxZoom;

   Hud.zoom($MouseZoomValue);
	//setFov($MouseZoomValue);
}

//------------------------------------------------------------------------------
// Message HUD
//------------------------------------------------------------------------------

function toggleMessageHud(%val)
{
	if(%val)
	{
		MessageHud.isTeamMsg = false;
		MessageHud.toggleState();
	}
}

function teamMessageHud(%val)
{
	if(%val)
	{
		MessageHud.isTeamMsg = true;
		MessageHud.toggleState();
	}
}

function pageMessageHudUp( %val )
{
	if ( %val )
		pageUpMessageHud();
}

function pageMessageHudDown( %val )
{
	if ( %val )
		pageDownMessageHud();
}

function resizeMessageHud( %val )
{
	if ( %val )
		cycleMessageHudSize();
}

//------------------------------------------------------------------------------
// Misc
//------------------------------------------------------------------------------

function biggerMiniMap( %val )
{
	BigMap.visible = %val;
}

function activateCmdrScreen(%val)
{
	if(%val)
		Canvas.setContent(CmdrScreen);
}

function toggleRecordingDemo( %val )
{
	if ( %val )
		toggleDemoRecord();
}

function takeScreenshot( %val )
{
	if ( %val )
		doScreenshot(1);
}

//------------------------------------------------------------------------------
// Player actions
//------------------------------------------------------------------------------

function action0(%val)
{
	commandToServer('PlayerAction', 0, %val);
}


function action1(%val)
{
	commandToServer('PlayerAction', 1, %val);
}


function action2(%val)
{
	commandToServer('PlayerAction', 2, %val);
}


function action3(%val)
{
	commandToServer('PlayerAction', 3, %val);
}


function action4(%val)
{
	commandToServer('PlayerAction', 4, %val);
}


function action5(%val)
{
	commandToServer('PlayerAction', 5, %val);
}


function action6(%val)
{
	commandToServer('PlayerAction', 6, %val);
}


function action7(%val)
{
	commandToServer('PlayerAction', 7, %val);
}


function action8(%val)
{
	commandToServer('PlayerAction', 8, %val);
}


function action9(%val)
{
	commandToServer('PlayerAction', 9, %val);
}


function action10(%val)
{
	commandToServer('PlayerAction', 10, %val);
}


function action11(%val)
{
	commandToServer('PlayerAction', 11, %val);
}


function action12(%val)
{
	commandToServer('PlayerAction', 12, %val);
}


function action13(%val)
{
	commandToServer('PlayerAction', 13, %val);
}


function action14(%val)
{
	commandToServer('PlayerAction', 14, %val);
}


function action15(%val)
{
	commandToServer('PlayerAction', 15, %val);
}


function action16(%val)
{
	commandToServer('PlayerAction', 16, %val);
}


function action17(%val)
{
	commandToServer('PlayerAction', 17, %val);
}


function action18(%val)
{
	commandToServer('PlayerAction', 18, %val);
}


function action19(%val)
{
	commandToServer('PlayerAction', 19, %val);
}


function action20(%val)
{
	commandToServer('PlayerAction', 20, %val);
}


function action21(%val)
{
	commandToServer('PlayerAction', 21, %val);
}


function action22(%val)
{
	commandToServer('PlayerAction', 22, %val);
}


function action23(%val)
{
	commandToServer('PlayerAction', 23, %val);
}


function action24(%val)
{
	commandToServer('PlayerAction', 24, %val);
}


function action25(%val)
{
	commandToServer('PlayerAction', 25, %val);
}


function action26(%val)
{
	commandToServer('PlayerAction', 26, %val);
}


function action27(%val)
{
	commandToServer('PlayerAction', 27, %val);
}


function action28(%val)
{
	commandToServer('PlayerAction', 28, %val);
}


function action29(%val)
{
	commandToServer('PlayerAction', 29, %val);
}


function action30(%val)
{
	commandToServer('PlayerAction', 30, %val);
}


function action31(%val)
{
	commandToServer('PlayerAction', 31, %val);
}


function action32(%val)
{
	commandToServer('PlayerAction', 32, %val);
}


function action33(%val)
{
	commandToServer('PlayerAction', 33, %val);
}


function action34(%val)
{
	commandToServer('PlayerAction', 34, %val);
}


function action35(%val)
{
	commandToServer('PlayerAction', 35, %val);
}


function action36(%val)
{
	commandToServer('PlayerAction', 36, %val);
}


function action37(%val)
{
	commandToServer('PlayerAction', 37, %val);
}


function action38(%val)
{
	commandToServer('PlayerAction', 38, %val);
}


function action39(%val)
{
	commandToServer('PlayerAction', 39, %val);
}


