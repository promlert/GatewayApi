namespace GatewayApi.Service
{
    public class CRC16
    {

        const ushort polynomial = 0xFFFF;//0xA001;
        static readonly ushort[] table = new ushort[256];

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        static CRC16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }
        //static void Main(string[] args)
        //{
        //    byte[] pattern = new byte[] { 0x02, 0x07, 0x01, 0x03, 0x01, 0x02, 0x00, 0x34, 0x07, 0x07, 0x1C, 0x59, 0x34, 0x6F, 0xE1, 0x83, 0x00, 0x00, 0x41, 0x06, 0x06, 0x7B, 0x3C, 0xFF, 0xCF, 0x3C, 0xC0 };

        //    // http://www.ite.org/standards/1203v03-04%20Part%201%20dms2011.pdf
        //    // Page 158, CRC = 0x52ED
        //    ushort fcs = compute_fcs(pattern); // 0x52ED
        //}
    
}
