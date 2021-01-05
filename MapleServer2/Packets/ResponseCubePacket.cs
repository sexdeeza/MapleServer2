using MaplePacketLib2.Tools;
using MapleServer2.Constants;
using MapleServer2.Types;
using MapleServer2.Tools;
using MapleServer2.Servers.Game;

namespace MapleServer2.Packets
{
    public static class ResponseCubePacket
    {
        private enum Mode : byte
        {
            Pickup = 0x11,
            Drop = 0x12
        }

        public static Packet Pickup(GameSession session, int weaponId, byte[] coords)
        {
            PacketWriter pWriter = PacketWriter.Of(SendOp.RESPONSE_CUBE);

            pWriter.WriteByte((byte) Mode.Pickup);
            pWriter.WriteZero(1);
            pWriter.WriteInt(session.FieldPlayer.ObjectId);
            pWriter.Write(coords);
            pWriter.WriteZero(1);
            pWriter.WriteInt(weaponId);
            pWriter.WriteInt(GuidGenerator.Int()); // Item uid

            return pWriter;
        }

        public static Packet Drop(IFieldObject<Player> player)
        {
            PacketWriter pWriter = PacketWriter.Of(SendOp.RESPONSE_CUBE);

            pWriter.WriteByte((byte) Mode.Drop);
            pWriter.WriteZero(1);
            pWriter.WriteInt(player.ObjectId);

            return pWriter;
        }
    }
}
