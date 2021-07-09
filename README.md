# GexSpriteRipTest
The first successful print of gex video game player sprite from binary (GEX002.LEV)

Windows 10 or Linux recommended.
If you have older Windows 10 version (19H2 or older) run the program with --vt-force argument.
Use raster fonts with 1:1 ratio if you can.

# How To Read Binary Code
* aligment map (89 03 85 04 84 04 ...)h

value > 80h. is a shift or just fill of empty space.
repeats 4 bytes (often 00 00 00 00), so it's not really shifting pixels.
It teaks the 4 bytes from bitmap.
fillment = 32 - (0x88 - mapValue) * 4

value < 80h. used bytes of bitmap * 4

* bitmap

indexed colors. 1 byte per pixel
