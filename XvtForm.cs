/*
 * YOGEME.exe, All-in-one Mission Editor for the X-wing series, XW through XWA
 * Copyright (C) 2007-2025 Michael Gaisser (mjgaisser@gmail.com)
 * Licensed under the MPL v2.0 or later
 * 
 * VERSION: 1.16.0.6
 *
 * CHANGELOG
 * v1.16.0.6, 250104
 * [FIX #114] Corrupted craft role (when AI Rating is written)
 * v1.16.0.3, 241027
 * [FIX #110] FG library callback cast exception
 * v1.16, 241013
 * [FIX] Special Cargo control visibility when not on first tab
 * [FIX] SaveAs behavior
 * [UPD] spec updates, cleanup
 * [FIX] Test now respects XvtDetectMission setting
 * v1.15.5, 231222
 * [NEW #97] GlobalSummary dialog
 * [UPD] SaveAs XWA now uses Platform
 * v1.13.12, 230116
 * [NEW] RememberSelectedOrder option functionality
 * v1.13.11, 221030
 * [FIX] Open dialog not following current directory after switching paltforms via "Open Recent"
 * v1.13.7, 220730
 * [FIX] crash when copying a WP value via Ctrl+C and no text is selected
 * v1.13.6, 220619
 * [UPD] Confirm save now only asks if modified
 * v1.13.4, 220606
 * [UPD] OneIndexedFGs implementation
 * v1.13.3, 220402
 * [FIX] ComboBox stutter for colorized cbo's due to OwnerDrawVariable
 * v1.13.2, 220319
 * [FIX] Remove focus during save to trigger any Leave events
 * v1.13.1, 220208
 * [NEW] menuCut [JB]
 * [FIX] multi-select refresh issues [JB]
 * [FIX] craftStart issues during Paste and arrival changes [JB]
 * [NEW] added copy/paste buttons for Skip triggers [JB]
 * v1.13, 220130
 * [UPD] OrderDesignation now a drop-down [JB]
 * [UPD] long else-if in setFlightgroupProperty() and setMessageProperty() changed to switch [JB]
 * [FIX] minor issues with multi-select [JB]
 * [UPD] multi-select functions moved to Common [JB]
 * v1.12, 220103
 * [NEW] Multi-select [JB]
 * [UPD] Unused messages drawn in gray
 * [FIX] Listbox scrolling
 * v1.11.2, 2101005
 * [FIX] Pasting a message when at capacity now correctly does nothing
 * [UPD] Copy/paste now uses system clipboard, can more easily paste external text
 * [NEW] Copy/paste now works for Waypoints, can paste XvT/XWA Triggers/Orders
 * v1.10, 210520
 * [UPD #56] Replaced try/catch with TryParse [JB]
 * v1.9.2, 210328
 * [FIX] Test load failure if mission isn't in platform directory
 * v1.9, 210108
 * [FIX] Clipboard path in some locations
 * v1.8.1, 201213
 * [UPD] _config passed to LST form, Backdrops, RunVerify()
 * [UPD #20] Test function now attempts to detect platform from MissionPath
 * [UPD] menuTest moved under Tools, changed to &Test
 * v1.8, 201004
 * [FIX] Deactivate added to force focus fix [JB]
 * [FIX] Test launching if you cancel the intial Save
 * [UPD] saveMission now won't save/rewrite file if unmodifed
 * [NEW] FlightGroupLibrary [JB]
 * [FIX] double listing of IFFs [JB]
 * [UPD] changes due to Unknown definitions: StopArrivingWhen, RndSeed, FG Goal TeamEnabled array, RandomArrDep Min/Sec [JB]
 * [UPD] colorized cbos now work with "not FG" [JB]
 * v1.7, 200816
 * [UPD] Unknowns tab cleanup
 * [FIX] recalculateEditorCraftNumbering() handles _activeFG now [JB]
 * [UPD] shiplist and Map calls updated for Wireframe implementation [JB]
 * [UPD] Blank messages now shown as "*" [JB]
 * [UPD] Cleanup index substitions [JB]
 * [UPD] Trigger label refresh updates [JB]
 * [FIX] Extra protections to handle custom missions using "bad" Status or Formation values [JB]
 * [NEW] BoP IFF names implemented (consumes Unknowns 4 and 5) [JB]
 * [NEW] More TriggerTypes added [JB]
 * [UPD] Unk6 renamed to PreventOutcome [JB]
 * [UPD] form handlers renamed
 * [FIX] re-init if load fails
 * v1.6.5, 200704
 * [UPD] More details to ProcessCraftList error message
 * [FIX #32] bin path now explicitly uses Startup Path to prevent implicit from defaulting to sys32
 * v1.6.4, 200119
 * [FIX] added Update to cmdBackdrop to ensure mission is dirtied
 * [NEW #30] Briefing callback
 * v1.5.1, 190513
 * [NEW] Changing GG value will now prompt to update references throughout if it's the only FG with that designation
 * v1.5, 180910
 * [NEW] Dictionaries for Control handling [JB]
 * [UPD] blank Team names now show generic in cbo's [JB]
 * [FIX] comboReset now has index check [JB]
 * [NEW] Xwing support [JB]
 * [FIX] non-XvT filestreams now closed properly [JB]
 * [UPD] lots of controls converted to instant-update instead of using _Leave. Done by pointing handlers to _Leave instead of redoing it [JB]
 * [UPD] order speed changed to cbo [JB]
 * [UPD] cboRoleImp/Reb renamed to 1/2 [JB]
 * [NEW] controls to apply roles to teams individually [JB]
 * [NEW] Ion Pulse, Energy beam, Cluster CM [JB]
 * [NEW] 'Enter' key trigger control update [JB]
 * [NEW] colorized cbo's [JB]
 * [UPD] copy/paste expanded [JB]
 * [NEW] cmdMoveMessUp/Down and cmdMoveFGUp/Down [JB]
 * [UPD] lbl colors now applied via function to allow themeing [JB]
 * [UPD] general performance improvements [JB]
 * [UPD] delete FG reworked [JB]
 * [NEW] editor-only craft numbering [JB]
 * [UPD] better tab updates [JB]
 * [NEW] PreventCraftNumbering, DepartureClock and Goal time limit unks implemented [JB]
 * [UPD] improved order information [JB]
 * [NEW] blank messages are shown [JB]
 * [FIX] exception in lblMessArr if no messages [JB]
 * v1.4.3, 180509
 * [UPD] changed how Strings.OrderDesc gets split
 * v1.4.1, 171118
 * [UPD] added Exclamation icon to FG delete confirmation
 * v1.4, 171016
 * [NEW #10] Custom ship list loading
 * v1.3, 170107
 * [FIX] various crashes [JB]
 * [NEW] MRU capability [JB]
 * [NEW] Delete menu item, delete key capture [JB]
 * [FIX] Redo opnXvT procedure [JB]
 * [NEW] Craft reference adjustment when deleting FGs [JB]
 * [UPD] newFG() now BOOL [JB]
 * [FIX] SpecialCargo assignment [JB]
 * [FIX] various label refresh issues [JB]
 * [NEW] FG Goal Summary [JB]
 * v1.2.8, 160606
 * [FIX] WaitForExit in Test replaced with named process check loop (Steam's fault)
 * v1.2.7, 150405
 * [FIX] Team copy/paste
 * [FIX] FG Goal copy/paste now gets entire goal with strings and points, not just trigger
 * [FIX] FG Goal strings were saving in the wrong order
 * [UPD] new Globals.Goal.Trigger implementation
 * [ADD] copy/paste mouse functions to Team listing
 * v1.2.5, 150110
 * [FIX] some type corrections near Update calls [JeremyAnsel]
 * [UPD] modified Common.Update calls for generics
 * v1.2.3, 141214
 * [UPD] change to MPL
 * [FIX] blank form when trying to use LstForm when TIE isn't installed
 * v1.2, 121006
 * - removed try{} in opnXvT_FileOk
 * - Settings passed in and out
 * [NEW] Test menu
 * [FIX] Global Goal text boxes saving contents of Completed for all
 * - txtGlobal_Leave now single function instead of Comp/Inc/Fail
 * [UPD] lblStarting now only applies to Normal difficulty
 * [UPD] opn/sav dialogs default to \Train
 * [NEW] Open Recent menu
 * v1.1.1, 120814
 * [UPD] chkWPArr_Leave to chkWPArr_CheckedChanged
 * [FIX] FG list display
 * - renamed a ton of stuff
 * - class renamed
 * v1.0, 110921
 * - Release
 */

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Idmr.Platform.Xvt;

namespace Idmr.Yogeme
{
	/// <summary>XvT Mission Editor GUI</summary>
	public partial class XvtForm : Form
	{
		#region vars and stuff
		readonly Settings _config = Settings.GetInstance();
		Mission _mission;
		bool _applicationExit;
		int _activeFGIndex = 0;
		int _startingShips = 1;
		bool _loading;
		bool _noRefresh = false;
		int _activeMessageIndex = 0;
		readonly DataTable _table = new DataTable("Waypoints");
		readonly DataTable _tableRaw = new DataTable("Waypoints_Raw");
		MapForm _fMap;
		BriefingForm _fBrief;
		LstForm _fLST;
		FlightGroupLibraryForm _fLibrary;
		byte _activeMessageTriggerIndex = 0;
		byte _activeGlobalTriggerIndex = 0;
		byte _activeTeamIndex = 0;
		byte _activeArrDepTriggerIndex = 0;
		byte _activeFGGoalIndex = 0;
		byte _activeOrderIndex = 0;
		byte _activeOptionCraftIndex = 0;
		byte _activeSkipTriggerIndex = 0;
		#endregion
		#region Control Arrays
#pragma warning disable IDE1006 // Naming Styles
		readonly TextBox[] txtIFF = new TextBox[4];
		readonly RadioButton[] optADAndOr = new RadioButton[8];
		readonly CheckBox[] chkSendTo = new CheckBox[10];
		readonly Label[] lblMessTrig = new Label[4];
		readonly Label[] lblGlobTrig = new Label[12];
		readonly RadioButton[] optGlobAndOr = new RadioButton[18];
		readonly Label[] lblTeam = new Label[10];
		readonly CheckBox[] chkAllies = new CheckBox[10];
		readonly Label[] lblADTrig = new Label[6];
		readonly Label[] lblGoal = new Label[8];
		readonly Label[] lblOrder = new Label[4];
		readonly CheckBox[] chkWP = new CheckBox[22];
		readonly CheckBox[] chkOpt = new CheckBox[18];
		readonly Label[] lblOptCraft = new Label[10];
		readonly ComboBox[] cboEoMColor = new ComboBox[6];
		readonly TextBox[] txtEoM = new TextBox[6];
		readonly MenuItem[] menuRecentMissions = new MenuItem[6];
		readonly Dictionary<ComboBox, ComboBox> ColorizedFGList = new Dictionary<ComboBox, ComboBox>();  //[JB] Maps a control that should have a colorized FG list with a control that determines whether the list actually contains a FG list.
#pragma warning restore IDE1006 // Naming Styles
		#endregion

		public XvtForm(bool bBoP)
		{
			InitializeComponent();
			_loading = true;
			initializeMission();
			setBop(bBoP);
			startup();
			lstFG.SelectedIndex = 0;
			_loading = false;
		}
		public XvtForm(string path)
		{
			InitializeComponent();
			_loading = true;
			initializeMission();
			startup();
			if (!loadMission(path)) return;
			lstFG.SelectedIndex = 0;
			if (_mission.Messages.Count != 0) lstMessages.SelectedIndex = 0;
			_loading = false;
		}

		#region methods
		void closeForms()
		{
			_fMap?.Close();
			_fBrief?.Close();
			_fLST?.Close();
			_fLibrary?.Close();
		}
		void comboVarRefresh(int varType, ComboBox cbo)
		{
			if (varType == -1) return;
			cbo.Items.Clear();
			string[] temp;
			switch ((Mission.Trigger.TypeList)varType)
			{
				case Mission.Trigger.TypeList.None:
				case Mission.Trigger.TypeList.AllCraft:
					cbo.Items.Add("None");
					break;
				case Mission.Trigger.TypeList.FlightGroup:
				case Mission.Trigger.TypeList.NotFG:
					cbo.Items.AddRange(_mission.FlightGroups.GetList());
					break;
				case Mission.Trigger.TypeList.ShipType:
				case Mission.Trigger.TypeList.NotShipType:
					cbo.Items.AddRange(Strings.CraftType);
					cbo.Items.RemoveAt(0);
					break;
				case Mission.Trigger.TypeList.ShipClass:
				case Mission.Trigger.TypeList.NotShipClass:
					cbo.Items.AddRange(Strings.ShipClass);
					break;
				case Mission.Trigger.TypeList.ObjectType:
				case Mission.Trigger.TypeList.NotObjectType:
					cbo.Items.AddRange(Strings.ObjectType);
					break;
				case Mission.Trigger.TypeList.IFF:
				case Mission.Trigger.TypeList.NotIFF:
					cbo.Items.AddRange(getIffStrings());
					break;
				case Mission.Trigger.TypeList.ShipOrders:
					cbo.Items.AddRange(Strings.Orders);
					break;
				case Mission.Trigger.TypeList.CraftWhen:
					cbo.Items.AddRange(Strings.CraftWhen);
					break;
				case Mission.Trigger.TypeList.AILevel:
					cbo.Items.AddRange(Strings.Rating);
					break;
				case Mission.Trigger.TypeList.Status:
					cbo.Items.AddRange(Strings.Status);
					break;
				case Mission.Trigger.TypeList.Team:
				case Mission.Trigger.TypeList.NotTeam:
					temp = _mission.Teams.GetList();
					for (int i = 0; i < temp.Length; i++)
						if (temp[i] == "") temp[i] = "Team " + (i + 1).ToString();  //[JB] Modified to replace empty strings.
					cbo.Items.AddRange(temp);
					break;
				case Mission.Trigger.TypeList.PlayerNum:
				case Mission.Trigger.TypeList.NotPlayerNum:
					temp = new string[256];
					for (int i = 0; i <= 255; i++) temp[i] = (i + 1).ToString();
					cbo.Items.AddRange(temp);
					if (varType == 0xD)
						cbo.Items[0] = "1   (this slot may be buggy!)";
					break;
				case Mission.Trigger.TypeList.BeforeTime:
					temp = new string[256];
					for (int i = 0; i <= 255; i++) temp[i] = Common.GetFormattedTime(i * 5, false);
					temp[0] += " seconds";
					cbo.Items.AddRange(temp);
					break;
				// case 8: Global Group
				// case 0x14: All Global Group except
				// case 0x17: Global Unit
				// case 0x18: All Global Unit except
				default:
					temp = new string[256];
					for (int i = 0; i <= 255; i++) temp[i] = i.ToString();
					cbo.Items.AddRange(temp);
					break;
			}
		}
		void comboReset(ComboBox cbo, string[] items, int index)
		{
			if (index < -1 || index >= items.Length) index = -1;  //[JB] Fixes rare out of bounds issues when FGs deleted or reset.
			cbo.Items.Clear();
			cbo.Items.AddRange(items);
			cbo.SelectedIndex = index;
		}
		void craftStart(FlightGroup fg, bool bAdd)
		{
			if (fg.Difficulty == Platform.BaseFlightGroup.Difficulties.Easy || fg.Difficulty == Platform.BaseFlightGroup.Difficulties.Hard || !fg.ArrivesIn30Seconds) return;
			if (bAdd) _startingShips += fg.NumberOfCraft;
			else _startingShips -= fg.NumberOfCraft;
			lblStarting.Text = _startingShips.ToString() + " craft at 30 seconds";
			if (_startingShips > Mission.CraftLimit) lblStarting.ForeColor = Color.Red;
			else lblStarting.ForeColor = SystemColors.ControlText;
		}
		Brush getFlightGroupDrawColor(int fgIndex)
		{
			Brush brText = SystemBrushes.ControlText;
			if (fgIndex < 0 || fgIndex >= _mission.FlightGroups.Count) return brText;
			switch (_mission.FlightGroups[fgIndex].IFF)
			{
				case 0:
					brText = Brushes.Lime; //LimeGreen;
					break;
				case 1:
					brText = Brushes.Red; //Crimson;
					break;
				case 2:
					brText = Brushes.DodgerBlue; //RoyalBlue;
					break;
				case 3:
					brText = Brushes.Yellow;
					break;
				case 4:
					brText = Brushes.OrangeRed; //Red;
					break;
				case 5:
					brText = Brushes.MediumOrchid; //DarkOrchid;
					break;
			}
			if (_mission.FlightGroups[fgIndex].Difficulty == Platform.BaseFlightGroup.Difficulties.Never)
				brText = Brushes.Gray;
			return brText;
		}
		Color getHighlightColor() => _config.ColorInteractSelected;
		/// <summary>Generates a string list of IFF names which provide default names instead of an empty string when no custom names are defined</summary>
		string[] getIffStrings()
		{
			string[] t = new string[_mission.IFFs.Length];
			for (int i = 0; i < t.Length; i++)
			{
				t[i] = _mission.IFFs[i];
				if (t[i] == "") t[i] = Strings.IFF[i];
			}
			return t;
		}
		bool hasFocus(Label[] list)
		{
			foreach (Label c in list)
				if (c.Focused)
					return true;
			return false;
		}
		void initializeMission()
		{
			tabMain.Focus();            // Exit focus from any form controls.  Fixes some issues that might arise from Leave() events trying to access modified lists.
			lstFG.Items.Clear();        // Clearing FGs here prevents issues with ComboBoxes further down.
			lstMessages.Items.Clear();  // Clearing messages to reset the move buttons.
			Common.UpdateMoveButtons(cmdMoveMessUp, cmdMoveMessDown, lstMessages);
			_mission = new Mission();
			_config.LastMission = "";
			_activeFGIndex = 0;
			_activeMessageIndex = 0;
			_mission.FlightGroups[0].CraftType = Convert.ToByte(_config.XvtCraft);
			_mission.FlightGroups[0].IFF = Convert.ToByte(_config.XvtIff);
			_startingShips = 0;
			craftStart(_mission.FlightGroups[0], true);
			string[] fgList = _mission.FlightGroups.GetList();
			comboReset(cboArrMS, fgList, 0);
			comboReset(cboArrMSAlt, fgList, 0);
			comboReset(cboDepMS, fgList, 0);
			comboReset(cboDepMSAlt, fgList, 0);
			lstFG.Items.Add(_activeFG.ToString(true));
			tabMain.SelectedIndex = 0;
			tabFGMinor.SelectedIndex = 0;
			comboReset(cboIFF, getIffStrings(), 0);
			Text = "Ye Olde Galactic Empire Mission Editor - XvT - New Mission.tie";
		}
		void loadCraftData(string fileMission)
		{
			Strings.OverrideShipList(null, null); //Restore defaults.
			try
			{
				CraftDataManager.GetInstance().LoadPlatform(_mission.IsBop ? Settings.Platform.BoP : Settings.Platform.XvT, Strings.CraftType, Strings.CraftAbbrv, fileMission);
				Strings.OverrideShipList(CraftDataManager.GetInstance().GetLongNames(), CraftDataManager.GetInstance().GetShortNames());
			}
			catch (Exception x) { MessageBox.Show("Error processing custom XvT ship list, using defaults.\n\n" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			cboCraft.Items.Clear();
			cboCraft.Items.AddRange(Strings.CraftType);
		}
		void labelRefresh(Mission.Trigger trigger, Label lbl)
		{ 
			string triggerText = trigger.ToString();
			triggerText = replaceTargetText(triggerText);
			lbl.Text = triggerText;
		}
		bool loadMission(string fileMission)
		{
			closeForms();
			lstFG.SelectedIndex = 0;
			lstFG.Items.Clear();
			_activeMessageIndex = 0;
			lstMessages.Items.Clear();
			_startingShips = 0;
			bool startBoP = _mission.IsBop;
			try
			{
				FileStream fs = File.OpenRead(fileMission);
				try
				{
					#region determine platform
					switch (Platform.MissionFile.GetPlatform(fs))
					{
						case Platform.MissionFile.Platform.Xwing:
							_applicationExit = false;
							new XwingForm(fileMission).Show();
							Close();
							fs.Close();
							return false;
						case Platform.MissionFile.Platform.TIE:
							_applicationExit = false;
							new TieForm(fileMission).Show();
							Close();
							fs.Close();
							return false;
						case Platform.MissionFile.Platform.XvT:
							txtMissDesc.Text = "";
							txtMissSucc.Text = "";
							txtMissFail.Text = "";
							_mission.MissionFailed = "";
							_mission.MissionSuccessful = "";
							setBop(false);
							break;
						case Platform.MissionFile.Platform.BoP:
							setBop(true);
							break;
						case Platform.MissionFile.Platform.XWA:
							_applicationExit = false;
							new XwaForm(fileMission).Show();
							Close();
							fs.Close();
							return false;
						default:
							throw new Exception("File is not a valid mission file for any platform, please select an appropriate mission file.");
					}
					#endregion
					_mission.LoadFromStream(fs);
					fs.Close();
				}
				catch (Exception x)
				{
					fs.Close();
					throw x;
				}
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (startBoP) menuNewBoP_Click(0, new EventArgs());
				else menuNewXvT_Click(0, new EventArgs());
				return false;
			}
			loadCraftData(fileMission);
			for (int i = 0; i < _mission.FlightGroups.Count; i++)
			{
				lstFG.Items.Add(_mission.FlightGroups[i].ToString(true));
				if (_mission.FlightGroups[i].ArrivesIn30Seconds) craftStart(_mission.FlightGroups[i], true);
			}
			updateFGList();
			if (_mission.Messages.Count == 0) enableMessages(false);
			else
			{
				enableMessages(true);
				for (int i = 0; i < _mission.Messages.Count; i++)
					lstMessages.Items.Add(_mission.Messages[i].MessageString != "" ? _mission.Messages[i].MessageString : " *");
			}
			bool btemp = _loading;
			_loading = true;
			comboReset(cboIFF, getIffStrings(), 0);
			updateMissionTabs();
			cboGlobalTeam.SelectedIndex = -1;   // otherwise it doesn't trigger an index change
			cboGlobalTeam.SelectedIndex = 0;
			for (_activeTeamIndex = 0; _activeTeamIndex < 10; _activeTeamIndex++) teamRefresh();
			lblTeamArr_Click(lblTeam[0], new EventArgs());
			_loading = btemp;
			Text = "Ye Olde Galactic Empire Mission Editor - " + (_mission.IsBop ? "BoP" : "XvT") + " - " + _mission.MissionFileName;
			_config.LastMission = fileMission;
			refreshRecent();
			return true;
		}
		void promptSave()
		{
			_config.SaveSettings();
			if (!_config.ConfirmSave || Text.IndexOf("*") == -1) return;

			DialogResult res = MessageBox.Show("Mission has been edited without saving, would you like to save?", "Confirm", MessageBoxButtons.YesNo);
			if (res == DialogResult.No) return;

			if (_mission.MissionPath == "\\NewMission.tie") savXvT.ShowDialog();
			else saveMission(_mission.MissionPath);
		}
		void refreshRecent()
		{
			for (int i = 1; i < 6; i++)
			{
				menuRecentMissions[i].Text = "&" + i + ": " + _config.RecentMissions[i] + " (" + _config.RecentPlatforms[i].ToString() + ")";
				menuRecentMissions[i].Visible = (_config.RecentMissions[i] != "");
			}
			menuRecentMissions[0].Enabled = menuRecentMissions[1].Visible;
		}
		void registerColorizedFGList(ComboBox variable, ComboBox variableType)
		{
			if (!_config.ColorizedDropDowns) return;
			if (variable == null) return;

			ColorizedFGList[variable] = variableType;
			variable.DrawMode = DrawMode.OwnerDrawFixed;
			variable.DrawItem += colorizedComboBox_DrawItem;
		}
		string replaceTargetText(string text)
		{
			while (text.Contains("FG:"))
			{
				int fg = Common.ParseIntAfter(text, "FG:");
				text = text.Replace("FG:" + fg, ((fg >= 0 && fg < _mission.FlightGroups.Count) ? _mission.FlightGroups[fg].ToString() : "Undefined"));
			}
			while (text.Contains("IFF:"))
			{
				int iff = Common.ParseIntAfter(text, "IFF:");
				text = text.Replace("IFF:" + iff, "IFF " + Common.SafeString(getIffStrings(), iff, true));
			}
			while (text.Contains("TM:"))
			{
				int team = Common.ParseIntAfter(text, "TM:");
				text = text.Replace("TM:" + team, ((team >= 0 && team < 10 && _mission.Teams[team].Name != "") ? _mission.Teams[team].Name : "Team " + (team + 1).ToString()));
			}
			return text;
		}
		void saveMission(string fileMission)
		{
			tabMain.Focus();
			try { _fBrief.Save(); }
			catch { /* do nothing */ }
			lblTeamArr_Click(lblTeam[_activeTeamIndex], new EventArgs());
			if (Text.IndexOf("*") == -1) return;

			try { _mission.Save(fileMission); }
			catch (Exception x) { MessageBox.Show(x.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			Text = "Ye Olde Galactic Empire Mission Editor - " + (_mission.IsBop ? "BoP" : "XvT") + " - " + _mission.MissionFileName;
			_config.LastMission = fileMission;
			refreshRecent();
			if (_config.Verify) Common.RunVerify(_mission.MissionPath);
		}
		void setBop(bool bop)
		{
			_mission.IsBop = bop;
			if (_mission.IsBop)
			{
				menuNewXvT.Shortcut = Shortcut.None;
				menuNewBoP.Shortcut = Shortcut.CtrlN;
				_config.LastPlatform = Settings.Platform.BoP;
				Text = Text.Substring(0, 41) + "BoP" + Text.Substring(44);
				txtMissDesc.MaxLength = 0x1000;
				menuTest.Enabled = _config.BopInstalled;
			}
			else
			{
				if (txtMissDesc.Text.Length > 0x400 || txtMissSucc.Text.Length != 0 || txtMissFail.Text.Length != 0)
				{
					DialogResult r = MessageBox.Show("Changing platforms will result in loss of Mission Description and Debriefing text", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					if (r == DialogResult.Cancel) { optBoP.Checked = true; return; }

					if (txtMissDesc.Text.Length > 0x400) txtMissDesc.Text = txtMissDesc.Text.Substring(0, 0x400);
				}
				menuTest.Enabled = _config.XvtInstalled;
				menuNewXvT.Shortcut = Shortcut.CtrlN;
				menuNewBoP.Shortcut = Shortcut.None;
				_config.LastPlatform = Settings.Platform.XvT;
				Text = Text.Substring(0, 41) + "XvT" + Text.Substring(44);
				txtMissDesc.MaxLength = 0x400;
				txtMissSucc.Text = "";
				txtMissFail.Text = "";
			}
			optBoP.Checked = _mission.IsBop;
			optXvT.Checked = !optBoP.Checked;
			txtMissSucc.Visible = _mission.IsBop;
			txtMissFail.Visible = _mission.IsBop;
			txtMissSucc.Enabled = _mission.IsBop;
			txtMissFail.Enabled = _mission.IsBop;
			menuNewXvT.ShowShortcut = !_mission.IsBop;
			menuNewBoP.ShowShortcut = _mission.IsBop;
			menuSaveAsBoP.Visible = !_mission.IsBop;
			menuSaveAsXvT.Visible = _mission.IsBop;
			numBackdrop.Maximum = (_mission.IsBop ? 16 : 7);
		}
		void setInteractiveLabelColor(Label control, bool highlight)
		{
			control.ForeColor = highlight ? _config.ColorInteractSelected : _config.ColorInteractNonSelected;
			control.BackColor = _config.ColorInteractBackground;
		}
		void startup()
		{
			loadCraftData("");
			Height = 600;   // since VS tends to slowly shrink the damn thing
			tabMain.SelectedIndex = 0;
			tabFGMinor.SelectedIndex = 0;
			_config.LastMission = "";
			_config.LastPlatform = _mission.IsBop ? Settings.Platform.BoP : Settings.Platform.XvT;
			opnXvT.InitialDirectory = _config.GetWorkingPath();
			savXvT.InitialDirectory = _config.GetWorkingPath();
			comboReset(cboIFF, getIffStrings(), 0);
			_applicationExit = true;    //becomes false if selecting "New Mission" from menu
			#region Menu
			// menuTest has already been taken care of
			if (_config.RestrictPlatforms)
			{
				if (!_config.TieInstalled) { menuNewTIE.Enabled = false; }
				if (!_config.BopInstalled) { menuNewBoP.Enabled = false; }
				if (!_config.XwaInstalled) { menuNewXWA.Enabled = false; }
			}
			menuRecentMissions[0] = menuRecent;
			menuRecentMissions[1] = menuRec1;
			menuRecentMissions[2] = menuRec2;
			menuRecentMissions[3] = menuRec3;
			menuRecentMissions[4] = menuRec4;
			menuRecentMissions[5] = menuRec5;
			for (int i = 1; i < 6; i++)
			{
				menuRecentMissions[i].Click += new EventHandler(menuRecentMissions_Click);
				menuRecentMissions[i].Tag = i;
			}
			refreshRecent();
			#endregion
			#region FlightGroups
			#region Craft
			cboCraft.SelectedIndex = _mission.FlightGroups[0].CraftType; // already loaded in loadCraftData
			cboIFF.SelectedIndex = _mission.FlightGroups[0].IFF; // already loaded in this function
			cboTeam.Items.AddRange(_mission.Teams.GetList()); cboTeam.SelectedIndex = _mission.FlightGroups[0].Team;
			cboAI.Items.AddRange(Strings.Rating); cboAI.SelectedIndex = _mission.FlightGroups[0].AI;
			cboMarkings.Items.AddRange(Strings.Color); cboMarkings.SelectedIndex = _mission.FlightGroups[0].Markings;
			cboPlayer.SelectedIndex = 0;
			cboPosition.SelectedIndex = 0;
			cboFormation.Items.AddRange(Strings.Formation); cboFormation.SelectedIndex = 0;
			cboRadio.Items.AddRange(Strings.Radio); cboRadio.SelectedIndex = (int)_mission.FlightGroups[0].Radio;
			cboStatus.Items.AddRange(Strings.Status); cboStatus.SelectedIndex = 0;
			cboStatus2.Items.AddRange(Strings.Status); cboStatus2.SelectedIndex = 0;
			cboWarheads.Items.AddRange(Strings.Warheads); cboWarheads.SelectedIndex = 0;
			cboBeam.Items.AddRange(Strings.Beam); cboBeam.SelectedIndex = 0;
			cboCounter.SelectedIndex = 0;
			#endregion
			#region Arr/Dep
			cboADTrig.Items.AddRange(Strings.Trigger);
			cboADTrigAmount.Items.AddRange(Strings.Amount);
			cboADTrigType.Items.AddRange(Strings.VariableType);
			cboAbort.Items.AddRange(Strings.Abort); cboAbort.SelectedIndex = 0;
			cboDiff.Items.AddRange(Strings.Difficulty); cboDiff.SelectedIndex = 0;
			string[] fgList = _mission.FlightGroups.GetList();
			cboArrMS.Items.AddRange(fgList); cboArrMS.SelectedIndex = 0;
			cboArrMSAlt.Items.AddRange(fgList); cboArrMSAlt.SelectedIndex = 0;
			cboDepMS.Items.AddRange(fgList); cboDepMS.SelectedIndex = 0;
			cboDepMSAlt.Items.AddRange(fgList); cboDepMSAlt.SelectedIndex = 0;
			lblADTrig[0] = lblArr1;
			lblADTrig[1] = lblArr2;
			lblADTrig[2] = lblArr3;
			lblADTrig[3] = lblArr4;
			lblADTrig[4] = lblDep1;
			lblADTrig[5] = lblDep2;
			for (int i = 0; i < 6; i++)
			{
				lblADTrig[i].Click += new EventHandler(lblADTrigArr_Click);
				lblADTrig[i].MouseUp += new MouseEventHandler(lblADTrigArr_MouseUp);
				lblADTrig[i].DoubleClick += new EventHandler(lblADTrigArr_DoubleClick);
				lblADTrig[i].Tag = i;
			}
			lblADTrigArr_Click(0, new EventArgs());
			optADAndOr[0] = optArr1OR2;
			optADAndOr[1] = optArr3OR4;
			optADAndOr[2] = optArr12OR34;
			optADAndOr[3] = optDepOR;
			optADAndOr[4] = optArr1AND2;
			optADAndOr[5] = optArr3AND4;
			optADAndOr[6] = optArr12AND34;
			optADAndOr[7] = optDepAND;
			for (int i = 0; i < 4; i++)
			{
				optADAndOr[i].CheckedChanged += new EventHandler(optADAndOrArr_CheckedChanged);
				optADAndOr[i].Tag = i;
			}
			cboStopArrivingWhen.Items.AddRange(Strings.StopArrivingWhen);
			#endregion
			#region Orders
			cboOrders.Items.AddRange(Strings.Orders);
			cboOString.Items.AddRange(Strings.OrderDesignation);
			cboOT1Type.Items.AddRange(Strings.VariableType);
			cboOT2Type.Items.AddRange(Strings.VariableType);
			cboOT3Type.Items.AddRange(Strings.VariableType);
			cboOT4Type.Items.AddRange(Strings.VariableType);
			lblOrder[0] = lblOrder1;
			lblOrder[1] = lblOrder2;
			lblOrder[2] = lblOrder3;
			lblOrder[3] = lblOrder4;
			for (int i = 0; i < 4; i++)
			{
				lblOrder[i].Click += new EventHandler(lblOrderArr_Click);
				lblOrder[i].DoubleClick += new EventHandler(lblOrderArr_DoubleClick);
				lblOrder[i].MouseUp += new MouseEventHandler(lblOrderArr_MouseUp);
				lblOrder[i].Tag = i;
			}
			lblOrderArr_Click(0, new EventArgs());
			for (int i = 1; i < 256; i++)  //The designer already starts with one item "default" for 0 MGLT.
				cboOSpeed.Items.Add(Convert.ToInt32(i * 2.2235));
			cboOSpeed.SelectedIndex = 0;
			#endregion
			#region Waypoints
			_table.Columns.Add("X"); _table.Columns.Add("Y"); _table.Columns.Add("Z");
			_tableRaw.Columns.Add("X"); _tableRaw.Columns.Add("Y"); _tableRaw.Columns.Add("Z");
			for (int i = 0; i < 22; i++)    //initialize WPs
			{
				DataRow dr = _table.NewRow();
				int j;
				for (j = 0; j < 3; j++) dr[j] = 0;  //set X Y Z to zero
				_table.Rows.Add(dr);
				dr = _tableRaw.NewRow();
				for (j = 0; j < 3; j++) dr[j] = 0;  //mirror in raw table
				_tableRaw.Rows.Add(dr);
			}
			dataWaypoints.Table = _table;
			dataWaypoints_Raw.Table = _tableRaw;
			dataWP.DataSource = dataWaypoints;
			dataWP_Raw.DataSource = dataWaypoints_Raw;
			_table.RowChanged += new DataRowChangeEventHandler(table_RowChanged);
			_tableRaw.RowChanged += new DataRowChangeEventHandler(tableRaw_RowChanged);
			chkWP[0] = chkSP1;
			chkWP[1] = chkSP2;
			chkWP[2] = chkSP3;
			chkWP[3] = chkSP4;
			chkWP[4] = chkWP1;
			chkWP[5] = chkWP2;
			chkWP[6] = chkWP3;
			chkWP[7] = chkWP4;
			chkWP[8] = chkWP5;
			chkWP[9] = chkWP6;
			chkWP[10] = chkWP7;
			chkWP[11] = chkWP8;
			chkWP[12] = chkWPRend;
			chkWP[13] = chkWPHyp;
			chkWP[14] = chkWPBrief1;
			chkWP[15] = chkWPBrief2;
			chkWP[16] = chkWPBrief3;
			chkWP[17] = chkWPBrief4;
			chkWP[18] = chkWPBrief5;
			chkWP[19] = chkWPBrief6;
			chkWP[20] = chkWPBrief7;
			chkWP[21] = chkWPBrief8;
			for (int i = 0; i < 22; i++)
			{
				chkWP[i].CheckedChanged += new EventHandler(chkWPArr_CheckedChanged);
				chkWP[i].Tag = i;
			}
			#endregion
			#region FG Goals
			cboGoalAmount.Items.AddRange(Strings.Amount);
			cboGoalTrigger.Items.AddRange(Strings.Trigger);
			lblGoal[0] = lblGoal1;
			lblGoal[1] = lblGoal2;
			lblGoal[2] = lblGoal3;
			lblGoal[3] = lblGoal4;
			lblGoal[4] = lblGoal5;
			lblGoal[5] = lblGoal6;
			lblGoal[6] = lblGoal7;
			lblGoal[7] = lblGoal8;
			for (int i = 0; i < 8; i++)
			{
				lblGoal[i].Click += new EventHandler(lblGoalArr_Click);
				lblGoal[i].DoubleClick += new EventHandler(lblGoalArr_DoubleClick);
				lblGoal[i].MouseUp += new MouseEventHandler(lblGoalArr_MouseUp);
				lblGoal[i].Tag = i;
			}
			lstGoalTeams.Items.AddRange(_mission.Teams.GetList());
			lblGoalArr_Click(0, new EventArgs());
			#endregion
			#region Options
			cboOptCraft.Items.AddRange(Strings.CraftType);
			cboSkipAmount.Items.AddRange(Strings.Amount); cboSkipAmount.SelectedIndex = 0;
			cboSkipTrig.Items.AddRange(Strings.Trigger); cboSkipTrig.SelectedIndex = 0;
			cboSkipType.Items.AddRange(Strings.VariableType); cboSkipType.SelectedIndex = 0;
			cboRole1.Items.AddRange(Strings.Roles); cboRole1.SelectedIndex = 0;
			cboRole2.Items.AddRange(Strings.Roles); cboRole2.SelectedIndex = 0;
			cboRole3.Items.AddRange(Strings.Roles); cboRole3.SelectedIndex = 0;
			cboRole4.Items.AddRange(Strings.Roles); cboRole4.SelectedIndex = 0;
			cboRoleTeam1.Items.AddRange(Strings.RoleTeams); cboRoleTeam1.SelectedIndex = 0;
			cboRoleTeam2.Items.AddRange(Strings.RoleTeams); cboRoleTeam2.SelectedIndex = 0;
			cboRoleTeam3.Items.AddRange(Strings.RoleTeams); cboRoleTeam3.SelectedIndex = 0;
			cboRoleTeam4.Items.AddRange(Strings.RoleTeams); cboRoleTeam4.SelectedIndex = 0;
			chkOpt[0] = chkOptWNone;
			chkOpt[1] = chkOptWBomb;
			chkOpt[2] = chkOptWRocket;
			chkOpt[3] = chkOptWMissile;
			chkOpt[4] = chkOptWTorp;
			chkOpt[5] = chkOptWAdvMissile;
			chkOpt[6] = chkOptWAdvTorp;
			chkOpt[7] = chkOptWMagPulse;
			chkOpt[8] = chkOptWIonPulse;
			chkOpt[9] = chkOptBNone;
			chkOpt[10] = chkOptBTractor;
			chkOpt[11] = chkOptBJamming;
			chkOpt[12] = chkOptBDecoy;
			chkOpt[13] = chkOptBEnergy;
			chkOpt[14] = chkOptCNone;
			chkOpt[15] = chkOptCChaff;
			chkOpt[16] = chkOptCFlare;
			chkOpt[17] = chkOptCCluster;
			for (int i = 0; i < 18; i++)
			{
				chkOpt[i].CheckedChanged += new EventHandler(chkOptArr_CheckedChanged);
				chkOpt[i].Tag = i;
			}
			lblOptCraft[0] = lblOptCraft1;
			lblOptCraft[1] = lblOptCraft2;
			lblOptCraft[2] = lblOptCraft3;
			lblOptCraft[3] = lblOptCraft4;
			lblOptCraft[4] = lblOptCraft5;
			lblOptCraft[5] = lblOptCraft6;
			lblOptCraft[6] = lblOptCraft7;
			lblOptCraft[7] = lblOptCraft8;
			lblOptCraft[8] = lblOptCraft9;
			lblOptCraft[9] = lblOptCraft10;
			for (int i = 0; i < 10; i++)
			{
				lblOptCraft[i].Click += new EventHandler(lblOptCraftArr_Click);
				lblOptCraft[i].Tag = i;
			}
			#endregion
			#endregion
			#region Messages
			cboMessAmount.Items.AddRange(Strings.Amount);
			cboMessTrig.Items.AddRange(Strings.Trigger);
			cboMessType.Items.AddRange(Strings.VariableType);
			chkSendTo[0] = chkMess1;
			chkSendTo[1] = chkMess2;
			chkSendTo[2] = chkMess3;
			chkSendTo[3] = chkMess4;
			chkSendTo[4] = chkMess5;
			chkSendTo[5] = chkMess6;
			chkSendTo[6] = chkMess7;
			chkSendTo[7] = chkMess8;
			chkSendTo[8] = chkMess9;
			chkSendTo[9] = chkMess10;
			for (int i = 0; i < 10; i++)
			{
				chkSendTo[i].Leave += new EventHandler(chkSendToArr_Leave);
				chkSendTo[i].Tag = i;
			}
			lblMessTrig[0] = lblMess1;
			lblMessTrig[1] = lblMess2;
			lblMessTrig[2] = lblMess3;
			lblMessTrig[3] = lblMess4;
			for (int i = 0; i < 4; i++)
			{
				lblMessTrig[i].Click += new EventHandler(lblMessTrigArr_Click);
				lblMessTrig[i].DoubleClick += new EventHandler(lblMessTrigArr_DoubleClick);
				lblMessTrig[i].MouseUp += new MouseEventHandler(lblMessTrigArr_MouseUp);
				lblMessTrig[i].Tag = i;
			}
			#endregion
			#region Globals
			cboGlobalAmount.Items.AddRange(Strings.Amount);
			cboGlobalTrig.Items.AddRange(Strings.Trigger);
			cboGlobalType.Items.AddRange(Strings.VariableType);
			cboGlobalTeam.Items.AddRange(_mission.Teams.GetList());
			lblGlobTrig[0] = lblPrim1;
			lblGlobTrig[1] = lblPrim2;
			lblGlobTrig[2] = lblPrim3;
			lblGlobTrig[3] = lblPrim4;
			lblGlobTrig[4] = lblPrev1;
			lblGlobTrig[5] = lblPrev2;
			lblGlobTrig[6] = lblPrev3;
			lblGlobTrig[7] = lblPrev4;
			lblGlobTrig[8] = lblSec1;
			lblGlobTrig[9] = lblSec2;
			lblGlobTrig[10] = lblSec3;
			lblGlobTrig[11] = lblSec4;
			for (int i = 0; i < 12; i++)
			{
				lblGlobTrig[i].Click += new EventHandler(lblGlobTrigArr_Click);
				lblGlobTrig[i].DoubleClick += new EventHandler(lblGlobTrigArr_DoubleClick);
				lblGlobTrig[i].MouseUp += new MouseEventHandler(lblGlobTrigArr_MouseUp);
				lblGlobTrig[i].Tag = i;
			}
			optGlobAndOr[0] = optPrim1OR2;
			optGlobAndOr[1] = optPrim3OR4;
			optGlobAndOr[2] = optPrim12OR34;
			optGlobAndOr[3] = optPrev1OR2;
			optGlobAndOr[4] = optPrev3OR4;
			optGlobAndOr[5] = optPrev12OR34;
			optGlobAndOr[6] = optSec1OR2;
			optGlobAndOr[7] = optSec3OR4;
			optGlobAndOr[8] = optSec12OR34;
			optGlobAndOr[9] = optPrim1AND2;
			optGlobAndOr[10] = optPrim3AND4;
			optGlobAndOr[11] = optPrim12AND34;
			optGlobAndOr[12] = optPrev1AND2;
			optGlobAndOr[13] = optPrev3AND4;
			optGlobAndOr[14] = optPrev12AND34;
			optGlobAndOr[15] = optSec1AND2;
			optGlobAndOr[16] = optSec3AND4;
			optGlobAndOr[17] = optSec12AND34;
			for (int i = 0; i < 9; i++)
			{
				optGlobAndOr[i].CheckedChanged += new EventHandler(optGlobAndOrArr_CheckedChanged);
				optGlobAndOr[i].Tag = i;
			}
			txtGlobalComp.Tag = Globals.GoalState.Complete;
			txtGlobalFail.Tag = Globals.GoalState.Failed;
			txtGlobalInc.Tag = Globals.GoalState.Incomplete;
			#endregion
			#region Teams
			lblTeam[0] = lblTeam1;
			lblTeam[1] = lblTeam2;
			lblTeam[2] = lblTeam3;
			lblTeam[3] = lblTeam4;
			lblTeam[4] = lblTeam5;
			lblTeam[5] = lblTeam6;
			lblTeam[6] = lblTeam7;
			lblTeam[7] = lblTeam8;
			lblTeam[8] = lblTeam9;
			lblTeam[9] = lblTeam10;
			chkAllies[0] = chkTeam1;
			chkAllies[1] = chkTeam2;
			chkAllies[2] = chkTeam3;
			chkAllies[3] = chkTeam4;
			chkAllies[4] = chkTeam5;
			chkAllies[5] = chkTeam6;
			chkAllies[6] = chkTeam7;
			chkAllies[7] = chkTeam8;
			chkAllies[8] = chkTeam9;
			chkAllies[9] = chkTeam10;
			for (int i = 0; i < 10; i++)
			{
				lblTeam[i].Click += new EventHandler(lblTeamArr_Click);
				lblTeam[i].DoubleClick += new EventHandler(lblTeamArr_DoubleClick);
				lblTeam[i].MouseUp += new MouseEventHandler(lblTeamArr_MouseUp);
				lblTeam[i].Tag = i;
				chkAllies[i].Leave += new EventHandler(chkAlliesArr_Leave);
				chkAllies[i].Tag = i;
			}
			cboEoMColor[0] = cboPC1Color;
			cboEoMColor[1] = cboPC2Color;
			cboEoMColor[2] = cboPF1Color;
			cboEoMColor[3] = cboPF2Color;
			cboEoMColor[4] = cboSC1Color;
			cboEoMColor[5] = cboSC2Color;
			txtEoM[0] = txtPrimComp1;
			txtEoM[1] = txtPrimComp2;
			txtEoM[2] = txtPrimFail1;
			txtEoM[3] = txtPrimFail2;
			txtEoM[4] = txtSecComp1;
			txtEoM[5] = txtSecComp2;
			for (int i = 0; i < 6; i++)
			{
				cboEoMColor[i].SelectedIndexChanged += new EventHandler(cboEoMColorArr_SelectedIndexChanged);
				cboEoMColor[i].Tag = i;
				txtEoM[i].Leave += new EventHandler(txtEoMArr_Leave);
				txtEoM[i].Tag = i;
			}
			for (_activeTeamIndex = 0; _activeTeamIndex < 10; _activeTeamIndex++) teamRefresh();
			#endregion
			cboGlobalTeam.SelectedIndex = 0;
			cboMissType.Items.AddRange(Enum.GetNames(typeof(Mission.MissionTypeEnum)));
			cboMissType.SelectedIndex = 0;

			txtIFF[0] = txtIFF3;
			txtIFF[1] = txtIFF4;
			txtIFF[2] = txtIFF5;
			txtIFF[3] = txtIFF6;
			for (int i = 0; i < 4; i++)
			{
				txtIFF[i].Leave += new EventHandler(txtIFFArr_Leave);
				txtIFF[i].Tag = i + 2;
			}

			#region ControlRegistration
			registerColorizedFGList(cboADTrigVar, cboADTrigType);
			registerColorizedFGList(cboSkipVar, cboSkipType);
			registerColorizedFGList(cboMessVar, cboMessType);
			registerColorizedFGList(cboGlobalVar, cboGlobalType);
			registerColorizedFGList(cboOT1, cboOT1Type);
			registerColorizedFGList(cboOT2, cboOT2Type);
			registerColorizedFGList(cboOT3, cboOT3Type);
			registerColorizedFGList(cboOT4, cboOT4Type);
			registerColorizedFGList(cboArrMS, null);
			registerColorizedFGList(cboArrMSAlt, null);
			registerColorizedFGList(cboDepMS, null);
			registerColorizedFGList(cboDepMSAlt, null);

			registerFgMultiEdit(txtName, "Name", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftName);
			registerFgMultiEdit(numCraft, "NumberOfCraft", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftName | MultiEditRefreshType.CraftCount);
			registerFgMultiEdit(numWaves, "NumberOfWaves", MultiEditRefreshType.ItemText);
			registerFgMultiEdit(numWavesDelay, "WavesDelay", 0);
			// numGG has special logic applied, doesn't update through this
			registerFgMultiEdit(numGU, "GlobalUnit", MultiEditRefreshType.ItemText);
			registerFgMultiEdit(chkPreventNumbering, "PreventCraftNumbering", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftName);
			registerFgMultiEdit(txtCargo, "Cargo", 0);
			registerFgMultiEdit(txtSpecCargo, "SpecialCargo", 0);
			registerFgMultiEdit(numSC, "SpecialCargoCraft", 0);
			registerFgMultiEdit(chkRandSC, "RandSpecCargo", 0);
			registerFgMultiEdit(cboCraft, "CraftType", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftName);
			registerFgMultiEdit(cboIFF, "IFF", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftName);
			registerFgMultiEdit(cboTeam, "Team", MultiEditRefreshType.ItemText);
			registerFgMultiEdit(cboAI, "AI", 0);
			registerFgMultiEdit(cboMarkings, "Markings", 0);
			registerFgMultiEdit(cboPlayer, "PlayerNumber", MultiEditRefreshType.ItemText);
			registerFgMultiEdit(cboPosition, "PlayerCraft", 0);
			registerFgMultiEdit(cboRadio, "Radio", 0);
			registerFgMultiEdit(cboFormation, "Formation", 0);
			registerFgMultiEdit(numSpacing, "FormDistance", 0);
			registerFgMultiEdit(cboStatus, "Status1", 0);    // numBackdrop tied to Status1
			registerFgMultiEdit(cboStatus2, "Status2", 0);
			registerFgMultiEdit(cboWarheads, "Missile", 0);
			registerFgMultiEdit(cboBeam, "Beam", 0);
			registerFgMultiEdit(cboCounter, "Countermeasures", 0);
			registerFgMultiEdit(numExplode, "ExplosionTime", 0);

			registerFgMultiEdit(optArrMS, "ArriveViaMothership", 0);
			registerFgMultiEdit(cboArrMS, "ArrivalMothership", 0);
			registerFgMultiEdit(optArrMSAlt, "AlternateMothershipUsed", 0);
			registerFgMultiEdit(cboArrMSAlt, "AlternateMothership", 0);
			registerFgMultiEdit(optDepMS, "DepartViaMothership", 0);
			registerFgMultiEdit(cboDepMS, "DepartureMothership", 0);
			registerFgMultiEdit(optDepMSAlt, "CapturedDepartViaMothership", 0);
			registerFgMultiEdit(cboDepMSAlt, "CapturedDepartureMothership", 0);
			registerFgMultiEdit(cboADTrigAmount, "ArrDepTrigger", MultiEditRefreshType.ArrDepLabel);
			registerFgMultiEdit(cboADTrigType, "ArrDepTrigger", MultiEditRefreshType.ArrDepLabel);
			registerFgMultiEdit(cboADTrigVar, "ArrDepTrigger", MultiEditRefreshType.ArrDepLabel);
			registerFgMultiEdit(cboADTrig, "ArrDepTrigger", MultiEditRefreshType.ArrDepLabel | MultiEditRefreshType.CraftCount);
			registerFgMultiEdit(numArrMin, "ArrivalDelayMinutes", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftCount);
			registerFgMultiEdit(numArrSec, "ArrivalDelaySeconds", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftCount);
			registerFgMultiEdit(cboAbort, "AbortTrigger", 0);
			registerFgMultiEdit(numDepMin, "DepartureTimerMinutes", 0);
			registerFgMultiEdit(numDepSec, "DepartureTimerSeconds", 0);
			registerFgMultiEdit(numDepClockMin, "DepartureClockMinutes", 0);
			registerFgMultiEdit(numDepClockSec, "DepartureClockSeconds", 0);
			registerFgMultiEdit(cboDiff, "Difficulty", MultiEditRefreshType.ItemText | MultiEditRefreshType.CraftCount);
			registerFgMultiEdit(chkArrHuman, "ArriveOnlyIfHuman", MultiEditRefreshType.ItemText);

			registerFgMultiEdit(txtGoalInc, "GoalTriggerInc", 0);
			registerFgMultiEdit(txtGoalComp, "GoalTriggerComp", 0);
			registerFgMultiEdit(txtGoalFail, "GoalTriggerFail", 0);
			registerFgMultiEdit(cboGoalAmount, "GoalTriggerAmount", MultiEditRefreshType.FgGoalLabel);
			registerFgMultiEdit(cboGoalArgument, "GoalTriggerArgument", MultiEditRefreshType.FgGoalLabel);
			registerFgMultiEdit(cboGoalTrigger, "GoalTriggerCondition", MultiEditRefreshType.FgGoalLabel);
			registerFgMultiEdit(numGoalPoints, "GoalTriggerPoints", MultiEditRefreshType.FgGoalLabel);
			registerFgMultiEdit(numGoalTimeLimit, "GoalTriggerTime", 0);

			registerFgMultiEdit(cboOrders, "OrderCommand", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOString, "OrderDesignation", 0);
			registerFgMultiEdit(cboOT1, "OrderTarget1", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT2, "OrderTarget2", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT3, "OrderTarget3", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT4, "OrderTarget4", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT1Type, "OrderTarget1Type", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT2Type, "OrderTarget2Type", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT3Type, "OrderTarget3Type", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOT4Type, "OrderTarget4Type", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(numOVar1, "OrderVar1", 0);
			registerFgMultiEdit(numOVar2, "OrderVar2", 0);
			registerFgMultiEdit(optOT1T2OR, "Order12Or", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(optOT3T4OR, "Order34Or", MultiEditRefreshType.OrderLabel);
			registerFgMultiEdit(cboOThrottle, "OrderThrottle", 0);
			registerFgMultiEdit(cboOSpeed, "OrderSpeed", 0);
			registerFgMultiEdit(cboHandicap, "Handicap", 0);

			registerFgMultiEdit(cboStopArrivingWhen, "StopArrivingWhen", 0);
			registerFgMultiEdit(numRandomArrivalDelayMinutes, "RandomArrivalDelayMinutes", 0);
			registerFgMultiEdit(numRandomArrivalDelaySeconds, "RandomArrivalDelaySeconds", 0);

			registerFgMultiEdit(cboOptCat, "OptCategory", 0);
			registerFgMultiEdit(numOptWaves, "OptNumWaves", MultiEditRefreshType.OptCraftLabel);
			registerFgMultiEdit(numOptCraft, "OptNumCraft", MultiEditRefreshType.OptCraftLabel);
			registerFgMultiEdit(cboOptCraft, "OptCraftType", MultiEditRefreshType.OptCraftLabel);
			registerFgMultiEdit(cboSkipAmount, "SkipTrigger", MultiEditRefreshType.SkipLabel);
			registerFgMultiEdit(cboSkipType, "SkipTrigger", MultiEditRefreshType.SkipLabel);
			registerFgMultiEdit(cboSkipVar, "SkipTrigger", MultiEditRefreshType.SkipLabel);
			registerFgMultiEdit(cboSkipTrig, "SkipTrigger", MultiEditRefreshType.SkipLabel);
			registerFgMultiEdit(optSkipOR, "SkipTriggerOr", 0);

			registerFgMultiEdit(numPitch, "Pitch", 0);
			registerFgMultiEdit(numYaw, "Yaw", 0);
			registerFgMultiEdit(numRoll, "Roll", 0);

			registerMsgMultiEdit(cboMessAmount, "MessTrigger", 0);
			registerMsgMultiEdit(cboMessType, "MessTrigger", 0);
			registerMsgMultiEdit(cboMessVar, "MessTrigger", 0);
			registerMsgMultiEdit(cboMessTrig, "MessTrigger", 0);
			registerMsgMultiEdit(cboMessColor, "MessColor", MultiEditRefreshType.ItemText);
			registerMsgMultiEdit(numMessDelay, "MessDelay", 0);
			registerMsgMultiEdit(optMess1OR2, "Mess1OR2", 0);
			registerMsgMultiEdit(optMess3OR4, "Mess3OR4", 0);
			registerMsgMultiEdit(optMess12OR34, "Mess12OR34", 0);
			#endregion ControlRegistration

			applySettingsHandler(0, new EventArgs());  // Configurable colors were added to options.
		}
		void updateMissionTabs()
		{
			numWinType.Value = _mission.WinType;
			for (int i = 0; i < 4; i++) txtIFF[i].Text = _mission.IFFs[i + 2];
			cboMissType.SelectedIndex = (int)_mission.MissionType;
			chkGoalsUnimportant.Checked = _mission.GoalsUnimportant;
			numRndSeed.Value = _mission.RndSeed;
			numMissTimeMin.Value = _mission.TimeLimitMin;
			numMissTimeSec.Value = _mission.TimeLimitSec;
			txtMissDesc.Text = _mission.MissionDescription;
			txtMissSucc.Text = _mission.MissionSuccessful;
			txtMissFail.Text = _mission.MissionFailed;
		}
		void registerFgMultiEdit(Control control, string propertyName, MultiEditRefreshType refreshType)
		{
			Common.AddControlChangedHandler(control, flightgroupMultiEditHandler);
			control.Tag = new MultiEditProperty(propertyName, refreshType);
		}
		void registerMsgMultiEdit(Control control, string propertyName, MultiEditRefreshType refreshType)
		{
			Common.AddControlChangedHandler(control, messageMultiEditHandler);
			control.Tag = new MultiEditProperty(propertyName, refreshType);
		}
		Mission.Trigger getTriggerFromControls(ComboBox amount, ComboBox varType, ComboBox var, ComboBox condition)
		{
			Mission.Trigger ret = new Mission.Trigger
			{
				Amount = (byte)amount.SelectedIndex,
				VariableType = (byte)varType.SelectedIndex,
				Variable = (byte)var.SelectedIndex,
				Condition = (byte)condition.SelectedIndex
			};
			return ret;
		}
		#endregion methods

		#region event handlers
		/// <summary> Apply color changes to all interactive labels. </summary>
		/// <remarks>This is a callback event when the program settings are updated.</remarks>
		void applySettingsHandler(object sender, EventArgs e)
		{
			foreach (Label lbl in lblADTrig) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeArrDepTriggerIndex.ToString());  //Tags are set to ints, but casting objects throws an exception, so convert to string and check those instead.
			foreach (Label lbl in lblGoal) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeFGGoalIndex.ToString());
			foreach (Label lbl in lblOrder) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeOrderIndex.ToString());
			foreach (Label lbl in lblOptCraft) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeOptionCraftIndex.ToString());
			foreach (Label lbl in lblMessTrig) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeMessageTriggerIndex.ToString());
			foreach (Label lbl in lblGlobTrig) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeGlobalTriggerIndex.ToString());
			foreach (Label lbl in lblTeam) setInteractiveLabelColor(lbl, lbl.Tag.ToString() == _activeTeamIndex.ToString());
			setInteractiveLabelColor(lblSkipTrig1, _activeSkipTriggerIndex == 0);
			setInteractiveLabelColor(lblSkipTrig2, _activeSkipTriggerIndex == 1);
		}

		void briefingModifiedCallback(object sender, EventArgs e) => Common.MarkDirty(this, _loading);

		void colorizedComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox variable = (ComboBox)sender;
			ColorizedFGList.TryGetValue(variable, out ComboBox variableType);
			bool colorize = true;
			if (variableType != null)        //If a VariableType selection control is attached, check that a Flight Group type is selected.
				colorize = (variableType.SelectedIndex == 1 || variableType.SelectedIndex == 0xF);

			if (e.Index == -1 || e.Index >= _mission.FlightGroups.Count) colorize = false;

			if (variable.BackColor == Color.Black || variable.BackColor == SystemColors.Window)
				variable.BackColor = (colorize == true) ? Color.Black : SystemColors.Window;

			e.DrawBackground();
			Brush brText = SystemBrushes.ControlText;
			if (colorize == true) brText = getFlightGroupDrawColor(e.Index);
			e.Graphics.DrawString(e.Index >= 0 ? variable.Items[e.Index].ToString() : "", e.Font, brText, e.Bounds, StringFormat.GenericDefault);
		}

		void form_Activated(object sender, EventArgs e) => lstFG_SelectedIndexChanged(0, new EventArgs());
		void form_Deactivate(object sender, EventArgs e) => lstFG.Focus();
		void form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			promptSave();
			if (_config.ConfirmExit && _applicationExit && Text.IndexOf("*") != -1)
			{
				DialogResult res = MessageBox.Show("There are unsaved changes, are you sure you wish to exit?", "Confirm", MessageBoxButtons.YesNo);
				if (res == DialogResult.No) { e.Cancel = true; return; }
			}
			closeForms();
			if (_applicationExit) Application.Exit();
		}
		void form_KeyDown(object sender, KeyEventArgs e)
		{
			//Instead of assigning this in designer.cs
			//  this.menuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
			//Trap and process the key here, with few changes to the original code
			//while allowing the delete key to remain functional in other areas like text boxes.

			if (e.KeyCode == Keys.Delete)
			{
				if (lstFG.Focused || lstMessages.Focused)
				{
					menuDelete_Click(0, new EventArgs());
					e.Handled = true;
				}
			}
			else if (Common.KeyDown(ActiveControl, e))
			{
				e.Handled = true;
				e.SuppressKeyPress = true; // Stop the Windows UI beeping
			}
		}
		void flightgroupMultiEditHandler(object sender, EventArgs e)
		{
			if (_loading) return;
			MultiEditProperty prop = (MultiEditProperty)((Control)sender).Tag;
			if (prop.Name != "")
			{
				setFlightgroupProperty(prop.RefreshType, prop.Name, Common.GetControlValue(sender));
				Common.MarkDirty(this);  // Since we're not loading, any change marks as dirty.
			}
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.ItemText)) listRefreshSelectedItems();
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.CraftName)) updateFGList();
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.FgGoalLabel)) goalLabelRefresh();
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.OrderLabel)) orderLabelRefresh();
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.OptCraftLabel)) optCraftLabelRefresh();
		}
		void messageMultiEditHandler(object sender, EventArgs e)
		{
			if (_loading) return;
			MultiEditProperty prop = (MultiEditProperty)((Control)sender).Tag;
			if (prop.Name != "")
			{
				setMessageProperty(prop.Name, Common.GetControlValue(sender));
				Common.MarkDirty(this);
			}
			if (prop.RefreshType.HasFlag(MultiEditRefreshType.ItemText)) messRefreshSelectedItems();
		}

		void savXvT_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_mission.MissionPath = savXvT.FileName;
			saveMission(_mission.MissionPath);
		}

		void tabMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabMain.SelectedIndex)
			{
				case 0:
					toolNewItem.ToolTipText = "New FlightGroup";
					toolNewItem.Enabled = true;
					toolDeleteItem.ToolTipText = "Delete FlightGroup";
					toolDeleteItem.Enabled = true;
					toolCopy.ToolTipText = "Copy FlightGroup";
					toolPaste.ToolTipText = "Paste FlightGroup";
					break;
				case 1:
					toolNewItem.ToolTipText = "New Message";
					toolNewItem.Enabled = true;
					toolDeleteItem.ToolTipText = "Delete Message";
					toolDeleteItem.Enabled = true;
					toolCopy.ToolTipText = "Copy Message";
					toolPaste.ToolTipText = "Paste Message";
					break;
				case 2:
					toolCopy.ToolTipText = "Copy selected Global Goal";
					toolPaste.ToolTipText = "Paste into selected Global Goal";
					toolNewItem.Enabled = false;
					toolDeleteItem.Enabled = false;
					toolNewItem.ToolTipText = "";
					toolDeleteItem.ToolTipText = "";
					break;
				case 3:
					toolCopy.ToolTipText = "Copy selected Team";
					toolPaste.ToolTipText = "Paste into selected Team";
					toolNewItem.Enabled = false;
					toolDeleteItem.Enabled = false;
					toolNewItem.ToolTipText = "";
					toolDeleteItem.ToolTipText = "";
					break;
				default:
					toolNewItem.Enabled = false;
					toolDeleteItem.Enabled = false;
					toolNewItem.ToolTipText = "";
					toolDeleteItem.ToolTipText = "";
					toolCopy.ToolTipText = "Copy Item";
					toolPaste.ToolTipText = "Paste Item";
					break;
			}
		}

		void toolXvT_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			toolXvT.Focus();    // clicking the toolbar doesn't remove focus, so last change may not be saved
			switch (toolXvT.Buttons.IndexOf(e.Button))
			{
				case 0:     //New Mission
					menuNewXvT_Click("toolbar", new EventArgs());
					_loading = false;
					break;
				case 1:     //Open Mission
					menuOpen_Click("toolbar", new EventArgs());
					_loading = false;
					break;
				case 2:     //Save Mission
					menuSave_Click("toolbar", new EventArgs());
					break;
				case 3:     //Save As
					if (_mission.IsBop) menuSaveAsBoP_Click("toolbar", new EventArgs());
					else menuSaveAsXvT_Click("toolbar", new EventArgs());
					break;
				case 5:     //New Item
					if (tabMain.SelectedIndex == 0) newFG();
					else if (tabMain.SelectedIndex == 1) newMess();
					break;
				case 6:     //Delete Item
					menuDelete_Click("toolbar", new EventArgs());
					break;
				case 7:     //Copy Item
					menuCopy_Click("toolbar", new EventArgs());
					break;
				case 8:     //Paste Item
					menuPaste_Click("toolbar", new EventArgs());
					break;
				case 10:    //Map
					menuMap_Click("toolbar", new EventArgs());
					break;
				case 11:    //Briefing
					menuBrief_Click("toolbar", new EventArgs());
					break;
				case 12:    //Verify
					menuVerify_Click("toolbar", new EventArgs());
					break;
				case 14:    //Options
					menuOptions_Click("toolbar", new EventArgs());
					break;
				case 15:    //LST
					menuLST_Click("toolbar", new EventArgs());
					break;
				case 16:    //Help
					menuHelpInfo_Click("toolbar", new EventArgs());
					break;
			}
		}
		#endregion event handlers

		#region Menu
		void menuAbout_Click(object sender, EventArgs e) => new AboutDialog().ShowDialog();
		void menuBrief_Click(object sender, EventArgs e)
		{
			Common.MarkDirty(this);
			try { _fBrief.Close(); }
			catch { /* do nothing */ }
			_fBrief = new BriefingForm(_mission.FlightGroups, _mission.Briefings, briefingModifiedCallback);
			_fBrief.Show();
		}
		void menuCopy_Click(object sender, EventArgs e)
		{
			System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Stream stream = new MemoryStream();
			DataObject data = new DataObject();

			if (sender.ToString() == "AD" || hasFocus(lblADTrig))
			{
				formatter.Serialize(stream, _activeArrDepTrigger);
				data.SetText(_activeArrDepTrigger.ToString());
			}
			else if (sender.ToString() == "Goal" || hasFocus(lblGoal))
			{
				formatter.Serialize(stream, _activeFGGoal);
				data.SetText(_activeFGGoal.ToString());
			}
			else if (sender.ToString() == "Order" || hasFocus(lblOrder))
			{
				formatter.Serialize(stream, _activeOrder);
				data.SetText(_activeOrder.ToString());
			}
			else if (sender.ToString() == "Skip" || lblSkipTrig1.Focused || lblSkipTrig2.Focused)
			{
				formatter.Serialize(stream, _activeFG.SkipToOrder4Trigger[(lblSkipTrig1.ForeColor == getHighlightColor() ? 0 : 1)]);
				data.SetText(_activeFG.SkipToOrder4Trigger[(lblSkipTrig1.ForeColor == getHighlightColor() ? 0 : 1)].ToString());
			}
			else if (ActiveControl.GetType().ToString() == "System.Windows.Forms.TextBox")
			{
				TextBox txt = (TextBox)ActiveControl;
				if (txt.SelectedText != "")
				{
					formatter.Serialize(stream, txt.SelectedText);
					data.SetText(txt.SelectedText);
				}
			}
			else if (ActiveControl.GetType().ToString() == "System.Windows.Forms.NumericUpDown")
			{
				NumericUpDown num = (NumericUpDown)ActiveControl;
				formatter.Serialize(stream, num.Value);
				data.SetText(num.Value.ToString());
			}
			else if (ActiveControl.GetType().ToString() == "System.Windows.Forms.DataGridTextBox")
			{
				DataGridTextBox dgt = (DataGridTextBox)ActiveControl;
				if (dgt.Text != "")
				{
					formatter.Serialize(stream, dgt.Text);
					data.SetText(dgt.Text);
				}
			}
			else if (sender.ToString() == "MessTrig" || hasFocus(lblMessTrig))
			{
				formatter.Serialize(stream, _activeMessage.Triggers[_activeMessageTriggerIndex]);
				data.SetText(_activeMessage.Triggers[_activeMessageTriggerIndex].ToString());
			}
			else
			{
				switch (tabMain.SelectedIndex)
				{
					case 0:
						formatter.Serialize(stream, _activeFG);
						data.SetText(_activeFG.ToString());
						break;
					case 1:
						if (_mission.Messages.Count != 0)
						{
							formatter.Serialize(stream, _activeMessage);
							data.SetText(_activeMessage.MessageString);
						}
						break;
					case 2:
						formatter.Serialize(stream, _activeGGTrigger.GoalTrigger);
						data.SetText(_activeGGTrigger.GoalTrigger.ToString());
						break;
					case 3:
						formatter.Serialize(stream, _activeTeam);
						data.SetText(_activeTeam.Name);
						break;
					default:
						break;
				}
			}
			data.SetData("yogeme", false, stream);
			Clipboard.SetDataObject(data, true);
		}
		void menuCut_Click(object sender, EventArgs e) { if (Common.Cut(ActiveControl)) Common.MarkDirty(this); }
		void menuER_Click(object sender, EventArgs e) => Common.LaunchER();
		void menuExit_Click(object sender, EventArgs e) => Close();
		void menuGlobalSummary_Click(object sender, EventArgs e) => new GlobalSummaryDialog(_mission.FlightGroups).Show();
		void menuGoalSummary_Click(object sender, EventArgs e)
		{
			string output = "(global goals not included):\r\n----------\r\n" + generateGoalSummary();
			new GoalSummaryDialog(output).Show();
		}
		void menuLibrary_Click(object sender, EventArgs e)
		{
			_fLibrary?.Close();
			_fLibrary = new FlightGroupLibraryForm(Settings.Platform.XvT, _mission.FlightGroups, flightGroupLibraryCallback);
		}
		void flightGroupLibraryCallback(object sender, EventArgs e)
		{
			foreach (object obj in (object[])sender)
			{
				FlightGroup fg = (FlightGroup)obj;
				if (fg == null || !newFG()) break;

				_mission.FlightGroups[_activeFGIndex] = fg;
				updateFGList();
				listRefreshItem(_activeFGIndex);
				_startingShips--;
				craftStart(fg, true);
			}
		}
		void menuHelpInfo_Click(object sender, EventArgs e) => Common.LaunchHelp();
		void menuIDMR_Click(object sender, EventArgs e) => Common.LaunchGithub();
		void menuLST_Click(object sender, EventArgs e)
		{
			try { _fLST.Close(); }
			catch { /* do nothing */ }
			if (_mission.IsBop) _fLST = new LstForm(Settings.Platform.BoP);
			else _fLST = new LstForm(Settings.Platform.XvT);
			_fLST.Show();
		}
		void menuMap_Click(object sender, EventArgs e)
		{
			try { _fMap.Close(); }
			catch { /* do nothing */ }
			_fMap = new MapForm(_mission.IsBop, _mission.FlightGroups, mapForm_DataChangedCallback);
			_fMap.Show();
		}
		void mapForm_DataChangedCallback(object sender, EventArgs e)
		{
			Common.MarkDirty(this);
			if (tabFGMinor.SelectedIndex == 3) refreshWaypointTab();
		}
		void menuNewXwing_Click(object sender, EventArgs e)
		{
			promptSave();
			closeForms();
			_applicationExit = false;
			new XwingForm().Show();
			Close();
		}
		void menuNewBoP_Click(object sender, EventArgs e) => menuNewXvT_Click("BoP", new EventArgs());
		void menuNewTIE_Click(object sender, EventArgs e)
		{
			promptSave();
			closeForms();
			_applicationExit = false;
			new TieForm().Show();
			Close();
		}
		void menuNewXvT_Click(object sender, EventArgs e)
		{
			promptSave();
			closeForms();
			_loading = true;
			initializeMission();
			updateMissionTabs();
			lstMessages.Items.Clear();
			enableMessages(false);
			lblMessage.Text = "Message #0 of 0";
			lstFG.SelectedIndex = 0;
			for (_activeTeamIndex = 0; _activeTeamIndex < 10; _activeTeamIndex++) teamRefresh();
			lblTeamArr_Click(lblTeam[0], new EventArgs());
			setBop(sender.ToString() == "BoP");
			if (Text.EndsWith("*")) Text = Text.Substring(0, Text.Length - 1);
			_loading = false;
		}
		void menuNewXWA_Click(object sender, EventArgs e)
		{
			promptSave();
			closeForms();
			_applicationExit = false;
			new XwaForm().Show();
			Close();
		}
		void menuOpen_Click(object sender, EventArgs e)
		{
			promptSave();
			opnXvT.FileName = _mission.MissionFileName;
			if (_mission.MissionFileName != "NewMission.tie") opnXvT.InitialDirectory = Directory.GetParent(_mission.MissionPath).FullName; // follow current mission, fixes when switching platforms it wouldn't follow
			if (opnXvT.ShowDialog() == DialogResult.Cancel) return;

			_loading = true;
			if (loadMission(opnXvT.FileName))
			{
				tabMain.SelectedIndex = 0;
				tabFGMinor.SelectedIndex = 0;
				lstFG.SelectedIndex = 0;
				if (_mission.Messages.Count != 0) lstMessages.SelectedIndex = 0;
			}
			_loading = false;
			_config.SetWorkingPath(Path.GetDirectoryName(opnXvT.FileName));
			opnXvT.InitialDirectory = _config.GetWorkingPath();
		}
		void menuOptions_Click(object sender, EventArgs e) => new OptionsDialog(applySettingsHandler).ShowDialog();
		void menuDelete_Click(object sender, EventArgs e)
		{
			if (tabMain.SelectedIndex == 0 && (sender.ToString() == "toolbar" || lstFG.Focused)) deleteFG();
			else if (tabMain.SelectedIndex == 1 && (sender.ToString() == "toolbar" || lstMessages.Focused)) deleteMess();
		}
		void menuPaste_Click(object sender, EventArgs e)
		{
			System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			if (!(Clipboard.GetDataObject() is DataObject data)) return;

			object obj;
			if (data.GetData("yogeme", false) is MemoryStream stream)
			{
				obj = formatter.Deserialize(stream);
				stream.Close();
			}
			else obj = data.GetData("Text");
			if (obj == null) return;

			Mission.Trigger trig = null;
			if (obj.GetType() == typeof(Mission.Trigger)) trig = (Mission.Trigger)obj;
			else if (obj.GetType() == typeof(Platform.Tie.Mission.Trigger)) trig = (Platform.Tie.Mission.Trigger)obj;
			else if (obj.GetType() == typeof(Platform.Xwa.Mission.Trigger))
			{
				trig = (Mission.Trigger)(Platform.Xwa.Mission.Trigger)obj;
				if (trig.VariableType == 2 /* CraftType */) trig.Variable--;
			}

			FlightGroup.Order ord = null;
			if (obj.GetType() == typeof(FlightGroup.Order)) ord = (FlightGroup.Order)obj;
			else if (obj.GetType() == typeof(Platform.Tie.FlightGroup.Order)) ord = (Platform.Tie.FlightGroup.Order)obj;
			else if (obj.GetType() == typeof(Platform.Xwa.FlightGroup.Order))
			{
				ord = (FlightGroup.Order)(Platform.Xwa.FlightGroup.Order)obj;
				if (ord.Target1Type == 2) ord.Target1--;
				if (ord.Target2Type == 2) ord.Target2--;
				if (ord.Target3Type == 2) ord.Target3--;
				if (ord.Target4Type == 2) ord.Target4--;
			}

			if (sender.ToString() == "AD" || hasFocus(lblADTrig))
			{
				try
				{
					foreach (FlightGroup fg in getSelectedFlightgroups())
					{
						craftStart(fg, false);
						fg.ArrDepTriggers[_activeArrDepTriggerIndex] = new Mission.Trigger(trig);
						craftStart(fg, true);
					}
					lblADTrigArr_Click(_activeArrDepTriggerIndex, new EventArgs());
					labelRefresh(_activeArrDepTrigger, lblADTrig[_activeArrDepTriggerIndex]);
					Common.MarkDirty(this);
				}
				catch { /* do nothing */ }
			}
			else if (sender.ToString() == "Order" || hasFocus(lblOrder))
			{
				try
				{
					foreach (FlightGroup fg in getSelectedFlightgroups())
						fg.Orders[_activeOrderIndex] = new FlightGroup.Order(ord);
					lblOrderArr_Click(_activeOrderIndex, new EventArgs());
					orderLabelRefresh();
					Common.MarkDirty(this);
				}
				catch { /* do nothing */ }
			}
			else if (sender.ToString() == "Goal" || hasFocus(lblGoal))
			{
				try
				{
					FlightGroup.Goal g = (FlightGroup.Goal)obj;
					foreach (FlightGroup fg in getSelectedFlightgroups())
						fg.Goals[_activeFGGoalIndex] = new FlightGroup.Goal(g);
					lblGoalArr_Click(_activeFGGoalIndex, new EventArgs());
					goalLabelRefresh();
					Common.MarkDirty(this);
				}
				catch { /* do nothing */ }
			}
			else if (sender.ToString() == "Skip" || lblSkipTrig1.Focused || lblSkipTrig2.Focused)
			{
				try
				{
					int j = (lblSkipTrig1.ForeColor == getHighlightColor() ? 0 : 1);
					foreach (FlightGroup fg in getSelectedFlightgroups())
						fg.SkipToOrder4Trigger[j] = new Mission.Trigger(trig);
					lblSkipTrigArr_Click(j, new EventArgs());
					labelRefresh(_activeFG.SkipToOrder4Trigger[j], (j == 0 ? lblSkipTrig1 : lblSkipTrig2));
					Common.MarkDirty(this);
				}
				catch { /* do nothing */ }
			}
			else if (Common.Paste(ActiveControl, obj))
			{
				Common.MarkDirty(this);
			}
			else if (ActiveControl.GetType() == typeof(DataGridTextBox))
			{
				try
				{
					string str = obj.ToString();
					if (str.IndexOf("System.", 0) != -1) throw new FormatException();   // bypass byte[]
					if (str.IndexOf("Idmr.", 0) != -1) throw new FormatException();
					DataGrid dg = (DataGrid)ActiveControl.Parent;
					int row = dg.CurrentRowIndex;
					DataTable dt = ((DataView)dg.DataSource).Table;
					dt.Rows[row][dg.CurrentCell.ColumnNumber] = str;
					if (dt.TableName == "Waypoints") table_RowChanged("paste", new DataRowChangeEventArgs(dt.Rows[row], DataRowAction.Change));
					else tableRaw_RowChanged("paste", new DataRowChangeEventArgs(dt.Rows[row], DataRowAction.Change));
				}
				catch { /* do nothing */ }
			}
			else if (sender.ToString() == "MessTrig" || hasFocus(lblMessTrig))
			{
				try
				{
					foreach (Platform.Xvt.Message msg in getSelectedMessages())
						msg.Triggers[_activeMessageTriggerIndex] = new Mission.Trigger(trig);
					lblMessTrigArr_Click(_activeMessageTriggerIndex, new EventArgs());
					labelRefresh(trig, lblMessTrig[_activeMessageTriggerIndex]);
					Common.MarkDirty(this);
				}
				catch { /* do nothing */ }
			}
			else
			{
				switch (tabMain.SelectedIndex)
				{
					case 0:
						try
						{
							FlightGroup fg = (FlightGroup)obj ?? throw new FormatException();
							if (!newFG()) break;

							_mission.FlightGroups[_activeFGIndex] = fg;
							refreshMap(-1);
							updateFGList();
							listRefreshItem(_activeFGIndex);
							_startingShips--;
							lstFG.SelectedIndex = _activeFGIndex;
							lstFG_SelectedIndexChanged(0, new EventArgs()); //[JB] Need to force refresh of form controls.
							craftStart(fg, true);
							lstFG.Focus();
						}
						catch { /* do nothing */ }
						break;
					case 1:
						try
						{
							Platform.Xvt.Message m = (Platform.Xvt.Message)obj ?? throw new FormatException();
							if (!newMess()) break;

							_mission.Messages[_activeMessageIndex] = m;
							messRefreshItem(_activeMessageIndex);
							lstMessages.SelectedIndex = _activeMessageIndex;
							lstMessages_SelectedIndexChanged(0, new EventArgs());
						}
						catch { /* do nothing */ }
						break;
					case 2:
						try
						{
							_activeGGTrigger.GoalTrigger = trig ?? throw new FormatException();
							lblGlobTrigArr_Click(_activeGlobalTriggerIndex, new EventArgs());
							Common.MarkDirty(this);
						}
						catch { /* do nothing */ }
						break;
					case 3:
						try
						{
							_mission.Teams[_activeTeamIndex] = (Team)obj ?? throw new FormatException();
							teamRefresh();
							lblTeamArr_Click(lblTeam[_activeTeamIndex], new EventArgs());
							Common.MarkDirty(this);
						}
						catch { /* do nothing */ }
						break;
				}
			}
		}
		void menuRecentMissions_Click(object sender, EventArgs e)
		{
			string mission = _config.RecentMissions[(int)((MenuItem)sender).Tag];
			promptSave();
			initializeMission();
			if (loadMission(mission))
			{
				tabMain.SelectedIndex = 0;
				tabFGMinor.SelectedIndex = 0;
				_activeFGIndex = 0;
				lstFG.SelectedIndex = 0;
				_loading = true;        //turned false in previous line
				if (_mission.Messages.Count != 0) lstMessages.SelectedIndex = 0;
			}
			_config.SetWorkingPath(Path.GetDirectoryName(mission));
			opnXvT.InitialDirectory = _config.GetWorkingPath();
			savXvT.InitialDirectory = _config.GetWorkingPath();
			_loading = false;
		}
		void menuSave_Click(object sender, EventArgs e)
		{
			if (_mission.MissionPath == "\\NewMission.tie") savXvT.ShowDialog();
			else saveMission(_mission.MissionPath);
		}
		void menuSaveAsBoP_Click(object sender, EventArgs e)
		{
			setBop(true);
			Common.MarkDirty(this);  // this is to avoid the "unmodified" cancel
			savXvT.ShowDialog();
		}
		void menuSaveAsTIE_Click(object sender, EventArgs e)
		{
			promptSave();
			try
			{
				Platform.Tie.Mission converted = Platform.Converter.XvtBopToTie(_mission);
				converted.Save();
			}
			catch (ArgumentException x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void menuSaveAsXvT_Click(object sender, EventArgs e)
		{
			setBop(false);
			Common.MarkDirty(this); // this is to avoid the "unmodified" cancel
			savXvT.ShowDialog();
		}
		void menuSaveAsXWA_Click(object sender, EventArgs e)
		{
			promptSave();
			try
			{
				Platform.Xwa.Mission converted = Platform.Converter.XvtBopToXwa(_mission);
				converted.Save();
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void menuTest_Click(object sender, EventArgs e)
		{
			if (_config.ConfirmTest)
			{
				DialogResult res = new TestDialog().ShowDialog();
				if (res == DialogResult.Cancel) return;
			}
			
			menuSave_Click("menuTest_Click", new EventArgs());
			if (_mission.MissionPath == "\\NewMission.tie") return;

			string path = (!_config.XvtDetectMission ? (_mission.IsBop ? _config.BopPath : _config.XvtPath) : Directory.GetParent(_mission.MissionPath).Parent.FullName + "\\");
			string xvtPath;
			string bopPath;
			if (!File.Exists(path + "Z_XVT__.exe") && _config.XvtDetectMission)
			{
				System.Diagnostics.Debug.WriteLine("XvT/BoP not detected at MissionPath, default used");
				path = (_mission.IsBop ? _config.BopPath : _config.XvtPath) + "\\";
				xvtPath = _config.XvtPath + "\\";
				bopPath = _config.BopPath + "\\";
			}
			else
			{
				if (path.ToLower().Contains("balanceofpower"))
				{
					bopPath = path;
					xvtPath = Directory.GetParent(path).Parent.FullName + "\\";
				}
				else
				{
					xvtPath = path;
					bopPath = path + "BalanceOfPower\\";
				}
			}

			bool localMission = _mission.MissionPath.ToLower().Contains(path.ToLower());
			string fileName = (!localMission ? path + "Train\\" + _mission.MissionFileName : _mission.MissionPath);
			if (!localMission)
			{
				if (File.Exists(fileName))
				{
					DialogResult res = MessageBox.Show("You are not working in the platform directory and a mission with that filename exists. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (res == DialogResult.No) return;

					File.Copy(fileName, fileName + ".bak");
				}
				File.Copy(_mission.MissionPath, fileName, true);
			}

			if (_config.VerifyTest && !_config.Verify) Common.RunVerify(_mission.MissionPath);
			/*Version os = Environment.OSVersion.Version;
			bool isWin7 = (os.Major == 6 && os.Minor == 1);
			System.Diagnostics.Process explorer = null;
			int restart = 1;
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);*/

			// configure XvT/BoP
			int index = 0;
			while (File.Exists(xvtPath + "test" + index + "0.plt")) index++;
			string pilot = "test" + index + "0.plt";
			string bopPilot = "test" + index + "0.pl2";
			string lst = "Train\\IMPERIAL.LST";
			string backup = "Train\\IMPERIAL_" + index + ".bak";

			File.Copy(Application.StartupPath + "\\xvttest0.plt", xvtPath + pilot);
			if (_config.BopInstalled) File.Copy(Application.StartupPath + "\\xvttest0.pl2", bopPath + bopPilot, true);
			// XvT pilot edit
			using (var pilotFile = File.OpenWrite(xvtPath + pilot))
			{
				pilotFile.Position = 4;
				char[] indexBytes = index.ToString().ToCharArray();
				new BinaryWriter(pilotFile).Write(indexBytes);
				for (int i = (int)pilotFile.Position; i < 0xC; i++) pilotFile.WriteByte(0);
			}
			// BoP pilot edit
			if (_config.BopInstalled)
			{
				using (var pilotFile = File.OpenWrite(bopPath + bopPilot))
				{
					pilotFile.Position = 4;
					char[] indexBytes = index.ToString().ToCharArray();
					new BinaryWriter(pilotFile).Write(indexBytes);
					for (int i = (int)pilotFile.Position; i < 0xC; i++) pilotFile.WriteByte(0);
				}
			}

			// configure XvT
			System.Diagnostics.Process xvt = new System.Diagnostics.Process();
			xvt.StartInfo.FileName = path + "Z_XVT__.exe";
			xvt.StartInfo.Arguments = "/skipintro";
			xvt.StartInfo.UseShellExecute = false;
			xvt.StartInfo.WorkingDirectory = path;
			File.Copy(path + lst, path + backup, true);
			string contents = "";
			using (var sr = File.OpenText(xvtPath + "Config.cfg")) contents = sr.ReadToEnd();
			int lastpilot = contents.IndexOf("lastpilot ") + 10;
			int nextline = contents.IndexOf("\r\n", lastpilot);
			string modified = contents.Substring(0, lastpilot) + "test" + index + contents.Substring(nextline);
			using (var sw = new FileInfo(xvtPath + "Config.cfg").CreateText()) sw.Write(modified);
			if (_config.BopInstalled)
			{
				using (var sr = File.OpenText(bopPath + "config2.cfg")) contents = sr.ReadToEnd();
				lastpilot = contents.IndexOf("lastpilot ") + 10;
				nextline = contents.IndexOf("\r\n", lastpilot);
				modified = contents.Substring(0, lastpilot) + "test" + index + contents.Substring(nextline);
				using (var sw = new FileInfo(bopPath + "config2.cfg").CreateText()) sw.Write(modified);
			}
			using (var sr = File.OpenText(path + lst)) contents = sr.ReadToEnd();
			string[] expanded = contents.Replace("\r\n", "\0").Split('\0');
			expanded[4] = _mission.MissionFileName;
			expanded[5] = "YOGEME: " + expanded[4];
			modified = string.Join("\r\n", expanded);
			using (var sw = new FileInfo(path + lst).CreateText()) sw.Write(modified);

			/*if (isWin7)	// explorer kill so colors work right
			{
				restart = (int)key.GetValue("AutoRestartShell", 1);
				key.SetValue("AutoRestartShell", 0, Microsoft.Win32.RegistryValueKind.DWord);
				explorer = System.Diagnostics.Process.GetProcessesByName("explorer")[0];
				explorer.Kill();
				explorer.WaitForExit();
			}*/

			xvt.Start();
			System.Threading.Thread.Sleep(1000);
			System.Diagnostics.Process[] runningXvts = System.Diagnostics.Process.GetProcessesByName("Z_XVT__");
			while (runningXvts.Length > 0)
			{
				Application.DoEvents();
				System.Diagnostics.Debug.WriteLine("sleeping...");
				System.Threading.Thread.Sleep(1000);
				runningXvts = System.Diagnostics.Process.GetProcessesByName("Z_XVT__");
			}

			/*if (isWin7)	// restart
			{
				key.SetValue("AutoRestartShell", restart, Microsoft.Win32.RegistryValueKind.DWord);
				explorer.StartInfo.UseShellExecute = false;
				explorer.StartInfo.FileName = "explorer.exe";
				explorer.Start();
			}*/
			if (_config.DeleteTestPilots)
			{
				File.Delete(xvtPath + pilot);
				File.Delete(bopPath + bopPilot);
			}
			File.Copy(path + backup, path + lst, true);
			File.Delete(path + backup);
			if (!localMission)
			{
				if (File.Exists(fileName + ".bak"))
				{
					File.Copy(fileName + ".bak", fileName, true);
					File.Delete(fileName + ".bak");
				}
				else File.Delete(fileName);
			}
			System.Diagnostics.Debug.WriteLine("Testing complete");
		}
		void menuVerify_Click(object sender, EventArgs e)
		{
			menuSave_Click("Verify", new EventArgs());
			if (!_config.Verify) Common.RunVerify(_mission.MissionPath);
		}
		#endregion
		#region Flight Groups
		FlightGroup _activeFG => _mission.FlightGroups[_activeFGIndex];
		/// <summary>Counts all trigger and parameter references of a FG</summary>
		/// <param name="fgIndex">Index within _mission.FlightGroups</param>
		/// <remarks>Used to populate the counters in the confirm deletion dialog</remarks>
		int[] countFlightGroupReferences(int fgIndex)
		{
			int[] count = new int[8];
			const int cMothership = 1, cArrDep = 2, cOrder = 3, cSkip = 4, cGoal = 5, cMessage = 6, cBrief = 7;
			byte typeFG = (byte)Mission.Trigger.TypeList.FlightGroup;

			for (int i = 0; i < _mission.FlightGroups.Count; i++)
			{
				if (fgIndex == i) continue;

				FlightGroup fg = _mission.FlightGroups[i];
				if (fg.ArriveViaMothership == true && fg.ArrivalMothership == fgIndex) count[cMothership]++;
				if (fg.AlternateMothershipUsed && fg.AlternateMothership == fgIndex) count[cMothership]++;
				if (fg.DepartViaMothership == true && fg.DepartureMothership == fgIndex) count[cMothership]++;
				if (fg.CapturedDepartViaMothership && fg.CapturedDepartureMothership == fgIndex) count[cMothership]++;
				foreach (Mission.Trigger adt in fg.ArrDepTriggers)
				{
					//Note: many FGs initially present in battle use the first FG for Arr/Dep condition, even though the FG isn't actually used (condition is TRUE or FALSE). In which case no need to warn.
					if (adt.VariableType == typeFG && adt.Variable == fgIndex && adt.Condition != 0 && adt.Condition != 10) count[cArrDep]++;
				}
				foreach (FlightGroup.Order order in fg.Orders)
				{
					if (order.Target1Type == typeFG && order.Target1 == fgIndex) count[cOrder]++;
					if (order.Target2Type == typeFG && order.Target2 == fgIndex) count[cOrder]++;
					if (order.Target3Type == typeFG && order.Target3 == fgIndex) count[cOrder]++;
					if (order.Target4Type == typeFG && order.Target4 == fgIndex) count[cOrder]++;
				}
				foreach (Mission.Trigger sk in fg.SkipToOrder4Trigger)
					if (sk.VariableType == typeFG && sk.Variable == fgIndex) count[cSkip]++;
			}

			foreach (Globals global in _mission.Globals)
				foreach (Globals.Goal goal in global.Goals)
					foreach (Globals.Goal.Trigger trig in goal.Triggers)
						if (trig.GoalTrigger.VariableType == typeFG && trig.GoalTrigger.Variable == fgIndex) count[cGoal]++;

			foreach (Platform.Xvt.Message msg in _mission.Messages)
				foreach (Mission.Trigger trig in msg.Triggers)
					if (trig.VariableType == typeFG && trig.Variable == fgIndex) count[cMessage]++;

			foreach (var br in _mission.Briefings)
				foreach (var evt in br.Events)
					if (evt.IsFGTag && evt.Variables[0] == fgIndex) count[cBrief]++;

			for (int i = 1; i < 8; i++)
				count[0] += count[i];
			return count;
		}
		void deleteFG()
		{
			_fBrief?.Close(); //Close (which also saves) the briefing before accessing it.  Don't call save directly since this may cause FG index corruption if multiple FGs are deleted.

            List<int> selection = Common.GetSelectedIndices(lstFG);
			int startFG = _activeFGIndex;
			for (int si = selection.Count - 1; si >= 0; si--)  // Delete from end so prior indices remain intact.
			{
				int fgIndex = selection[si];
				if (_config.ConfirmFGDelete)
				{
					int[] count = countFlightGroupReferences(fgIndex);
					if (count[0] > 0)
					{
						string[] reasons = new string[8] { "", "Mothership reference", "Arrival/Departure trigger", "Order target reference", "'Skip to Order 4' trigger", "Global Goal trigger", "Message trigger", "Briefing FG Tag" };
						string breakdown = "";
						for (int i = 1; i < 8; i++) if (count[i] > 0) breakdown += "    " + count[i] + " " + reasons[i] + ((count[i] > 1) ? "s" : "") + "\n";

						string s = _mission.FlightGroups[fgIndex].ToString(false) + "\nIs referenced " + count[0] + " time" + ((count[0] > 1) ? "s" : "") + " in these cases:\n" + breakdown + "\nAll references targeting this flight group will be reset to default.";
						if (count[7] > 0) s += "\nAssociated Briefing FG Tag events will be deleted.";
						s += "\n\nAre you sure you want to delete this Flight Group?";
						DialogResult res = MessageBox.Show(s, "WARNING: Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
						if (res == DialogResult.No) break;  // exit the outer for() loop
					}
				}
				replaceClipboardFGReference(fgIndex, -1);
				if (_mission.FlightGroups.Count != 1) lstFG.Items.RemoveAt(fgIndex);
				craftStart(_mission.FlightGroups[fgIndex], false);
				if (_mission.FlightGroups.Count == 1)
				{
					_mission.DeleteFG(fgIndex);  // Need to perform a full delete to wipe the FG indexes (messages or briefing tags may still have them).  The delete function always ensures that Count==1, so it must be inside this block, not before.
					_mission.FlightGroups.Clear();
					_mission.FlightGroups[0].CraftType = _config.XvtCraft;
					_mission.FlightGroups[0].IFF = _config.XvtIff;
					craftStart(_mission.FlightGroups[0], true);
					break;
				}
				else _mission.DeleteFG(fgIndex);
			}
			if (startFG >= _mission.FlightGroups.Count) startFG = _mission.FlightGroups.Count - 1;
			lstFG.SelectedIndex = startFG;
			updateFGList();
			refreshMap(-1);
			try
			{
				_fBrief.Import(_mission.FlightGroups);
				_fBrief.MapPaint();
			}
			catch { /* do nothing */ }
			Common.MarkDirty(this);
			
			lstMessages_SelectedIndexChanged(0, new EventArgs());
			cboGlobalTeam_SelectedIndexChanged(0, new EventArgs());
			lstFG_SelectedIndexChanged(0, new EventArgs());

			if (!lstFG.Focused) lstFG.Focus();
		}
		string generateGoalSummary()
		{
			//30 elements:  Primary,Prevent,Bonus, ... (repeat for each team)
			//Each element contains a list of strings for each line of text.
			//Was going to try and summarize global goals but the output was ugly, so removed it. Easy for the user to view those anyway.
			List<string>[] goalList = new List<string>[30];

			for (int i = 0; i < 30; i++)
				goalList[i] = new List<string>();

			//Iterate FGs and their goals, adding them to the proper list
			for (int i = 0; i < _mission.FlightGroups.Count; i++)
			{
				FlightGroup fg = _mission.FlightGroups[i];
				foreach (FlightGroup.Goal goal in fg.Goals)
				{
					if (goal.Condition == 0 || goal.Condition == 10)  continue;

					for (int j = 0; j < 10; j++)
					{
						if (!goal.GetEnabledForTeam(j)) continue;
						
						string c = Strings.CraftAbbrv[fg.CraftType] + " " + fg.Name;
						string n = goal.ToString().Replace("Flight Group", c);
						int category = ((goal.Argument <= 1) ? 0 : 2);  //0 = primary, 1 = prevent, 2 = bonus
						goalList[(j * 3) + category].Add(n);
					}
				}
			}

			//Compose the output by going through the teams and writing the results from each goal category
			string output = "";
			for (int i = 0; i < 10; i++) //Each team
			{
				if (goalList[(i * 3) + 0].Count == 0 && goalList[(i * 3) + 2].Count == 0)  //No primary or bonus goals
					continue;

				if (output.Length > 0) output += "\r\n----------\r\n";
				output += "TEAM #" + (i + 1) + ": " + _mission.Teams[i].Name + "\r\n";
				output += "PRIMARY:\r\n";
				foreach (string s in goalList[(i * 3) + 0]) output += s + "\r\n";

				if (goalList[(i * 3) + 1].Count > 0)
				{
					output += "\r\n";
					output += "SECONDARY:\r\n";
					foreach (string s in goalList[(i * 3) + 1]) output += s + "\r\n";
				}

				if (goalList[(i * 3) + 2].Count > 0)
				{
					output += "\r\n";
					output += "BONUS:\r\n";
					foreach (string s in goalList[(i * 3) + 2]) output += s + "\r\n";
				}
			}
			if (output == "") output = "Nothing here.";
			output += "\r\n";

			return output;
		}
		void listRefreshItem(int index, bool mapUpdate = true)
		{
			bool btemp = _noRefresh;
			_noRefresh = true;                      // Modifying an item will invoke SelectedIndexChanged.
			bool state = lstFG.GetSelected(index);  // It may also interfere with the current selection state.
			lstFG.Items[index] = _mission.FlightGroups[index].ToString(true);
			lstFG.SetSelected(index, state);
			if (!lstFG.IsDisposed) lstFG.Invalidate(lstFG.GetItemRectangle(index));
			if (_fMap != null && mapUpdate) _fMap.UpdateFlightGroup(index, _mission.FlightGroups[index]);
			_noRefresh = btemp;
		}
		void listRefreshSelectedItems() { foreach (int i in Common.GetSelectedIndices(lstFG)) listRefreshItem(i); }
		bool newFG()
		{
			if (_mission.FlightGroups.Count >= Mission.FlightGroupLimit)
			{
				MessageBox.Show("Mission contains maximum number of Flight Groups", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			_activeFGIndex = _mission.FlightGroups.Add();
			_activeFG.CraftType = _config.XvtCraft;
			_activeFG.IFF = _config.XvtIff;
			craftStart(_activeFG, true);
			lstFG.Items.Add("");    // only need to create the item, listRefresh() will fill it in
			updateFGList();
			lstFG.ClearSelected();
			lstFG.SelectedIndex = _activeFGIndex;
			_loading = false;
			refreshMap(-1);
			try
			{
				_fBrief.Import(_mission.FlightGroups);
				_fBrief.MapPaint();
			}
			catch { /* do nothing */ }
			Common.MarkDirty(this, _loading);
			return true;
		}
		/// <summary>Scans all Flight Groups to detect duplicate names, to provide helpful craft numbering within the editor so that the user can easily tell duplicates apart in triggers.</summary>
		void recalculateEditorCraftNumber()
		{
			// Note: changing an item in lstFG will activate lstFG_SelectedIndexChanged, which changes _activeFG and potentially cause bugs elsewhere. So need to restore before exiting the function.
			int currentFG = _activeFGIndex;

			//A-W Red and X-W Red should not be considered duplicates, so this structure maps a CraftType to a sub-dictionary of CraftName and Count.  
			//Due to the complexity and careful error checking involved (throwing exceptions is incredibly slow), two separate functions are provided to manipulate and access them.
			Dictionary<int, Dictionary<string, int>> dupeCount = new Dictionary<int, Dictionary<string, int>>();
			Dictionary<int, Dictionary<string, int>> nameCount = new Dictionary<int, Dictionary<string, int>>();
			Dictionary<int, Dictionary<string, int>> craftCount = new Dictionary<int, Dictionary<string, int>>();

			foreach (var fg in _mission.FlightGroups)     //Need to know the duplicates ahead of time, so that even the first craft encountered can be numbered accordingly.
				Common.AddFGCounter(fg.CraftType, fg.IFF, fg.Name, 1, dupeCount);

			for (int i = 0; i < _mission.FlightGroups.Count; i++)
			{
				FlightGroup fg = _mission.FlightGroups[i];

				int current;
				if (fg.PreventCraftNumbering) current = Common.AddFGCounter(fg.CraftType, fg.IFF, fg.Name, 1, nameCount);
				else current = Common.GetFGCounter(fg.CraftType, fg.IFF, fg.Name, craftCount) + 1;

				if (Common.GetFGCounter(fg.CraftType, fg.IFF, fg.Name, dupeCount) <= 1) current = 0;

				bool change = false;
				if (fg.EditorCraftNumber != current)
				{
					fg.EditorCraftNumber = current;
					change = true;
				}
				if (fg.EditorCraftExplicit != !fg.PreventCraftNumbering)
				{
					fg.EditorCraftExplicit = !fg.PreventCraftNumbering;
					change = true;
				}

				if (!fg.PreventCraftNumbering) Common.AddFGCounter(fg.CraftType, fg.IFF, fg.Name, fg.NumberOfCraft, craftCount);

				if (change) listRefreshItem(i);
			}
			_activeFGIndex = currentFG;
		}
		/// <summary>Updates the clipboard contents from containing broken indexes.</summary>
		/// <remarks>Should be called during swap or delete (dstIndex < 0) operations.</remarks>
		void replaceClipboardFGReference(int srcIndex, int dstIndex)
		{
			try
			{
				System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				if (!(Clipboard.GetDataObject() is DataObject data) || !data.GetDataPresent("yogeme", false)) return;
				if (!(data.GetData("yogeme", false) is MemoryStream stream)) return;

				object raw = formatter.Deserialize(stream);
				stream.Close();

				data = new DataObject();
				bool change = false;
				if (raw.GetType() == typeof(FlightGroup))
				{
					FlightGroup fg = (FlightGroup)raw;
					if (dstIndex >= 0)
					{
						change |= fg.TransformFGReferences(dstIndex, 255);
						change |= fg.TransformFGReferences(srcIndex, dstIndex);
						change |= fg.TransformFGReferences(255, srcIndex);
					}
					else change |= fg.TransformFGReferences(srcIndex, -1);
					data.SetText(fg.ToString());
				}
				else if (raw.GetType() == typeof(Platform.Xvt.Message))
				{
					Platform.Xvt.Message mess = (Platform.Xvt.Message)raw;
					foreach (var trig in mess.Triggers)
					{
						if (dstIndex >= 0) change |= trig.SwapFGReferences(srcIndex, dstIndex);
						else change |= trig.TransformFGReferences(srcIndex, dstIndex, true);
					}
					data.SetText(mess.MessageString);
				}
				else if (raw.GetType() == typeof(Mission.Trigger))
				{
					Mission.Trigger trig = (Mission.Trigger)raw;
					if (dstIndex >= 0) change |= trig.SwapFGReferences(srcIndex, dstIndex);
					else change |= trig.TransformFGReferences(srcIndex, dstIndex, true);
					data.SetText(trig.ToString());

				}
				else if (raw.GetType() == typeof(FlightGroup.Order))
				{
					FlightGroup.Order order = (FlightGroup.Order)raw;
					if (dstIndex >= 0)
					{
						change |= order.TransformFGReferences(dstIndex, 255);
						change |= order.TransformFGReferences(srcIndex, dstIndex);
						change |= order.TransformFGReferences(255, srcIndex);
					}
					else change |= order.TransformFGReferences(srcIndex, -1);
					data.SetText(order.ToString());
				}
				if (change)
				{
					stream = new MemoryStream();
					formatter.Serialize(stream, raw);
					data.SetData("yogeme", false, stream);
					Clipboard.SetDataObject(data, true);
				}
			}
			catch { /* do nothing*/ }
		}
		void updateFGList()
		{
			recalculateEditorCraftNumber();

			string[] fgList = _mission.FlightGroups.GetList();
			bool temp = _loading;
			byte typeFG = (byte)Mission.Trigger.TypeList.FlightGroup;
			_loading = true;
			comboReset(cboArrMS, fgList, _activeFG.ArrivalMothership);
			comboReset(cboArrMSAlt, fgList, _activeFG.AlternateMothership);
			comboReset(cboDepMS, fgList, _activeFG.DepartureMothership);
			comboReset(cboDepMSAlt, fgList, _activeFG.CapturedDepartureMothership);
			if (cboADTrigType.SelectedIndex == typeFG) comboReset(cboADTrigVar, fgList, _activeArrDepTrigger.Variable);
			if (cboSkipType.SelectedIndex == typeFG) comboReset(cboSkipVar, fgList, cboSkipVar.SelectedIndex);
			if (cboGlobalType.SelectedIndex == typeFG) comboReset(cboGlobalVar, fgList, cboGlobalVar.SelectedIndex);
			if (cboOT1Type.SelectedIndex == typeFG) comboReset(cboOT1, fgList, _activeOrder.Target1);
			if (cboOT2Type.SelectedIndex == typeFG) comboReset(cboOT2, fgList, _activeOrder.Target2);
			if (cboOT3Type.SelectedIndex == typeFG) comboReset(cboOT3, fgList, _activeOrder.Target3);
			if (cboOT4Type.SelectedIndex == typeFG) comboReset(cboOT4, fgList, _activeOrder.Target4);
			if (cboMessType.SelectedIndex == typeFG) comboReset(cboMessVar, fgList, cboMessVar.SelectedIndex);
			for (int i = 0; i < 6; i++) labelRefresh(_activeFG.ArrDepTriggers[i], lblADTrig[i]);
			lblADTrigArr_Click(lblADTrig[_activeArrDepTriggerIndex], new EventArgs());
			byte restore = _activeOrderIndex;
			for (_activeOrderIndex = 0; _activeOrderIndex < 4; _activeOrderIndex++) orderLabelRefresh();
			_activeOrderIndex = restore;
			labelRefresh(_activeFG.SkipToOrder4Trigger[0], lblSkipTrig1);
			labelRefresh(_activeFG.SkipToOrder4Trigger[1], lblSkipTrig2);
			lblSkipTrigArr_Click(_activeSkipTriggerIndex == 0 ? lblSkipTrig1 : lblSkipTrig2, new EventArgs());
			restore = _activeGlobalTriggerIndex;
			foreach (var lbl in lblGlobTrig) lblGlobTrigArr_Click(lbl, new EventArgs());
			lblGlobTrigArr_Click(lblGlobTrig[restore], new EventArgs());
			if (_mission.Messages.Count > 0)
			{
				for (int i = 0; i < 4; i++) labelRefresh(_activeMessage.Triggers[i], lblMessTrig[i]);
				lblMessTrigArr_Click(lblMessTrig[_activeMessageTriggerIndex], new EventArgs());
			}
			_loading = temp;
			listRefreshItem(_activeFGIndex);
		}
		bool updateGG(bool update)
		{
			int refCount = 0;
			int ggCount = 0;
			byte gg = _activeFG.GlobalGroup;
			byte typeGG = (byte)Mission.Trigger.TypeList.GlobalGroup;
			byte typeNotGG = (byte)Mission.Trigger.TypeList.NotGlobalGroup;
			for (int i = 0; i < _mission.FlightGroups.Count; i++)
			{
				if (_activeFGIndex == i) continue;

				FlightGroup fg = _mission.FlightGroups[i];
				if (fg.GlobalGroup == gg)
				{
					ggCount++;
					continue;
				}

				foreach (Mission.Trigger adt in fg.ArrDepTriggers)
					if ((adt.VariableType == typeGG || adt.VariableType == typeNotGG) && adt.Variable == gg)
					{
						if (update) adt.Variable = (byte)numGG.Value;
						else refCount++;
					}
				foreach (FlightGroup.Order order in fg.Orders)
				{
					if ((order.Target1Type == typeGG || order.Target1Type == typeNotGG) && order.Target1 == gg)
					{
						if (update) order.Target1 = (byte)numGG.Value;
						else refCount++;
					}
					if ((order.Target2Type == typeGG || order.Target2Type == typeNotGG) && order.Target2 == gg)
					{
						if (update) order.Target2 = (byte)numGG.Value;
						else refCount++;
					}
					if ((order.Target3Type == typeGG || order.Target3Type == typeNotGG) && order.Target3 == gg)
					{
						if (update) order.Target3 = (byte)numGG.Value;
						else refCount++;
					}
					if ((order.Target4Type == typeGG || order.Target4Type == typeNotGG) && order.Target4 == gg)
					{
						if (update) order.Target4 = (byte)numGG.Value;
						else refCount++;
					}
				}
				foreach (Mission.Trigger sk in fg.SkipToOrder4Trigger)
					if ((sk.VariableType == typeGG || sk.VariableType == typeNotGG) && sk.Variable == gg)
					{
						if (update) sk.Variable = (byte)numGG.Value;
						else refCount++;
					}
			}
			foreach (Globals global in _mission.Globals)
				foreach (Globals.Goal goal in global.Goals)
					foreach (Globals.Goal.Trigger trig in goal.Triggers)
						if ((trig.GoalTrigger.VariableType == typeGG || trig.GoalTrigger.VariableType == typeNotGG) && trig.GoalTrigger.Variable == gg)
						{
							if (update) trig.GoalTrigger.Variable = (byte)numGG.Value;
							else refCount++;
						}
			foreach (Platform.Xvt.Message msg in _mission.Messages)
				foreach (Mission.Trigger trig in msg.Triggers)
					if ((trig.VariableType == typeGG || trig.VariableType == typeNotGG) && trig.Variable == gg)
					{
						if (update) trig.Variable = (byte)numGG.Value;
						else refCount++;
					}
			// since I'm using foreach and don't have the index, just redo all of the visible ones in case it's one we updated
			for (int i = 0; i < 12; i++) labelRefresh(_mission.Globals[_activeTeamIndex].Goals[i / 4].Triggers[i % 4].GoalTrigger, lblGlobTrig[i]);
			lblGlobTrigArr_Click(_activeGlobalTriggerIndex, new EventArgs());
			if (_mission.Messages.Count > 0)
			{
				for (int i = 0; i < 4; i++) labelRefresh(_activeMessage.Triggers[i], lblMessTrig[i]);
				lblMessTrigArr_Click(_activeMessageTriggerIndex, new EventArgs());
			}
			return !update && ggCount == 0 && refCount > 0;
		}
		List<FlightGroup> getSelectedFlightgroups()
		{
			List<FlightGroup> fgs = new List<FlightGroup>();
			foreach (int fgIndex in lstFG.SelectedIndices) fgs.Add(_mission.FlightGroups[fgIndex]);
			return fgs;
		}
		void setFlightgroupProperty(MultiEditRefreshType refreshType, string name, object value)
		{
			Mission.Trigger trig = null;  // Need a trigger to refresh certain labels.  Doesn't matter which item it's from.
			foreach (FlightGroup fg in getSelectedFlightgroups())
			{
				if (refreshType.HasFlag(MultiEditRefreshType.CraftCount)) craftStart(fg, false);
				switch (name)
				{
					case "Name": fg.Name = (string)value; break;
					case "NumberOfCraft":
						fg.NumberOfCraft = Convert.ToByte(value);
						if (fg.SpecialCargoCraft > fg.NumberOfCraft) fg.SpecialCargoCraft = 0;
						break;
					case "NumberOfWaves": fg.NumberOfWaves = Convert.ToByte(value); break;
					case "WavesDelay": fg.WavesDelay = Convert.ToByte(value); break;
					// "GlobalGroup" has special logic, not handled here.
					case "GlobalUnit": fg.GlobalUnit = Convert.ToByte(value); break;
					case "PreventCraftNumbering": fg.PreventCraftNumbering = Convert.ToBoolean(value); break;
					case "Cargo": fg.Cargo = (string)value; break;
					case "SpecialCargo": fg.SpecialCargo = (string)value; break;
					case "SpecialCargoCraft":
						fg.SpecialCargoCraft = Convert.ToByte((int)value);
						if (fg.SpecialCargoCraft > fg.NumberOfCraft) fg.SpecialCargoCraft = 0;
						break;
					case "RandSpecCargo": fg.RandSpecCargo = Convert.ToBoolean(value); break;
					case "CraftType": fg.CraftType = Convert.ToByte(value); break;
					case "IFF": fg.IFF = Convert.ToByte(value); break;
					case "Team": fg.Team = Convert.ToByte(value); break;
					case "AI": fg.AI = Convert.ToByte(value); break;
					case "Markings": fg.Markings = Convert.ToByte(value); break;
					case "PlayerNumber": fg.PlayerNumber = Convert.ToByte(value); break;
					case "PlayerCraft": fg.PlayerCraft = Convert.ToByte(value); break;
					case "Radio": fg.Radio = (FlightGroup.RadioChannel)Convert.ToByte(value); break;
					case "Formation": fg.Formation = Convert.ToByte(value); break;
					case "FormDistance": fg.FormDistance = Convert.ToByte(value); break;
					case "Status1": fg.Status1 = Convert.ToByte(value); break;
					case "Status2": fg.Status2 = Convert.ToByte(value); break;
					case "Missile": fg.Missile = Convert.ToByte(value); break;
					case "Beam": fg.Beam = Convert.ToByte(value); break;
					case "Countermeasures": fg.Countermeasures = (FlightGroup.CounterTypes)value; break;
					case "ExplosionTime": fg.ExplosionTime = Convert.ToByte(value); break;
					case "ArrivalMothership": fg.ArrivalMothership = Convert.ToByte(value); break;
					case "AlternateMothership": fg.AlternateMothership = Convert.ToByte(value); break;
					case "DepartureMothership": fg.DepartureMothership = Convert.ToByte(value); break;
					case "CapturedDepartureMothership": fg.CapturedDepartureMothership = Convert.ToByte(value); break;
					case "ArriveViaMothership": fg.ArriveViaMothership = Convert.ToBoolean(value); break;
					case "AlternateMothershipUsed": fg.AlternateMothershipUsed = Convert.ToBoolean(value); break;
					case "DepartViaMothership": fg.DepartViaMothership = Convert.ToBoolean(value); break;
					case "CapturedDepartViaMothership": fg.CapturedDepartViaMothership = Convert.ToBoolean(value); break;
					case "ArrDepTrigger":
						trig = getTriggerFromControls(cboADTrigAmount, cboADTrigType, cboADTrigVar, cboADTrig);
						fg.ArrDepTriggers[_activeArrDepTriggerIndex] = trig;     // trig needed for refresh at end
						break;
					case "SkipTrigger":
						trig = getTriggerFromControls(cboSkipAmount, cboSkipType, cboSkipVar, cboSkipTrig);
						fg.SkipToOrder4Trigger[_activeSkipTriggerIndex] = trig;  // trig needed for refresh at end
						break;
					case "SkipTriggerOr": fg.SkipToO4T1OrT2 = Convert.ToBoolean(value); break;
					case "AbortTrigger": fg.AbortTrigger = Convert.ToByte(value); break;
					case "ArrivalDelayMinutes": fg.ArrivalDelayMinutes = Convert.ToByte(value); break;
					case "ArrivalDelaySeconds": fg.ArrivalDelaySeconds = Convert.ToByte(value); break;
					case "DepartureTimerMinutes": fg.DepartureTimerMinutes = Convert.ToByte(value); break;
					case "DepartureTimerSeconds": fg.DepartureTimerSeconds = Convert.ToByte(value); break;
					case "DepartureClockMinutes": fg.DepartureClockMinutes = Convert.ToByte(value); break;
					case "DepartureClockSeconds": fg.DepartureClockSeconds = Convert.ToByte(value); break;
					case "Difficulty": fg.Difficulty = (Platform.BaseFlightGroup.Difficulties)value; break;
					case "ArriveOnlyIfHuman": fg.ArriveOnlyIfHuman = Convert.ToBoolean(value); break;
					case "GoalTriggerAmount": fg.Goals[_activeFGGoalIndex].Amount = Convert.ToByte(value); break;
					case "GoalTriggerArgument": fg.Goals[_activeFGGoalIndex].Argument = Convert.ToByte(value); break;
					case "GoalTriggerCondition": fg.Goals[_activeFGGoalIndex].Condition = Convert.ToByte(value); break;
					case "GoalTriggerPoints": fg.Goals[_activeFGGoalIndex].Points = Convert.ToInt16(value); break;
					case "GoalTriggerTime": fg.Goals[_activeFGGoalIndex].TimeLimit = Convert.ToByte(value); break;
					case "GoalTriggerInc": fg.Goals[_activeFGGoalIndex].IncompleteText = (string)value; break;
					case "GoalTriggerComp": fg.Goals[_activeFGGoalIndex].CompleteText = (string)value; break;
					case "GoalTriggerFail": fg.Goals[_activeFGGoalIndex].FailedText = (string)value; break;
					case "OrderCommand": fg.Orders[_activeOrderIndex].Command = Convert.ToByte(value); break;
					case "OrderDesignation": fg.Orders[_activeOrderIndex].Designation = (string)value; break;
					case "OrderTarget1": fg.Orders[_activeOrderIndex].Target1 = Convert.ToByte(value); break;
					case "OrderTarget2": fg.Orders[_activeOrderIndex].Target2 = Convert.ToByte(value); break;
					case "OrderTarget3": fg.Orders[_activeOrderIndex].Target3 = Convert.ToByte(value); break;
					case "OrderTarget4": fg.Orders[_activeOrderIndex].Target4 = Convert.ToByte(value); break;
					case "OrderTarget1Type": fg.Orders[_activeOrderIndex].Target1Type = Convert.ToByte(value); break;
					case "OrderTarget2Type": fg.Orders[_activeOrderIndex].Target2Type = Convert.ToByte(value); break;
					case "OrderTarget3Type": fg.Orders[_activeOrderIndex].Target3Type = Convert.ToByte(value); break;
					case "OrderTarget4Type": fg.Orders[_activeOrderIndex].Target4Type = Convert.ToByte(value); break;
					case "OrderVar1": fg.Orders[_activeOrderIndex].Variable1 = Convert.ToByte(value); break;
					case "OrderVar2": fg.Orders[_activeOrderIndex].Variable2 = Convert.ToByte(value); break;
					case "Order12Or": fg.Orders[_activeOrderIndex].T1OrT2 = Convert.ToBoolean(value); break;
					case "Order34Or": fg.Orders[_activeOrderIndex].T3OrT4 = Convert.ToBoolean(value); break;
					case "OrderThrottle": fg.Orders[_activeOrderIndex].Throttle = Convert.ToByte(value); break;
					case "OrderSpeed": fg.Orders[_activeOrderIndex].Speed = Convert.ToByte(value); break;
					case "Handicap": fg.Handicap = Convert.ToByte(value); break;
					case "StopArrivingWhen": fg.StopArrivingWhen = (FlightGroup.WavesEnd)value; break;
					case "RandomArrivalDelayMinutes": fg.RandomArrivalDelayMinutes = Convert.ToByte(value); break;
					case "RandomArrivalDelaySeconds": fg.RandomArrivalDelaySeconds = Convert.ToByte(value); break;
					case "OptCategory": fg.OptCraftCategory = (FlightGroup.OptionalCraftCategory)Convert.ToByte(value); break;
					case "OptNumWaves": fg.OptCraft[_activeOptionCraftIndex].NumberOfWaves = Convert.ToByte((int)value - 1); break;
					case "OptNumCraft": fg.OptCraft[_activeOptionCraftIndex].NumberOfCraft = Convert.ToByte(value); break;  // Take value exactly as is.
					case "OptCraftType":
						fg.OptCraft[_activeOptionCraftIndex].CraftType = Convert.ToByte(value);
						if (fg.OptCraft[_activeOptionCraftIndex].NumberOfCraft < 1) fg.OptCraft[_activeOptionCraftIndex].NumberOfCraft = 1;
						break;
					case "Pitch": fg.Pitch = Convert.ToInt16(value); break;
					case "Yaw": fg.Yaw = Convert.ToInt16(value); break;
					case "Roll": fg.Roll = Convert.ToInt16(value); break;
					default: throw new ArgumentException("Unhandled multi-edit property: " + name);
				}
				if(refreshType.HasFlag(MultiEditRefreshType.CraftCount)) craftStart(fg, true);
			}
			if (refreshType.HasFlag(MultiEditRefreshType.ArrDepLabel) && trig != null) labelRefresh(trig, lblADTrig[_activeArrDepTriggerIndex]);
			if (refreshType.HasFlag(MultiEditRefreshType.SkipLabel) && trig != null) labelRefresh(trig, _activeSkipTriggerIndex == 0 ? lblSkipTrig1 : lblSkipTrig2);
		}
		void moveFlightgroups(int direction)
		{
			List<int> selection = Common.GetSelectedIndices(lstFG);
			if (selection.Count == 0 || (direction == -1 && selection[0] == 0) || (direction == 1 && selection[selection.Count - 1] == lstFG.Items.Count - 1)) return;

			for (int i = 0; i < selection.Count; i++)
			{
				// Traverse the selection list forward if moving up, backward if moving down.
				int accessIndex = ((direction == -1) ? i : selection.Count - 1 - i);
				int fgIndex = selection[accessIndex];
				_mission.SwapFG(fgIndex, fgIndex + direction);
				replaceClipboardFGReference(fgIndex, fgIndex + direction);
				// Updating the map after each item is slow. Reimport the entire list after we're done.
				listRefreshItem(fgIndex + direction, false);
				listRefreshItem(fgIndex, false);
				selection[accessIndex] += direction;
			}
			Common.SetSelectedIndices(lstFG, selection, ref _noRefresh);

			_fBrief?.Close();
			refreshMap(-1);
			updateFGList();
			Common.MarkDirty(this);
			Common.UpdateMoveButtons(cmdMoveFGUp, cmdMoveFGDown, lstFG);
		}

		void lstFG_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index == -1 || _mission.FlightGroups[e.Index] == null) return;
			e.DrawBackground();
			Brush brText = getFlightGroupDrawColor(e.Index);
			e.Graphics.DrawString(lstFG.Items[e.Index].ToString(), e.Font, brText, e.Bounds, StringFormat.GenericDefault);
		}
		void lstFG_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstFG.SelectedIndex == -1 || _noRefresh) return;
			_activeFGIndex = lstFG.SelectedIndex;
			byte order = _activeOrderIndex;
			lblFG.Text = "Flight Group #" + (_activeFGIndex + (_config.OneIndexedFGs ? 1 : 0)).ToString() + " of " + _mission.FlightGroups.Count.ToString();
			bool btemp = _loading;
			_loading = true;
			#region Craft
			txtName.Text = _activeFG.Name;
			txtCargo.Text = _activeFG.Cargo;
			txtSpecCargo.Text = _activeFG.SpecialCargo;
			numSC.Value = _activeFG.SpecialCargoCraft;
			chkRandSC.Checked = _activeFG.RandSpecCargo;
			cboCraft.SelectedIndex = _activeFG.CraftType;
			cboIFF.SelectedIndex = _activeFG.IFF;
			cboTeam.SelectedIndex = _activeFG.Team;
			try { cboAI.SelectedIndex = _activeFG.AI; }  // for some reason, some custom missions have this as -1
			catch { cboAI.SelectedIndex = 2; _activeFG.AI = 2; }
			cboMarkings.SelectedIndex = _activeFG.Markings;
			cboPlayer.SelectedIndex = _activeFG.PlayerNumber;
			cboPosition.SelectedIndex = _activeFG.PlayerCraft;
			cboFormation.SelectedIndex = _activeFG.Formation;
			cboRadio.SelectedIndex = (int)_activeFG.Radio;
			numSpacing.Value = _activeFG.FormDistance;
			numWaves.Value = _activeFG.NumberOfWaves;
			numWavesDelay.Value = _activeFG.WavesDelay;
			numCraft.Value = _activeFG.NumberOfCraft;
			numGG.Value = _activeFG.GlobalGroup;
			numGU.Value = _activeFG.GlobalUnit;
			chkPreventNumbering.Checked = _activeFG.PreventCraftNumbering;
			refreshStatus();  //Handles Status1, special case for mines.
			Common.SafeSetCBO(cboStatus2, _activeFG.Status2, true);
			cboWarheads.SelectedIndex = _activeFG.Missile;
			cboBeam.SelectedIndex = _activeFG.Beam;
			cboCounter.SelectedIndex = (int)_activeFG.Countermeasures;
			numExplode.Value = _activeFG.ExplosionTime;
			#endregion
			#region Arr/Dep
			optArrMS.Checked = _activeFG.ArriveViaMothership;
			optArrHyp.Checked = !optArrMS.Checked;
			try { cboArrMS.SelectedIndex = _activeFG.ArrivalMothership; }
			catch { cboArrMS.SelectedIndex = 0; _activeFG.ArrivalMothership = 0; optArrHyp.Checked = true; }
			optArrMSAlt.Checked = _activeFG.AlternateMothershipUsed;
			optArrHypAlt.Checked = !optArrMSAlt.Checked;
			try { cboArrMSAlt.SelectedIndex = _activeFG.AlternateMothership; }
			catch { cboArrMSAlt.SelectedIndex = 0; _activeFG.AlternateMothership = 0; optArrHypAlt.Checked = true; }
			optDepMS.Checked = _activeFG.DepartViaMothership;
			optDepHyp.Checked = !optDepMS.Checked;
			try { cboDepMS.SelectedIndex = _activeFG.DepartureMothership; }
			catch { cboDepMS.SelectedIndex = 0; _activeFG.DepartureMothership = 0; optDepHyp.Checked = true; }
			optDepMSAlt.Checked = _activeFG.CapturedDepartViaMothership;
			optDepHypAlt.Checked = !optDepMSAlt.Checked;
			try { cboDepMSAlt.SelectedIndex = _activeFG.CapturedDepartureMothership; }
			catch { cboDepMSAlt.SelectedIndex = 0; _activeFG.CapturedDepartureMothership = 0; optDepHypAlt.Checked = true; }
			for (int i = 0; i < 4; i++)
			{
				optADAndOr[i].Checked = _activeFG.ArrDepAO[i];
				optADAndOr[i + 4].Checked = !optADAndOr[i].Checked;
			}
			numArrMin.Value = _activeFG.ArrivalDelayMinutes;
			numArrSec.Value = _activeFG.ArrivalDelaySeconds;
			numDepMin.Value = _activeFG.DepartureTimerMinutes;
			numDepSec.Value = _activeFG.DepartureTimerSeconds;
			numDepClockMin.Value = _activeFG.DepartureClockMinutes;
			numDepClockSec.Value = _activeFG.DepartureClockSeconds;
			cboAbort.SelectedIndex = _activeFG.AbortTrigger;
			cboDiff.SelectedIndex = (byte)_activeFG.Difficulty;
			chkArrHuman.Checked = _activeFG.ArriveOnlyIfHuman;
			for (int i = 0; i < 6; i++) labelRefresh(_activeFG.ArrDepTriggers[i], lblADTrig[i]);
			lblADTrigArr_Click(lblADTrig[0], new EventArgs());
			Common.SafeSetCBO(cboStopArrivingWhen, (int)_activeFG.StopArrivingWhen, true);
			numRandomArrivalDelayMinutes.Value = _activeFG.RandomArrivalDelayMinutes;
			numRandomArrivalDelaySeconds.Value = _activeFG.RandomArrivalDelaySeconds;
			#endregion
			for (_activeFGGoalIndex = 0; _activeFGGoalIndex < 8; _activeFGGoalIndex++) goalLabelRefresh();
			lblGoalArr_Click(lblGoal[0], new EventArgs());
			refreshWaypointTab();
			for (_activeOrderIndex = 0; _activeOrderIndex < 4; _activeOrderIndex++) orderLabelRefresh();
			lblOrderArr_Click(lblOrder[_config.RememberSelectedOrder ? order : 0], new EventArgs());
			cboHandicap.SelectedIndex = _activeFG.Handicap;
			#region Options
			cboRole1.SelectedIndex = 0;
			cboRole2.SelectedIndex = 0;
			cboRole3.SelectedIndex = 0;
			cboRole4.SelectedIndex = 0;
			cboRoleTeam1.SelectedIndex = 0;
			setRoleControls(_activeFG);
			for (int i = 0; i < 18; i++) chkOpt[i].Checked = _activeFG.OptLoadout[i];
			labelRefresh(_activeFG.SkipToOrder4Trigger[0], lblSkipTrig1);
			labelRefresh(_activeFG.SkipToOrder4Trigger[1], lblSkipTrig2);
			lblSkipTrigArr_Click(lblSkipTrig2, new EventArgs());
			lblSkipTrigArr_Click(lblSkipTrig1, new EventArgs()); // Refresh first one last so that active index is zero.
			for (_activeOptionCraftIndex = 0; _activeOptionCraftIndex < 10; _activeOptionCraftIndex++) optCraftLabelRefresh();
			lblOptCraftArr_Click(lblOptCraft[0], new EventArgs());
			cboOptCat.SelectedIndex = (int)_activeFG.OptCraftCategory;
			optSkipOR.Checked = _activeFG.SkipToO4T1OrT2;
			optSkipAND.Checked = !optSkipOR.Checked;
			#endregion
			bool sc = _activeFG.RandSpecCargo | (_activeFG.SpecialCargoCraft > 0);
			lblNotUsed.Visible = !sc;
			txtSpecCargo.Visible = sc;
			if (numBackdrop.Enabled)
			{
				int v = _activeFG.Status1;
				if (v > numBackdrop.Maximum)
					v = (int)numBackdrop.Maximum;
				numBackdrop.Value = v;  //[JB] Need to enforce limit since some XvT missions have values out of range which throw an exception when trying to select that FG
			}
			_loading = btemp;
			Common.UpdateMoveButtons(cmdMoveFGUp, cmdMoveFGDown, lstFG);
			if (!lstFG.Focused) lstFG.Focus();
		}
		void cmdMoveFGUp_Click(object sender, EventArgs e) => moveFlightgroups(-1);
		void cmdMoveFGDown_Click(object sender, EventArgs e) => moveFlightgroups(1);

		void tabFGMinor_SelectedIndexChanged(object sender, EventArgs e) { if (tabFGMinor.SelectedIndex == 0) setSpecialVisibility(); }
		#region Craft
		void enableBackdrop(bool state)
		{
			cboStatus2.Enabled = !state;
			cboWarheads.Enabled = !state;
			cboCounter.Enabled = !state;
			cboBeam.Enabled = !state;
			numExplode.Enabled = !state;
			numCraft.Enabled = !state;
			numWaves.Enabled = !state;
			numWavesDelay.Enabled = !state;
			chkPreventNumbering.Enabled = !state;
			txtCargo.Enabled = !state;
			txtSpecCargo.Enabled = !state;
			numSC.Enabled = !state;
			chkRandSC.Enabled = !state;
			cboAI.Enabled = !state;
			cboMarkings.Enabled = !state;
			cboPlayer.Enabled = !state;
			cboPosition.Enabled = !state;
			cboRadio.Enabled = !state;
			cboFormation.Enabled = !state;
			numSpacing.Enabled = !state;
			cmdForms.Enabled = !state;
			cmdBackdrop.Enabled = state;
			numBackdrop.Enabled = state;
			cboStatus.Enabled = !state;
			if (state) lblStatus.Text = "Backdrop";
			else lblStatus.Text = "Status";
		}
		void refreshStatus()
		{
			cboStatus.Items.Clear();
			bool isMine = (cboCraft.SelectedIndex >= 0x4B && cboCraft.SelectedIndex <= 0x4D);
			lblStatus.Text = isMine ? "Mine Formation" : "Status";
			cboStatus.Items.AddRange(isMine ? Strings.FormationMine : Strings.Status);
			Common.SafeSetCBO(cboStatus, (isMine ? _activeFG.Status1 & 3 : _activeFG.Status1), true);
			cboFormation.Enabled = !isMine && cboCraft.SelectedIndex != 0x57;	// and not planet
		}
		void setSpecialVisibility()
		{
			lblNotUsed.Visible = ((numSC.Value == 0 || numSC.Value > _activeFG.NumberOfCraft) && !chkRandSC.Checked);
			txtSpecCargo.Visible = !lblNotUsed.Visible;
		}

		void cboCraft_SelectedIndexChanged(object sender, EventArgs e)
		{
			enableBackdrop(cboCraft.SelectedIndex == 0x57);
			refreshStatus();
		}
		void cboStatus_Leave(object sender, EventArgs e)
		{
			try { numBackdrop.Value = cboStatus.SelectedIndex; }
			catch { numBackdrop.Value = numBackdrop.Maximum; }
		}

		void chkRandSC_CheckedChanged(object sender, EventArgs e) => setSpecialVisibility();

		void cmdBackdrop_Click(object sender, EventArgs e)
		{
			try
			{
				BackdropDialog dlg = new BackdropDialog((_mission.IsBop ? Platform.MissionFile.Platform.BoP : Platform.MissionFile.Platform.XvT), _activeFG.Status1);
				if (dlg.ShowDialog() == DialogResult.Cancel) return;
				
				numBackdrop.Value = dlg.BackdropIndex;
				cboStatus.SelectedIndex = (int)numBackdrop.Value;
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void cmdForms_Click(object sender, EventArgs e)
		{
			FormationDialog dlg = new FormationDialog(_activeFG.Formation, _activeFG.FormDistance, Settings.Platform.XvT);
			if (dlg.ShowDialog() == DialogResult.Cancel) return;
			
			cboFormation.SelectedIndex = dlg.Formation;
			numSpacing.Value = dlg.Spacing;
		}

		void numBackdrop_Leave(object sender, EventArgs e) => cboStatus.SelectedIndex = (int)numBackdrop.Value;
		void numGG_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) numGG_Leave("numGG_KeyDown", new EventArgs()); }
		void numGG_Leave(object sender, EventArgs e)
		{
			if (_activeFG.GlobalGroup != Convert.ToByte(numGG.Value) && updateGG(false))
			{
				DialogResult res = MessageBox.Show("Global Group is unique and referenced. Update references to new number?", "Update Reference?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (res == DialogResult.Yes) updateGG(true);
			}
			foreach(FlightGroup fg in getSelectedFlightgroups()) fg.GlobalGroup = Common.Update(this, fg.GlobalGroup, Convert.ToByte(numGG.Value));
			listRefreshSelectedItems();
		}
		void numSC_ValueChanged(object sender, EventArgs e) => setSpecialVisibility();
		#endregion
		#region Arr/Dep
		Mission.Trigger _activeArrDepTrigger => _activeFG.ArrDepTriggers[_activeArrDepTriggerIndex];
		void lblADTrigArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeArrDepTriggerIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeArrDepTriggerIndex = Convert.ToByte(sender); l = lblADTrig[_activeArrDepTriggerIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 6; i++) if (i != _activeArrDepTriggerIndex) setInteractiveLabelColor(lblADTrig[i], false);
			bool btemp = _loading;
			_loading = true;
			cboADTrig.SelectedIndex = _activeArrDepTrigger.Condition;
			cboADTrigType.SelectedIndex = -1;
			cboADTrigType.SelectedIndex = _activeArrDepTrigger.VariableType;
			cboADTrigAmount.SelectedIndex = _activeArrDepTrigger.Amount;
			_loading = btemp;
		}
		void lblADTrigArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("AD", new EventArgs()); }
		void lblADTrigArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("AD", new EventArgs());
		void optADAndOrArr_CheckedChanged(object sender, EventArgs e)
		{
			if (_loading) return;

			RadioButton r = (RadioButton)sender;
			foreach(FlightGroup fg in getSelectedFlightgroups()) fg.ArrDepAO[(int)r.Tag] = Common.Update(this, fg.ArrDepAO[(int)r.Tag], r.Checked);
		}
		void cboADTrigType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboADTrigType.SelectedIndex == -1) return;

			comboVarRefresh(cboADTrigType.SelectedIndex, cboADTrigVar);
			try { cboADTrigVar.SelectedIndex = _activeArrDepTrigger.Variable; }
			catch { cboADTrigVar.SelectedIndex = 0; }
		}
		void cmdCopyAD_Click(object sender, EventArgs e) => menuCopy_Click("AD", new EventArgs());
		void cmdPasteAD_Click(object sender, EventArgs e) => menuPaste_Click("AD", new EventArgs());
		void optArrMS_CheckedChanged(object sender, EventArgs e) => cboArrMS.Enabled = optArrMS.Checked;
		void optArrMSAlt_CheckedChanged(object sender, EventArgs e) => cboArrMSAlt.Enabled = optArrMSAlt.Checked;
		void optDepMS_CheckedChanged(object sender, EventArgs e) => cboDepMS.Enabled = optDepMS.Checked;
		void optDepMSAlt_CheckedChanged(object sender, EventArgs e) => cboDepMSAlt.Enabled = optDepMSAlt.Checked;
		#endregion
		#region Orders
		FlightGroup.Order _activeOrder => _activeFG.Orders[_activeOrderIndex];
		void orderLabelRefresh()
		{
			string orderText = _activeOrder.ToString();
			orderText = replaceTargetText(orderText);
			if (_activeOrderIndex == 3 && orderText == "None")  //[JB] Order 4 can only be activated by using the Skip trigger.
				orderText += new string(' ', 50) + "(only used by Skip trigger)";
			if (_activeOrder.Command == (byte)FlightGroup.Order.CommandList.DropOff && _activeOrder.Variable2 >= 1 && _activeOrder.Variable2 <= _mission.FlightGroups.Count)
				orderText += ", " + _mission.FlightGroups[_activeOrder.Variable2 - 1].ToString(false);
			lblOrder[_activeOrderIndex].Text = "Order " + (_activeOrderIndex + 1) + ": " + orderText;
		}

		void lblOrderArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeOrderIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeOrderIndex = Convert.ToByte(sender); l = lblOrder[_activeOrderIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 4; i++) if (i != _activeOrderIndex) setInteractiveLabelColor(lblOrder[i], false);
			bool btemp = _loading;
			_loading = true;
			cboOrders.SelectedIndex = _activeOrder.Command;
			cboOThrottle.SelectedIndex = _activeOrder.Throttle;
			numOVar1.Value = _activeOrder.Variable1;
			numOVar2.Value = _activeOrder.Variable2;
			cboOT3Type.SelectedIndex = -1;
			cboOT3Type.SelectedIndex = _activeOrder.Target3Type;
			cboOT4Type.SelectedIndex = -1;
			cboOT4Type.SelectedIndex = _activeOrder.Target4Type;
			optOT3T4OR.Checked = _activeOrder.T3OrT4;
			optOT3T4AND.Checked = !optOT3T4OR.Checked;
			cboOT1Type.SelectedIndex = -1;
			cboOT1Type.SelectedIndex = _activeOrder.Target1Type;
			cboOT2Type.SelectedIndex = -1;
			cboOT2Type.SelectedIndex = _activeOrder.Target2Type;
			optOT1T2OR.Checked = _activeOrder.T1OrT2;
			optOT1T2AND.Checked = !optOT1T2OR.Checked;
			cboOSpeed.SelectedIndex = _activeOrder.Speed;
			cboOString.Text = _activeOrder.Designation;
			_loading = btemp;
		}
		void lblOrderArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("Order", new EventArgs());
		void lblOrderArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("Order", new EventArgs()); }

		void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
		{
			string[] s = Strings.OrderDesc[cboOrders.SelectedIndex].Split('|');
			lblODesc.Text = s[0];
			lblOVar1.Text = s[1];
			lblOVar2.Text = s[2];
			numOVar1_ValueChanged(0, new EventArgs()); // Force refresh, since label information is provided to the user.
			numOVar2_ValueChanged(0, new EventArgs());
		}
		void cboOT1Type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboOT1Type.SelectedIndex == -1) return;
			comboVarRefresh(cboOT1Type.SelectedIndex, cboOT1);
			try { cboOT1.SelectedIndex = _activeOrder.Target1; }
			catch { cboOT1.SelectedIndex = 0; }
		}
		void cboOT2Type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboOT2Type.SelectedIndex == -1) return;
			comboVarRefresh(cboOT2Type.SelectedIndex, cboOT2);
			try { cboOT2.SelectedIndex = _activeOrder.Target2; }
			catch { cboOT2.SelectedIndex = 0; }
			orderLabelRefresh();
		}
		void cboOT3Type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboOT3Type.SelectedIndex == -1) return;
			comboVarRefresh(cboOT3Type.SelectedIndex, cboOT3);
			try { cboOT3.SelectedIndex = _activeOrder.Target3; }
			catch { cboOT3.SelectedIndex = 0; }
		}
		void cboOT4Type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboOT4Type.SelectedIndex == -1) return;
			comboVarRefresh(cboOT4Type.SelectedIndex, cboOT4);
			try { cboOT4.SelectedIndex = _activeOrder.Target4; }
			catch { cboOT4.SelectedIndex = 0; }
		}
		void cboOSpeed_SelectedIndexChanged(object sender, EventArgs e) => lblOSpeedNote.Visible = (cboOSpeed.SelectedIndex > 0);

		void cmdCopyOrder_Click(object sender, EventArgs e) => menuCopy_Click("Order", new EventArgs());
		void cmdPasteOrder_Click(object sender, EventArgs e) => menuPaste_Click("Order", new EventArgs());

		void numOVar1_ValueChanged(object sender, EventArgs e)
		{
			byte value = _activeOrder.Variable1;
			var command = (FlightGroup.Order.CommandList)_activeOrder.Command;
			string text = "";
			bool warning = false;
			switch (command)
			{
				case FlightGroup.Order.CommandList.BoardGiveCargo:
				case FlightGroup.Order.CommandList.BoardTakeCargo:
				case FlightGroup.Order.CommandList.BoardExchangeCargo:
				case FlightGroup.Order.CommandList.BoardToCapture:
				case FlightGroup.Order.CommandList.BoardDestroy:
				case FlightGroup.Order.CommandList.PickUp:
				case FlightGroup.Order.CommandList.Wait:
				case FlightGroup.Order.CommandList.SSWait:
				case FlightGroup.Order.CommandList.SSBoard:
				case FlightGroup.Order.CommandList.BoardRepair:
				case FlightGroup.Order.CommandList.SelfDestruct:
					text = Common.GetFormattedTime(value * 5, true);
					break;
				case FlightGroup.Order.CommandList.Circle:
				case FlightGroup.Order.CommandList.CircleEvade:
				case FlightGroup.Order.CommandList.SSPatrol:
					if (value == 0) { text = "Zero, no loops!"; warning = true; }
					break;
				case FlightGroup.Order.CommandList.Escort:
					if (value < 9) text = "Above";
					else if (value > 17) text = "Below";
					if (value % 3 == 0) text += " Left";
					else if (value % 3 == 2) text += " Right";
					if (value == 13 || value == 27) { text = "Coincident"; warning = true; }   // the only one that won't be caught otherwise
					value = (byte)(value % 9);
					if (value < 3 && numOVar1.Value != 27) text = "Leading " + text;
					else if (value > 5) text = "Trailing " + text;
					text = text.Replace("  ", " ");
					if (numOVar1.Value > 27) { text = "Invalid"; warning = true; }
					break;
			}
			lblOVar1Note.Text = text;
			lblOVar1Note.Visible = (text != "");
			lblOVar1Note.ForeColor = warning ? Color.Red : SystemColors.ControlText;
		}
		void numOVar2_ValueChanged(object sender, EventArgs e)
		{
			var command = (FlightGroup.Order.CommandList)_activeOrder.Command;
			int value = _activeOrder.Variable2;
			string text = "";
			bool warning = false;
			switch (command)
			{
				case FlightGroup.Order.CommandList.BoardGiveCargo:
				case FlightGroup.Order.CommandList.BoardTakeCargo:
				case FlightGroup.Order.CommandList.BoardExchangeCargo:
				case FlightGroup.Order.CommandList.BoardToCapture:
				case FlightGroup.Order.CommandList.BoardDestroy:
				case FlightGroup.Order.CommandList.PickUp:
				case FlightGroup.Order.CommandList.SSBoard:
				case FlightGroup.Order.CommandList.BoardRepair:
					warning = (value == 0);
					if (value == 0) text = "No dockings.";
					break;
				case FlightGroup.Order.CommandList.Escort:
					if (_mission.IsBop)
					{
						text = "Order bugged in BoP!";
						warning = true;
					}
					break;
				case FlightGroup.Order.CommandList.DropOff:
					if (value >= 1 && value <= _mission.FlightGroups.Count)   //Variable is FG #, one based.
					{
						text = _mission.FlightGroups[value - 1].ToString(false);
					}
					else
					{
						text = "None specified.";
						warning = true;
					}
					if (ActiveControl == numOVar2) orderLabelRefresh();
					break;
			}
			lblOVar2Note.Text = text;
			lblOVar2Note.Visible = (text != "");
			lblOVar2Note.ForeColor = warning ? Color.Red : SystemColors.ControlText;
		}
		#endregion
		#region Goals
		FlightGroup.Goal _activeFGGoal => _activeFG.Goals[_activeFGGoalIndex];
		void goalLabelRefresh() => lblGoal[_activeFGGoalIndex].Text = "Goal " + (_activeFGGoalIndex + 1).ToString() + ": " + _activeFGGoal.ToString();

		void lblGoalArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeFGGoalIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeFGGoalIndex = Convert.ToByte(sender); l = lblGoal[_activeFGGoalIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 8; i++) if (i != _activeFGGoalIndex) setInteractiveLabelColor(lblGoal[i], false);
			bool btemp = _loading;
			_loading = true;
			cboGoalArgument.SelectedIndex = _activeFGGoal.Argument;
			cboGoalTrigger.SelectedIndex = _activeFGGoal.Condition;
			cboGoalAmount.SelectedIndex = _activeFGGoal.Amount;
			numGoalPoints.Value = _activeFGGoal.Points;
			txtGoalInc.Text = _activeFGGoal.IncompleteText;
			txtGoalComp.Text = _activeFGGoal.CompleteText;
			txtGoalFail.Text = _activeFGGoal.FailedText;
			numGoalTimeLimit.Value = _activeFGGoal.TimeLimit;
			for (int i = 0; i < 10; i++) lstGoalTeams.SetSelected(i, _activeFGGoal.GetEnabledForTeam(i));
			_loading = btemp;
		}
		void lblGoalArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("Goal", new EventArgs());
		void lblGoalArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("Goal", new EventArgs()); }

		void grpGoal_Leave(object sender, EventArgs e) => goalLabelRefresh();

		void lstGoalTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ActiveControl != lstGoalTeams || _loading) return;

			foreach (FlightGroup fg in getSelectedFlightgroups())
				for (int i = 0; i < lstGoalTeams.Items.Count; i++) fg.Goals[_activeFGGoalIndex].SetEnabledForTeam(i, lstGoalTeams.GetSelected(i));
			Common.MarkDirty(this, true);
		}

		void numGoalTimeLimit_ValueChanged(object sender, EventArgs e)
		{
			int sec = (int)numGoalTimeLimit.Value * 5;
			lblGoalTimeLimit.Text = (sec == 0 ? "No time limit" : "< " + Common.GetFormattedTime(sec, false));
		}
		#endregion
		#region Waypoints
		void enableRot(bool state)
		{
			numYaw.Enabled = state;
			numRoll.Enabled = state;
		}
		/// <summary>Checks if the map exists and requests a paint operation</summary>
		/// <remarks>Useful to keep the map synced to the main form's waypoint tab.</remarks>
		void refreshMap(int fgIndex)
		{
			if (_fMap == null || _fMap.IsDisposed) return;
			
			if (fgIndex < 0) _fMap.Import(_mission.FlightGroups);
			else if (fgIndex < _mission.FlightGroups.Count) _fMap.UpdateFlightGroup(fgIndex, _mission.FlightGroups[fgIndex]);
			_fMap.MapPaint();
		}
		void refreshWaypointTab()
		{
			bool btemp = _loading;
			_loading = true;
			for (int i = 0; i < 22; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_tableRaw.Rows[i][j] = _activeFG.Waypoints[i][j];
					_table.Rows[i][j] = Math.Round((double)_activeFG.Waypoints[i][j] / 160, 2);
				}
				chkWP[i].Checked = _activeFG.Waypoints[i].Enabled;
			}
			_tableRaw.AcceptChanges();
			_table.AcceptChanges();
			numYaw.Value = _activeFG.Yaw;
			numPitch.Value = _activeFG.Pitch;
			numRoll.Value = _activeFG.Roll;
			enableRot(_activeFG.CraftType > 0x45);
			_loading = btemp;
		}

		void chkWPArr_CheckedChanged(object sender, EventArgs e)
		{
			if (_loading) return;

			CheckBox c = (CheckBox)sender;
			foreach(FlightGroup fg in getSelectedFlightgroups()) fg.Waypoints[(int)c.Tag].Enabled = Common.Update(this, fg.Waypoints[(int)c.Tag].Enabled, c.Checked);
			refreshMap(_activeFGIndex);
		}

		void table_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (_loading) return;
			
			int i, j;
			_loading = true;
			for (j = 0; j < 22; j++) if (_table.Rows[j].Equals(e.Row)) break;   //find the row index that you're changing
			for (i = 0; i < 3; i++)
			{
				if (!double.TryParse(_table.Rows[j][i].ToString(), out double cell)) _table.Rows[j][i] = 0;
				short raw = (short)(cell * 160);
				foreach (FlightGroup fg in getSelectedFlightgroups()) fg.Waypoints[j][i] = Common.Update(this, fg.Waypoints[j][i], raw);
				_tableRaw.Rows[j][i] = raw;
			}
			_loading = false;
			refreshMap(_activeFGIndex);
		}
		void tableRaw_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (_loading) return;

			int i, j;
			_loading = true;
			for (j = 0; j < 22; j++) if (_tableRaw.Rows[j].Equals(e.Row)) break;    //find the row index that you're changing
			for (i = 0; i < 3; i++)
			{
				if (!short.TryParse(_tableRaw.Rows[j][i].ToString(), out short raw)) _tableRaw.Rows[j][i] = 0;
				foreach (FlightGroup fg in getSelectedFlightgroups()) fg.Waypoints[j][i] = Common.Update(this, fg.Waypoints[j][i], raw);
				_table.Rows[j][i] = Math.Round((double)raw / 160, 2);
			}
			_loading = false;
			refreshMap(_activeFGIndex);
		}
		#endregion
		#region Options
		FlightGroup.OptionalCraft _activeOptCraft => _activeFG.OptCraft[_activeOptionCraftIndex];
		void enableOptCat(bool state)
		{
			numOptCraft.Enabled = state;
			numOptWaves.Enabled = state;
			cboOptCraft.Enabled = state;
			for (int i = 0; i < 10; i++) lblOptCraft[i].Enabled = state;
		}
		string getRoleString(ComboBox teamSel, ComboBox roleSel)
		{
			if (teamSel.SelectedIndex <= 0 || roleSel.SelectedIndex == -1) return "";

			int team = teamSel.SelectedIndex;
			if (team <= Strings.TeamPrefixes.Length)
				return Strings.TeamPrefixes.Substring(team - 1, 1) + Strings.Roles[roleSel.SelectedIndex].Substring(0, 3).ToUpper();

			return "";
		}
		void optCraftLabelRefresh()
		{
			lblOptCraft[_activeOptionCraftIndex].Text = "Craft " + (_activeOptionCraftIndex + 1).ToString() + ":";
			if (_activeOptCraft.CraftType != 0)
				lblOptCraft[_activeOptionCraftIndex].Text += " " + (_activeOptCraft.NumberOfWaves + 1)
				+ " x (" + (_activeOptCraft.NumberOfCraft) + ") " + Strings.CraftType[_activeOptCraft.CraftType];
			//[JB] Fix so all labels properly refresh in load time, getting the craft name directly from the setting rather than the combobox . Also fixed, NumberOfCraft is not +1, should be exactly as is.
		}
		void setRoleControls(FlightGroup fg)
		{
			ComboBox[] teams = new ComboBox[4];
			teams[0] = cboRoleTeam1;
			teams[1] = cboRoleTeam2;
			teams[2] = cboRoleTeam3;
			teams[3] = cboRoleTeam4;
			ComboBox[] roles = new ComboBox[4];
			roles[0] = cboRole1;
			roles[1] = cboRole2;
			roles[2] = cboRole3;
			roles[3] = cboRole4;

			string[] roleList = Strings.Roles;
			for (int i = 0; i < 4; i++)
			{
				string code = fg.Roles[i];
				int tindex = 0;
				int rindex = -1;
				if (code.Length == 4)
				{
					string team = code.Substring(0, 1).ToUpper();
					string role = code.Substring(1, 3).ToUpper();

					tindex = Strings.TeamPrefixes.IndexOf(team) + 1;
					for (int j = 0; j < roleList.Length; j++)
					{
						if (roleList[j].ToUpper().IndexOf(role) == 0)
						{
							rindex = j;
							break;
						}
					}
				}
				if (rindex < 0) rindex = 0;
				try
				{
					teams[i].SelectedIndex = tindex;
					roles[i].SelectedIndex = rindex;
				}
				catch
				{
					teams[i].SelectedIndex = 0;
					roles[i].SelectedIndex = 0;
				}
			}
		}

		void chkOptArr_CheckedChanged(object sender, EventArgs e)
		{
			if (_loading) return;

			CheckBox c = (CheckBox)sender;
			int i = (int)c.Tag;
			foreach(FlightGroup fg in getSelectedFlightgroups()) fg.OptLoadout[i] = Common.Update(this, fg.OptLoadout[i], c.Checked);
			bool tempLoad = _loading;
			_loading = true;
			foreach (FlightGroup fg in getSelectedFlightgroups())
			{
				if (c.Checked)
				{
					if (i == 0) for (int j = 1; j < 9; j++) fg.OptLoadout[j] = false; // turn off warheads
					else if (i > 0 && i < 9) fg.OptLoadout[0] = false;        // clear warhead None
					else if (i == 9) for (int j = 10; j < 14; j++) fg.OptLoadout[j] = false;  // turn off beams
					else if (i > 9 && i < 14) fg.OptLoadout[9] = false;   // clear beam None
					else if (i == 14) for (int j = 15; j < 18; j++) fg.OptLoadout[j] = false;  // turn off CMs
					else fg.OptLoadout[14] = false;   // clear CM None
				}
				else
				{
					bool b = false;
					if (i > 0 && i < 9)
					{
						for (int j = 1; j < 9; j++) b |= fg.OptLoadout[j];
						if (!b && !chkOpt[0].Checked) fg.OptLoadout[0] = true;
					}
					b = false;
					if (i > 9 && i < 14)
					{
						for (int j = 10; j < 14; j++) b |= fg.OptLoadout[j];
						if (!b && !chkOpt[9].Checked) fg.OptLoadout[9] = true;
					}
					b = false;
					if (i > 14 && i < 18)
					{
						for (int j = 15; j < 18; j++) b |= fg.OptLoadout[j];
						if (!b && !chkOpt[14].Checked) fg.OptLoadout[14] = true;
					}
				}
			}
			for (i = 0; i < 18; i++) chkOpt[i].Checked = _activeFG.OptLoadout[i];
			_loading = tempLoad;
		}
		void lblOptCraftArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeOptionCraftIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeOptionCraftIndex = Convert.ToByte(sender); l = lblOptCraft[_activeOptionCraftIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 10; i++) if (i != _activeOptionCraftIndex) setInteractiveLabelColor(lblOptCraft[i], false);
			bool btemp = _loading;
			_loading = true;
			cboOptCraft.SelectedIndex = _activeOptCraft.CraftType;
			int numCraft = _activeOptCraft.NumberOfCraft;
			if (numCraft < 1) numCraft = 1;
			numOptCraft.Value = numCraft; //[JB] This isn't +1 like craft waves is (appears in XvT exactly as its value), but the control only accepts a minimum of 1.
			numOptWaves.Value = _activeOptCraft.NumberOfWaves + 1;
			_loading = btemp;
		}
		void lblSkipTrigArr_Click(object sender, EventArgs e)
		{
			Label l; // clicked
			Label ll; // other one
			int i;
			try
			{
				l = (Label)sender;
				l.Focus();
				ll = (l == lblSkipTrig1 ? lblSkipTrig2 : lblSkipTrig1);
				i = (l == lblSkipTrig1 ? 0 : 1);    // i = clicked trigger
			}
			catch (InvalidCastException)
			{
				i = (int)sender;    // i = clicked trigger from code
				if (i == 0) { l = lblSkipTrig1; ; ll = lblSkipTrig2; }
				else { l = lblSkipTrig2; ll = lblSkipTrig1; }
			}
			setInteractiveLabelColor(l, true);
			setInteractiveLabelColor(ll, false);
			_activeSkipTriggerIndex = (byte)i;
			bool btemp = _loading;
			_loading = true;
			cboSkipTrig.SelectedIndex = _activeFG.SkipToOrder4Trigger[i].Condition;
			cboSkipType.SelectedIndex = -1;
			cboSkipType.SelectedIndex = _activeFG.SkipToOrder4Trigger[i].VariableType;
			cboSkipAmount.SelectedIndex = _activeFG.SkipToOrder4Trigger[i].Amount;
			_loading = btemp;
		}
		void lblSkipTrigArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("Skip", new EventArgs());
		void lblSkipTrigArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("Skip", new EventArgs()); }
		void cboOptCat_SelectedIndexChanged(object sender, EventArgs e) => enableOptCat(cboOptCat.SelectedIndex == 4);
		void cboSkipType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSkipType.SelectedIndex == -1) return;

			comboVarRefresh(cboSkipType.SelectedIndex, cboSkipVar);
			try { cboSkipVar.SelectedIndex = _activeFG.SkipToOrder4Trigger[_activeSkipTriggerIndex].Variable; }
			catch { cboSkipVar.SelectedIndex = 0; }
		}
		void cmdCopySkip_Click(object sender, EventArgs e) => menuCopy_Click("Skip", new EventArgs());
		void cmdPasteSkip_Click(object sender, EventArgs e) => menuPaste_Click("Skip", new EventArgs());
		void grpRole_Leave(object sender, EventArgs e)
		{
			ComboBox[] teams = new ComboBox[4];
			teams[0] = cboRoleTeam1;
			teams[1] = cboRoleTeam2;
			teams[2] = cboRoleTeam3;
			teams[3] = cboRoleTeam4;
			ComboBox[] roles = new ComboBox[4];
			roles[0] = cboRole1;
			roles[1] = cboRole2;
			roles[2] = cboRole3;
			roles[3] = cboRole4;
			string s;
			for (int i = 0; i < 4; i++)
			{
				s = getRoleString(teams[i], roles[i]);
				foreach(FlightGroup fg in getSelectedFlightgroups()) fg.Roles[i] = Common.Update(this, fg.Roles[i], s);
			}
		}
		void numExplode_ValueChanged(object sender, EventArgs e) => lblExplode.Text = numExplode.Value != 0 ? (numExplode.Value * 5) + " sec" : "default";
		#endregion
		#endregion
		#region Messages
		Platform.Xvt.Message _activeMessage => _mission.Messages[_activeMessageIndex];
		bool newMess()
		{
			if (_mission.Messages.Count == Mission.MessageLimit)
			{
				MessageBox.Show("Mission contains maximum number of Messages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			_activeMessageIndex = _mission.Messages.Add();
			if (_mission.Messages.Count == 1) enableMessages(true);
			lstMessages.Items.Add(_activeMessage.MessageString);
			lstMessages.ClearSelected();
			lstMessages.SelectedIndex = _activeMessageIndex;
			Common.MarkDirty(this, _loading);
			return true;
		}
		void deleteMess()
		{
			List<int> selection = Common.GetSelectedIndices(lstMessages);
			if (selection.Count == 0) return;
			int startMsg = _activeMessageIndex;
			for (int si = selection.Count - 1; si >= 0; si--)
			{
				_mission.Messages.RemoveAt(selection[si]);
				lstMessages.Items.RemoveAt(selection[si]);
			}
			Common.MarkDirty(this);
			if (_mission.Messages.Count == 0)
			{
				lstMessages.Items.Clear();
				enableMessages(false);
				lblMessage.Text = "Message #0 of 0";
				return;
			}
			if (startMsg >= _mission.Messages.Count) startMsg = _mission.Messages.Count - 1;
			lstMessages.SelectedIndex = startMsg;
		}
		void enableMessages(bool state)
		{
			grpMessages.Enabled = state;
			txtMessage.Enabled = state;
			txtShort.Enabled = state;
			grpSend.Enabled = state;
			numMessDelay.Enabled = state;
			cboMessTrig.Enabled = state;
			cboMessType.Enabled = state;
			cboMessVar.Enabled = state;
			cboMessAmount.Enabled = state;
			cboMessColor.Enabled = state;
		}
		void messRefreshItem(int index)
		{
			bool btemp = _noRefresh;
			_noRefresh = true;                            // Modifying an item will invoke SelectedIndexChanged.
			bool state = lstMessages.GetSelected(index);  // It may also interfere with the current selection state.
			lstMessages.Items[index] = _mission.Messages[index].MessageString != "" ? _mission.Messages[index].MessageString : " *";
			lstMessages.SetSelected(index, state);
			_noRefresh = btemp;
		}
		void messRefreshSelectedItems() { foreach (int i in Common.GetSelectedIndices(lstMessages)) messRefreshItem(i); }
		List<Platform.Xvt.Message> getSelectedMessages()
		{
			List<Platform.Xvt.Message> msgs = new List<Platform.Xvt.Message>();
			foreach (int msgIndex in lstMessages.SelectedIndices) msgs.Add(_mission.Messages[msgIndex]);
			return msgs;
		}
		void setMessageProperty(string name, object value)
		{
			int trigRefresh = 0;
			foreach (Platform.Xvt.Message msg in getSelectedMessages())
			{
				switch (name)
				{
					case "MessTrigger":
						Mission.Trigger trig = getTriggerFromControls(cboMessAmount, cboMessType, cboMessVar, cboMessTrig);
						msg.Triggers[_activeMessageTriggerIndex] = trig;
						if (trigRefresh++ == 0) labelRefresh(trig, lblMessTrig[_activeMessageTriggerIndex]);  // only refresh once
						break;
					case "MessColor": msg.Color = Convert.ToByte(value); break;
					case "MessDelay": msg.RawDelay = Convert.ToByte((int)value / 5); break;
					case "Mess1OR2": msg.T1OrT2 = Convert.ToBoolean(value); break;
					case "Mess3OR4": msg.T3OrT4 = Convert.ToBoolean(value); break;
					case "Mess12OR34": msg.T12OrT34 = Convert.ToBoolean(value); break;
				}
			}
		}
		void moveMessages(int direction)
		{
			List<int> selection = Common.GetSelectedIndices(lstMessages);
			if (selection.Count == 0 || (direction == -1 && selection[0] == 0) || (direction == 1 && selection[selection.Count - 1] == lstMessages.Items.Count - 1)) return;

			for (int i = 0; i < selection.Count; i++)
			{
				// Traverse the selection list forward if moving up, backward if moving down.
				int accessIndex = ((direction == -1) ? i : selection.Count - 1 - i);
				int msgIndex = selection[accessIndex];
				Platform.Xvt.Message tmp = _mission.Messages[msgIndex];
				_mission.Messages[msgIndex] = _mission.Messages[msgIndex + direction];
				_mission.Messages[msgIndex + direction] = tmp;
				messRefreshItem(msgIndex);
				messRefreshItem(msgIndex + direction);
				selection[accessIndex] += direction;
			}
			_activeMessageIndex += direction;

			Common.SetSelectedIndices(lstMessages, selection, ref _noRefresh);
			Common.MarkDirty(this);
			Common.UpdateMoveButtons(cmdMoveMessUp, cmdMoveMessDown, lstMessages);
		}

		void lstMessages_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (_mission.Messages.Count == 0 || _mission.Messages[e.Index] == null) return;

			e.DrawBackground();
			var mess = _mission.Messages[e.Index];
			Brush brText = SystemBrushes.ControlText;
			switch (mess.Color)
			{
				case 0:
					brText = Brushes.Red; //was Crimson;
					break;
				case 1:
					brText = Brushes.Lime; //was LimeGreen;
					break;
				case 2:
					brText = Brushes.DodgerBlue; //was RoyalBlue;
					break;
				case 3:
					brText = Brushes.Yellow;
					break;
			}

			bool used = false;
			for (int i = 0; i < mess.SentToTeam.Length; i++) used |= mess.SentToTeam[i];
			// evaluate the FALSE conditions to detect if it's locked into NEVER
			bool[] never = new bool[6];
			for (int i = 0; i < 4; i++) never[i] = (mess.Triggers[i].Condition == 10);
			never[4] = ((never[0] || never[1]) && !mess.T1OrT2) || (never[0] && never[1]);   // T1/2 pair
			never[5] = ((never[2] || never[3]) && !mess.T3OrT4) || (never[2] && never[3]);   // T3/4 pair
			if (never[4] && never[5]) used = false;
			else if ((never[4] || never[5]) && !mess.T12OrT34) used = false;
			if (!used) brText = Brushes.Gray;

			e.Graphics.DrawString(lstMessages.Items[e.Index].ToString(), e.Font, brText, e.Bounds, StringFormat.GenericDefault);
		}
		void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.UpdateMoveButtons(cmdMoveMessUp, cmdMoveMessDown, lstMessages);  // Running this first lets it detect if all messages have been deselected
			if (lstMessages.SelectedIndex == -1 || _noRefresh) return;

			_activeMessageIndex = lstMessages.SelectedIndex;
			lblMessage.Text = "Message #" + (_activeMessageIndex + 1).ToString() + " of " + _mission.Messages.Count.ToString();
			bool btemp = _loading;
			_loading = true;
			for (int i = 0; i < 4; i++) labelRefresh(_activeMessage.Triggers[i], lblMessTrig[i]);
			txtMessage.Text = _activeMessage.MessageString;
			cboMessColor.SelectedIndex = _activeMessage.Color;
			optMess1OR2.Checked = _activeMessage.T1OrT2;
			optMess1AND2.Checked = !optMess1OR2.Checked;
			optMess3OR4.Checked = _activeMessage.T3OrT4;
			optMess3AND4.Checked = !optMess3OR4.Checked;
			optMess12OR34.Checked = _activeMessage.T12OrT34;
			optMess12AND34.Checked = !optMess12OR34.Checked;
			txtShort.Text = _activeMessage.Note;
			numMessDelay.Value = _activeMessage.DelaySeconds;
			for (int i = 0; i < 10; i++) chkSendTo[i].Checked = _activeMessage.SentToTeam[i];
			lblMessTrigArr_Click(0, new EventArgs());
			_loading = btemp;
		}

		void chkSendToArr_Leave(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			foreach(Platform.Xvt.Message msg in getSelectedMessages()) msg.SentToTeam[(int)c.Tag] = Common.Update(this, msg.SentToTeam[(int)c.Tag], c.Checked);
		}
		void lblMessTrigArr_Click(object sender, EventArgs e)
		{
			if (_mission.Messages.Count == 0) return;

			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeMessageTriggerIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeMessageTriggerIndex = Convert.ToByte(sender); l = lblMessTrig[_activeMessageTriggerIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 4; i++) if (i != _activeMessageTriggerIndex) setInteractiveLabelColor(lblMessTrig[i], false);
			bool btemp = _loading;
			_loading = true;
			cboMessTrig.SelectedIndex = _activeMessage.Triggers[_activeMessageTriggerIndex].Condition;
			cboMessType.SelectedIndex = -1;
			cboMessType.SelectedIndex = _activeMessage.Triggers[_activeMessageTriggerIndex].VariableType;
			cboMessAmount.SelectedIndex = _activeMessage.Triggers[_activeMessageTriggerIndex].Amount;
			_loading = btemp;
		}
		void lblMessTrigArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("MessTrig", new EventArgs());
		void lblMessTrigArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("MessTrig", new EventArgs()); }
		void cboMessType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMessType.SelectedIndex == -1) return;

			comboVarRefresh(cboMessType.SelectedIndex, cboMessVar);
			try { cboMessVar.SelectedIndex = _activeMessage.Triggers[_activeMessageTriggerIndex].Variable; }
			catch { cboMessVar.SelectedIndex = 0; }
		}

		void txtMessage_TextChanged(object sender, EventArgs e)
		{
			if (_loading) return;

			_activeMessage.MessageString = Common.Update(this, _activeMessage.MessageString, txtMessage.Text);
			messRefreshItem(_activeMessageIndex);
		}
		void txtShort_Leave(object sender, EventArgs e) => _activeMessage.Note = Common.Update(this, _activeMessage.Note, txtShort.Text);

		void cmdMoveMessUp_Click(object sender, EventArgs e) => moveMessages(-1);
		void cmdMoveMessDown_Click(object sender, EventArgs e) => moveMessages(1);
		#endregion
		#region Globals
		Globals.Goal _activeGlobalGoal => _mission.Globals[_activeTeamIndex].Goals[_activeGlobalTriggerIndex / 4];
		Globals.Goal.Trigger _activeGGTrigger => _activeGlobalGoal.Triggers[_activeGlobalTriggerIndex % 4];
		void cboGlobalTeam_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboGlobalTeam.SelectedIndex == -1) return;

			_activeTeamIndex = (byte)cboGlobalTeam.SelectedIndex;
			lblTeamArr_Click(lblTeam[_activeTeamIndex], new EventArgs());    // link the Globals and Team tabs to share GlobTeam
			bool btemp = _loading;
			_loading = true;
			for (int i = 0; i < 12; i++) labelRefresh(_mission.Globals[_activeTeamIndex].Goals[i / 4].Triggers[i % 4].GoalTrigger, lblGlobTrig[i]);
			for (int i = 0; i < 9; i++)
			{
				optGlobAndOr[i].Checked = _mission.Globals[_activeTeamIndex].Goals[i / 3].AndOr[i % 3];  // OR
				optGlobAndOr[i + 9].Checked = !optGlobAndOr[i].Checked; // AND
			}
			lblGlobTrigArr_Click(0, new EventArgs());
			_loading = btemp;
		}

		void lblGlobTrigArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeGlobalTriggerIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeGlobalTriggerIndex = Convert.ToByte(sender); l = lblGlobTrig[_activeGlobalTriggerIndex]; }
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 12; i++) if (i != _activeGlobalTriggerIndex) setInteractiveLabelColor(lblGlobTrig[i], false);
			bool btemp = _loading;
			_loading = true;
			int g = _activeGlobalTriggerIndex / 4;
			cboGlobalTrig.SelectedIndex = _activeGGTrigger.GoalTrigger.Condition;
			cboGlobalType.SelectedIndex = -1;
			cboGlobalType.SelectedIndex = _activeGGTrigger.GoalTrigger.VariableType;
			cboGlobalAmount.SelectedIndex = _activeGGTrigger.GoalTrigger.Amount;
			numGlobalPoints.Value = _activeGlobalGoal.Points;
			txtGlobalInc.Text = _activeGGTrigger[Globals.GoalState.Incomplete];
			txtGlobalComp.Text = _activeGGTrigger[Globals.GoalState.Complete];
			txtGlobalFail.Text = _activeGGTrigger[Globals.GoalState.Failed];
			txtGlobalFail.Visible = (g < (int)Globals.GoalIndex.Prevent);
			txtGlobalInc.Visible = (g < (int)Globals.GoalIndex.Secondary);
			labelRefresh(_activeGGTrigger.GoalTrigger, lblGlobTrig[_activeGlobalTriggerIndex]);
			numGlobalDelay.Value = _activeGlobalGoal.Delay * 5;
			_loading = btemp;
		}
		void lblGlobTrigArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("Glob", new EventArgs());
		void lblGlobTrigArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("Glob", new EventArgs()); }
		void optGlobAndOrArr_CheckedChanged(object sender, EventArgs e)
		{
			if (_loading) return;

			RadioButton r = (RadioButton)sender;
			int i = (int)r.Tag % 3;
			_activeGlobalGoal.AndOr[i] = Common.Update(this, _activeGlobalGoal.AndOr[i], r.Checked);
		}

		void cboGlobalAmount_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_loading) _activeGGTrigger.GoalTrigger.Amount = Common.Update(this, _activeGGTrigger.GoalTrigger.Amount, Convert.ToByte(cboGlobalAmount.SelectedIndex));
			labelRefresh(_activeGGTrigger.GoalTrigger, lblGlobTrig[_activeGlobalTriggerIndex]);
		}
		void cboGlobalTrig_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_loading) _activeGGTrigger.GoalTrigger.Condition = Common.Update(this, _activeGGTrigger.GoalTrigger.Condition, Convert.ToByte(cboGlobalTrig.SelectedIndex));
			labelRefresh(_activeGGTrigger.GoalTrigger, lblGlobTrig[_activeGlobalTriggerIndex]);
		}
		void cboGlobalType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboGlobalType.SelectedIndex == -1) return;

			if (!_loading) _activeGGTrigger.GoalTrigger.VariableType = Common.Update(this, _activeGGTrigger.GoalTrigger.VariableType, Convert.ToByte(cboGlobalType.SelectedIndex));
			comboVarRefresh(_activeGGTrigger.GoalTrigger.VariableType, cboGlobalVar);
			try { cboGlobalVar.SelectedIndex = _activeGGTrigger.GoalTrigger.Variable; }
			catch { cboGlobalVar.SelectedIndex = 0; _activeGGTrigger.GoalTrigger.Variable = 0; }
			if (!_loading) labelRefresh(_activeGGTrigger.GoalTrigger, lblGlobTrig[_activeGlobalTriggerIndex]);
		}
		void cboGlobalVar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_loading) _activeGGTrigger.GoalTrigger.Variable = Common.Update(this, _activeGGTrigger.GoalTrigger.Variable, Convert.ToByte(cboGlobalVar.SelectedIndex));
			labelRefresh(_activeGGTrigger.GoalTrigger, lblGlobTrig[_activeGlobalTriggerIndex]);
		}

		void numGlobalDelay_Leave(object sender, EventArgs e) => _activeGlobalGoal.Delay = Common.Update(this, _activeGlobalGoal.Delay, (byte)(numGlobalDelay.Value / 5));
		void numGlobalPoints_Leave(object sender, EventArgs e) => _activeGlobalGoal.Points = Common.Update(this, _activeGlobalGoal.Points, (short)numGlobalPoints.Value);

		void txtGlobal_Leave(object sender, EventArgs e)
		{
			Globals.GoalState gs = (Globals.GoalState)((TextBox)sender).Tag;
			_activeGGTrigger[gs] = Common.Update(this, _activeGGTrigger[gs], ((TextBox)sender).Text);
		}
		#endregion
		#region Teams
		Team _activeTeam => _mission.Teams[_activeTeamIndex];
		void teamRefresh()
		{
			string team = _activeTeam.Name;
			lblTeam[_activeTeamIndex].Text = "Team " + (_activeTeamIndex + 1).ToString() + ": " + team;
			if (team == "") team = "Team " + (_activeTeamIndex + 1).ToString();
			cboGlobalTeam.Items[_activeTeamIndex] = team;
			cboTeam.Items[_activeTeamIndex] = team;

			ComboBox[] cboType = new ComboBox[8];
			cboType[0] = cboADTrigType;
			cboType[1] = cboOT1Type;
			cboType[2] = cboOT2Type;
			cboType[3] = cboOT3Type;
			cboType[4] = cboOT4Type;
			cboType[5] = cboSkipType;
			cboType[6] = cboMessType;
			cboType[7] = cboGlobalType;
			ComboBox[] cbo = new ComboBox[8];
			cbo[0] = cboADTrigVar;
			cbo[1] = cboOT1;
			cbo[2] = cboOT2;
			cbo[3] = cboOT3;
			cbo[4] = cboOT4;
			cbo[5] = cboSkipVar;
			cbo[6] = cboMessVar;
			cbo[7] = cboGlobalVar;
			for (int i = 0; i < 8; i++)
				if (cboType[i].SelectedIndex == (int)Mission.Trigger.TypeList.Team || cboType[i].SelectedIndex == (int)Mission.Trigger.TypeList.NotTeam)
					cbo[i].Items[_activeTeamIndex] = team;

			ComboBox[] cboRole = new ComboBox[4];
			cboRole[0] = cboRoleTeam1;
			cboRole[1] = cboRoleTeam2;
			cboRole[2] = cboRoleTeam3;
			cboRole[3] = cboRoleTeam4;

			chkAllies[_activeTeamIndex].Text = team;

			for (int i = 0; i < _mission.Teams.Count; i++) BriefingForm.SharedTeamNames[i] = _mission.Teams[i].Name;

			if (_activeTeamIndex >= 0 && _activeTeamIndex < 4)    //Each role only displays 4 teams beginning at index[1]
				for (int i = 0; i < 4; i++) cboRole[i].Items[1 + _activeTeamIndex] = team;

			if (_activeTeamIndex >= 0 && _activeTeamIndex < 8)   //8 teams in the Radio list beginning at index[1]
				cboRadio.Items[1 + _activeTeamIndex] = team;

			lstGoalTeams.Items[_activeTeamIndex] = team;
		}

		void cboEoMColorArr_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox c = (ComboBox)sender;
			if (!_loading) _activeTeam.EndOfMissionMessageColor[(int)c.Tag] = Common.Update(this, _activeTeam.EndOfMissionMessageColor[(int)c.Tag], Convert.ToByte(c.SelectedIndex));
			Color clr = Color.Crimson;
			if (c.SelectedIndex == 1) clr = Color.LimeGreen;
			else if (c.SelectedIndex == 2) clr = Color.RoyalBlue;
			else if (c.SelectedIndex == 3) clr = Color.Yellow;
			txtEoM[(int)c.Tag].ForeColor = clr;
		}
		void chkAlliesArr_Leave(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)sender;
			_activeTeam.AlliedWithTeam[(int)c.Tag] = Common.Update(this, _activeTeam.AlliedWithTeam[(int)c.Tag], c.Checked);
		}

		void lblTeamArr_Click(object sender, EventArgs e)
		{
			Label l;
			try
			{
				l = (Label)sender;
				l.Focus();
				_activeTeamIndex = Convert.ToByte(l.Tag);
			}
			catch (InvalidCastException) { _activeTeamIndex = Convert.ToByte(sender); l = lblTeam[_activeTeamIndex]; }
			if (l == null) return;

			cboGlobalTeam.SelectedIndex = _activeTeamIndex;
			setInteractiveLabelColor(l, true);
			for (int i = 0; i < 10; i++) if (i != _activeTeamIndex) setInteractiveLabelColor(lblTeam[i], false);
			bool btemp = _loading;
			_loading = true;
			txtTeamName.Text = _activeTeam.Name;
			for (int i = 0; i < 10; i++) chkAllies[i].Checked = _activeTeam.AlliedWithTeam[i];
			for (int i = 0; i < 6; i++)
			{
				txtEoM[i].Text = _activeTeam.EndOfMissionMessages[i];
				cboEoMColor[i].SelectedIndex = _activeTeam.EndOfMissionMessageColor[i];
			}
			numEomCompDelay.Value = _activeTeam.EomRawDelay[0] * 5;
			numEomSecDelay.Value = _activeTeam.EomRawDelay[1] * 5;
			numEomFailedDelay.Value = _activeTeam.EomRawDelay[2] * 5;
			_loading = btemp;
		}
		void lblTeamArr_DoubleClick(object sender, EventArgs e) => menuPaste_Click("Team", new EventArgs());
		void lblTeamArr_MouseUp(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) menuCopy_Click("Team", new EventArgs()); }

		void numEomCompDelay_Leave(object sender, EventArgs e) => _activeTeam.EomRawDelay[0] = Common.Update(this, _activeTeam.EomRawDelay[0], (byte)(numEomCompDelay.Value / 5));
		void numEomSecDelay_Leave(object sender, EventArgs e) => _activeTeam.EomRawDelay[1] = Common.Update(this, _activeTeam.EomRawDelay[1], (byte)(numEomSecDelay.Value / 5));
		void numEomFailedDelay_Leave(object sender, EventArgs e) => _activeTeam.EomRawDelay[2] = Common.Update(this, _activeTeam.EomRawDelay[2], (byte)(numEomFailedDelay.Value / 5));

		void txtEoMArr_Leave(object sender, EventArgs e)
		{
			TextBox t = (TextBox)sender;
			_activeTeam.EndOfMissionMessages[(int)t.Tag] = Common.Update(this, _activeTeam.EndOfMissionMessages[(int)t.Tag], t.Text);
		}

		void txtTeamName_Leave(object sender, EventArgs e)
		{
			_activeTeam.Name = Common.Update(this, _activeTeam.Name, txtTeamName.Text);
			teamRefresh();
		}
		#endregion
		#region Mission
		void cboMissType_Leave(object sender, EventArgs e) => _mission.MissionType = Common.Update(this, _mission.MissionType, (Mission.MissionTypeEnum)Convert.ToByte(cboMissType.SelectedIndex));

		void chkGoalsUnimportant_Leave(object sender, EventArgs e) => _mission.GoalsUnimportant = Common.Update(this, _mission.GoalsUnimportant, chkGoalsUnimportant.Checked);
		private void numRndSeed_ValueChanged(object sender, EventArgs e) => _mission.RndSeed = Common.Update(this, _mission.RndSeed, Convert.ToByte(numRndSeed.Value));
		void numMissTimeMin_Leave(object sender, EventArgs e) => _mission.TimeLimitMin = Common.Update(this, _mission.TimeLimitMin, Convert.ToByte(numMissTimeMin.Value));
		void numMissTimeSec_Leave(object sender, EventArgs e) => _mission.TimeLimitSec = Common.Update(this, _mission.TimeLimitSec, Convert.ToByte(numMissTimeSec.Value));
		void numWinType_Leave(object sender, EventArgs e) => _mission.WinType = Common.Update(this, _mission.WinType, Convert.ToByte(numWinType.Value));

		void optXvT_CheckedChanged(object sender, EventArgs e)
		{
			setBop(!optXvT.Checked);
			Common.MarkDirty(this, _loading);
		}

		void txtIFFArr_Leave(object sender, EventArgs e)
		{
			TextBox t = (TextBox)sender;
			_mission.IFFs[(int)t.Tag] = Common.Update(this, _mission.IFFs[(int)t.Tag], t.Text);
			comboReset(cboIFF, getIffStrings(), cboIFF.SelectedIndex);
		}

		void txtMissDesc_Leave(object sender, EventArgs e) => _mission.MissionDescription = Common.Update(this, _mission.MissionDescription, txtMissDesc.Text);
		void txtMissFail_Leave(object sender, EventArgs e) => _mission.MissionFailed = Common.Update(this, _mission.MissionFailed, txtMissFail.Text);
		void txtMissSucc_Leave(object sender, EventArgs e) => _mission.MissionSuccessful = Common.Update(this, _mission.MissionSuccessful, txtMissSucc.Text);
		#endregion
	}
}