using System;
using Extensions;
using LavishScriptAPI;

namespace EVE.ISXEVE
{
	/// <summary>
	/// This is the Local TLO -- it is named LocalPilots to avoid reserved word conflict.
	/// </summary>
	public class Pilot : LavishScriptObject
	{
		#region Constructors
		/// <summary>
		/// LocalPilots copy constructor.
		/// </summary>
		/// <param name="Obj"></param>
		public Pilot(LavishScriptObject Obj)
			: base(Obj)
		{
		}

		/// <summary>
		/// Get a Local pilot by ID.
		/// </summary>
		public Pilot(Int64 CharID)
			: base(LavishScript.Objects.GetObject("Local", CharID.ToString()))
		{
		}

		/// <summary>
		/// Get a Local pilot by name.
		/// </summary>
		public Pilot(string CharName)
			: base(LavishScript.Objects.GetObject("Local", CharName))
		{
		}
		#endregion

		#region Members
		public Int64 ID
		{
			get { return this.GetInt64FromLSO("ID"); }
		}

		/// <summary>
		/// Wrapper for the Name member of a localpilots type.
		/// </summary>
		public string Name
		{
			get { return this.GetStringFromLSO("Name"); }
		}

		/// <summary>
		/// Wrapper for the CharID member of a localpilots type.
		/// </summary>
		public Int64 CharID
		{
			get { return this.GetInt64FromLSO("CharID"); }
		}

		/// <summary>
		/// Wrapper for the Type member of a localpilots type.
		/// </summary>
		public string Type
		{
			get { return this.GetStringFromLSO("Type"); }
		}

		/// <summary>
		/// This is, for the most part, your 'race' subtype)
		/// </summary>
		public int TypeID
		{
			get { return this.GetIntFromLSO("TypeID"); }
		}

	    public Corporation Corp
	    {
	        get
	        {
	            return new Corporation(GetMember("Corp"));
	        }
	    }

		/// <summary>
		/// Wrapper for the Alliance member of a localpilots type.
		/// </summary>
		public string Alliance
		{
			get { return this.GetStringFromLSO("Alliance"); }
		}

		/// <summary>
		/// Wrapper for the AllianceID member of a localpilots type.
		/// </summary>
		public int AllianceID
		{
			get { return this.GetIntFromLSO("AllianceID"); }
		}

		/// <summary>
		/// Wrapper for the AllianceTicker member of a localpilots type.
		/// </summary>
		public string AllianceTicker
		{
			get { return this.GetStringFromLSO("AllianceTicker"); }
		}

		/// <summary>
		/// If they're within range of your overhead.
		/// </summary>
		public Entity ToEntity
		{
			get
			{
				return new Entity(GetMember("ToEntity"));
			}
		}

		/// <summary>
		/// Returns invalid if this pilot is not in your fleet.
		/// Use LavishScriptObject.IsNullOrInvalid to check.
		/// </summary>
		public FleetMember ToFleetMember
		{
			get
			{
				return new FleetMember(GetMember("ToFleetMember"));
			}
		}

		/// <summary>
		/// The pilots standing towards you.
		/// </summary>
		public Standing Standing
		{
			get
			{
				return new Standing(GetMember("Standing"));
			}
		}

		/// <summary>
		/// The pilots standing towards any other CharID, CorporationID, or AllianceID
		/// </summary>
		public double StandingTo(int ID)
		{
			return this.GetDoubleFromLSO("StandingTo", ID.ToString());
		}
		#endregion

		#region Methods
		/// <summary>
		/// EXAMPLE: new LocalPilots("Amadeus").SetStanding(5.0,"Amadeus rocks");
		/// </summary>
		public bool SetStanding(int Standing, string Reason)
		{
			Tracing.SendCallback("Pilot.SetStanding", Standing, Reason);
			return ExecuteMethod("SetStanding", Standing.ToString(), Reason);
		}

		/// <summary>
		/// Invite a localpilot to your fleet.
		/// </summary>
		/// <returns></returns>
		public bool InviteToFleet()
		{
			Tracing.SendCallback("Pilot.InviteToFleet");
			return ExecuteMethod("InviteToFleet");
		}
		#endregion
	}
}
