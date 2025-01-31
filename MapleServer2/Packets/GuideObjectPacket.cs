﻿using Maple2Storage.Types;
using MaplePacketLib2.Tools;
using MapleServer2.Constants;
using MapleServer2.Types;

namespace MapleServer2.Packets
{
    public static class GuideObjectPacket
    {
        private enum GuideObjectPacketMode : byte
        {
            Add = 0x0,
            Remove = 0x1,
            Sync = 0x2,
        }

        public static Packet Add(IFieldObject<Player> player)
        {
            PacketWriter pWriter = PacketWriter.Of(SendOp.GUIDE_OBJECT);
            pWriter.WriteEnum(GuideObjectPacketMode.Add);
            pWriter.WriteShort(player.Value.Guide.Value.Type);
            pWriter.WriteInt(player.Value.Guide.ObjectId);
            pWriter.WriteLong(player.Value.CharacterId);
            pWriter.Write(player.Value.Guide.Coord);
            pWriter.Write(player.Rotation);
            if (player.Value.Guide.Value.Type == 0)
            {
                pWriter.WriteLong();
            }

            return pWriter;
        }

        public static Packet Remove(IFieldObject<Player> player)
        {
            PacketWriter pWriter = PacketWriter.Of(SendOp.GUIDE_OBJECT);
            pWriter.WriteEnum(GuideObjectPacketMode.Remove);
            pWriter.WriteInt(player.Value.Guide.ObjectId);
            pWriter.WriteLong(player.Value.CharacterId);

            return pWriter;
        }

        public static Packet Sync(IFieldObject<GuideObject> guide, byte unk2, byte unk3, byte unk4, byte unk5, CoordS unkCoord, short unk6, int unk7)
        {
            PacketWriter pWriter = PacketWriter.Of(SendOp.GUIDE_OBJECT);
            pWriter.WriteEnum(GuideObjectPacketMode.Sync);
            pWriter.WriteInt(guide.ObjectId);
            pWriter.WriteByte(unk2);
            pWriter.WriteByte(unk3);
            pWriter.WriteByte(unk4);
            pWriter.WriteByte(unk5);
            pWriter.Write(guide.Coord.ToShort());
            pWriter.Write(unkCoord);
            pWriter.Write(guide.Rotation.ToShort());
            pWriter.WriteShort(unk6);
            pWriter.WriteInt(unk7);

            return pWriter;
        }
    }
}
