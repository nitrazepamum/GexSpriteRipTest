using System;
using System.Drawing;
using VT100;

namespace GexExportTest1
{
    class Program
    {
        static bool stopRequest = false;
        static int line = 0;
        static int iteration = 0;

        //temp
        static int partWidth = 32;

        //            0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 83 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99 00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55
        static string map = "89 03 85 04 84 04 84 04 84 05 83 05 83 05 82 06 82 06 82 06 83 05 83 05 85 03 86 02 86 02 86 02 86 03 85 01 82 85 04 84 04 84 36 82 04 84 04 84 04 84 04 84 04 83 05 83 05 83 05 83 05 83 05 83 01 82 02 83 05 83 05 83 05 83 02 82 01 83 02 82 01 83 02 82 01 83 02 82 01 82 82 11 F4 01 85 01 84 02 84 01 85 01 85 01 85 03 83 03 83 03 82 04 82 04 82 04 82 04 82 04 82 04 82 02 84 02 83 02 82 04 82 04 82 04 82 04 82 03 83 03 83 01 85 01 85 01 85 01 85 02 84 01 85 85 06 82";
        static string bitmap = "00 00 00 00 00 00 00 EA FE EA EA FD EA B0 B0 00 00 00 00 00 00 00 93 B6 B5 FD FD EA FD FD FD FD B8 B0 00 00 00 00 00 00 00 00 8D B6 02 E6 EA FD FD FD FD FD FD D1 AD 00 00 00 00 00 00 7F 93 ED 0F 0B EA FD FD FD FB FD FD F7 AA B4 00 00 00 00 00 7F 8D B5 6B 95 FD FD FD F5 E5 FD FB E1 7E A8 BB 00 00 00 00 00 00 00 00 92 92 D1 FA FD FD F7 E3 CE FD FB F6 C7 71 AF BA 00 00 00 00 00 00 00 E8 E1 FD FD FB F6 E2 C2 D5 FD FB D2 89 3D 72 A5 B1 A0 00 00 00 00 00 00 00 00 FD FD FD FD FB F6 D5 89 87 F0 FB D6 44 40 41 44 70 A3 B0 A7 00 00 00 00 00 00 00 D7 F0 F4 E4 DB C6 45 C6 F0 F5 CC 45 41 43 41 41 44 6F 7C A9 A7 00 00 00 00 00 00 00 00 3B 46 46 48 DF FB E3 89 41 3E 40 41 41 3E 3E 89 70 7F A5 B2 00 00 00 00 00 00 00 E0 C9 44 41 44 43 41 2C 2C 2C 2C 2C C9 73 8E A3 58 00 00 00 00 00 00 40 3C 40 43 41 00 00 00 00 00 27 2C 3D D4 8E 8E 59 B2 00 00 00 00 00 00 00 00 00 27 8B D9 8E 8E A3 AD A0 00 00 00 00 00 D0 D9 8F 8F A3 AD AC 00 00 00 00 00 CD D1 8F 81 A5 AD AD 00 00 00 00 00 D2 95 7F 7A 7A 7A 7A A3 00 00 00 00 D7 91 7F 79 79 7A 82 7C 7A 00 00 00 00 00 00 00 D2 8F 7F 79 79 79 7A 7A 00 00 00 00 CB 8F 8E 6E 75 77 79 79 79 79 79 79 7A 00 00 00 00 00 00 00 BF 90 8E 8E 2D 27 20 2D 20 22 5D 79 A6 7A 00 00 00 00 00 00 45 8C 8E 8F 8E 60 12 10 00 00 5D 7A EA A6 7C 00 00 00 00 00 00 3B 47 45 43 00 00 00 00 2C 3D 3D 45 8B 8E 8E 8E 81 6A 12 10 00 00 6D 81 B7 7C 00 00 00 00 00 00 00 00 40 41 41 41 3E 3E 3F 3F 3F 41 BF 72 8E 8E 81 A5 0C 12 00 00 5C 77 B8 7A 00 00 00 00 47 48 45 47 43 40 41 41 3F 3F 3F 3F 3F 3F 86 6F 8E 8E 8E A3 A1 12 00 00 00 75 82 A6 95 00 00 00 00 00 47 47 47 41 40 3F 3E 3E 3D 3D 3D 3D 45 8B 73 8E 8E A6 AA 4B 00 00 00 60 95 FA FD 00 00 00 48 48 45 47 47 47 43 41 00 00 00 00 00 00 3C 84 70 74 8E 81 A5 4C 13 00 00 00 F5 FD FD 00 00 00 45 00 47 45 43 43 00 00 00 00 00 00 00 00 3B 86 65 73 8E 7F A3 BC 4F 00 00 FD FD FD FD 00 00 00 00 88 45 00 00 00 00 00 00 00 00 41 83 73 95 95 B7 BA 59 00 00 F5 E5 F6 FB 00 00 00 00 00 00 3B 44 61 92 E9 FB B5 B0 97 00 F5 00 D8 F6 00 00 00 00 00 00 3A 3E 2D 6C E9 FA E1 AD 4C 00 D8 00 E1 C8 00 00 00 00 00 00 27 3C 3D 1E 7F E9 F7 B8 BA 00 00 CD 00 F5 00 00 00 00 00 1A 1A 2C 2C 1A 5C 92 FD E6 59 31 00 00 00 F5 00 00 00 00 00 00 00 79 7A 5A 1F 1F 2C 1F 1F 7C FC FD B8 A9 08 00 00 CD 00 00 00 00 00 00 7A 79 79 6D 1F 1F 2C 2C 27 75 95 FD FA B0 31 11 00 00 00 00 00 00 00 77 79 79 79 6C 1F 00 00 3C 3B 5F 7F FD FB E9 9D 11 08 9C 00 00 00 00 00 78 79 79 75 5F 00 00 00 00 3C 3D 7A D1 F7 FB 88 0F 1C 30 00 00 00 00 75 79 79 61 2D 00 00 00 00 00 00 3C 5B 8E E8 F7 D2 17 1B 1B 00 00 00 00 22 79 7F D1 00 00 00 00 1F 77 95 E1 F7 44 17 17 00 00 00 00 00 75 7F D1 F5 00 00 00 00 00 00 00 00 5C 81 95 E9 F7 BF 17 00 00 00 00 00 5B 7C 92 E1 00 00 00 00 00 00 00 00 00 5E 81 92 E9 FD D8 00 00 00 00 00 5A 7A 81 E9 F5 00 00 00 00 00 00 00 00 00 22 7F 91 E9 FD 00 00 00 00 00 21 79 7F E8 F6 00 00 00 00 00 00 22 80 92 FA 00 00 00 00 00 22 6D 7F E8 F6 00 00 00 00 00 00 1B 22 7F E8 00 00 00 00 00 22 60 83 D9 F5 D8 00 00 00 00 00 00 1F 91 E1 00 00 00 00 D0 C3 E7 E7 DE F5 E2 00 00 00 00 00 FD FD FB FB 00 00 00 00 FD FB FD FD FB F5 DD 00 00 00 00 00 00 FD FD FB FD FD DB C8 00 00 00 00 00 00 00 FD EE DB FD F8 48 3C 47 C3 C3 C8 C8 00 00 00 00 00 00 D5 8A C8 E7 45 00 00 00 00 00 00 00 00 88 47 45 47 43 00 00 00 00 40 40 00 00 00 00 00 00 00 00 B7 00 00 00 00 00 00 B8 2D 00 00 00 00 00 00 00 00 00 A6 62 00 00 00 00 00 00 00 00 00 B0 71 00 00 00 00 00 AD 82 2D 00 00 00 00 00 B0 74 00 00 00 00 00 AD A6 64 00 00 00 00 00 FD 00 00 00 00 00 00 00 B0 8E 3D 00 00 00 00 00 FD 00 00 00 00 00 00 00 AA 74 3D 00 00 00 00 00 FD F7 00 00 00 00 00 00 00 00 00 AD 82 65 00 00 00 00 00 00 FD F6 00 00 00 00 00 00 00 00 00 B0 8E 83 00 00 00 00 00 00 F5 CD F6 00 00 00 00 00 00 00 AD AA 8E 5F 00 00 00 00 00 00 E5 F6 E1 F7 00 00 00 00 00 00 AD 82 74 3D 00 00 00 00 00 00 00 F5 D6 C3 00 00 00 00 00 00 B0 92 6F 00 00 00 00 00 00 00 00 D8 F5 00 00 00 00 00 00 AD AB 8F 83 00 00 00 00 00 00 00 00 40 00 00 00 00 00 00 00 B0 92 73 3D 00 00 00 00 00 00 00 AD AB 8F 62 28 00 00 00 00 00 00 00 00 00 00 AD B0 8E 65 25 00 00 00 00 B0 BE BD 00 00 00 00 00 00 AD AD B0 92 70 1F 0D 00 00 00 00 2F BC BD B8 B0 B0 B0 B0 B5 B0 AA 8E 65 27 0D 00 00 00 00 00 1B 29 EC B8 B8 B8 B8 B8 B8 82 72 2D 25 0D 00 00 00 00 00 00 25 17 83 D1 E9 E8 95 90 65 20 25 26 2A 00 00 00 00 00 00 00 27 19 1D 1F 60 5F 20 27 25 28 2A 00 00 00 00 00 F6 3D 29 29 29 29 29 35 35 00 00 00 00 00 00 00 FD F6 40 3A 00 00 00 00 FD FD FB 00 00 00 00 00 FD FD FD 00 00 00 00 00 FB FB FD FD 00 00 00 00 BF E1 FB FD F6 00 00 00 00 00 00 00 3C 3C 47 48 00 00 00 00";
        static string[] mapValues = map.Split(" ");
        static string[] pixels = bitmap.Split(" ");

        static int iPixel = 0;
        static int iRowChar = 0;

        static Palettes.Palette defaultPalette = new Palettes.gexPalette();


        static short mapValueOf(int index) {
            return Convert.ToInt16(mapValues[index], 16);
        }

        //if break returns true
        static bool wrap()
        {
            // | second half of sprtie width change 
            // v for test purpose
            if (line == 49 && iRowChar == 1)
            {
                partWidth = 24;
            }

            if (iRowChar >= partWidth)
            {
                Console.WriteLine("\t\t Line: {0}, map_i: {1}", line++, iteration);
                iRowChar = 0;
                return true;
            }
            return false;
        }

        //Prints pixel with given palette with auto wraping
        static void getAndPrintPixel(int iPixel, Palettes.Palette palette)
        {
            //out of index fix
            if (iPixel + 1 >= pixels.Length)
            {
                stopRequest = true;
            }
            if (stopRequest) return;

            string byteValue = pixels[iPixel];

            if (byteValue != "00")
            {
                byte colorIndex = (byte)Convert.ToInt16(byteValue, 16);
                Color pixelColor = palette.getColor(colorIndex);
                printSinglePixel(pixelColor);
            }
            else Console.Write(" ");

            iRowChar++;
            wrap();
        }
        static void printSinglePixel(Color color)
        {
            VTConsole.setBackgroundColor(color);
            Console.Write(" ");
            VTConsole.resetBackgroundColor();
        }

        /// <summary>
        /// important!
        /// every 0x80+ repeat 4 bytes (often 00 00 00 00).
        /// That's mean that's not really shifting
        /// </summary>
        /// <param name="mapValue"></param>
        static void shiftPixels(Int16 mapValue){

            int shift = (0x88 - mapValue) * 4; // one of the most imporant things!
            shift = 32 - shift;

            for (int j = 0; j < shift; j++)
            {
                //repeat 4 bytes (can I call it a padding?)
                getAndPrintPixel(iPixel + j % 4, defaultPalette);
                if (stopRequest) return;
            }
            iPixel += 4;
    }

        static void printPixels()
        {
            //pixels per row
            int pixelsPerLine = mapValueOf(iteration) * 4; // imporant!
            
            //print pixels
            for (int j = 0; j < pixelsPerLine; j++)
            {
                getAndPrintPixel(iPixel, defaultPalette);
                if (stopRequest) return;
                iPixel++;
            }
        }

        static int Main(string[] args)
        {
            //Start arguments
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--vt-force":
                        VTConsole.enable();
                        break;
                }
            }
         
            //Start of Program
            for (int i = 0; i < mapValues.Length; i++)
            {
                iteration = i;


                short mapValue = mapValueOf(i);


                // if lower than 10 print pixels // important!
                if (mapValue < 0x70)
                {
                    printPixels();
                }
                // if greater than 9 shift pixels // important!
                else
                {
                    shiftPixels(mapValue);
                }
                if (stopRequest) return 0;

                
            }
            return 0;
        }
    }
}
