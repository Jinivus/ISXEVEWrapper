using System;
using System.Collections.Generic;
using LavishScriptAPI;
using Extensions;

namespace EVE.ISXEVE
{
	/// <summary>
	/// Wrapper for the entity data type.
	/// </summary>
	public class Entity : LavishScriptObject
	{
		#region Constructors
		/// <summary>
		/// Copy constructor for the Entity object.
		/// </summary>
		/// <param name="Obj"></param>
		public Entity(LavishScriptObject Obj)
			: base(Obj)
		{
		}

		/// <summary>
		/// Search for an Entity using LS Query syntax.
		/// </summary>
		/// <param queryString="queryString"></param>
		public Entity(string queryString)
			: base(LavishScript.Objects.GetObject("Entity", queryString))
		{
		}
		#endregion

		#region Members
		/// <summary>
		/// Wrapper for the Alliance member of the entity type.
		/// </summary>
		public string Alliance
		{
			get { return this.GetStringFromLSO("Alliance"); }
		}

		/// <summary>
		/// Wrapper for the AllianceID member of the entity type.
		/// </summary>
		public int AllianceID
		{
			get { return this.GetIntFromLSO("AllianceID"); }
		}

		/// <summary>
		/// Wrapper for the AllianceTicker member of the entity type.
		/// </summary>
		public string AllianceTicker
		{
			get { return this.GetStringFromLSO("AllianceTicker"); }
		}

		/// <summary>
		/// Wrapper for the Category member of the entity type.
		/// </summary>
		public string Category
		{
			get { return this.GetStringFromLSO("Category"); }
		}

		/// <summary>
		/// Wrapper for the CategoryID member of the entity type.
		/// </summary>
		public int CategoryID
		{
			get { return this.GetIntFromLSO("CategoryID"); }
		}

		/// <summary>
		/// Wrapper for the CategoryType member of the entity type.
		/// </summary>
		public CategoryType CategoryType
		{
			get
			{
				return (CategoryType)CategoryID;
			}
		}

		/// <summary>
		/// Wrapper for the CharID member of the entity type.
		/// </summary>
		public Int64 CharID
		{
			get { return this.GetInt64FromLSO("CharID"); }
		}

	    /// <summary>
	    /// Wrapper for the Corporation member of the entity type.
	    /// </summary>
	    public Corporation Corp
	    {
	        get
	        {
	            return new Corporation(GetMember("Corporation"));
	        }
	    }

		/// <summary>
		/// Wrapper for the FormationID member of the entity type.
		/// </summary>
		public int FormationID
		{
			get { return this.GetIntFromLSO("FormationID"); }
		}

		/// <summary>
		/// Wrapper for the Group member of the entity type.
		/// </summary>
		public string Group
		{
			get { return this.GetStringFromLSO("Group"); }
		}

		/// <summary>
		/// Wrapper for the GroupID member of the entity type.
		/// </summary>
		public int GroupID
		{
			get { return this.GetIntFromLSO("GroupID"); }
		}

		/// <summary>
		/// Wrapper for the ID member of the entity type.
		/// </summary>
		public Int64 ID
		{
			get
			{
				Tracing.SendCallback("Entity.ID");
				return this.GetInt64FromLSO("ID");
			}
		}

	    public bool IsAbandoned
	    {
	        get { return this.GetBoolFromLSO("IsAbandoned"); }
	    }

		/// <summary>
		/// Wrapper for the MaxVelocity member of the entity type.
		/// </summary>
		public double MaxVelocity
		{
			get { return this.GetDoubleFromLSO("MaxVelocity"); }
		}

		/// <summary>
		/// Wrapper for the Name member of the entity type.
		/// </summary>
		public string Name
		{
			get { return this.GetStringFromLSO("Name"); }
		}

		/// <summary>
		/// Only valid if the owner is on the locals list.  Use OwnerID otherwise.
		/// </summary>
		public Pilot Owner
		{
			get
			{
				var owner = GetMember("Owner");

				if (!IsNullOrInvalid(owner) && owner.LSType == "pilot")
					return new Pilot(owner);

				// invalid return
				return new Pilot((LavishScriptObject)null);
			}
		}

		/// <summary>
		/// Wrapper for the OwnerID member of the entity type.
		/// </summary>
		public Int64 OwnerID
		{
			get { return this.GetInt64FromLSO("OwnerID"); }
		}

		/// <summary>
		/// Wrapper for the Security member of the entity type.
		/// </summary>
		public double Security
		{
			get { return this.GetDoubleFromLSO("Security"); }
		}

		/// <summary>
		/// Wrapper for the Type member of the entity type.
		/// </summary>
		public string Type
		{
			get { return this.GetStringFromLSO("Type"); }
		}

		/// <summary>
		/// Wrapper for the TypeID member of the entity type.
		/// </summary>
		public int TypeID
		{
			get { return this.GetIntFromLSO("TypeID"); }
		}

		/// <summary>
		/// Wrapper for the WreckID member of the entity type.
		/// </summary>
		public int WreckID
		{
			get
			{
				return GetMember<int>("WreckID");
			}
		}

		/// <summary>
		/// Wrapper for the ToActiveDrone member of the entity type.
		/// </summary>
		public ActiveDrone ToActiveDrone
		{
			get
			{
				return new ActiveDrone(GetMember("ToActiveDrone"));
			}
		}

		/// <summary>
		/// Wrapper for the GetActiveDrones member of the entity type.
		/// </summary>
		/// <returns></returns>
		public List<ActiveDrone> GetActiveDrones()
		{
			Tracing.SendCallback("Entity.GetActiveDrones");
			return Util.GetListFromMethod<ActiveDrone>(this, "GetActiveDrones", "activedrone");
		}

		/// <summary>
		/// Wrapper for the IsWreckEmpty member of the entity type.
		/// </summary>
		public bool IsWreckEmpty
		{
			get
			{
				using (var isWreckEmpty = GetMember("IsWreckEmpty"))
				{
					//return true because a "negative" is empty, aka true
					return IsNullOrInvalid(isWreckEmpty) || isWreckEmpty.GetValue<bool>();
				}
			}
		}

		/// <summary>
		/// Wrapper for the IsOwnedByCorpMember member of the entity type.
		/// </summary>
		public bool IsOwnedByCorpMember
		{
			get { return this.GetBoolFromLSO("IsOwnedByCorpMember"); }
		}

		/// <summary>
		/// Wrapper for the IsOwnedByAllianceMember member of the entity type.
		/// </summary>
		public bool IsOwnedByAllianceMember
		{
			get { return this.GetBoolFromLSO("IsOwnedByAllianceMember"); }
		}

		#region Location
		/// <summary>
		/// Wrapper for the X member of the entity type.
		/// </summary>
		public double X
		{
			get { return this.GetDoubleFromLSO("X"); }
		}

		/// <summary>
		/// Wrapper for the Y member of the entity type.
		/// </summary>
		public double Y
		{
			get { return this.GetDoubleFromLSO("Y"); }
		}

		/// <summary>
		/// Wrapper for the Z member of the entity type.
		/// </summary>
		public double Z
		{
			get { return this.GetDoubleFromLSO("Z"); }
		}

		/// <summary>
		/// Wrapper for the vX member of the entity type.
		/// </summary>
		public double vX
		{
			get { return this.GetDoubleFromLSO("vX"); }
		}

		/// <summary>
		/// Wrapper for the vY member of the entity type.
		/// </summary>
		public double vY
		{
			get { return this.GetDoubleFromLSO("vY"); }
		}

		/// <summary>
		/// Wrapper for the vZ member of the entity type.
		/// </summary>
		public double vZ
		{
			get { return this.GetDoubleFromLSO("vZ"); }
		}

		/// <summary>
		/// Wrapper for the Pitch member of the entity type.
		/// </summary>
		public double Pitch
		{
			get { return this.GetDoubleFromLSO("Pitch"); }
		}

		/// <summary>
		/// Wrapper for the Roll member of the entity type.
		/// </summary>
		public double Roll
		{
			get { return this.GetDoubleFromLSO("Roll"); }
		}

		/// <summary>
		/// Wrapper for the Yaw member of the entity type.
		/// </summary>
		public double Yaw
		{
			get { return this.GetDoubleFromLSO("Yaw"); }
		}

		/// <summary>
		/// Wrapper for the Velocity member of the entity type.
		/// </summary>
		public double Velocity
		{
			get { return this.GetDoubleFromLSO("Velocity"); }
		}

		/// <summary>
		/// Wrapper for the Distance member of the entity type.
		/// </summary>
		public double Distance
		{
			get { return this.GetDoubleFromLSO("Distance"); }
		}

		/// <summary>
		/// Wrapper for the DistanceTo member of the entity type.
		/// </summary>
		/// <param name="entityId"></param>
		/// <returns></returns>
		public double DistanceTo(int entityId)
		{
			return this.GetDoubleFromLSO("DistanceTo", entityId.ToString());
		}

		/// <summary>
		/// Wrapper for the FollowRange member of the entity type.
		/// </summary>
		public double FollowRange
		{
			get { return this.GetDoubleFromLSO("FollowRange"); }
		}
		#endregion

		#region Physical
		/// <summary>
		/// Wrapper for the Mass member of the entity type.
		/// </summary>
		public double Mass
		{
			get { return this.GetDoubleFromLSO("Mass"); }
		}

		/// <summary>
		/// Wrapper for the Radius member of the entity type.
		/// </summary>
		public double Radius
		{
			get { return this.GetDoubleFromLSO("Radius"); }
		}

		/// <summary>
		/// Wrapper for the ShieldPct member of the entity type.
		/// </summary>
		public double ShieldPct
		{
			get { return this.GetDoubleFromLSO("ShieldPct"); }
		}

		/// <summary>
		/// Wrapper for the ArmorPct member of the entity type.
		/// </summary>
		public double ArmorPct
		{
			get { return this.GetDoubleFromLSO("ArmorPct"); }
		}

		/// <summary>
		/// Wrapper for the StructurePct member of the entity type.
		/// </summary>
		public double StructurePct
		{
			get { return this.GetDoubleFromLSO("StructurePct"); }
		}
		#endregion

		#region Logical
		/// <summary>
		/// Wrapper for the IsCloaked member of the entity type.
		/// </summary>
		public bool IsCloaked
		{
			get { return this.GetBoolFromLSO("IsCloaked"); }
		}

		/// <summary>
		/// Wrapper for the IsInteractive member of the entity type.
		/// </summary>
		public bool IsInteractive
		{
			get { return this.GetBoolFromLSO("IsInteractive"); }
		}

		/// <summary>
		/// Wrapper for the IsMassive member of the entity type.
		/// </summary>
		public bool IsMassive
		{
			get { return this.GetBoolFromLSO("IsMassive"); }
		}

		/// <summary>
		/// Wrapper for the IsGlobal member of the entity type.
		/// </summary>
		public bool IsGlobal
		{
			get { return this.GetBoolFromLSO("IsGlobal"); }
		}

		/// <summary>
		/// Wrapper for the IsMoribund member of the entity type.
		/// </summary>
		public bool IsMoribund
		{
			get { return this.GetBoolFromLSO("IsMoribund"); }
		}

		/// <summary>
		/// Wrapper for the IsWarpScrambled member of the entity type.
		/// </summary>
		public bool IsWarpScrambled
		{
			get { return this.GetBoolFromLSO("IsWarpScrambled"); }
		}

		/// <summary>
		/// Wrapper for the IsActiveTarget member of the entity type.
		/// </summary>
		public bool IsActiveTarget
		{
			get { return this.GetBoolFromLSO("IsActiveTarget"); }
		}

		/// <summary>
		/// Wrapper for the IsLockedTarget member of the entity type.
		/// </summary>
		public bool IsLockedTarget
		{
			get { return this.GetBoolFromLSO("IsLockedTarget"); }
		}

		/// <summary>
		/// Wrapper for the IsNPC member of the entity type.
		/// </summary>
		public bool IsNPC
		{
			get { return this.GetBoolFromLSO("IsNPC"); }
		}

		/// <summary>
		/// Wrapper for the IsPC member of the entity type.
		/// </summary>
		public bool IsPC
		{
			get { return this.GetBoolFromLSO("IsPC"); }
		}

		/// <summary>
		/// Wrapper for the HaveLootRights member of the entity type.
		/// </summary>
		public bool HaveLootRights
		{
			get { return this.GetBoolFromLSO("HaveLootRights"); }
		}

		/// <summary>
		/// Known Modes
		/// 2 - Stopped 
		/// 3 - Warping (in warp) 
		/// </summary>
		public int Mode
		{
			get { return this.GetIntFromLSO("Mode"); }
		}

		/// <summary>
		/// Wrapper for the IsTargetingMe member of the entity type.
		/// </summary>
		public bool IsTargetingMe
		{
			get { return this.GetBoolFromLSO("IsTargetingMe"); }
		}

		/// <summary>
		/// Wrapper for the IsWarpScramblingMe member of the entity type.
		/// </summary>
		public bool IsWarpScramblingMe
		{
			get { return this.GetBoolFromLSO("IsWarpScramblingMe"); }
		}

		/// <summary>
		/// Wrapper for the IsTargetJammingMe member of the entity type.
		/// </summary>
		public bool IsTargetJammingMe
		{
			get { return this.GetBoolFromLSO("IsTargetJammingMe"); }
		}

		/// <summary>
		/// Wrapper for the BeingTargeted member of the entity type.
		/// </summary>
		public bool BeingTargeted
		{
			get { return this.GetBoolFromLSO("BeingTargeted"); }
		}

		/// <summary>
		/// Wrapper for the Approaching member of the entity type.
		/// </summary>
		public Entity Approaching
		{
			get
			{
				return new Entity(GetMember("Approaching"));
			}
		}

		/// <summary>
		/// Wrapper for the Following member of the entity type.
		/// </summary>
		public Entity Following
		{
			get
			{
				return new Entity(GetMember("Following"));
			}
		}
		#endregion

		#region Cargo
		/// <summary>
		/// Wrapper for the CargoCapacity member of the entity type.
		/// </summary>
		public double CargoCapacity
		{
			get { return this.GetDoubleFromLSO("CargoCapacity"); }
		}

		/// <summary>
		/// Wrapper for the UsedCargoCapacity member of the entity type.
		/// </summary>
		public double UsedCargoCapacity
		{
			get { return this.GetDoubleFromLSO("UsedCargoCapacity"); }
		}

		/// <summary>
		/// List of all cargo items.  Keep in mind this might
		/// be empty or invalid if the cargo hold isn't open
		/// </summary>
		/// <returns></returns>
		public List<Item> GetCargo()
		{
			Tracing.SendCallback("Entity.GetCargo");
			return Util.GetListFromMethod<Item>(this, "GetCargo", "item");
		}

		/// <summary>
		/// If you have used "OpenCargo" on this entity and a 'loot window' 
		/// has appeared, then this member will return an evewindow datatype 
		/// object representing that lootwindow. Otherwise, it will return NULL.
		/// </summary>
		public EVEWindow LootWindow
		{
			get
			{
				return new EVEWindow(GetMember("LootWindow"));
			}
		}

		/// <summary>
		/// Alias for 'LootWindow'
		/// </summary>
		public EVEWindow CargoWindow
		{
			get
			{
				return new EVEWindow(GetMember("CargoWindow"));
			}
		}

        public EVEWindow StorageWindow
        {
            get
            {
                return new EVEWindow(GetMember("StorageWindow"));
            }
        }
		#endregion

		/// <summary>
		/// Wrapper for the ToAttacker member of the Entity datatype.
		/// </summary>
		public Attacker ToAttacker
		{
			get
			{
				return new Attacker(GetMember("ToAttacker"));
			}
		}

        /// <summary>
        /// Get the Jammer member of the Entity object
        /// </summary>
        public Jammer ToJammer
        {
            get
            {
                return new Jammer(GetMember("ToJammer"));
            }
        }
		#endregion

		#region Methods
		/// <summary>
		/// Activate the entity.
		/// </summary>
		/// <returns></returns>
		public bool Activate()
		{
			Tracing.SendCallback("Entity.Activate");
			return ExecuteMethod("Activate");
		}
		/// <summary>
		/// Warp to zero distance
		/// </summary>
		public bool WarpTo()
		{
			Tracing.SendCallback("Entity.WarpTo");
			return ExecuteMethod("WarpTo");
		}

		/// <summary>
		/// Warp to the given distance, in meters.
		/// </summary>
		public bool WarpTo(int Distance)
		{
			Tracing.SendCallback("Entity.WarpTo", Distance.ToString());
			return ExecuteMethod("WarpTo", Distance.ToString());
		}

		/// <summary>
		/// Warp fleet to zero distance
		/// </summary>
		public bool WarpFleetTo()
		{
			Tracing.SendCallback("Entity.WarpFleetTo");
			return ExecuteMethod("WarpFleetTo");
		}

		/// <summary>
		/// Warp fleet to the given distance, in meters.
		/// </summary>
		public bool WarpFleetTo(int Distance)
		{
			Tracing.SendCallback("Entity.WarpFleetTo", string.Empty);
			return ExecuteMethod("WarpFleetTo", Distance.ToString());
		}

		/// <summary>
		/// Align to the entity.
		/// </summary>
		public bool AlignTo()
		{
			Tracing.SendCallback("Entity.AlignTo");
			return ExecuteMethod("AlignTo");
		}

		/// <summary>
		/// Start target lock on the entity
		/// </summary>
		/// <returns></returns>
		public bool LockTarget()
		{
			Tracing.SendCallback("Entity.LockTarget");
			return ExecuteMethod("LockTarget");
		}

		/// <summary>
		/// Unlock the entity
		/// </summary>
		/// <returns></returns>
		public bool UnlockTarget()
		{
			Tracing.SendCallback("Entity.UnlockTarget");
			return ExecuteMethod("UnlockTarget");
		}

		/// <summary>
		/// Approach to 50 meters from target
		/// </summary>
		public bool Approach()
		{
			Tracing.SendCallback("Entity.Approach");
			return ExecuteMethod("Approach");
		}

		/// <summary>
		/// Approach to within the given number of meters
		/// </summary>
		public bool Approach(int Distance)
		{
			Tracing.SendCallback("Entity.Approach", Distance.ToString());
			return ExecuteMethod("Approach", Distance.ToString());
		}

		/// <summary>
		/// Keep at a range of 1000 meters.
		/// </summary>
		public bool KeepAtRange()
		{
			Tracing.SendCallback("Entity.KeepAtRange");
			return ExecuteMethod("KeepAtRange");
		}

		/// <summary>
		/// Keep at a range of Distance meters.
		/// </summary>
		public bool KeepAtRange(int Distance)
		{
			Tracing.SendCallback("Entity.KeepAtRange", Distance.ToString());
			return ExecuteMethod("KeepAtRange", Distance.ToString());
		}

		/// <summary>
		/// Orbit at 5000 meters
		/// </summary>
		/// <returns></returns>
		public bool Orbit()
		{
			Tracing.SendCallback("Entity.Orbit");
			return ExecuteMethod("Orbit");
		}

		/// <summary>
		/// Orbit at Distance meters
		/// </summary>
		public bool Orbit(int Distance)
		{
			Tracing.SendCallback("Entity.Orbit", Distance.ToString());
			return ExecuteMethod("Orbit", Distance.ToString());
		}

		/// <summary>
		/// Dock at a station.  Note: You must be within docking range of the station.
		/// </summary>
		public bool Dock()
		{
			Tracing.SendCallback("Entity.Dock");
			return ExecuteMethod("Dock");
		}

		/// <summary>
		/// Selects a locked target as your current Active target
		/// </summary>
		public bool MakeActiveTarget()
		{
			Tracing.SendCallback("Entity.MakeActiveTarget");
			return ExecuteMethod("MakeActiveTarget");
		}

		/// <summary>
		/// Open cargo hold of entity.
		/// </summary>
		/// <returns></returns>
		public bool OpenCargo()
		{
			Tracing.SendCallback("Entity.OpenCargo");
			return ExecuteMethod("OpenCargo");
		}

        public bool OpenStorage()
        {
            Tracing.SendCallback("Entity.OpenStorage");
            return ExecuteMethod("OpenStorage");
        }

        public bool CloseStorage()
        {
            Tracing.SendCallback("Entity.CloseStorage");
            return ExecuteMethod("CloseStorage");
        }

		/// <summary>
		/// Close cargo hold of entity.
		/// </summary>
		/// <returns></returns>
		public bool CloseCargo()
		{
			Tracing.SendCallback("Entity.CloseCargo");
			return ExecuteMethod("CloseCargo");
		}

		/// <summary>
		/// Same as right click, Stack All -- consolidates stacks
		/// </summary>
		public bool StackAllCargo()
		{
			Tracing.SendCallback("Entity.StackAllCargo");
			return ExecuteMethod("StackAllCargo");
		}

		/// <summary>
		/// Sets the entity (container, probably) name.  Your code shouldn't name unnamable entities.
		/// </summary>
		public bool SetName(string Name)
		{
			Tracing.SendCallback("Entity.SetName", Name);
			return ExecuteMethod("SetName", Name);
		}


		/// <summary>
		/// Creates a bookmark.
		/// </summary>
		public bool CreateBookmark()
		{
			return CreateBookmark(null, null);
		}

		/// <summary>
		/// Creates a bookmark.
		/// </summary>
		public bool CreateBookmark(string Label)
		{
			return CreateBookmark(Label, null);
		}

		/// <summary>
		/// Creates a bookmark.
		/// </summary>
		public bool CreateBookmark(string Label, string Notes)
		{
			if (!string.IsNullOrEmpty(Label) &&
				!string.IsNullOrEmpty(Notes))
			{
				Tracing.SendCallback("Entity.CreateBookmark", Label, Notes);
				return ExecuteMethod("CreateBookmark", Label, Notes);
			}
			else if (!string.IsNullOrEmpty(Label))
			{
				Tracing.SendCallback("Entity.CreateBookmark", Label);
				return ExecuteMethod("CreateBookmark", Label);
			}
			else
			{
				Tracing.SendCallback("Entity.CreateBookmark");
				return ExecuteMethod("CreateBookmark");
			}
		}

		/// <summary>
		/// For stations, similar to choosing 'Dock' from the station right click menu while in space.
		/// </summary>
		public bool WarpToAndDock()
		{
		Tracing.SendCallback("Entity.WarpToAndDock");
			return ExecuteMethod("WarpToAndDock");
		}

		/// <summary>
		/// 'Stargate' entities only. You must also be in range to jump.
		/// </summary>
		public bool Jump()
		{
			Tracing.SendCallback("Entity.Jump");
			return ExecuteMethod("Jump");
		}

        /// <summary>
        /// This is the preferred method if your script is abandoning one thing at a time.
        /// </summary>
        public bool Abandon()
        {
            Tracing.SendCallback("Entity.Abandon", string.Empty);
            return ExecuteMethod("Abandon");
        }

        /// <summary>
        /// Abandons all of nearby entities of the same group type
        /// </summary>
        public bool AbandonAll()
        {
            Tracing.SendCallback("Entity.AbandonAll", string.Empty);
            return ExecuteMethod("AbandonAll");
        }

		#region Mines
		/// <summary>
		/// Mines only
		/// </summary>
		public bool Mine()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.Mine", string.Empty);
			return ExecuteMethod("Mine");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool MineRepeatedly()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.MineRepeatedly", string.Empty);
			return ExecuteMethod("MineRepeatedly");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool ReturnAndOrbit()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.ReturnAndOrbit", string.Empty);
			return ExecuteMethod("ReturnAndOrbit");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool ReturnToDroneBay()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.ReturnToDroneBay", string.Empty);
			return ExecuteMethod("ReturnToDroneBay");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool ScoopToDroneBay()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.ScoopToDroneBay", string.Empty);
			return ExecuteMethod("ScoopToDroneBay");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool ScoopToCargoBay()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.ScoopToCargoBay", string.Empty);
			return ExecuteMethod("ScoopToCargoBay");
		}

		/// <summary>
		/// Mines only
		/// </summary>
		public bool EngageMyTarget()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Entity.EngageMyTarget", string.Empty);
			return ExecuteMethod("EngageMyTarget");
		}
		#endregion
		#endregion
	}

	/// <summary>
	/// Entity category types
	/// </summary>
	public enum CategoryType
	{
		/// <summary>
		/// System type.
		/// </summary>
		System = 0,

		/// <summary>
		/// Owner type.
		/// </summary>
		Owner = 1,

		/// <summary>
		/// Celestial type.
		/// </summary>
		Celestial = 2,

		/// <summary>
		/// Station type.
		/// </summary>
		Station = 3,

		/// <summary>
		/// Material type.
		/// </summary>
		Material = 4,

		/// <summary>
		/// Accessoriestype.
		/// </summary>
		Accessories = 5,

		/// <summary>
		/// Ship type.
		/// </summary>
		Ship = 6,

		/// <summary>
		/// Module type.
		/// </summary>
		Module = 7,

		/// <summary>
		/// Charge type.
		/// </summary>
		Charge = 8,

		/// <summary>
		/// Blueprint type.
		/// </summary>
		Blueprint = 9,

		/// <summary>
		/// Trading type.
		/// </summary>
		Trading = 10,

		/// <summary>
		/// Entity type.
		/// </summary>
		Entity = 11,

		/// <summary>
		/// Bonus type.
		/// </summary>
		Bonus = 14,

		/// <summary>
		/// AsteroidBelt type.
		/// </summary>
		AsteroidBelt = 15,

		/// <summary>
		/// Skill type.
		/// </summary>
		Skill = 16,

		/// <summary>
		/// Commodity type.
		/// </summary>
		Commodity = 17,

		/// <summary>
		/// Drone type.
		/// </summary>
		Drone = 18,

		/// <summary>
		/// Implant type.
		/// </summary>
		Implant = 20,

		/// <summary>
		/// Deployable type.
		/// </summary>
		Deployable = 22,

		/// <summary>
		/// Structure type.
		/// </summary>
		Structure = 23,

		/// <summary>
		/// Reaction type.
		/// </summary>
		Reaction = 24,

		/// <summary>
		/// Asteroid type.
		/// </summary>
		Asteroid = 25,
	}
}
