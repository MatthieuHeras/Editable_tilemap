using UnityEngine;

public static class TilesBehaviour
{

    private static int What_disposition(bool[] neighbours)
    {
        int disposition = 0;

        // Top side
        if (!neighbours[1])
            disposition |= 128;
        else
        {
            if (neighbours[7] && !neighbours[0])
                disposition |= 8;
            if (neighbours[3] && !neighbours[2])
                disposition |= 4;
        }

        // Right side
        if (!neighbours[3])
            disposition |= 64;
        else
        {
            if (neighbours[1] && !neighbours[2])
                disposition |= 4;
            if (neighbours[5] && !neighbours[4])
                disposition |= 2;
        }

        // Bottom side
        if (!neighbours[5])
            disposition |= 32;
        else
        {
            if (neighbours[3] && !neighbours[4])
                disposition |= 2;
            if (neighbours[7] && !neighbours[6])
                disposition |= 1;
        }

        // Left side
        if (!neighbours[7])
            disposition |= 16;
        else
        {
            if (neighbours[5] && !neighbours[6])
                disposition |= 1;
            if (neighbours[1] && !neighbours[0])
                disposition |= 8;
        }

        return disposition;
    }

    private static int What_index(int disposition)
    {
        switch (disposition)
        {
            case 240: return 0;
            case 224:
            case 208:
            case 176:
            case 112: return 1;
            case 193:
            case 104:
            case 52:
            case 146: return 2;
            case 192:
            case 96:
            case 48:
            case 144: return 3;
            case 160:
            case 80: return 4;
            case 131:
            case 73:
            case 44:
            case 22: return 5;
            case 129:
            case 72:
            case 36:
            case 18: return 6;
            case 130:
            case 65:
            case 40:
            case 20: return 7;
            case 16:
            case 32:
            case 64:
            case 128: return 8;
            case 15: return 9;
            case 14:
            case 13:
            case 11:
            case 7: return 10;
            case 12:
            case 6:
            case 3:
            case 9: return 11;
            case 10:
            case 5: return 12;
            case 8:
            case 4:
            case 2:
            case 1: return 13;
            case 0: return 14;
            default: return -1;
        }
    }

    private static int What_rotation(int disposition)
    {
        switch (disposition)
        {
            case 1:
            case 3:
            case 11:
            case 32:
            case 40:
            case 36:
            case 44:
            case 96:
            case 104:
            case 224: return 1;
            case 2:
            case 6:
            case 7:
            case 64:
            case 65:
            case 72:
            case 73:
            case 192:
            case 193:
            case 208: return 2;
            case 4:
            case 5:
            case 12:
            case 14:
            case 128:
            case 130:
            case 129:
            case 131:
            case 160:
            case 144:
            case 146:
            case 176: return 3;
            default: return 0;
        }
    }
    
    public static int[] What_tile(bool[] neighbours)
    {
        int disposition = What_disposition(neighbours);
        int[] index_and_rotation = {What_index(disposition), What_rotation(disposition)};
        return index_and_rotation;
    }
}
