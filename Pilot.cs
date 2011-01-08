using System;
using System.Collections.Generic;
using System.Text;

using InnerSpaceAPI;
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
		public Pilot(int CharID)
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
		public int ID
		{
			get
			{
				LavishScriptObject id = GetMember("ID");
				if (LavishScriptObject.IsNullOrInvalid(id))
				{
					return -1;
				}
				else
				{
					return id.GetValue<Int32>();
				}
			}
		}

		/// <summary>
		/// Wrapper for the Name member of a localpilots type.
		/// </summary>
		public string Name
		{
			get
			{
				return GetMember<string>("Name");
			}
		}

		/// <summary>
		/// Wrapper for the CharID member of a localpilots type.
		/// </summary>
		public int CharID
		{
			get
			{
				return GetMember<int>("CharID");
			}
		}

		/// <summary>
		/// Wrapper for the Type member of a localpilots type.
		/// </summary>
		public string Type
		{
			get
			{
				return GetMember<string>("Type");
			}
		}

		/// <summary>
		/// This is, for the most part, your 'race' subtype)
		/// </summary>
		public int TypeID
		{
			get
			{
				return GetMember<int>("TypeID");
			}
		}

		/// <summary>
		/// Wrapper for the Corporation member of a localpilots type.
		/// </summary>
		public string Corporation
		{
			get
			{
				return GetMember<string>("Corporation");
			}
		}

		/// <summary>
		/// Wrapper for the CorporationID member of a localpilots type.
		/// </summary>
		public int CorporationID
		{
			get
			{
				return GetMember<int>("CorporationID");
			}
		}

		/// <summary>
		/// Wrapper for the CorporationTicker member of a localpilots type.
		/// </summary>
		public string CorporationTicker
		{
			get
			{
				return GetMember<string>("CorporationTicker");
			}
		}

		/// <summary>
		/// Wrapper for the Alliance member of a localpilots type.
		/// </summary>
		public string Alliance
		{
			get
			{
				return GetMember<string>("Alliance");
			}
		}

		/// <summary>
		/// Wrapper for the AllianceID member of a localpilots type.
		/// </summary>
		public int AllianceID
		{
			get
			{
				return GetMember<int>("AllianceID");
			}
		}

		/// <summary>
		/// Wrapper for the AllianceTicker member of a localpilots type.
		/// </summary>
		public string AllianceTicker
		{
			get
			{
				return GetMember<string>("AllianceTicker");
			}
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
			return GetMember<double>("StandingTo", ID.ToString());
		}
		#endregion

		#region Methods
		/// <summary>
		/// EXAMPLE: new LocalPilots("Amadeus").SetStanding(5.0,"Amadeus rocks");
		/// </summary>
		public bool SetStanding(int Standing, string Reason)
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Pilot.SetStanding", String.Format("{0},{1}", Standing, Reason));
			return ExecuteMethod("SetStanding", Standing.ToString(), Reason);
		}

		/// <summary>
		/// Invite a localpilot to your fleet.
		/// </summary>
		/// <returns></returns>
		public bool InviteToFleet()
		{
			if (Tracing.Callback != null)
				Tracing.SendCallback("Pilot.InviteToFleet", string.Empty);
			return ExecuteMethod("InviteToFleet");
		}
		#endregion
	}
}
