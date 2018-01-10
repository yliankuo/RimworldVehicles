using System;
using RimWorld;
using Verse;

namespace RWVehicles
{
	public class VehicleSpawner : Building
	{

		private PawnKindDef pawnkind;

		public PawnKindDef pawnktest
		{
			get
			{
				return this.pawnkind;
			}
		}

		public void SpawnPawn()
		{

			RWVProperties properties = def.TryGetModExtension<RWVProperties>();
			pawnkind = properties.genSpawnPawn;
			Pawn pawn = PawnGenerator.GeneratePawn(pawnkind, base.Faction);
			GenSpawn.Spawn(pawn, this.Position, base.Map);
		}

		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
			if (base.Faction == null)
			{
				this.SetFaction(Faction.OfPlayer, null);
			}

			SpawnPawn();
			this.Destroy();
		}

	}
}
