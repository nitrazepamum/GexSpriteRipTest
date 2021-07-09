/*static void splitDataToParts(Part[] parts)
        {
            //[0] map length [1] bitmap length
            int[] length(int start, Part part) {
                int width = part.width;
                int bytes = 0;
                int mapLen = 0;
                for (int i = 0; start + i < mapVal.Length; i++)
                {
                    mapLen = i;
                    int cuMapVal = mapVal[start + i];
                    bytes += (cuMapVal > 0x70 ? 4 : cuMapVal * 4);
                    if (bytes >= width) break;
                }
                return new int[2] { mapLen, bytes };
            }

            int start = 0;
            int bitmapIndex = 0;
            foreach (Part part in parts)
            {
                int[] res = length(start, part);
                part.map = new short[res[0]];
                part.bitmap = new short[res[1]];
                for (int i = 0; i < res[0]; i++)
                {
                    part.map[i] = mapVal[start + i];
                }
                for (int i = 0; i < res[1]; i++)
                {
                    part.bitmap[i] = bitmapVal[start + i]
                }
                    
            }

        }
        */