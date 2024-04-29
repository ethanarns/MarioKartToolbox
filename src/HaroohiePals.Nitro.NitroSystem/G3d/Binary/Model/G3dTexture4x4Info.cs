﻿using HaroohiePals.IO;
using HaroohiePals.IO.Serialization;

namespace HaroohiePals.Nitro.NitroSystem.G3d.Binary.Model;

[FieldAlignment(FieldAlignment.FieldSize)]
public sealed class G3dTexture4x4Info
{
    public G3dTexture4x4Info() { }

    public G3dTexture4x4Info(EndianBinaryReaderEx er)
    {
        er.ReadObject(this);

        long curPos = er.JumpRelative(TextureDataOffset);
        TextureData = er.Read<byte>(TextureDataSize << 3);

        er.JumpRelative(TexturePaletteIndexDataOffset);
        TexturePaletteIndexData = er.Read<byte>(TextureDataSize << 2);

        er.BaseStream.Position = curPos;
    }

    public void Write(EndianBinaryWriterEx er)
    {
        TextureDataSize = (ushort)(TextureData.Length + 7 >> 3);
        er.WriteObject(this);
    }

    public uint VramKey;
    public ushort TextureDataSize;
    public ushort DictionaryOffset;
    public ushort Flag;

    public uint TextureDataOffset;
    public uint TexturePaletteIndexDataOffset;

    [Ignore]
    public byte[] TextureData, TexturePaletteIndexData;
}