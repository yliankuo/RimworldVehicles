using System;
using Verse;

namespace RWVehicles
{
	public static class RWVExtensionUtility
	{
		public static T TryGetModExtension<T>(this Def def) where T : DefModExtension
		{
			if (def.HasModExtension<T>())
				return def.GetModExtension<T>();

			return null;
		}
	}
}
