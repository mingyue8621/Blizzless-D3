﻿//Blizzless Project 2022
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using CrystalMpq;
//Blizzless Project 2022 
using DiIiS_NA.Core.MPQ.FileFormats.Types;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.SNO;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.Math;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.Collision;
//Blizzless Project 2022 
using Gibbed.IO;
//Blizzless Project 2022 
using System.Drawing;
//Blizzless Project 2022 
using System;

namespace DiIiS_NA.Core.MPQ.FileFormats
{
    [FileFormat(SNOGroup.Scene)]
    public class Scene : FileFormat
    {
        public Header Header { get; private set; }
        public int Int0 { get; private set; }
        public bool NoSpawn { get; private set; }
        public AABB AABBBounds { get; private set; }
        public AABB AABBMarketSetBounds { get; private set; }
        public NavMeshDef NavMesh { get; private set; }
        public List<int> MarkerSets { get; private set; }
        public List<int> Exclusions { get; private set; }
        public List<int> Inclusions { get; private set; }
        public string LookLink { get; private set; }
        public int Int1 { get; private set; }
        public List<MsgTriggeredEvent> MsgTriggeredEvent { get; private set; }
        public NavZoneDef NavZone { get; private set; }
        public int F0 { get; private set; }
        public int SNOAppearance { get; private set; }
        public int SNOPhysMesh { get; private set; }

        public Scene(MpqFile file)
        {
            var stream = file.Open();
            this.Header = new Header(stream);
            ///+16
            Int0 = stream.ReadValueS32(); //12 - 28
            this.AABBBounds = new AABB(stream); //16 - 32
            this.AABBMarketSetBounds = new AABB(stream); //40 - 56
            this.NavMesh = new NavMeshDef(stream); //64 - 80
            this.Exclusions = stream.ReadSerializedInts(); //104 - 120
            stream.Position += (14 * 4);
            this.Inclusions = stream.ReadSerializedInts(); //168 - 184
            stream.Position += (14 * 4);
            this.MarkerSets = stream.ReadSerializedInts(); //232 - 248
            stream.Position += (14 * 4);
            this.LookLink = stream.ReadString(64, true); //296 - 312
            //stream.Position += (14 * 4;
            this.MsgTriggeredEvent = stream.ReadSerializedData<MsgTriggeredEvent>(); //360 - 376
            this.Int1 = stream.ReadValueS32(); //368 - 384
            stream.Position += (3 * 4);
            this.NavZone = new NavZoneDef(stream); //384 - 400
            this.SNOAppearance = stream.ReadValueS32(); //520 - 536
            stream.Position += 4;
            this.SNOPhysMesh = stream.ReadValueS32(); //528 - 544
            stream.Close();

            this.NoSpawn = false;
            int NoSpawnSquares = 0;

            foreach (var zone in this.NavMesh.Squares)
            {
                if (!((zone.Flags & DiIiS_NA.Core.MPQ.FileFormats.Scene.NavCellFlags.NoSpawn) == 0))
                {
                    NoSpawnSquares++;
                }
            }

            if ((this.NavMesh.Squares.Count - NoSpawnSquares) < (this.NavMesh.Squares.Count / 10)) this.NoSpawn = true;
        }

        public class NavMeshDef
        {
            public int SquaresCountX { get; private set; }
            public int SquaresCountY { get; private set; }
            public int Int0 { get; private set; }
            public int NavMeshSquareCount { get; private set; }
            public float Float0 { get; private set; }
            public List<NavMeshSquare> Squares = new List<NavMeshSquare>();

            public byte[,] WalkGrid;
            //public string Filename { get; private set; }

            public NavMeshDef(MpqFileStream stream)
            {
                this.SquaresCountX = stream.ReadValueS32();
                this.SquaresCountY = stream.ReadValueS32();
                this.Int0 = stream.ReadValueS32();
                this.NavMeshSquareCount = stream.ReadValueS32();
                this.Float0 = stream.ReadValueF32();
                this.Squares = stream.ReadSerializedData<NavMeshSquare>();


                if (SquaresCountX <= 64 && SquaresCountY <= 64)
                {
                    WalkGrid = new byte[64, 64];
                }
                else if (SquaresCountX <= 128 && SquaresCountY <= 128)
                {
                    WalkGrid = new byte[128, 128]; //96*96
                }
                else if (SquaresCountX <= 256 && SquaresCountY <= 256)
                {
                    WalkGrid = new byte[256, 256];
                }
                else if (SquaresCountX <= 384 && SquaresCountY <= 384)
                {
                    WalkGrid = new byte[384, 384];
                }
                else if (SquaresCountX > 384 || SquaresCountY > 384)
                {
                    WalkGrid = new byte[512, 512];
                }


                // Loop thru each NavmeshSquare in the array, and fills the grid
                for (int i = 0; i < NavMeshSquareCount; i++)
                {
                    WalkGrid[i % SquaresCountX, i / SquaresCountY] = (byte)(Squares[i].Flags & Scene.NavCellFlags.AllowWalk);
                    // Set the grid to 0x1 if its walkable, left as 0 if not. - DarkLotus
                }

                stream.Position += (3 * 4);
                //this.Filename = stream.ReadString(256, true);
            }
        }

        public class NavZoneDef
        {
            public int NavCellCount { get; private set; }
            public List<NavCell> NavCells = new List<NavCell>();
            public int NeighbourCount { get; private set; }
            public List<NavCellLookup> NavCellNeighbours = new List<NavCellLookup>();
            public float Float0 { get; private set; }
            public float Float1 { get; private set; }
            public int Int2 { get; private set; }
            public Vector2D V0 { get; private set; }
            public List<NavGridSquare> GridSquares = new List<NavGridSquare>();
            public int Int3 { get; private set; }
            public List<NavCellLookup> CellLookups = new List<NavCellLookup>();
            public int BorderDataCount { get; private set; }
            public List<NavCellBorderData> BorderData = new List<NavCellBorderData>();

            public NavZoneDef(MpqFileStream stream)
            {
                this.NavCellCount = stream.ReadValueS32();
                stream.Position += (3 * 4);
                this.NavCells = stream.ReadSerializedData<NavCell>();

                this.NeighbourCount = stream.ReadValueS32();
                stream.Position += (3 * 4);
                this.NavCellNeighbours = stream.ReadSerializedData<NavCellLookup>();

                this.Float0 = stream.ReadValueF32();
                this.Float1 = stream.ReadValueF32();
                this.Int2 = stream.ReadValueS32();
                this.V0 = new Vector2D(stream);

                stream.Position += (3 * 4);
                this.GridSquares = stream.ReadSerializedData<NavGridSquare>();

                this.Int3 = stream.ReadValueS32();
                stream.Position += (3 * 4);
                this.CellLookups = stream.ReadSerializedData<NavCellLookup>();

                this.BorderDataCount = stream.ReadValueS32();
                stream.Position += (3 * 4);
                this.BorderData = stream.ReadSerializedData<NavCellBorderData>();
            }
        }

        public class NavMeshSquare : ISerializableData
        {
            public float Z { get; private set; }
            public NavCellFlags Flags { get; private set; }

            public void Read(MpqFileStream stream)
            {
                this.Z = stream.ReadValueF32();
                this.Flags = (NavCellFlags)stream.ReadValueS32();
            }
        }

        public class NavCell : ISerializableData
        {
            public Vector3D Min { get; private set; }
            public Vector3D Max { get; private set; }
            public NavCellFlags Flags { get; private set; }
            public short NeighbourCount { get; private set; }
            public int NeighborsIndex { get; private set; }
            public RectangleF Bounds { get { return new RectangleF(Min.X, Min.Y, Max.X - Min.X, Max.Y - Min.Y); } }
            public void Read(MpqFileStream stream)
            {
                this.Min = new Vector3D(stream.ReadValueF32(), stream.ReadValueF32(), stream.ReadValueF32());
                this.Max = new Vector3D(stream.ReadValueF32(), stream.ReadValueF32(), stream.ReadValueF32());
                this.Flags = (NavCellFlags)stream.ReadValueS16();
                this.NeighbourCount = stream.ReadValueS16();
                this.NeighborsIndex = stream.ReadValueS32();
            }
        }

        /// <summary>
        /// Flags for NavCell.
        /// </summary>
        [Flags]
        public enum NavCellFlags : int
        {
            AllowWalk = 0x1,
            AllowFlier = 0x2,
            AllowSpider = 0x4,
            LevelAreaBit0 = 0x8,
            LevelAreaBit1 = 0x10,
            NoNavMeshIntersected = 0x20,
            NoSpawn = 0x40,
            Special0 = 0x80,
            Special1 = 0x100,
            SymbolNotFound = 0x200,
            AllowProjectile = 0x400,
            AllowGhost = 0x800,
            RoundedCorner0 = 0x1000,
            RoundedCorner1 = 0x2000,
            RoundedCorner2 = 0x4000,
            RoundedCorner3 = 0x8000
        }

        public class NavCellLookup : ISerializableData
        {
            public short Flags { get; private set; }
            public short WCell { get; private set; }

            public void Read(MpqFileStream stream)
            {
                this.Flags = stream.ReadValueS16();
                this.WCell = stream.ReadValueS16();
            }
        }

        public class NavGridSquare : ISerializableData
        {
            public short Flags { get; private set; }
            public short W1 { get; private set; }
            public short W2 { get; private set; }

            public void Read(MpqFileStream stream)
            {
                Flags = stream.ReadValueS16();
                W1 = stream.ReadValueS16();
                W2 = stream.ReadValueS16();
            }
        }

        public class NavCellBorderData : ISerializableData
        {
            public short W0 { get; private set; }
            public short W1 { get; private set; }

            public void Read(MpqFileStream stream)
            {
                W0 = stream.ReadValueS16();
                W1 = stream.ReadValueS16();
            }
        }
    }
}
