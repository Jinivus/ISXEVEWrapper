﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LavishScriptAPI;
using InnerSpaceAPI;

namespace EVE.ISXEVE
{
	/// <summary>
	/// Attacker class
	/// </summary>
	public class Attacker : Entity
	{
		#region Constructors
		/// <summary>
		/// Attacker copy constructor
		/// </summary>
		/// <param name="copy"></param>
		public Attacker(LavishScriptObject copy) : base(copy) { }
		#endregion

		#region Members
		public int ID
		{
			get
			{
				Tracing.SendCallback("Attacker.ID");
				var id = GetMember("ID");
				if (IsNullOrInvalid(id))
				{
					return -1;
				}
				else
				{
					return id.GetValue<int>();
				}
			}
		}

		/// <summary>
		/// IsCurrentlyAttacking member
		/// </summary>
		public bool IsCurrentlyAttacking
		{
			get
			{
				LavishScriptObject isCurrentlyAttacking = GetMember("IsCurrentlyAttacking");
				if (LavishScriptObject.IsNullOrInvalid(isCurrentlyAttacking))
				{
					return false;
				}
				return isCurrentlyAttacking.GetValue<bool>();
			}
		}

		/// Get the Jammer member of the Attacker object
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
		/// GetAttacks method
		/// </summary>
		/// <returns></returns>
		public List<Attack> GetAttacks()
		{
			Tracing.SendCallback("Attacker.GetAttacks");
			return Util.GetListFromMethod<Attack>(this, "GetAttacks", "attack");
		}
		#endregion
	}
}
