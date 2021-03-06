//------------------------------------------------------------------------------
// Cat5
// Copyright notices are in the file named COPYING.
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// Cat5 - profiles.cs
// GuiControlProfiles for Cat5' shell
//------------------------------------------------------------------------------

new AudioProfile(GuiSoundButtonOver)
{
	filename = "share/sounds/cat5/beep1a.wav";
	description = AudioGui;
	preload = true;
};

new AudioProfile(GuiSoundButtonDown)
{
	filename = "share/sounds/cat5/beep1b.wav";
	description = AudioGui;
	preload = true;
};

new GuiControlProfile(GuiDefaultProfile)
{
	tab = false;
	canKeyFocus = false;
	hasBitmapArray = false;
	mouseOverSelected = false;

	// fill color
	opaque = false;
	fillColor = "0 0 0 0";
	fillColorHL = "50 50 50 220";
	fillColorNA = "221 202 173 220";

	// border color
	border = false;
	borderColor	= "200 200 200 255";
	borderColorHL = "100 100 100 255";
	borderColorNA = "100 100 100 255";

	// font
	fontType = "Cat5";
	fontSize = 14;

	fontColor = "255 255 255 255";
	fontColorHL = "39 55 157 255";
	fontColorNA = "100 100 100 255";
	fontColorSEL= "255 255 255 255";
	fontColors[4] = "255 96 96 255"; // aka fontColorLink
	fontColors[5] = "0 0 255 255"; // aka fontColorLinkHL
	fontColors[6] = "0 200 0 255";
	fontColors[7] = "200 0 200 255";
	fontColors[8] = "255 200 0 255";
	fontColors[9] = "0 200 255 255";

	// bitmap information
	bitmap = "./pixmaps/cat5window";
	bitmapBase = "";
	textOffset = "0 0";

	// used by guiTextControl
	modal = true;
   justify = "left";
	autoSizeWidth = false;
	autoSizeHeight = false;
	returnTab = false;
	numbersOnly = false;
	cursorColor = "200 200 200";

	// sounds
	soundButtonDown = GuiSoundButtonDown;
	soundButtonOver = GuiSoundButtonOver;
};

//--------------------------------------------------------------------------

new GuiControlProfile(GuiScanlinesProfile : GuiDefaultProfile)
{
   modal = false;
   fillColor = "0 255 255 100";
};

new GuiControlProfile(GuiCursorEffectsProfile : GuiDefaultProfile)
{
   modal = false;
   fillColor = "255 255 255 255";
};

//--------------------------------------------------------------------------
// Console Window
//
new GuiControlProfile(GuiConsoleProfile : GuiDefaultProfile)
{
	fontType = "Lucida Console";
	fontSize = 12;
	fontColor = "0 0 255";
	fontColorHL = "130 130 130";
	fontColorNA = "255 0 0";
	fontColors[6] = "50 50 50";
	fontColors[7] = "50 50 0";
	fontColors[8] = "0 0 50";
	fontColors[9] = "0 50 0";
};
//--------------------------------------------------------------------------

new GuiControlProfile(GuiButtonProfile : GuiDefaultProfile)
{
	opaque = false;
	border = true;
	fixedExtent = true;
	justify = "center";
	canKeyFocus = false;
	bitmap = "./pixmaps/cat5button";
};

new GuiControlProfile(GuiHilightButtonProfile : GuiButtonProfile)
{
	bitmap = "./pixmaps/cat5buttonhilight";
};

new GuiControlProfile(GuiTitleButtonProfile : GuiButtonProfile)
{
	bitmap = "./pixmaps/cat5button";
};

new GuiControlProfile(GuiRootMenuButtonProfile : GuiDefaultProfile)
{
	opaque = false;
	border = true;
	fixedExtent = true;
	justify = "center";
	canKeyFocus = false;
};

new GuiControlProfile(GuiBorderButtonProfile : GuiDefaultProfile)
{
	fontColorHL = "0 0 0";
};

new GuiControlProfile(GuiMenuBarProfile : GuiDefaultProfile)
{
	opaque = true;
	border = 4;
	fixedExtent = true;
	justify = "center";
	canKeyFocus = false;
	mouseOverSelected = true;
	bitmap = ($platform $= "macos") ? "./pixmaps/osxMenu" : "./pixmaps/torqueMenu";
	hasBitmapArray = true;
};

new GuiControlProfile(GuiTextProfile : GuiDefaultProfile)
{
	autoSizeWidth = true;
	autoSizeHeight = true;
};

new GuiControlProfile(GuiMediumTextProfile : GuiTextProfile)
{
	fontSize = 24;
};

new GuiControlProfile(GuiBigTextProfile : GuiTextProfile)
{
	fontSize = 36;
};

new GuiControlProfile(GuiCenterTextProfile : GuiTextProfile)
{
	justify = "center";
};


new GuiControlProfile(GuiTextEditProfile : GuiDefaultProfile)
{
	opaque = true;
	border = true;
	borderThickness = 3;
	textOffset = "0 2";
	autoSizeWidth = false;
	autoSizeHeight = true;
	tab = true;
	canKeyFocus = true;
};

new GuiControlProfile(GuiControlListPopupProfile : GuiDefaultProfile)
{
	opaque = true;
	border = true;
	borderColor = "0 0 0";
	textOffset = "0 2";
	autoSizeWidth = false;
	autoSizeHeight = true;
	tab = true;
	canKeyFocus = true;
	bitmap = ($platform $= "macos") ? "./pixmaps/osxScroll" : "./pixmaps/darkScroll";
	hasBitmapArray = true;
};

new GuiControlProfile(GuiTextArrayProfile : GuiTextProfile)
{
	fontSize = 12;
};

new GuiControlProfile(GuiTextListProfile : GuiTextProfile) ;

new GuiControlProfile(GuiTreeViewProfile : GuiDefaultProfile)
{
	fontSize = 13;  // dhc - trying a better fit...
	bitmap = "common/ui/shll_treeView";
};

new GuiControlProfile(GuiPaneProfile : GuiDefaultProfile)
{
	bitmap = "./pixmaps/simplePane";
	hasBitmapArray = true;
};

new GuiControlProfile(GuiPopUpMenuProfile : GuiDefaultProfile)
{
	opaque = true;
	mouseOverSelected = true;

	border = 4;
	borderThickness = 2;
	borderColor = "0 0 0";
	fixedExtent = true;
	justify = "center";
	bitmap = ($platform $= "macos") ? "./pixmaps/osxScroll" : "./pixmaps/darkScroll";
	hasBitmapArray = true;
};


new GuiControlProfile(LoadTextProfile : GuiDefaultProfile)
{
	autoSizeWidth = true;
	autoSizeHeight = true;
};


new GuiControlProfile(GuiMLTextProfile : GuiDefaultProfile)
{
	fillColor = "0 0 0 0";
	fontColorLink = "39 55 157 255";
	fontColorLinkHL = "63 255 255 255";
};

new GuiControlProfile(GuiMLTextNoSelectProfile : GuiDefaultProfile)
{
	fillColor = "0 0 0 0";
	modal = false;
};

new GuiControlProfile(GuiMLTextEditProfile : GuiDefaultProfile)
{
	fillColor = "0 0 0 0";
	fontColorLink = "0 150 0";
	fontColorLinkHL = "100 255 100";
	autoSizeWidth = true;
	autoSizeHeight = true;
	tab = true;
	canKeyFocus = true;
};

new GuiControlProfile(GuiProgressProfile : GuiDefaultProfile)
{
	opaque = false;
	fillColor = "44 152 162 100";
	border = true;
};

new GuiControlProfile(GuiProgressTextProfile : GuiDefaultProfile)
{
	justify = "center";
};

new GuiControlProfile(GuiBitmapBorderProfile : GuiDefaultProfile)
{
	bitmap = "./darkBorder";
	hasBitmapArray = true;
};

new GuiControlProfile ( GuiDirectoryTreeProfile : GuiTreeViewProfile )
{
	bitmap = "common/ui/shll_treeView";
};

new GuiControlProfile ( GuiDirectoryFileListProfile : GuiTreeViewProfile )
{
	fillColor = "50 50 50 220";
};


//-----------------------------------------------------------------------

new GuiControlProfile(GuiWindowProfile : GuiDefaultProfile)
{
	canKeyFocus = true;
	opaque = false;
	border = 8;
	fillColor = "0 0 0 220";
	fillColorHL = "0 0 0 220";
	fillColorNA = "0 0 0 220";
	fontColor = "0 210 255";
	fontColorHL = "0 210 255";
	text = "GuiWindowCtrl test";
	bitmap = "./pixmaps/cat5window";
	textOffset = "12 6";
	hasBitmapArray = true;
	justify = "left";
};

new GuiControlProfile(GuiInactiveWindowProfile : GuiDefaultProfile)
{
	canKeyFocus = true;
	opaque = false;
	border = 8;
	fillColor = "0 0 0 220";
	fillColorHL = "0 0 0 220";
	fillColorNA = "0 0 0 220";
	fontColor = "170 170 170";
	fontColorHL = "170 170 170";
	text = "GuiWindowCtrl test";
	bitmap = "./pixmaps/cat5window";
	textOffset = "12 6";
	hasBitmapArray = true;
	justify = "left";
};

new GuiControlProfile(GuiTransparentWindowProfile : GuiDefaultProfile)
{
	opaque = true;
	border = 0;
	fillColor = "0 0 0 220";
	fillColorHL = "0 0 0 220";
	fillColorNA = "0 0 0 220";
	fontColor = "255 255 255";
	fontColorHL = "255 255 255";
	text = "GuiWindowCtrl test";
	bitmap = "./pixmaps/cat5window";
	textOffset = "6 6";
	hasBitmapArray = true;
	justify = "center";
};

new GuiControlProfile(GuiScrollProfile : GuiDefaultProfile)
{
	opaque = false;
	border = 3;
	borderThickness = 3;
	bitmap = "./pixmaps/cat5scroll";
	hasBitmapArray = true;
	fillColor = "0 0 0 0";
};

new GuiControlProfile(MissionWindowQuickbarScrollProfile : GuiScrollProfile)
{
	border = 1;
	borderThickness = 0;
	fillColor = "0 0 0 200";
};

new GuiControlProfile(MissionWindowMenuScrollProfile : GuiScrollProfile)
{
	border = 1;
	borderThickness = 5;
	fillColor = "0 0 0 200";
};

new GuiControlProfile(GuiCheckBoxProfile : GuiDefaultProfile)
{
	opaque = false;
	border = false;
	fixedExtent = true;
	justify = "left";
	bitmap = "./pixmaps/cat5check";
	hasBitmapArray = true;
};

new GuiControlProfile(GuiRadioProfile : GuiDefaultProfile)
{
	fillColorHL = "0 128 255 255";
	fixedExtent = true;
	bitmap = "./pixmaps/cat5radio";
	hasBitmapArray = true;
};

