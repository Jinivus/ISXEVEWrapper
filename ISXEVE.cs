using System;
using System.Collections.Generic;
using System.Text;
using InnerSpaceAPI;
using LavishScriptAPI;

namespace EVE.ISXEVE
{
	/// <summary>
	/// Wrapper for the isxeve data type.
	/// </summary>
	public class ISXEVE : LavishScriptPersistentObject
	{
		#region Constructors
		/// <summary>
		/// Copy constructor for ISXEVE object
		/// </summary>
		/// <param name="Obj"></param>
		public ISXEVE(LavishScriptPersistentObject Obj)
			: base(Obj)
		{
		}

		/// <summary>
		/// Default constructor for ISXEVE object.  Returns the persistent LS object.
		/// </summary>
		public ISXEVE()
			: base(LavishScript.Objects.GetPersistentObject("ISXEVE"))
		{
		}
		#endregion

		#region Members
		/// <summary>
		/// Wrapper for the Version member of the isxeve object.
		/// </summary>
		public string Version
		{
			get
			{
				return GetMember<string>("Version");
			}
		}

		/// <summary>
		/// Note: All scripts should check to make sure that this is true before running.
		/// </summary>
		public bool IsReady
		{
			get
			{
				return GetMember<bool>("IsReady");
			}
		}

		/// <summary>
		/// Returns true if the extension is currently in the authentication/patching phase of loading
		/// </summary>
		public bool IsLoading
		{
			get
			{
				return GetMember<bool>("IsLoading");
			}
		}

		/// <summary>
		/// This is simply a utility for scripts to convert any number of seconds into a string:
		/// 0 - 59 = "# seconds"
		/// 60 - 3599 = "# minutes and # seconds"
		/// 3600+ = "# hours, # minutes, and # seconds" 
		/// </summary>
		public string SecsToString(int seconds)
		{
			return GetMember<string>("SecsToString", seconds.ToString());
		}

		/// <summary>
		/// This should be checked before doing anything else once docking/undocking/system changing/warping.
		/// Returns true if safe to use ISXEVE members/methods/TLOS/etc, false if you need to avoid using ISXEVE calls.
		/// </summary>
		public bool IsSafe
		{
			get
			{
				LavishScriptObject isSafe = GetMember("IsSafe");
				if (LavishScriptObject.IsNullOrInvalid(isSafe))
				{
					return false;
				}
				return isSafe.GetValue<bool>();
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Unload the extension.
		/// </summary>
		public void Unload()
		{
			Tracing.SendCallback("ISXEVE.Unload");
			ExecuteMethod("Unload");
		}

		/// <summary>
		/// Reload the extension.
		/// </summary>
		public void Reload()
		{
			Tracing.SendCallback("ISXEVE.Reload");
			ExecuteMethod("Reload");
		}

		/// <summary>
		/// Alias for Reload
		/// </summary>
		public void Patch()
		{
			Tracing.SendCallback("ISXEVE.Patch");
			ExecuteMethod("Patch");
		}

		/// <summary>
		/// Alias for Reload
		/// </summary>
		public void Update()
		{
			Tracing.SendCallback("ISXEVE.Update");
			ExecuteMethod("Update");
		}
		#endregion
	}
}
