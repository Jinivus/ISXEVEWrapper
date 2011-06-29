﻿using System;
using System.Collections.Generic;
using System.Text;

using InnerSpaceAPI;
using LavishScriptAPI;

namespace EVE.ISXEVE
{
  /// <summary>
  /// The CachedEntity class (??).
  /// </summary>
  public class CachedEntity : LavishScriptObject
  {
    #region Constructors
    /// <summary>
    /// CachedEntity copy constructor.
    /// </summary>
    /// <param name="Obj"></param>
    public CachedEntity(LavishScriptObject Obj)
        : base(Obj)
    {
    }
    #endregion

    #region Members
    /// <summary>
    /// Wrapper for the ID member of the CachedEntity object.
    /// </summary>
    public Int64 ID
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
                return id.GetValue<Int64>();
            }
        }
    }

    /// <summary>
    /// Wrapper for the CategoryID member of the CachedEntity object.
    /// </summary>
    public int CategoryID
    {
        get
        {
            return GetMember<int>("CategoryID");
        }
    }

    /// <summary>
    /// Wrapper for the GroupID member of the CachedEntity object.
    /// </summary>
    public int GroupID
    {
        get
        {
            LavishScriptObject groupID = GetMember("GroupID");
            if (LavishScriptObject.IsNullOrInvalid(groupID))
            {
                return -1;
            }
            else
            {
                return groupID.GetValue<int>();
            }
        }
    }

    /// <summary>
    /// Wrapper for the Name member of the CachedEntity object.
    /// </summary>
    public string Name
    {
        get
        {
            return GetMember<string>("Name");
        }
    }

    /// <summary>
    /// Wrapper for the TypeID member of the CachedEntity object.
    /// </summary>
    public int TypeID
    {
        get
        {
            LavishScriptObject typeID = GetMember("TypeID");
            if (LavishScriptObject.IsNullOrInvalid(typeID))
            {
                return -1;
            }
            else
            {
                return typeID.GetValue<int>();
            }
        }
    }

    /// <summary>
    /// Wrapper for the X member of the CachedEntity object.
    /// </summary>
	  public double X
	  {
		  get
		  {
			  return GetMember<double>("X");
		  }
	  }

    /// <summary>
    /// Wrapper for the Y member of the CachedEntity object.
    /// </summary>
    public double Y
	  {
		  get
		  {
			  return GetMember<double>("Y");
		  }
	  }

    /// <summary>
    /// Wrapper for the Z member of the CachedEntity object.
    /// </summary>
	  public double Z
	  {
		  get
		  {
			  return GetMember<double>("Z");
		  }
	  }

    /// <summary>
    /// Wrapper for the Distance member of the CachedEntity object.
    /// </summary>
    public double Distance
    {
        get
        {
            return (double)GetMember<float>("Distance");
        }
    }

    /// <summary>
    /// Wrapper for the ShieldPct member of the CachedEntity object.
    /// </summary>
    public double ShieldPct
    {
        get
        {
            return GetMember<double>("ShieldPct");
        }
    }

    /// <summary>
    /// Wrapper for the ArmorPct member of the CachedEntity object.
    /// </summary>
    public double ArmorPct
    {
        get
        {
            return GetMember<double>("ArmorPct");
        }
    }

    /// <summary>
    /// Wrapper for the StructurePct member of the CachedEntity object.
    /// </summary>
    public double StructurePct
    {
        get
        {
            return GetMember<double>("StructurePct");
        }
    }

    /// <summary>
    /// Wrapper for the IsLockedTarget member of the CachedEntity object.
    /// </summary>
    public bool IsLockedTarget
    {
        get
        {
            return GetMember<bool>("IsLockedTarget");
        }
    }

    /// <summary>
    /// Wrapper for the IsNPC member of the CachedEntity object.
    /// </summary>
    public bool IsNPC
    {
        get
        {
            LavishScriptObject isNPC = GetMember("IsNPC");
            if (LavishScriptObject.IsNullOrInvalid(isNPC))
            {
                return false;
            }
            else
            {
                return isNPC.GetValue<bool>();
            }
        }
    }

    /// <summary>
    /// Wrapper for the IsPC member of the CachedEntity object.
    /// </summary>
    public bool IsPC
    {
        get
        {
            return GetMember<bool>("IsPC");
        }
    }

    /// <summary>
    /// Wrapper for the IsTargetingMe member of the CachedEntity object.
    /// </summary>
    public bool IsTargetingMe
    {
        get
        {
            return GetMember<bool>("IsTargetingMe");
        }
    }

    /// <summary>
    /// Wrapper for the BeingTargeted member of the CachedEntity object.
    /// </summary>
    public bool BeingTargeted
    {
        get
        {
            return GetMember<bool>("BeingTargeted");
        }
    }

    /// <summary>
    /// Wrapper for the ToEntity member of the CachedEntity object.
    /// </summary>
    public Entity ToEntity
    {
        get
        {
            return new Entity(GetMember("ToEntity"));
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
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Activate", string.Empty);
        return ExecuteMethod("Activate");
    }

    /// <summary>
    /// Warp to zero distance
    /// </summary>
    public bool WarpTo()
    {
        return ExecuteMethod("WarpTo");
    }

    /// <summary>
    /// Warp to the given distance, in meters.
    /// </summary>
    public bool WarpTo(int Distance)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.WarpTo", Distance.ToString());
        return ExecuteMethod("WarpTo", Distance.ToString());
    }

    /// <summary>
    /// Warp fleet to zero distance
    /// </summary>
    public bool WarpFleetTo()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.WarpFleetTo", string.Empty);
        return ExecuteMethod("WarpFleetTo");
    }

    /// <summary>
    /// Warp fleet to the given distance, in meters.
    /// </summary>
    public bool WarpFleetTo(int Distance)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.WarpFleetTo", Distance.ToString());
        return ExecuteMethod("WarpFleetTo", Distance.ToString());
    }

    /// <summary>
    /// Align to the entity.
    /// </summary>
    public bool Align()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Align", string.Empty);
        return ExecuteMethod("Align");
    }

    /// <summary>
    /// Lock the entity.
    /// </summary>
    /// <returns></returns>
    public bool LockTarget()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.LockTarget", string.Empty);
        return ExecuteMethod("LockTarget");
    }

    /// <summary>
    /// Unlock the entity.
    /// </summary>
    /// <returns></returns>
    public bool UnlockTarget()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.UnlockTarget", string.Empty);
        return ExecuteMethod("UnlockTarget");
    }

    /// <summary>
    /// Approach to 50 meters from target
    /// </summary>
    public bool Approach()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Approach", string.Empty);
        return ExecuteMethod("Approach");
    }

    /// <summary>
    /// Approach to within the given number of meters
    /// </summary>
    public bool Approach(int Distance)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Approach", Distance.ToString());
        return ExecuteMethod("Approach", Distance.ToString());
    }

    /// <summary>
    /// Keep at a range of 1000 meters.
    /// </summary>
    public bool KeepAtRange()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.KeepAtRange", string.Empty);
        return ExecuteMethod("KeepAtRange");
    }

    /// <summary>
    /// Keep at a range of Distance meters.
    /// </summary>
    public bool KeepAtRange(int Distance)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.KeepAtRange", Distance.ToString());
        return ExecuteMethod("KeepAtRange", Distance.ToString());
    }

    /// <summary>
    /// Orbit at 5000 meters
    /// </summary>
    /// <returns></returns>
    public bool Orbit()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Orbit", string.Empty);
        return ExecuteMethod("Orbit");
    }

    /// <summary>
    /// Orbit at Distance meters
    /// </summary>
    public bool Orbit(int Distance)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Orbit", Distance.ToString());
        return ExecuteMethod("Orbit", Distance.ToString());
    }

    /// <summary>
    /// Dock at a station.  Note: You must be within docking range of the station.
    /// </summary>
    public bool Dock()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Dock", string.Empty);
        return ExecuteMethod("Dock");
    }

    /// <summary>
    /// Selects a locked target as your current Active target
    /// </summary>
    public bool MakeActiveTarget()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.MakeActiveTarget", string.Empty);
        return ExecuteMethod("MakeActiveTarget");
    }

    /// <summary>
    /// Open cargo hold of entity.
    /// </summary>
    /// <returns></returns>
    public bool OpenCargo()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.OpenCargo", string.Empty);
        return ExecuteMethod("OpenCargo");
    }

    public bool OpenStorage()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("Entity.OpenStorage", string.Empty);
        return ExecuteMethod("OpenStorage");
    }

    public bool CloseStorage()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("Entity.CloseStorage", string.Empty);
        return ExecuteMethod("CloseStorage");
    }

    /// <summary>
    /// Close cargo hold of entity.
    /// </summary>
    /// <returns></returns>
    public bool CloseCargo()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.CloseCargo", string.Empty);
        return ExecuteMethod("CloseCargo");
    }

    /// <summary>
    /// Same as right click, Stack All -- consolidates stacks
    /// </summary>
    public bool StackAllCargo()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.StartConversation", string.Empty);
        return ExecuteMethod("StackAllCargo");
    }

    /// <summary>
    /// Sets the entity (container, probably) name.  Your code shouldn't name unnamable entities.
    /// </summary>
    public bool SetName(string Name)
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.SetName", Name);
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
            if (Tracing.Callback != null)
                Tracing.SendCallback("CachedEntity.CreateBM", String.Format("{0},{1}", Label, Notes));
            return ExecuteMethod("CreateBookmark", Label, Notes);
        }
        else if (!string.IsNullOrEmpty(Label))
        {
            if (Tracing.Callback != null)
                Tracing.SendCallback("CachedEntity.CreateBM", Label);
            return ExecuteMethod("CreateBookmark", Label);
        }
        else
        {
            if (Tracing.Callback != null)
                Tracing.SendCallback("CachedEntity.CreateBM", string.Empty);
            return ExecuteMethod("CreateBookmark");
        }
    }

    /// <summary>
    /// For stations, similar to choosing 'Dock' from the station right click menu while in space.
    /// </summary>
    public bool WarpToAndDock()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.WarpToAndDock", string.Empty);
        return ExecuteMethod("WarpToAndDock");
    }

    /// <summary>
    /// 'Stargate' entities only. You must also be in range to jump.
    /// </summary>
    public bool Jump()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Jump", string.Empty);
        return ExecuteMethod("Jump");
    }

    #region Mines
    /// <summary>
    /// Mines only
    /// </summary>
    public bool Mine()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.Mine", string.Empty);
        return ExecuteMethod("Mine");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool MineRepeatedly()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.MineRepeatedly", string.Empty);
        return ExecuteMethod("MineRepeatedly");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool ReturnAndOrbit()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.ReturnAndOrbit", string.Empty);
        return ExecuteMethod("ReturnAndOrbit");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool ReturnToDroneBay()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.ReturnToDroneBay", string.Empty);
        return ExecuteMethod("ReturnToDroneBay");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool ScoopToDroneBay()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.ScoopToDroneBay", string.Empty);
        return ExecuteMethod("ScoopToDroneBay");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool ScoopToCargoBay()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.ScoopToCargoBay", string.Empty);
        return ExecuteMethod("ScoopToCargoBay");
    }

    /// <summary>
    /// Mines only
    /// </summary>
    public bool EngageMyTarget()
    {
        if (Tracing.Callback != null)
            Tracing.SendCallback("CachedEntity.EngageMyTarget", string.Empty);
        return ExecuteMethod("EngageMyTarget");
    }
    #endregion
    #endregion
  }
}
