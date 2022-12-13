using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;

namespace TheGrotto.Content.NPCs.Corruption
{
    internal class Strider : ModNPC
    {
        public StriderLimb rightLeg;
        public StriderLimb leftLeg;




        public bool Vulnerable = false;
        //public ref float Phase => ref NPC.ai[0];
        public ref float Timer => ref NPC.ai[0];
        private ref float WalkTimer => ref NPC.ai[1];
        public ref float AttackTimer => ref NPC.ai[2];
        private ref float State => ref NPC.ai[3];
        private ref float Landed => ref NPC.ai[4];
        public Phase phase = Phase.Idle;

        private bool Floating => !leftLeg.footOnGround && !rightLeg.footOnGround;
        private StriderLimb FootOffGround => FootOnGround == leftLeg ? rightLeg : leftLeg;
        private StriderLimb FootOnGround;
        private const int WALK_RADIUS = 16;



        private Player Target => Main.player[NPC.target];

        private int xFrame = 0;
        private int yFrame = 0;
        private int frameCounter = 0;

        public enum Phase
        {
            /// <summary>
            /// hiding/in tree
            /// </summary>
            Idle = 0,

            /// <summary>
            /// chasing player
            /// </summary>
            Chasing = 1,

            /// <summary>
            /// trying to spike with legs/tbd alt attack
            /// </summary>
            Attacking = 2,

            /// <summary>
            /// looking for players
            /// </summary>
            Seeking = 3
        };

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override string Texture => AssetDirectory.NPCs + "Corruption/Strider";

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.noTileCollide = false;
            //NPC.noGravity = true;
            NPC.knockBackResist = 0.5f;
            NPC.damage = 30;
            NPC.dontTakeDamage = false;
            NPC.lifeMax = 500;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement("[PH] Birthed from the chasms of the corruption, this slender beast roams the diseased surface, seeking anyone who dares trespass.")

            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneCorrupt && spawnInfo.Player.Center.Y > Main.worldSurface ? 0.1f : 0;
        }


        /// <summary>
        /// decides when the strider can take damage
        /// </summary>
        internal void CanTakeDamage()
        {
            if(Vulnerable == true)
            {
                NPC.dontTakeDamage = false;
            }
        }

        public override void AI()
        {

            Vulnerable = true;

            NPC.TargetClosest(true);

            switch (phase)
            {
                case Phase.Idle:
                    IdleBehavior(); break;
                //case Phase.Chasing:
                //    ChasingBehavior(); break;
                //case Phase.Attacking:
                //    AttackingBehavior(); break;
            }
        }




        private void IdleBehavior() 
        {
            float xdist = Math.Abs(Target.Center.X - NPC.Center.X);

            if (xdist > 30)
            {
                xFrame = 1;
                if (frameCounter % 5 == 0)
                {
                    yFrame++;
                    yFrame %= Main.npcFrameCount[NPC.type];
                }

                NPC.spriteDirection = NPC.direction = Math.Sign(Target.Center.X - NPC.Center.X);

                NPC.velocity.X += NPC.direction * 0.15f;
                NPC.velocity.X = MathHelper.Clamp(NPC.velocity.X, -3, 3);

                if (NPC.collideX && NPC.velocity.Y == 0)
                    NPC.velocity.Y = -8;
            }

            if (Timer == 1) // On-Spawn
            {
                leftLeg = new StriderLimb(this, new Vector2(-10, 0));
                rightLeg = new StriderLimb(this, new Vector2(10, 0));
            }
        }

        private void ChasingBehavior()
        {

        }

        private void AttackingBehavior()
        {

        }







        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = Request<Texture2D>(Texture).Value;
            Vector2 slopeOffset = new Vector2(0, NPC.gfxOffY);

            SpriteEffects effects = SpriteEffects.None;
            Vector2 origin = new Vector2((NPC.width * 0.75f), (NPC.height / 2) - 6);

            if (NPC.spriteDirection != 1)
                effects = SpriteEffects.FlipHorizontally;

            Main.spriteBatch.Draw(texture, NPC.Center, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);


            return false;
        }












        public class StriderLimb
        {

            public Vector2 joint;
            public Vector2 foot;
            public Vector2 attachPoint;
            public Vector2 savedPoint;
            private Vector2 attachOff;

            private Strider parent;
            private NPC parentNPC => parent.NPC;

            public bool footOnGround => PointInTile(foot);

            public StriderLimb(Strider parent, Vector2 attachOff)
            {
                this.parent = parent;
                attachPoint = parent.NPC.Center + attachOff;
                foot = attachPoint + new Vector2(0, 64);
                joint = attachPoint + new Vector2(0, 32);
                this.attachOff = attachOff;

            }

            public void MoveWholeLimb(Vector2 velocity)
            {
                attachPoint += velocity;
                joint += velocity;
                foot += velocity;
            }

            public void Constrain()
            {
                joint = Vector2.Lerp(foot, attachPoint, 0.5f) + Vector2.UnitY * -15;

                if (Vector2.Distance(foot, attachPoint) > 120) foot -= Vector2.Normalize(foot - attachPoint) * 3;

                attachPoint = parentNPC.Center + attachOff;
            }


            public void Draw(SpriteBatch sb)
            {
                var limbTex = Request<Texture2D>("TheGrotto/Assets/Corruption/StriderLimb").Value;
                var jointTex = Request<Texture2D>("TheGrotto/Assets/Corruption/StrideJoint").Value;

                sb.Draw(jointTex, joint - Main.screenPosition, null, Color.White, 0, jointTex.Size() / 2, 1, 0, 0);
                sb.Draw(jointTex, attachPoint - Main.screenPosition, null, Color.White, 0, jointTex.Size() / 2, 1, 0, 0);
                sb.Draw(jointTex, foot - Main.screenPosition, null, Color.White, 0, jointTex.Size() / 2, 1, 0, 0);

                sb.Draw(limbTex, joint - Main.screenPosition, null, Color.White, (joint - attachPoint).ToRotation() + 1.57f, Vector2.UnitX * limbTex.Width / 2, 1, 0, 0);
                sb.Draw(limbTex, foot - Main.screenPosition, null, Color.White, (foot - joint).ToRotation() + 1.57f, Vector2.UnitX * limbTex.Width / 2, 1, 0, 0);
            }
        }



        //move this to a helper class idk
        public static bool PointInTile(Vector2 point)
        {
            Point16 startCoords = new Point16((int)point.X / 16, (int)point.Y / 16);
            for (int x = -1; x <= 1; x++)
                for (int y = -1; y <= 1; y++)
                {
                    var thisPoint = startCoords + new Point16(x, y);

                    if (!WorldGen.InWorld(thisPoint.X, thisPoint.Y)) return false;

                    var tile = Framing.GetTileSafely(thisPoint);
                    if (Main.tileSolid[tile.TileType] && tile.HasTile)
                    {
                        var rect = new Rectangle(thisPoint.X * 16, thisPoint.Y * 16, 16, 16);
                        if (rect.Contains(point.ToPoint()))
                            return true;
                    }
                }

            return false;
        }




    }
}
