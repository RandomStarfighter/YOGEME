﻿/*
 * YOGEME.exe, All-in-one Mission Editor for the X-wing series, XW through XWA
 * Copyright (C) 2007-2021 Michael Gaisser (mjgaisser@gmail.com)
 * Licensed under the MPL v2.0 or later
 * 
 * VERSION: 1.10
 */

/* CHANGELOG
 * v1.10, 210520
 * [ADD] Wingman markings, Droid1/2Update
 * [ADD] S-Foils, Skins (32bpp), Shield hook support
 * [FIX] Missing Droid1/2PositionZ read
 * [UPD] Layout redesigned
 * [FIX] Now can handle comments at the end of a line
 * v1.8.2, 201219
 * [FIX] Add BD/Sound/Object/Hangar was cutting off first letter due to removal of "\\"
 * [UPD] Default ObjectsProfile updated to "default"
 * v1.8.1, 201213
 * [UPD] Settings passed in instead of re-init
 * [UPD] replaced StringFunctions.GetFileName with Path
 * [UPD] added a \\ into _installDirectory so it could be pulled out of everything else
 * [ADD] ObjectProfile_fg_#
 * v1.8, 201004
 * [UPD] improved use* bool efficiency
 * [ADD] HangarRoofCranePositionX, HangarRoofCraneAxis, HangarRoofCraneLowOffset, HangarRoofCraneHighOffset, HangarIff
 * [ADD] ShuttlePositionX/Y/Z, ShuttleOrientation, IsShuttleFloorInverted
 * [ADD] Droids/Droid1/Droid2PositionZ, IsDroidsFloorInverted
 * [ADD] PlayerOffsetX/Y/Z, IsPlayerFloorInverted
 * [FIX] case-sensitivity in filename [JB]
 * [FIX] added missing checks for chkObjects and chkSounds state [JB]
 * [FIX] handling of hex values and negative integers [JB]
 * [ADD] HangarRoofCranePositionY, HangarRoofCranePositionZ, PlayerAnimationElevation [JB]
 * [FIX] missing Write section for [Objects] [JB]
 * v1.6.3, 200101
 * [ADD] ShuttleAnimation and ShuttleAnimationStraightLine
 * v1.6.2, 190928
 * [UPD] changed the INI save backup name to prevent possible clashes
 * v1.6.1, 190916
 * [FIX #27] Crash when the INI doesn't exist
 * v1.6, 190915
 * - Release
 */

using Idmr.Platform.Xwa;
using System;
using System.IO;
using System.Windows.Forms;

namespace Idmr.Yogeme
{
	public partial class XwaHookDialog : Form
	{
		// this is going to be setup to read from the individual TXT files, but always write to Mission.ini
		readonly string _mission;
		readonly string _fileName = "";
		readonly string _bdFile = "";
		readonly string _soundFile = "";
		readonly string _objFile = "";
		readonly string _missionTxtFile = "";
		readonly string _hangarObjectsFile = "";
		readonly string _hangarCameraFile = "";
		readonly string _famHangarCameraFile = "";
		readonly string _hangarMapFile = "";
		readonly string _famHangarMapFile = "";
		readonly string _32bppFile = "";
		readonly string _shieldFile = "";
		readonly string _installDirectory = "";
		readonly string _mis = "Missions\\";
		readonly string _res = "Resdata\\";
		readonly string _wave = "Wave\\";
		readonly string _fm = "FlightModels\\";
		enum ReadMode { None = -1, Backdrop, Mission, Sounds, Objects, HangarObjects, HangarCamera, FamilyHangarCamera, HangarMap, FamilyHangarMap, Skins, Shield }
		bool _loading = false;
		readonly int[,] _cameras = new int[5, 3];
		readonly int[,] _defaultCameras = new int[5, 3];
		readonly int[,] _familyCameras = new int[7, 3];
		readonly int[,] _defaultFamilyCameras = new int[7, 3];
		enum ShuttleAnimation { Right, Top, Bottom }
		readonly int[] _defaultShuttlePosition = new int[4] { 1127, 959, 0, 43136 };
		readonly int[] _defaultRoofCranePosition = new int[3] { -1400, 786, -282 };

		public XwaHookDialog(Mission mission, Settings config)
		{
			InitializeComponent();
			_mission = Path.GetFileNameWithoutExtension(mission.MissionPath);
			if (_mission == "NewMission")
			{
				MessageBox.Show("Please perform initial save prior to hook assignment.", "New Mission detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cmdCancel_Click("NewMission", new EventArgs());
				return;
			}
			_fileName = mission.MissionPath.ToLower().Replace(".tie", ".ini");

			#region initialize
			cboIff.Items.AddRange(Strings.IFF);
			cboHangarIff.Items.AddRange(Strings.IFF);
			for (int i = cboIff.Items.Count; i < 256; i++)
			{
				cboIff.Items.Add("IFF #" + (i + 1));
				cboHangarIff.Items.Add("IFF #" + (i + 1));
			}
			cboIff.SelectedIndex = 0;
			cboMarkings.Items.AddRange(Strings.Color);
			cboShuttleMarks.Items.AddRange(Strings.Color);
			cboMapMarkings.Items.AddRange(Strings.Color);
			cboFamMapMarkings.Items.AddRange(Strings.Color);
			cboSkinMarks.Items.AddRange(Strings.Color);
			for (int i = cboMarkings.Items.Count; i < 256; i++)
			{
				cboMarkings.Items.Add("Clr #" + (i + 1));
				cboShuttleMarks.Items.Add("Clr #" + (i + 1));
				cboMapMarkings.Items.Add("Clr #" + (i + 1));
				cboFamMapMarkings.Items.Add("Clr #" + (i + 1));
				cboSkinMarks.Items.Add("Clr #" + (i + 1));
			}
			cboMarkings.SelectedIndex = 0;
			cboShuttleMarks.SelectedIndex = 0;
			cboShuAnimation.SelectedIndex = 0;
			cboMapMarkings.SelectedIndex = 0;
			cboFamMapMarkings.SelectedIndex = 0;
			cboSkinMarks.SelectedIndex = 0;
			cboFG.Items.AddRange(mission.FlightGroups.GetList());
			cboProfileFG.Items.AddRange(mission.FlightGroups.GetList());
			cboSFoilFG.Items.AddRange(mission.FlightGroups.GetList());
			for (int i = 0; i < 400; i++)
			{
				cboShuttleModel.Items.Add(i);
				cboMapIndex.Items.Add(i);
				cboFamMapIndex.Items.Add(i);
			}
			// TODO: ShuttleModel really should be using the craft list
			cboShuttleModel.SelectedIndex = 50;
			cboMapIndex.SelectedIndex = 0;
			cboFamMapIndex.SelectedIndex = 0;
			for (int i = 4; i >= 0; i--)
			{
				cboCamera.SelectedIndex = i;
				cmdDefaultCamera_Click("startup", new EventArgs());
			}
			for (int i = 0; i < 5; i++)
				for (int j = 0; j < 3; j++)
					_defaultCameras[i, j] = _cameras[i, j];
			for (int i = 6; i >= 0; i--)
			{
				cboFamilyCamera.SelectedIndex = i;
				cmdDefaultFamilyCamera_Click("startup", new EventArgs());
			}
			for (int i = 0; i < 7; i++)
				for (int j = 0; j < 3; j++)
					_defaultFamilyCameras[i, j] = _familyCameras[i, j];
			cboShield.Items.AddRange(Strings.CraftType);
			cboShield.SelectedIndex = 0;
			#endregion

			if (config.XwaInstalled)
			{
				_installDirectory = config.XwaPath + "\\";
				chkBackdrops.Enabled = File.Exists(_installDirectory + "Hook_Backdrops.dll");
				chkMission.Enabled = File.Exists(_installDirectory + "Hook_Mission_Tie.dll");
				chkSounds.Enabled = File.Exists(_installDirectory + "Hook_Engine_Sound.dll");
				chkObjects.Enabled = File.Exists(_installDirectory + "Hook_Mission_Objects.dll");
				chkHangars.Enabled = File.Exists(_installDirectory + "Hook_Hangars.dll");
				chkSkins.Enabled = File.Exists(_installDirectory + "Hook_32bpp.dll");
				chkShield.Enabled = File.Exists(_installDirectory + "Hook_Shield.dll");
				chkSFoils.Enabled = File.Exists(_installDirectory + "Hook_SFoils.dll");

				_bdFile = checkFile("_Resdata.txt");
				_soundFile = checkFile("_Sounds.txt");
				_objFile = checkFile("_Objects.txt");
				_missionTxtFile = checkFile(".txt");
				_hangarObjectsFile = checkFile("_HangarObjects.txt");
				_hangarCameraFile = checkFile("_HangarCamera.txt");
				_famHangarCameraFile = checkFile("_FamHangarCamera.txt");
				_hangarMapFile = checkFile("_HangarMap.txt");
				_famHangarMapFile = checkFile("_FamHangarMap.txt");
				_32bppFile = checkFile("_Skins.txt");
				_shieldFile = checkFile("_Shield.txt");
			}
			StreamReader srMission = null;
			string line;
			string lineLower;
			if (File.Exists(_fileName)) srMission = new StreamReader(_fileName);
			ReadMode readMode = ReadMode.None;

			#region individual files
			if (_bdFile != "")
			{
				StreamReader srBD = new StreamReader(_bdFile);
				while ((line = srBD.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					lstBackdrops.Items.Add(line);
				}
				srBD.Close();
			}
			if (_missionTxtFile != "")
			{
				StreamReader srMiss = new StreamReader(_missionTxtFile);
				while((line = srMiss.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					parseMission(line);
				}
				srMiss.Close();
			}
			if (_soundFile != "")
			{
				StreamReader srSounds = new StreamReader(_soundFile);
				while ((line = srSounds.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					lstSounds.Items.Add(line);
				}
				srSounds.Close();
			}
			if (_objFile != "")
			{
				StreamReader srObjects = new StreamReader(_objFile);
				while ((line = srObjects.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					lstObjects.Items.Add(line);
				}
				srObjects.Close();
			}
			if (_hangarObjectsFile != "")
			{
				StreamReader srHangarObjects = new StreamReader(_hangarObjectsFile);
				while ((line = srHangarObjects.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					parseHangarObjects(line);
				}
				srHangarObjects.Close();
			}
			if (_hangarCameraFile != "")
			{
				StreamReader srHangarCamera = new StreamReader(_hangarCameraFile);
				while((line = srHangarCamera.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					parseHangarCamera(line);
				}
				srHangarCamera.Close();
			}
			if (_famHangarCameraFile != "")
			{
				StreamReader srFamilyHangarCamera = new StreamReader(_famHangarCameraFile);
				while ((line = srFamilyHangarCamera.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					parseFamilyHangarCamera(line);
				}
				srFamilyHangarCamera.Close();
			}
			if (_hangarMapFile != "")
			{
				StreamReader srMap = new StreamReader(_hangarMapFile);
				MapEntry entry = new MapEntry();
				while((line = srMap.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					if (entry.Parse(line))
						lstMap.Items.Add(entry.ToString());
				}
				srMap.Close();
			}
			if (_famHangarMapFile != "")
			{
				StreamReader srFamMap = new StreamReader(_famHangarMapFile);
				MapEntry entry = new MapEntry();
				while ((line = srFamMap.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					if (entry.Parse(line))
						lstFamilyMap.Items.Add(entry.ToString());
				}
				srFamMap.Close();
			}
			if (_32bppFile != "")
			{
				StreamReader sr32bpp = new StreamReader(_32bppFile);
				while ((line = sr32bpp.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					lstSkins.Items.Add(line);
				}
				sr32bpp.Close();
			}
			if (_shieldFile != "")
			{
				StreamReader srShield = new StreamReader(_shieldFile);
				while ((line = srShield.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					parseShield(line);
				}
				srShield.Close();
			}
			#endregion

			if (srMission != null)
			{
				#region read
				while ((line = srMission.ReadLine()) != null)
				{
					line = removeComment(line);
					if (line == "") continue;

					lineLower = line.ToLower();

					if (line.StartsWith("["))
					{
						readMode = ReadMode.None;
						if (lineLower == "[resdata]") readMode = ReadMode.Backdrop;
						else if (lineLower == "[mission_tie]") readMode = ReadMode.Mission;
						else if (lineLower == "[sounds]") readMode = ReadMode.Sounds;
						else if (lineLower == "[objects]") readMode = ReadMode.Objects;
						else if (lineLower == "[hangarobjects]") readMode = ReadMode.HangarObjects;
						else if (lineLower == "[hangarcamera]") readMode = ReadMode.HangarCamera;
						else if (lineLower == "[famhangarcamera]") readMode = ReadMode.FamilyHangarCamera;
						else if (lineLower == "[hangarmap]") readMode = ReadMode.HangarMap;
						else if (lineLower == "[famhangarmap]") readMode = ReadMode.FamilyHangarMap;
						else if (lineLower == "[skins]") readMode = ReadMode.Skins;
						else if (lineLower == "[shield]") readMode = ReadMode.Shield;
					}
					else if (readMode == ReadMode.Backdrop) lstBackdrops.Items.Add(line);
					else if (readMode == ReadMode.Mission) parseMission(line);
					else if (readMode == ReadMode.Sounds) lstSounds.Items.Add(line);
					else if (readMode == ReadMode.Objects) lstObjects.Items.Add(line);
					else if (readMode == ReadMode.HangarObjects) parseHangarObjects(line);
					else if (readMode == ReadMode.HangarCamera) parseHangarCamera(line);
					else if (readMode == ReadMode.FamilyHangarCamera) parseFamilyHangarCamera(line);
					else if (readMode == ReadMode.HangarMap)
					{
						MapEntry entry = new MapEntry();
						if (entry.Parse(line))
							lstMap.Items.Add(entry.ToString());
					}
					else if (readMode == ReadMode.FamilyHangarMap)
					{
						MapEntry entry = new MapEntry();
						if (entry.Parse(line))
							lstFamilyMap.Items.Add(entry.ToString());
					}
					else if (readMode == ReadMode.Skins) lstSkins.Items.Add(line);
					else if (readMode == ReadMode.Shield) parseShield(line);
				}
				#endregion
				srMission.Close();
			}

			chkBackdrops.Checked = (lstBackdrops.Items.Count > 0);
			chkMission.Checked = (lstMission.Items.Count > 0);
			chkSounds.Checked = (lstSounds.Items.Count > 0);
			chkObjects.Checked = (lstObjects.Items.Count > 0);
			chkHangars.Checked = useHangarObjects | useHangarCamera | useFamilyHangarCamera | useHangarMap;
			chkSkins.Checked = (lstSkins.Items.Count > 0);
			chkShield.Checked = (lstShield.Items.Count > 0);
		}

		string checkFile(string extension)
		{
			if (File.Exists(_installDirectory + _mis + _mission + extension)) return _installDirectory + _mis + _mission + extension;
			return "";
		}

		#region Backdrops
		private void chkBackdrops_CheckedChanged(object sender, EventArgs e)
		{
			lstBackdrops.Enabled = chkBackdrops.Checked;
			cmdAddBD.Enabled = chkBackdrops.Checked;
			cmdRemoveBD.Enabled = chkBackdrops.Checked;
		}

		private void cmdAddBD_Click(object sender, EventArgs e)
		{
			if (_installDirectory != "") opnBackdrop.InitialDirectory = _installDirectory + _res;
			DialogResult res = opnBackdrop.ShowDialog();
			if (res == DialogResult.OK)
				lstBackdrops.Items.Add(opnBackdrop.FileName.Substring(opnBackdrop.FileName.IndexOf(_res)));
		}
		private void cmdRemoveBD_Click(object sender, EventArgs e)
		{
			if (lstBackdrops.SelectedIndex != -1) lstBackdrops.Items.RemoveAt(lstBackdrops.SelectedIndex);
		}
		#endregion Backdrops

		#region MissionTie
		/// <remarks>This also parses S-Foils</remarks>
		void parseMission(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));

			string[] parts = line.ToLower().Replace(" ", "").Split(',');
			if (parts[0] == "fg")
			{
				int fg = int.Parse(parts[1]);
				if (parts[2] == "markings")
					lstMission.Items.Add(cboFG.Items[fg].ToString() + ",marks," + cboMarkings.Items[int.Parse(parts[3])].ToString());
				else if (parts[2] == "index")
					lstMission.Items.Add(cboFG.Items[fg].ToString() + ",wing," + int.Parse(parts[3]) + "," + cboMarkings.Items[int.Parse(parts[5])].ToString());
				else if (parts[2] == "iff")
					lstMission.Items.Add(cboFG.Items[fg].ToString() + ",iff," + cboIff.Items[int.Parse(parts[3])].ToString());
				else if (parts[2] == "pilotvoice")
					lstMission.Items.Add(cboFG.Items[fg].ToString() + ",pilot," + parts[3]);
				else if (parts[2] == "close_sfoils")
				{
					chkSFoils.Checked = true;
					lstSFoils.Items.Add(cboSFoilFG.Items[fg].ToString() + ",closed");
				}
				else if (parts[2] == "open_landinggears")
				{
					chkSFoils.Checked = true;
					lstSFoils.Items.Add(cboSFoilFG.Items[fg].ToString() + ",open");
				}
			}
			parts = parts[0].Split('=');
			if (parts[0] == "closesfoilsandopenlandinggearsbeforeenterhangar" && parts[1] == "1")
			{
				chkSFoils.Checked = true;
				chkForceHangarSF.Checked = true;
			}
			else if (parts[0] == "closelandinggearsbeforeenterhyperspace" && parts[1] == "1")
			{
				chkSFoils.Checked = true;
				chkForceHyperLG.Checked = true;
			}
			else if (parts[0] == "autoclosesfoils" && parts[1] == "0")
			{
				chkSFoils.Checked = true;
				chkManualSF.Checked = true;
			}
		}

		void cboMission_CheckedChanged(object sender, EventArgs e)
		{
			cboMarkings.Enabled = optMarkings.Checked | optWingman.Checked;
			numWingman.Enabled = optWingman.Checked;
			cboIff.Enabled = optIff.Checked;
			txtPilot.Enabled = optPilot.Checked;
		}

		private void chkMission_CheckedChanged(object sender, EventArgs e)
		{
			lstMission.Enabled = chkMission.Checked;
			cmdAddMiss.Enabled = chkMission.Checked;
			cmdRemoveMiss.Enabled = chkMission.Checked;
			cboFG.Enabled = chkMission.Checked;
			optMarkings.Enabled = chkMission.Checked;
			optWingman.Enabled = chkMission.Checked;
			optIff.Enabled = chkMission.Checked;
			optPilot.Enabled = chkMission.Checked;
			if (chkMission.Checked) cboMission_CheckedChanged("chkMission", new EventArgs());
			else
			{
				cboMarkings.Enabled = false;
				numWingman.Enabled = false;
				cboIff.Enabled = false;
				txtPilot.Enabled = false;
			}
		}

		private void cmdAddMiss_Click(object sender, EventArgs e)
		{
			if (cboFG.SelectedIndex == -1 || ((optWingman.Checked || optMarkings.Checked) && cboMarkings.SelectedIndex == -1) || (optIff.Checked && cboIff.SelectedIndex == -1)
				|| (optPilot.Checked && txtPilot.Text == "")) return;

			if (optMarkings.Checked) lstMission.Items.Add(cboFG.Text + ",marks," + cboMarkings.Text);
			else if (optWingman.Checked) lstMission.Items.Add(cboFG.Text + ",wing," + numWingman.Value + "," + cboMarkings.Text);
			else if (optIff.Checked) lstMission.Items.Add(cboFG.Text + ",iff," + cboIff.Text);
			else if (optPilot.Checked) lstMission.Items.Add(cboFG.Text + ",pilot," + txtPilot.Text);
		}
		private void cmdRemoveMiss_Click(object sender, EventArgs e)
		{
			if (lstMission.SelectedIndex == -1) return;
			lstMission.Items.RemoveAt(lstMission.SelectedIndex);
		}
		#endregion

		#region Sounds
		private void chkSounds_CheckedChanged(object sender, EventArgs e)
		{
			lstSounds.Enabled = chkSounds.Checked;
			cmdAddSounds.Enabled = chkSounds.Checked;
			cmdRemoveSounds.Enabled = chkSounds.Checked;
		}

		private void cmdAddSounds_Click(object sender, EventArgs e)
		{
			if (_installDirectory != "") opnSounds.InitialDirectory = _installDirectory + _wave;
			opnSounds.Title = "Select original sound...";
			DialogResult res = opnSounds.ShowDialog();
			if (res == DialogResult.OK)
			{
				string line = opnSounds.FileName.Substring(opnSounds.FileName.IndexOf(_wave)) + " = ";
				opnSounds.Title = "Select new sound...";
				res = opnSounds.ShowDialog();
				if (res == DialogResult.OK)
					lstSounds.Items.Add(line + opnSounds.FileName.Substring(opnSounds.FileName.IndexOf(_wave) + 1));
			}
		}
		private void cmdRemoveSounds_Click(object sender, EventArgs e)
		{
			if (lstSounds.SelectedIndex != -1) lstSounds.Items.RemoveAt(lstSounds.SelectedIndex);
		}
		#endregion

		#region Objects
		private void chkObjects_CheckedChanged(object sender, EventArgs e)
		{
			lstObjects.Enabled = chkObjects.Checked;
			cmdAddObjects.Enabled = chkObjects.Checked;
			cmdRemoveObjects.Enabled = chkObjects.Checked;
			optCraft.Enabled = chkObjects.Checked;
			optProfile.Enabled = chkObjects.Checked;
			cboProfileFG.Enabled = chkObjects.Checked && optProfile.Checked;
			txtProfile.Enabled = chkObjects.Checked && optProfile.Checked;
		}

		private void cmdAddObjects_Click(object sender, EventArgs e)
		{
			if (optCraft.Checked)
			{
				if (_installDirectory != "") opnObjects.InitialDirectory = _installDirectory + _fm;
				opnObjects.Title = "Select original object...";
				DialogResult res = opnObjects.ShowDialog();
				if (res == DialogResult.OK)
				{
					string line = opnObjects.FileName.Substring(opnObjects.FileName.IndexOf(_fm)) + " = ";
					opnObjects.Title = "Select new object...";
					res = opnObjects.ShowDialog();
					if (res == DialogResult.OK)
						lstObjects.Items.Add(line + opnObjects.FileName.Substring(opnObjects.FileName.IndexOf(_fm)));
				}
			}
			else if (optProfile.Checked && txtProfile.Text != "" && txtProfile.Text.ToLower() != "default")
			{
				string line = "ObjectProfile_fg_" + cboProfileFG.SelectedIndex + "=" + txtProfile.Text;
				lstObjects.Items.Add(line);
			}
		}
		private void cmdRemoveObjects_Click(object sender, EventArgs e)
		{
			if (lstObjects.SelectedIndex != -1) lstObjects.Items.RemoveAt(lstObjects.SelectedIndex);
		}

		private void optProfile_CheckedChanged(object sender, EventArgs e)
		{
			cboProfileFG.Enabled = optProfile.Checked;
			txtProfile.Enabled = optProfile.Checked;
		}
		#endregion

		#region Hangars
		// TODO: need a top-level IFF selector, and clone all Hangar values X times, including read/write all of the IFF-specific hangar files
		void parseHangarCamera(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));

			int view = 0;
			int camera = 0;
			string[] parts = line.ToLower().Replace(" ", "").Split('=');
			if (parts.Length == 2)
			{
				if (parts[0].StartsWith("key1")) view = 0;
				else if (parts[0].StartsWith("key2")) view = 1;
				else if (parts[0].StartsWith("key3")) view = 2;
				else if (parts[0].StartsWith("key6")) view = 3;
				else if (parts[0].StartsWith("key9")) view = 4;

				if (parts[0].IndexOf("_x") != -1) camera = 0;
				else if (parts[0].IndexOf("_y") != -1) camera = 1;
				else if (parts[0].IndexOf("_z") != -1) camera = 2;

				_cameras[view, camera] = int.Parse(parts[1]);
			}
		}
		void parseFamilyHangarCamera(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));

			int view = 0;
			int camera = 0;
			string[] parts = line.ToLower().Replace(" ", "").Split('=');
			if (parts.Length == 2)
			{
				if (parts[0].StartsWith("key1")) view = 0;
				else if (parts[0].StartsWith("key2")) view = 1;
				else if (parts[0].StartsWith("key3")) view = 2;
				else if (parts[0].StartsWith("key6")) view = 3;
				else if (parts[0].StartsWith("key7")) view = 4;
				else if (parts[0].StartsWith("key8")) view = 5;
				else if (parts[0].StartsWith("key9")) view = 6;

				if (parts[0].IndexOf("_x") != -1) camera = 0;
				else if (parts[0].IndexOf("_y") != -1) camera = 1;
				else if (parts[0].IndexOf("_z") != -1) camera = 2;

				_familyCameras[view, camera] = int.Parse(parts[1]);
			}
		}
		void parseHangarObjects(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));

			string[] parts = line.ToLower().Replace(" ", "").Split('=');
			if (parts.Length == 2)
			{
				if (parts[0] == "loadshuttle") chkShuttle.Checked = (parts[1] != "0");
				else if (parts[0] == "shuttlemodelindex") cboShuttleModel.SelectedIndex = int.Parse(parts[1]);
				else if (parts[0] == "shuttlemarkings") cboShuttleMarks.SelectedIndex = int.Parse(parts[1]);
				else if (parts[0] == "shuttlepositionx") numShuttlePositionX.Value = int.Parse(parts[1]);
				else if (parts[0] == "shuttlepositiony") numShuttlePositionY.Value = int.Parse(parts[1]);
				else if (parts[0] == "shuttlepositionz") numShuttlePositionZ.Value = int.Parse(parts[1]);
				else if (parts[0] == "shuttleorientation") numShuttleOrientation.Value = int.Parse(parts[1]);
				else if (parts[0] == "isshuttlefloorinverted") chkShuttleFloor.Checked = (parts[1] != "0");
				else if (parts[0] == "shuttleanimation")
					try { cboShuAnimation.SelectedIndex = (int)Enum.Parse(typeof(ShuttleAnimation), parts[1], true); }
					catch { MessageBox.Show("Error reading ShuttleAnimation, using default.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
				else if (parts[0] == "shuttleanimationstraightline") numShuDistance.Value = int.Parse(parts[1]);

				else if (parts[0] == "loaddroids") chkDroids.Checked = (parts[1] != "0");
				else if (parts[0] == "droidspositionz") numDroidsZ.Value = int.Parse(parts[1]);
				else if (parts[0] == "droid1positionz")
				{
					numDroid1Z.Value = int.Parse(parts[1]);
					chkDroid1.Checked = (numDroid1Z.Value != numDroidsZ.Value);
				}
				else if (parts[0] == "droid2positionz")
				{
					numDroid2Z.Value = int.Parse(parts[1]);
					chkDroid2.Checked = (numDroid2Z.Value != numDroidsZ.Value);
				}
				else if (parts[0] == "isdroidsfloorinverted") chkDroidsFloor.Checked = (parts[1] != "0");
				else if (parts[0] == "droid1update") chkDroid1Update.Checked = (parts[1] != "0");
				else if (parts[0] == "droid2update") chkDroid2Update.Checked = (parts[1] != "0");

				else if (parts[0] == "hangarroofcranepositionx") numRoofCranePositionX.Value = int.Parse(parts[1]);
				else if (parts[0] == "hangarroofcranepositiony") numRoofCranePositionY.Value = int.Parse(parts[1]);
				else if (parts[0] == "hangarroofcranepositionz") numRoofCranePositionZ.Value = int.Parse(parts[1]);
				else if (parts[0] == "hangarroofcraneaxis")
				{
					// 0 is default, don't need to check it
					if (int.Parse(parts[1]) == 1) optRoofCraneAxisY.Checked = true;
					else if (int.Parse(parts[1]) == 2) optRoofCraneAxisZ.Checked = true;
				}
				else if (parts[0] == "hangarroofcranelowoffset") numRoofCraneLowOffset.Value = int.Parse(parts[1]);
				else if (parts[0] == "hangarroofcranehighoffset") numRoofCraneHighOffset.Value = int.Parse(parts[1]);
				else if (parts[0] == "ishangarfloorinverted") chkFloor.Checked = (parts[1] != "0");
				else if (parts[0] == "hangariff")
				{
					if (int.Parse(parts[1]) != -1)
					{
						chkHangarIff.Checked = true;
						try { cboHangarIff.SelectedIndex = int.Parse(parts[1]); }
						catch
						{
							chkHangarIff.Checked = false;
							MessageBox.Show("Error reading HangarIff, using default.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}

				else if (parts[0] == "playeranimationelevation") numPlayerAnimationElevation.Value = int.Parse(parts[1]);
				else if (parts[0] == "playeroffsetx") numPlayerX.Value = int.Parse(parts[1]);
				else if (parts[0] == "playeroffsety") numPlayerY.Value = int.Parse(parts[1]);
				else if (parts[0] == "playeroffsetz") numPlayerZ.Value = int.Parse(parts[1]);
				else if (parts[0] == "isplayerfloorinverted") chkPlayerFloor.Checked = (parts[1] != "0");
				else if (parts[0] == "foldoutside") chkHangarFold.Checked = (parts[1] != "0");
				else lstHangarObjects.Items.Add(line);
			}
		}

		private void cboCamera_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCamera.SelectedIndex == -1) return;
			_loading = true;
			numCameraX.Value = _cameras[cboCamera.SelectedIndex, 0];
			numCameraY.Value = _cameras[cboCamera.SelectedIndex, 1];
			numCameraZ.Value = _cameras[cboCamera.SelectedIndex, 2];
			_loading = false;
		}
		private void cboFamilyCamera_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFamilyCamera.SelectedIndex == -1) return;
			_loading = true;
			numFamilyCameraX.Value = _familyCameras[cboFamilyCamera.SelectedIndex, 0];
			numFamilyCameraY.Value = _familyCameras[cboFamilyCamera.SelectedIndex, 1];
			numFamilyCameraZ.Value = _familyCameras[cboFamilyCamera.SelectedIndex, 2];
			_loading = false;
		}

		private void chkDroid1_CheckedChanged(object sender, EventArgs e)
		{
			numDroid1Z.Enabled = chkDroid1.Checked;
		}
		private void chkDroid2_CheckedChanged(object sender, EventArgs e)
		{
			numDroid2Z.Enabled = chkDroid2.Checked;
		}
		private void chkFamGrounded_CheckedChanged(object sender, EventArgs e)
		{
			numFamPosZ.Enabled = !chkFamGrounded.Checked;
		}
		private void chkFamMarks_CheckedChanged(object sender, EventArgs e)
		{
			cboFamMapMarkings.Enabled = chkFamMarks.Checked;
		}
		private void chkGrounded_CheckedChanged(object sender, EventArgs e)
		{
			numPosZ.Enabled = !chkGrounded.Checked;
		}
		private void chkHangars_CheckedChanged(object sender, EventArgs e)
		{
			tcHangar.Enabled = chkHangars.Checked;
		}
		private void chkHangarIff_CheckedChanged(object sender, EventArgs e)
		{
			cboHangarIff.Enabled = chkHangarIff.Checked;
			if (chkHangarIff.Checked && cboHangarIff.SelectedIndex == -1) cboHangarIff.SelectedIndex = 0;
		}
		private void chkMarks_CheckedChanged(object sender, EventArgs e)
		{
			cboMapMarkings.Enabled = chkMarks.Checked;
		}

		private void cmdAddFamMap_Click(object sender, EventArgs e)
		{
			MapEntry entry = new MapEntry
			{
				ModelIndex = cboFamMapIndex.SelectedIndex,
				Markings = (byte)cboFamMapMarkings.SelectedIndex,
				PositionX = (int)numFamPosX.Value,
				PositionY = (int)numFamPosY.Value,
				PositionZ = (int)numFamPosZ.Value,
				IsGrounded = chkFamGrounded.Checked,
				HeadingXY = (int)numFamHeadingXY.Value,
				HeadingZ = (int)numFamHeadingZ.Value
			};
			lstFamilyMap.Items.Add(entry.ToString());
		}
		private void cmdAddHangar_Click(object sender, EventArgs e)
		{
			if (_installDirectory != "") opnObjects.InitialDirectory = _installDirectory + _fm;
			opnObjects.Title = "Select original object...";
			DialogResult res = opnObjects.ShowDialog();
			if (res == DialogResult.OK)
			{
				string line = opnObjects.FileName.Substring(opnObjects.FileName.IndexOf(_fm)) + " = ";
				opnObjects.Title = "Select new object...";
				res = opnObjects.ShowDialog();
				if (res == DialogResult.OK)
					lstHangarObjects.Items.Add(line + opnObjects.FileName.Substring(opnObjects.FileName.IndexOf(_fm)));
			}
		}
		private void cmdAddMap_Click(object sender, EventArgs e)
		{
			MapEntry entry = new MapEntry
			{
				ModelIndex = cboMapIndex.SelectedIndex,
				Markings = (byte)cboMapMarkings.SelectedIndex,
				PositionX = (int)numPosX.Value,
				PositionY = (int)numPosY.Value,
				PositionZ = (int)numPosZ.Value,
				IsGrounded = chkGrounded.Checked,
				HeadingXY = (int)numHeadingXY.Value,
				HeadingZ = (int)numHeadingZ.Value
			};
			lstMap.Items.Add(entry.ToString());
		}
		private void cmdCraneReset_Click(object sender, EventArgs e)
		{
			numRoofCranePositionX.Value = _defaultRoofCranePosition[0];
			numRoofCranePositionY.Value = _defaultRoofCranePosition[1];
			numRoofCranePositionZ.Value = _defaultRoofCranePosition[2];
		}
		private void cmdDefaultCamera_Click(object sender, EventArgs e)
		{
			switch(cboCamera.SelectedIndex)
			{
				case 0:	// View 1
					numCameraX.Value = 1130;
					numCameraY.Value = -2320;
					numCameraZ.Value = -300;
					break;
				case 1:	// View 2
					numCameraX.Value = 1240;
					numCameraY.Value = -330;
					numCameraZ.Value = -700;
					break;
				case 2:	// View 3
					numCameraX.Value = -1120;
					numCameraY.Value = 1360;
					numCameraZ.Value = -790;
					break;
				case 3:	// View 6
					numCameraX.Value = -1200;
					numCameraY.Value = -1530;
					numCameraZ.Value = -850;
					break;
				case 4:	// View 9
					numCameraX.Value = 1070;
					numCameraY.Value = 4640;
					numCameraZ.Value = -130;
					break;
			}
		}
		private void cmdDefaultFamilyCamera_Click(object sender, EventArgs e)
		{
			switch (cboFamilyCamera.SelectedIndex)
			{
				case 0: // View 1
					numFamilyCameraX.Value = 780;
					numFamilyCameraY.Value = -6471;
					numFamilyCameraZ.Value = -4977;
					break;
				case 1: // View 2
					numFamilyCameraX.Value = -1970;
					numFamilyCameraY.Value = -8810;
					numFamilyCameraZ.Value = -4707;
					break;
				case 2: // View 3
					numFamilyCameraX.Value = 2510;
					numFamilyCameraY.Value = -5391;
					numFamilyCameraZ.Value = -5067;
					break;
				case 3: // View 6
					numFamilyCameraX.Value = 1740;
					numFamilyCameraY.Value = -8461;
					numFamilyCameraZ.Value = -5047;
					break;
				case 4: // View 7
					numFamilyCameraX.Value = 3180;
					numFamilyCameraY.Value = 2629;
					numFamilyCameraZ.Value = -3777;
					break;
				case 5: // View 8
					numFamilyCameraX.Value = 8242;
					numFamilyCameraY.Value = 6500;
					numFamilyCameraZ.Value = 10;
					break;
				case 6: // View 9
					numFamilyCameraX.Value = -13360;
					numFamilyCameraY.Value = 35019;
					numFamilyCameraZ.Value = -6537;
					break;
			}
		}
		private void cmdPlayerReset_Click(object sender, EventArgs e)
		{
			numPlayerX.Value = 0;
			numPlayerY.Value = 0;
			numPlayerZ.Value = 0;
		}
		private void cmdRemoveFamMap_Click(object sender, EventArgs e)
		{
			if (lstFamilyMap.SelectedIndex != -1)
			{
				if (lstFamilyMap.Items.Count == 4)    // warn here only when initially dropping below 4
				{
					DialogResult res = MessageBox.Show("Family Hangar Map requires at least 4 line items to be saved. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (res == DialogResult.No) return;
				}

				lstFamilyMap.Items.RemoveAt(lstFamilyMap.SelectedIndex);
			}
		}
		private void cmdRemoveHangar_Click(object sender, EventArgs e)
		{
			if (lstHangarObjects.SelectedIndex != -1) lstHangarObjects.Items.RemoveAt(lstHangarObjects.SelectedIndex);
		}
		private void cmdRemoveMap_Click(object sender, EventArgs e)
		{
			if (lstMap.SelectedIndex != -1)
			{
				if (lstMap.Items.Count == 4)	// warn here only when initially dropping below 4
				{
					DialogResult res = MessageBox.Show("Hangar Map requires at least 4 line items to be saved. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (res == DialogResult.No) return;
				}

				lstMap.Items.RemoveAt(lstMap.SelectedIndex);
			}
		}
		private void cmdShuttleReset_Click(object sender, EventArgs e)
		{
			numShuttlePositionX.Value = _defaultShuttlePosition[0];
			numShuttlePositionY.Value = _defaultShuttlePosition[1];
			numShuttlePositionZ.Value = _defaultShuttlePosition[2];
			numShuttleOrientation.Value = _defaultShuttlePosition[3];
		}

		private void numCameraX_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _cameras[cboCamera.SelectedIndex, 0] = (int)numCameraX.Value;
		}
		private void numCameraY_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _cameras[cboCamera.SelectedIndex, 1] = (int)numCameraY.Value;
		}
		private void numCameraZ_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _cameras[cboCamera.SelectedIndex, 2] = (int)numCameraZ.Value;
		}
		private void numFamilyCameraX_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _familyCameras[cboFamilyCamera.SelectedIndex, 0] = (int)numFamilyCameraX.Value;
		}
		private void numFamilyCameraY_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _familyCameras[cboFamilyCamera.SelectedIndex, 1] = (int)numFamilyCameraY.Value;
		}
		private void numFamilyCameraZ_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading) _familyCameras[cboFamilyCamera.SelectedIndex, 2] = (int)numFamilyCameraZ.Value;
		}

		bool useHangarCamera
		{
			get
			{
				for (int i = 0; i < 5; i++)
					for (int j = 0; j < 3; j++)
						if (_cameras[i, j] != _defaultCameras[i, j]) return true;
				return false;
			}
		}
		bool useFamilyHangarCamera
		{
			get
			{
				for (int i = 0; i < 7; i++)
					for (int j = 0; j < 3; j++)
						if (_familyCameras[i, j] != _defaultFamilyCameras[i, j]) return true;
				return false;
			}
		}
		bool useHangarObjects
		{
			get
			{
				return (lstHangarObjects.Items.Count > 0) ||
					!chkShuttle.Checked || (cboShuttleModel.SelectedIndex != 50) || (cboShuttleMarks.SelectedIndex != 0) ||
					(numShuttlePositionX.Value != _defaultShuttlePosition[0]) || (numShuttlePositionY.Value != _defaultShuttlePosition[1]) || (numShuttlePositionZ.Value != _defaultShuttlePosition[2]) ||
					(numShuttleOrientation.Value != _defaultShuttlePosition[3]) || chkShuttleFloor.Checked || (cboShuAnimation.SelectedIndex != 0) || (numShuDistance.Value != 0) ||
					!chkDroids.Checked || (numDroidsZ.Value != 0) || (chkDroid1.Checked && numDroid1Z.Value != numDroidsZ.Value) || (chkDroid2.Checked && numDroid2Z.Value != numDroidsZ.Value) ||
					chkDroidsFloor.Checked || !chkDroid1Update.Checked || !chkDroid2Update.Checked ||
					(numRoofCranePositionX.Value != _defaultRoofCranePosition[0]) || (numRoofCranePositionY.Value != _defaultRoofCranePosition[1]) || (numRoofCranePositionZ.Value != _defaultRoofCranePosition[2]) ||
					!optRoofCraneAxisX.Checked || (numRoofCraneLowOffset.Value != 0) || (numRoofCraneHighOffset.Value != 0) ||
					chkFloor.Checked || chkHangarIff.Checked ||
					(numPlayerAnimationElevation.Value != 0) || (numPlayerX.Value != 0) || (numPlayerY.Value != 0) || (numPlayerZ.Value != 0) || chkPlayerFloor.Checked ||
					chkHangarFold.Checked;
			}
		}
		bool useHangarMap {  get { return lstMap.Items.Count >= 4; } }
		bool useFamilyHangarMap { get { return lstFamilyMap.Items.Count >= 4; } }
		#endregion

		#region S-Foils
		private void chkSFoils_CheckedChanged(object sender, EventArgs e)
		{
			lstSFoils.Enabled = chkSFoils.Checked;
			cboSFoilFG.Enabled = chkSFoils.Checked;
			cmdAddSFoils.Enabled = chkSFoils.Checked;
			cmdRemoveSFoils.Enabled = chkSFoils.Checked;
			chkCloseSF.Enabled = chkSFoils.Checked;
			chkOpenLG.Enabled = chkSFoils.Checked;
			chkForceHangarSF.Enabled = chkSFoils.Checked;
			chkForceHyperLG.Enabled = chkSFoils.Checked;
			chkManualSF.Enabled = chkSFoils.Checked;
		}

		private void cmdAddSFoils_Click(object sender, EventArgs e)
		{
			if (cboSFoilFG.SelectedIndex == -1) return;

			if (chkCloseSF.Checked) lstSFoils.Items.Add(cboSFoilFG.Text + ",closed");
			if (chkOpenLG.Checked) lstSFoils.Items.Add(cboSFoilFG.Text + ",open");
		}
		private void cmdRemoveSFoils_Click(object sender, EventArgs e)
		{
			if (lstSFoils.SelectedIndex == -1) return;
			lstSFoils.Items.RemoveAt(lstSFoils.SelectedIndex);
		}

		bool useSFoils
		{
			get
			{
				return (lstSFoils.Items.Count > 0 || chkForceHangarSF.Checked || chkForceHyperLG.Checked || chkManualSF.Checked);
			}
		}
		#endregion

		#region Skins
		private void chkDefaultSkin_CheckedChanged(object sender, EventArgs e)
		{
			txtSkin.Enabled = (!chkDefaultSkin.Checked && chkSkins.Checked);
		}
		private void chkSkins_CheckedChanged(object sender, EventArgs e)
		{
			lstSkins.Enabled = chkSkins.Checked;
			cmdAddSkin.Enabled = chkSkins.Checked;
			cmdAppendSkin.Enabled = chkSkins.Checked;
			cmdRemoveSkin.Enabled = chkSkins.Checked;
			chkSkinMarks.Enabled = chkSkins.Checked;
			chkDefaultSkin.Enabled = chkSkins.Checked;
			chkSkinMarks_CheckedChanged("chkSkins", new EventArgs());
			chkDefaultSkin_CheckedChanged("chkSkins", new EventArgs());
		}
		private void chkSkinMarks_CheckedChanged(object sender, EventArgs e)
		{
			cboSkinMarks.Enabled = (chkSkinMarks.Checked && chkSkins.Checked);
		}

		private void cmdAddSkin_Click(object sender, EventArgs e)
		{
			if (_installDirectory != "") opnObjects.InitialDirectory = _installDirectory + _fm;
			opnObjects.Title = "Select affected OPT...";
			DialogResult res = opnObjects.ShowDialog();
			if (res == DialogResult.OK)
			{
				string line = Path.GetFileNameWithoutExtension(opnObjects.FileName) + (chkSkinMarks.Checked ? "_fgc_" + cboSkinMarks.SelectedIndex : "") + " = "
					+ (chkDefaultSkin.Checked ? "Default" : txtSkin.Text);
				lstSkins.Items.Add(line);
			}
		}
		private void cmdAppendSkin_Click(object sender, EventArgs e)
		{
			if (lstSkins.SelectedIndex == -1) return;
			string line = lstSkins.SelectedItem.ToString();
			line += ", " + (chkDefaultSkin.Checked ? "Default" : txtSkin.Text);
			lstSkins.Items[lstSkins.SelectedIndex] = line;
		}
		private void cmdRemoveSkin_Click(object sender, EventArgs e)
		{
			if (lstSkins.SelectedIndex != -1) lstSkins.Items.RemoveAt(lstSkins.SelectedIndex);
		}
		#endregion Skins

		#region Shield
		void parseShield(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));

			string[] parts = line.ToLower().Replace(" ", "").Split(',');
			bool perGen = (parts[1] == "1");
			int rate = (perGen ? int.Parse(parts[2]) : int.Parse(parts[3]));
			lstShield.Items.Add(Strings.CraftType[int.Parse(parts[0])] + " = " + rate + (perGen ? " per" : ""));
		}
		private void chkShield_CheckedChanged(object sender, EventArgs e)
		{
			lstShield.Enabled = chkShield.Checked;
			cmdAddShield.Enabled = chkShield.Checked;
			cmdRemoveShield.Enabled = chkShield.Checked;
			chkShieldGen.Enabled = chkShield.Checked;
			cboShield.Enabled = chkShield.Checked;
			numShieldRate.Enabled = chkShield.Checked;
		}

		private void cmdAddShield_Click(object sender, EventArgs e)
		{
			if (cboShield.SelectedIndex < 1) return;
			string line = cboShield.Text + " = " + Math.Round(numShieldRate.Value) + (chkShieldGen.Checked ? " per" : "");
			lstShield.Items.Add(line);
		}
		private void cmdRemoveShield_Click(object sender, EventArgs e)
		{
			if (lstShield.SelectedIndex != -1) lstShield.Items.RemoveAt(lstShield.SelectedIndex);
		}
		#endregion

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (chkHangars.Checked && lstMap.Items.Count > 0 && lstMap.Items.Count < 4)
			{
				DialogResult res = MessageBox.Show("Hangar Map must have at least 4 entries to be used. Continue without it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.No) return;
			}
			if (chkHangars.Checked && lstFamilyMap.Items.Count > 0 && lstFamilyMap.Items.Count < 4)
			{
				DialogResult res = MessageBox.Show("Family Hangar Map must have at least 4 entries to be used. Continue without it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.No) return;
			}

			if (!chkBackdrops.Checked && _bdFile != "") File.Delete(_bdFile);

			if (!chkMission.Checked && !chkSFoils.Checked && _missionTxtFile != "") File.Delete(_missionTxtFile);

			if (!chkSounds.Checked && _soundFile != "") File.Delete(_soundFile);
			if (!chkObjects.Checked && _objFile != "") File.Delete(_objFile);

			if (!useHangarObjects && _hangarObjectsFile != "") File.Delete(_hangarObjectsFile);
			if (!useHangarCamera && _hangarCameraFile != "") File.Delete(_hangarCameraFile);
			if (!useFamilyHangarCamera && _famHangarCameraFile != "") File.Delete(_famHangarCameraFile);
			if (!useHangarMap && _hangarMapFile != "") File.Delete(_hangarMapFile);
			if (!useFamilyHangarMap && _famHangarMapFile != "") File.Delete(_famHangarMapFile);

			if (!chkSkins.Checked && _32bppFile != "") File.Delete(_32bppFile);
			if (!chkShield.Checked && _shieldFile != "") File.Delete(_shieldFile);

			if (!chkBackdrops.Checked && !chkMission.Checked && !chkSounds.Checked && !chkObjects.Checked && !useHangarObjects && !useHangarCamera && !useFamilyHangarCamera && !useHangarMap && !useFamilyHangarMap && !chkSFoils.Checked && !chkShield.Checked)
			{
				File.Delete(_fileName);
				Close();
				return;
			}

			string backup = _fileName.Replace(".ini", "_ini.bak");
			if (File.Exists(_fileName))
			{
				File.Copy(_fileName, backup);
				File.Delete(_fileName);
			}
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(_fileName);
				sw.WriteLine(";" + _mission + ".ini");
				sw.WriteLine("");

				if (chkBackdrops.Checked && lstBackdrops.Items.Count > 0)
				{
					sw.WriteLine("[Resdata]");
					for (int i = 0; i < lstBackdrops.Items.Count; i++) sw.WriteLine(lstBackdrops.Items[i]);
					sw.WriteLine("");
				}
				if ((chkMission.Checked && lstMission.Items.Count > 0) || (chkSFoils.Checked && useSFoils))
				{
					sw.WriteLine("[Mission_Tie]");
					if (chkMission.Checked)
					{
						for (int i = 0; i < lstMission.Items.Count; i++)
						{
							string[] parts = lstMission.Items[i].ToString().Split(',');
							int fg;
							for (fg = 0; fg < cboFG.Items.Count; fg++) if (cboFG.Items[fg].ToString() == parts[0]) break;
							if (parts[1] == "marks")
							{
								for (int m = 0; m < cboMarkings.Items.Count; m++)
									if (cboMarkings.Items[m].ToString() == parts[2])
									{
										sw.WriteLine("fg, " + fg + ", markings, " + m);
										break;
									}
							}
							else if (parts[1] == "wing")
							{
								for (int m = 0; m < cboMarkings.Items.Count; m++)
									if (cboMarkings.Items[m].ToString() == parts[3])
									{
										sw.WriteLine("fg, " + fg + ", index, " + parts[2] + ", markings, " + m);
										break;
									}
							}
							else if (parts[1] == "iff")
							{
								for (int iff = 0; iff < cboIff.Items.Count; iff++)
									if (cboIff.Items[iff].ToString() == parts[2])
									{
										sw.WriteLine("fg, " + fg + ", iff, " + iff);
										break;
									}
							}
							else if (parts[1] == "pilot")
								sw.WriteLine("fg, " + fg + ", pilotvoice, " + parts[2]);
						}
					}
					if (chkSFoils.Checked)
					{
						for (int i = 0; i < lstSFoils.Items.Count; i++)
						{
							string[] parts = lstSFoils.Items[i].ToString().Split(',');
							int fg;
							for (fg = 0; fg < cboSFoilFG.Items.Count; fg++) if (cboSFoilFG.Items[fg].ToString() == parts[0]) break;
							if (parts[1] == "closed")
								sw.WriteLine("fg, " + fg + ", close_SFoils, 1");
							else if (parts[1] == "open")
								sw.WriteLine("fg, " + fg + ", open_LandingGears, 1");
						}
						if (chkForceHangarSF.Checked)
							sw.WriteLine("CloseSFoilsAndOpenLandingGearsBeforeEnterHangar = 1");
						if (chkForceHyperLG.Checked)
							sw.WriteLine("CloseLandingGearsBeforeEnterHyperspace = 1");
						if (chkManualSF.Checked)
							sw.WriteLine("AutoCloseSFoils = 0");
					}
					sw.WriteLine("");
				}
				if (chkSounds.Checked && lstSounds.Items.Count > 0)
				{
					sw.WriteLine("[Sounds]");
					for (int i = 0; i < lstSounds.Items.Count; i++) sw.WriteLine(lstSounds.Items[i]);
					sw.WriteLine("");
				}
				if (chkObjects.Checked && lstObjects.Items.Count > 0)
				{
					sw.WriteLine("[Objects]");
					for (int i = 0; i < lstObjects.Items.Count; i++) sw.WriteLine(lstObjects.Items[i]);
					sw.WriteLine("");
				}
				if (chkHangars.Checked)
				{
					if (useHangarObjects)
					{
						sw.WriteLine("[HangarObjects]");
						if (!chkShuttle.Checked) sw.WriteLine("LoadShuttle = 0");
						if (cboShuttleModel.SelectedIndex != 50) sw.WriteLine("ShuttleModelIndex = " + cboShuttleModel.SelectedIndex);
						if (cboShuttleMarks.SelectedIndex != 0) sw.WriteLine("ShuttleMarkings = " + cboShuttleMarks.SelectedIndex);
						if (numShuttlePositionX.Value != _defaultShuttlePosition[0]) sw.WriteLine("ShuttlePositionX = " + (int)numShuttlePositionX.Value);
						if (numShuttlePositionY.Value != _defaultShuttlePosition[1]) sw.WriteLine("ShuttlePositionY = " + (int)numShuttlePositionY.Value);
						if (numShuttlePositionZ.Value != _defaultShuttlePosition[2]) sw.WriteLine("ShuttlePositionZ = " + (int)numShuttlePositionZ.Value);
						if (numShuttleOrientation.Value != _defaultShuttlePosition[3]) sw.WriteLine("ShuttleOrientation = " + (int)numShuttleOrientation.Value);
						if (chkShuttleFloor.Checked) sw.WriteLine("IsShuttleFloorInverted = 1");
						if (cboShuAnimation.SelectedIndex != 0) sw.WriteLine("ShuttleAnimation = " + cboShuAnimation.Text);
						if (numShuDistance.Value != 0) sw.WriteLine("ShuttleAnimationStraightLine = " + (int)numShuDistance.Value);

						if (!chkDroids.Checked) sw.WriteLine("LoadDroids = 0");
						if (numDroidsZ.Value != 0) sw.WriteLine("DroidsPositionZ = " + (int)numDroidsZ.Value);
						if (chkDroid1.Checked && numDroid1Z.Value != numDroidsZ.Value) sw.WriteLine("Droid1PositionZ = " + (int)numDroid1Z.Value);
						if (chkDroid2.Checked && numDroid2Z.Value != numDroidsZ.Value) sw.WriteLine("Droid2PositionZ = " + (int)numDroid2Z.Value);
						if (chkDroidsFloor.Checked) sw.WriteLine("IsDroidsFloorInverted = 1");
						if (!chkDroid1Update.Checked) sw.WriteLine("Droid1Update = 0");
						if (!chkDroid2Update.Checked) sw.WriteLine("Droid2Update = 0");

						if (numRoofCranePositionX.Value != _defaultRoofCranePosition[0]) sw.WriteLine("HangarRoofCranePositionX = " + (int)numRoofCranePositionX.Value);
						if (numRoofCranePositionY.Value != _defaultRoofCranePosition[1]) sw.WriteLine("HangarRoofCranePositionY = " + (int)numRoofCranePositionY.Value);
						if (numRoofCranePositionZ.Value != _defaultRoofCranePosition[2]) sw.WriteLine("HangarRoofCranePositionZ = " + (int)numRoofCranePositionZ.Value);
						if (optRoofCraneAxisY.Checked) sw.WriteLine("HangarRoofCraneAxis = 1");
						else if (optRoofCraneAxisZ.Checked) sw.WriteLine("HangarRoofCraneAxis = 2");
						if (numRoofCraneLowOffset.Value != 0) sw.WriteLine("HangarRoofCraneLowOffset = " + (int)numRoofCraneLowOffset.Value);
						if (numRoofCraneHighOffset.Value != 0) sw.WriteLine("HangarRoofCraneHighOffset = " + (int)numRoofCraneHighOffset.Value);
						if (chkFloor.Checked) sw.WriteLine("IsHangarFloorInverted = 1");
						if (chkHangarIff.Checked) sw.WriteLine("HangarIff = " + cboHangarIff.SelectedIndex);

						if (numPlayerAnimationElevation.Value != 0) sw.WriteLine("PlayerAnimationElevation = " + (int)numPlayerAnimationElevation.Value);
						if (numPlayerX.Value != 0) sw.WriteLine("PlayerOffsetX = " + (int)numPlayerX.Value);
						if (numPlayerY.Value != 0) sw.WriteLine("PlayerOffsetY = " + (int)numPlayerY.Value);
						if (numPlayerZ.Value != 0) sw.WriteLine("PlayerOffsetZ = " + (int)numPlayerZ.Value);
						if (chkPlayerFloor.Checked) sw.WriteLine("IsPlayerFloorInverted = 1");
						if (chkHangarFold.Checked) sw.WriteLine("FoldOutside = 1");

						for (int i = 0; i < lstHangarObjects.Items.Count; i++) sw.WriteLine(lstHangarObjects.Items[i]);
						sw.WriteLine("");
					}
					if (useHangarCamera)
					{
						sw.WriteLine("[HangarCamera]");
						string[] keys = { "1", "2", "3", "6", "9" };
						for (int i = 0; i < 5; i++)
						{
							bool use = false;
							for (int j = 0; j < 3; j++) use |= (_cameras[i, j] != _defaultCameras[i, j]);
							if (use)
							{
								sw.WriteLine("Key" + keys[i] + "_X = " + _cameras[i, 0]);
								sw.WriteLine("Key" + keys[i] + "_Y = " + _cameras[i, 1]);
								sw.WriteLine("Key" + keys[i] + "_Z = " + _cameras[i, 2]);
								sw.WriteLine("");
							}
						}
					}
					if (useFamilyHangarCamera)
					{
						sw.WriteLine("[FamHangarCamera]");
						string[] keys = { "1", "2", "3", "6", "7", "8", "9" };
						for (int i = 0; i < 7; i++)
						{
							bool use = false;
							for (int j = 0; j < 3; j++) use |= (_familyCameras[i, j] != _defaultFamilyCameras[i, j]);
							if (use)
							{
								sw.WriteLine("Key" + keys[i] + "_X = " + _familyCameras[i, 0]);
								sw.WriteLine("Key" + keys[i] + "_Y = " + _familyCameras[i, 1]);
								sw.WriteLine("Key" + keys[i] + "_Z = " + _familyCameras[i, 2]);
								sw.WriteLine("");
							}
						}
					}
					if (useHangarMap)
					{
						sw.WriteLine("[HangarMap]");
						for (int i = 0; i < lstMap.Items.Count; i++) sw.WriteLine(lstMap.Items[i].ToString());
						sw.WriteLine("");
					}
					if (useFamilyHangarMap)
					{
						sw.WriteLine("[FamHangarMap]");
						for (int i = 0; i < lstFamilyMap.Items.Count; i++) sw.WriteLine(lstFamilyMap.Items[i].ToString());
						sw.WriteLine("");
					}
				}
				if (chkSkins.Checked && lstSkins.Items.Count > 0)
				{
					sw.WriteLine("[Skins]");
					for (int i = 0; i < lstSkins.Items.Count; i++) sw.WriteLine(lstSkins.Items[i]);
					sw.WriteLine("");
				}
				if (chkShield.Checked && lstShield.Items.Count > 0)
				{
					sw.WriteLine("[Shield]");
					for (int i = 0; i < lstShield.Items.Count; i++)
					{
						string[] parts = lstShield.Items[i].ToString().Split('=');
						parts[0] = parts[0].Trim();
						int craft;
						for (craft = 0; craft < Strings.CraftType.Length; craft++)
							if (parts[0] == Strings.CraftType[craft]) break;
						parts = parts[1].Trim().Split(' ');
						bool perGen = (parts.Length > 1);
						int rate = int.Parse(parts[0]);
						sw.WriteLine(craft + ", " + (perGen ? "1, " + rate + ", 0" : "0, 0, " + rate));
					}
					sw.WriteLine("");
				}
				sw.Flush();
				sw.Close();
				if (_bdFile != "") File.Delete(_bdFile);
				if (_missionTxtFile != "") File.Delete(_missionTxtFile);
				if (_soundFile != "") File.Delete(_soundFile);
				if (_objFile != "") File.Delete(_objFile);
				if (_hangarObjectsFile != "") File.Delete(_hangarObjectsFile);
				if (_hangarCameraFile != "") File.Delete(_hangarCameraFile);
				if (_famHangarCameraFile != "") File.Delete(_famHangarCameraFile);
				if (_hangarMapFile != "") File.Delete(_hangarMapFile);
				if (_famHangarMapFile != "") File.Delete(_famHangarMapFile);
				if (_32bppFile != "") File.Delete(_32bppFile);
				if (_shieldFile != "") File.Delete(_shieldFile);
			}
			catch
			{
				if (sw != null) sw.Close();
				if (File.Exists(backup))
				{
					File.Delete(_fileName);
					File.Copy(backup, _fileName);
				}
			}
			File.Delete(backup);
			Close();
		}

		string removeComment(string line)
		{
			if (line.IndexOf(";") != -1)
				line = line.Substring(0, line.IndexOf(";"));
			if (line.IndexOf("#") != -1)
				line = line.Substring(0, line.IndexOf("#"));
			if (line.IndexOf("////") != -1)
				line = line.Substring(0, line.IndexOf("////"));
			return line.Trim();
		}

		struct MapEntry
		{
			// doing it this way so the output processing is in only one spot
			public int ModelIndex;
			public byte Markings;
			public int PositionX;
			public int PositionY;
			public int PositionZ;
			public int HeadingXY;
			public int HeadingZ;
			public bool IsGrounded;

			public override string ToString()
			{
				return ModelIndex + ", " + (Markings != 0 ? Markings.ToString() + ", " : "") + PositionX + ", " + PositionY + ", " + (IsGrounded ? "0x7FFFFFFF" : PositionZ.ToString()) + ", " + HeadingXY + ", " + HeadingZ;
			}

			public bool Parse(string line)
			{
				if (line.IndexOf(";") != -1)
					line = line.Substring(0, line.IndexOf(";"));

				int offset = 0;
				string[] parts = line.Replace(" ", "").Split(',');
				if (parts.Length == 7) offset = 1;
				else if (parts.Length != 6) return false;

				ModelIndex = parseInt32(parts[0]);
				if (offset != 0) Markings = Convert.ToByte(parseInt32(parts[1]) & 0xFF);
				else Markings = 0;
				PositionX = parseInt32(parts[1 + offset]);
				PositionY = parseInt32(parts[2 + offset]);
				IsGrounded = (parts[3 + offset].ToLower() == "0x7fffffff");
				if (!IsGrounded) PositionZ = parseInt32(parts[3 + offset]);
				HeadingXY = parseInt32(parts[4 + offset]);
				HeadingZ = parseInt32(parts[5 + offset]);

				return true;
			}

			private int parseInt32(string token)
			{
				// Using this because Convert.ToInt32 was throwing an exception on signed integers.
				token = token.Trim();
				int result;
				if (token.StartsWith("0x") && int.TryParse(token.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out result))
					return result;
				if (int.TryParse(token, System.Globalization.NumberStyles.Integer, null, out result))
					return result;
				int.TryParse(token, System.Globalization.NumberStyles.HexNumber, null, out result);
				return result;
			}
		}
	}
}
