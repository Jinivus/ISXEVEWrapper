using System;
using System.Collections.Generic;
using System.Text;
using Extensions;
using LavishScriptAPI;
using LavishScriptAPI.Interfaces;

namespace EVE.ISXEVE
{
    /// <summary>
    /// CallbackDelegate used in trace logging.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="args"></param>
    public delegate void CallbackDelegate(string method, string args);
    /// <summary>
    /// Class used for trace logging.
    /// </summary>
    public class Tracing
    {
		/// <summary>
		/// Callback to use for logging.
		/// </summary>
		public static CallbackDelegate Callback;

        /// <summary>
        /// Add a callback delegate for trace logging.
        /// </summary>
        /// <param name="callbackDelegate"></param>
        public static void AddCallback(CallbackDelegate callbackDelegate)
        {
            Callback = callbackDelegate;
        }

        /// <summary>
        /// Clear the callback delegate.
        /// </summary>
        public static void RemoveCallback()
        {
            Callback = null;
        }

        /// <summary>
        /// Use the callback delegate to send a log message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void SendCallback(string message, params object[] args)
        {
        	if (Callback == null) return;

        	var argString = new StringBuilder();
        	if (args.Length > 0)
        	{
        		argString.Append(args[0].ToString());
        	}
        	for (int idx = 1; idx < args.Length; idx++)
        	{
        		argString.Append(String.Format(", {0}", args[idx]));
        	}

        	Callback(message, argString.ToString());
        }
    }

	internal class Util
	{
		private static T[] PrefixArray<T>(T first, T[] rest)
		{
			var newArray = new T[rest.Length + 1];

			newArray[0] = first;

			for (var i = 0; i < rest.Length; i++)
				newArray[i + 1] = rest[i];

			return newArray;
		}

		private static List<T> IndexToLavishScriptObjectList<T>(LavishScriptObject index, string lsTypeName)
		{
			//string methodName = "IndexToLSOList";
			//Tracing.SendCallback(methodName, LSTypeName);

			//Tracing.SendCallback(methodName, "getmember Used");
			var list = new List<T>();
			var count = index.GetMember<int>("Used");

			if (count == 0)
			{	
				return list;
			}

			//Tracing.SendCallback(methodName, "get constructor info");
			var constructor = typeof(T).GetConstructor(new[] { typeof(LavishScriptObject) });

			//Tracing.SendCallback(methodName, "loop add items");
			for (var i = 1; i <= count; i++)
			{
				var objectLso = index.GetIndex(i.ToString());

				if (LavishScriptObject.IsNullOrInvalid(objectLso))
				{
					Tracing.SendCallback(String.Format("Error: Index contains invalid LSO. NewObject will fail; aborting."));
					return list;
				}

				var objectId = objectLso.GetStringFromLSO("ID");

				if (objectId == null)
				{
					Tracing.SendCallback(String.Format("Error: LStype \"{0}\" has no ID member. NewObject will fail; aborting.", lsTypeName));
					return list;
				}

				if (objectId == string.Empty)
				{
					Tracing.SendCallback(String.Format("Error: LStype \"{0}\" has an ID member but it is returning an empty string. NewObject will fail; aborting.", lsTypeName));
					return list;
				}

				var lsObject = LavishScript.Objects.NewObject(lsTypeName, objectId);
				var item = (T) constructor.Invoke(new object[] {lsObject});
				list.Add(item);
			}

			return list;
		}

		private static List<T> IndexToStructList<T>(LavishScriptObject index)
		{
			var list = new List<T>();
			var count = index.GetMember<int>("Used");

			for (var i = 1; i <= count; i++)
				list.Add(index.GetIndex<T>(i.ToString()));

			return list;
		}

		private static List<T> IndexToList<T>(LavishScriptObject index, string lsTypeName)
		{
			//Tracing.SendCallback("IndextoList", LSTypeName);
			return typeof(T).IsSubclassOf(typeof(LavishScriptObject)) ? IndexToLavishScriptObjectList<T>(index, lsTypeName) : IndexToStructList<T>(index);
		}

		private static T IndexToLavishScriptObject<T>(LavishScriptObject index, int number)
		{
			var constructor = typeof(T).GetConstructor(new[] { typeof(LavishScriptObject) });

			return (T)constructor.Invoke(new object[] { index.GetIndex(number.ToString()) });
		}

		public static T GetIndexMember<T>(LavishScriptObject index, int number)
		{
			if (typeof(T).IsSubclassOf(typeof(LavishScriptObject)))
				return (T)typeof(T).GetConstructor(new[] { typeof(LavishScriptObject) }).Invoke(new object[] { index.GetIndex(number.ToString()) });
			return index.GetIndex<T>(number.ToString());
		}

		internal static List<T> GetListFromMethod<T>(ILSObject obj, string methodName, string lsTypeName, params string[] args)
		{
			//string methodName = "GetListFromMethod";
			//Tracing.SendCallback(methodName, MethodName, LSTypeName);

			if (obj == null || !obj.IsValid)
				return null;

			//Tracing.SendCallback(methodName, "Create new LSO of index. Type: ", LSTypeName);
			using (var index = LavishScript.Objects.NewObject("index:" + lsTypeName))
			{
				//Tracing.SendCallback(methodName, "Collapsing Args[]");

				string[] allargs;
				if (args.Length > 0)
				{
					allargs = PrefixArray(index.LSReference, args);
				}
				else
				{
					allargs = new string[1];
					allargs[0] = index.LSReference;
				}

				//Tracing.SendCallback(methodName, "Execute method, name: ", MethodName);
				if (!obj.ExecuteMethod(methodName, allargs))
					return null;

				//Tracing.SendCallback(methodName, "Get member Used");
				using (var used = index.GetMember("Used"))
				{
					//Tracing.SendCallback(methodName, "LSO.IsNullOrInvalid (used)");
					if (LavishScriptObject.IsNullOrInvalid(used))
						return null;
				}

				//Tracing.SendCallback(methodName, "IndexToList");
				var list = IndexToList<T>(index, lsTypeName);

				//Tracing.SendCallback(methodName, "Returning");
				return list;
			}
		}

		internal static T GetFromIndexMethod<T>(ILSObject obj, string methodName, string lsTypeName, int number, params string[] args)
		{
			// argument is 0-based
			number += 1;

			if (obj == null || !obj.IsValid || number <= 0)
				return default(T);

			using (var index = LavishScript.Objects.NewObject("index:" + lsTypeName))
			{
				var allargs = PrefixArray(index.LSReference, args);

				if (!obj.ExecuteMethod(methodName, allargs))
					return default(T);

				using (var used = index.GetMember("Used"))
				{
					// if it failed or we want one off the end, return
					if (LavishScriptObject.IsNullOrInvalid(used) || used.GetValue<int>() < number)
						return default(T);
				}

				var member = GetIndexMember<T>(index, number);
				return member;
			}
		}

		internal static List<T> GetListFromMember<T>(ILSObject obj, string memberName, string lsTypeName, params string[] args)
		{
			//var methodName = "GetListFromMember";
			//Tracing.SendCallback(methodName, MemberName, LSTypeName);
			
			if (obj == null || !obj.IsValid)
				return null;

			//Tracing.SendCallback(methodName, "new index");
			using (var index = LavishScript.Objects.NewObject("index:" + lsTypeName))
			{
				//Tracing.SendCallback(methodName, "arg condensing");
				var allargs = PrefixArray(index.LSReference, args);

				//Tracing.SendCallback(methodName, "getmember retval");
				using (var retval = obj.GetMember(memberName, allargs))
				{
					if (LavishScriptObject.IsNullOrInvalid(retval))
						return null;
				}

				//Tracing.SendCallback(methodName, "index to list");
				var list = IndexToList<T>(index, lsTypeName);

				//Tracing.SendCallback(methodName, "invalidate");

				//Tracing.SendCallback(methodName, "return");
				return list;
			}
		}

		internal static T GetFromIndexMember<T>(ILSObject obj, string memberName, string lsTypeName, int number, params string[] args)
		{
			// argument is 0-based
			number += 1;

			if (obj == null || !obj.IsValid)
				return default(T);

			using (var index = LavishScript.Objects.NewObject("index:" + lsTypeName))
			{
				var allargs = PrefixArray(index.LSReference, args);

				using (var retval = obj.GetMember(memberName, allargs))
				{
					if (LavishScriptObject.IsNullOrInvalid(retval) || retval.GetValue<int>() < number)
						return default(T);
				}

				var member = GetIndexMember<T>(index, number);
				return member;
			}
		}
	}
}
