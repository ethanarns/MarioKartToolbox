﻿using HaroohiePals.IO.Compression;
using NUnit.Framework;
using System;

namespace HaroohiePals.IO.Test.Compression;

class Yaz0CompressionAlgorithmTests
{
    [Test]
    public void Yaz0CompressionAlgorithm_Decompress_DecompressesData()
    {
        // Arrange
        var yaz0 = new Yaz0CompressionAlgorithm();

        // Act
        var result = yaz0.Decompress(Yaz0CompressedData);

        // Assert
        Assert.That(result, Is.EqualTo(UncompressedData));
    }

    [Test]
    public void Yaz0CompressionAlgorithm_Compress_CompressesData([Values] bool useLookAhead)
    {
        // Arrange
        var yaz0 = new Yaz0CompressionAlgorithm(useLookAhead);

        // Act
        var result = yaz0.Compress(UncompressedData);

        // Assert
        Assert.That(yaz0.Decompress(result), Is.EqualTo(UncompressedData));
    }

    [Test]
    public void Yaz0CompressionAlgorithm_CompressWithLongRun_CompressesData([Values] bool useLookAhead)
    {
        // Arrange
        var yaz0 = new Yaz0CompressionAlgorithm(useLookAhead);
        var data = new byte[4096];
        Array.Fill(data, (byte)0xAA, 5, 300);
        for (int i = 0; i < 256; i++)
        {
            data[1024 + i] = (byte)i;
        }

        // Act
        var result = yaz0.Compress(data);

        // Assert
        Assert.That(yaz0.Decompress(result), Is.EqualTo(data));
    }

    private static readonly byte[] UncompressedData =
    {
        0x4E, 0x41, 0x52, 0x43, 0xFE, 0xFF, 0x00, 0x01, 0xFC, 0x01, 0x00, 0x00,
        0x10, 0x00, 0x03, 0x00, 0x42, 0x54, 0x41, 0x46, 0x14, 0x00, 0x00, 0x00,
        0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x91, 0x01, 0x00, 0x00,
        0x42, 0x54, 0x4E, 0x46, 0x3C, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x03, 0x00, 0x2F, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0xF0,
        0x30, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0xF0, 0x83, 0x46, 0x6F, 0x6F,
        0x01, 0xF0, 0x83, 0x42, 0x61, 0x72, 0x02, 0xF0, 0x09, 0x64, 0x75, 0x6D,
        0x6D, 0x79, 0x2E, 0x74, 0x78, 0x74, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF,
        0x47, 0x4D, 0x49, 0x46, 0x9C, 0x01, 0x00, 0x00, 0x41, 0x63, 0x63, 0x6F,
        0x72, 0x64, 0x69, 0x6E, 0x67, 0x20, 0x74, 0x6F, 0x20, 0x61, 0x6C, 0x6C,
        0x20, 0x6B, 0x6E, 0x6F, 0x77, 0x6E, 0x20, 0x6C, 0x61, 0x77, 0x73, 0x0D,
        0x0A, 0x6F, 0x66, 0x20, 0x61, 0x76, 0x69, 0x61, 0x74, 0x69, 0x6F, 0x6E,
        0x2C, 0x0D, 0x0A, 0x0D, 0x0A, 0x20, 0x20, 0x0D, 0x0A, 0x74, 0x68, 0x65,
        0x72, 0x65, 0x20, 0x69, 0x73, 0x20, 0x6E, 0x6F, 0x20, 0x77, 0x61, 0x79,
        0x20, 0x61, 0x20, 0x62, 0x65, 0x65, 0x0D, 0x0A, 0x73, 0x68, 0x6F, 0x75,
        0x6C, 0x64, 0x20, 0x62, 0x65, 0x20, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74,
        0x6F, 0x20, 0x66, 0x6C, 0x79, 0x2E, 0x0D, 0x0A, 0x0D, 0x0A, 0x20, 0x20,
        0x0D, 0x0A, 0x49, 0x74, 0x73, 0x20, 0x77, 0x69, 0x6E, 0x67, 0x73, 0x20,
        0x61, 0x72, 0x65, 0x20, 0x74, 0x6F, 0x6F, 0x20, 0x73, 0x6D, 0x61, 0x6C,
        0x6C, 0x20, 0x74, 0x6F, 0x20, 0x67, 0x65, 0x74, 0x0D, 0x0A, 0x69, 0x74,
        0x73, 0x20, 0x66, 0x61, 0x74, 0x20, 0x6C, 0x69, 0x74, 0x74, 0x6C, 0x65,
        0x20, 0x62, 0x6F, 0x64, 0x79, 0x20, 0x6F, 0x66, 0x66, 0x20, 0x74, 0x68,
        0x65, 0x20, 0x67, 0x72, 0x6F, 0x75, 0x6E, 0x64, 0x2E, 0x0D, 0x0A, 0x0D,
        0x0A, 0x20, 0x20, 0x0D, 0x0A, 0x54, 0x68, 0x65, 0x20, 0x62, 0x65, 0x65,
        0x2C, 0x20, 0x6F, 0x66, 0x20, 0x63, 0x6F, 0x75, 0x72, 0x73, 0x65, 0x2C,
        0x20, 0x66, 0x6C, 0x69, 0x65, 0x73, 0x20, 0x61, 0x6E, 0x79, 0x77, 0x61,
        0x79, 0x0D, 0x0A, 0x0D, 0x0A, 0x20, 0x20, 0x0D, 0x0A, 0x62, 0x65, 0x63,
        0x61, 0x75, 0x73, 0x65, 0x20, 0x62, 0x65, 0x65, 0x73, 0x20, 0x64, 0x6F,
        0x6E, 0x27, 0x74, 0x20, 0x63, 0x61, 0x72, 0x65, 0x0D, 0x0A, 0x77, 0x68,
        0x61, 0x74, 0x20, 0x68, 0x75, 0x6D, 0x61, 0x6E, 0x73, 0x20, 0x74, 0x68,
        0x69, 0x6E, 0x6B, 0x20, 0x69, 0x73, 0x20, 0x69, 0x6D, 0x70, 0x6F, 0x73,
        0x73, 0x69, 0x62, 0x6C, 0x65, 0x2E, 0x0D, 0x0A, 0x0D, 0x0A, 0x20, 0x20,
        0x0D, 0x0A, 0x59, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x2C, 0x20, 0x62, 0x6C,
        0x61, 0x63, 0x6B, 0x2E, 0x20, 0x59, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x2C,
        0x20, 0x62, 0x6C, 0x61, 0x63, 0x6B, 0x2E, 0x0D, 0x0A, 0x59, 0x65, 0x6C,
        0x6C, 0x6F, 0x77, 0x2C, 0x20, 0x62, 0x6C, 0x61, 0x63, 0x6B, 0x2E, 0x20,
        0x59, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x2C, 0x20, 0x62, 0x6C, 0x61, 0x63,
        0x6B, 0x2E, 0x0D, 0x0A, 0x0D, 0x0A, 0x20, 0x20, 0x0D, 0x0A, 0x4F, 0x6F,
        0x68, 0x2C, 0x20, 0x62, 0x6C, 0x61, 0x63, 0x6B, 0x20, 0x61, 0x6E, 0x64,
        0x20, 0x79, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x21, 0x0D, 0x0A, 0x4C, 0x65,
        0x74, 0x27, 0x73, 0x20, 0x73, 0x68, 0x61, 0x6B, 0x65, 0x20, 0x69, 0x74,
        0x20, 0x75, 0x70, 0x20, 0x61, 0x20, 0x6C, 0x69, 0x74, 0x74, 0x6C, 0x65,
        0x2E, 0xFF, 0xFF, 0xFF
    };

    private static readonly byte[] Yaz0CompressedData =
    {
        0x59, 0x61, 0x7A, 0x30, 0x00, 0x00, 0x01, 0xFC, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0xFF, 0x4E, 0x41, 0x52, 0x43, 0xFE, 0xFF, 0x00,
        0x01, 0xFF, 0xFC, 0x01, 0x00, 0x00, 0x10, 0x00, 0x03, 0x00, 0xFF, 0x42,
        0x54, 0x41, 0x46, 0x14, 0x00, 0x00, 0x00, 0x2F, 0x10, 0x0E, 0x30, 0x01,
        0x91, 0x10, 0x17, 0x42, 0x54, 0x4E, 0x46, 0xAE, 0x3C, 0x10, 0x13, 0x18,
        0x30, 0x13, 0x03, 0x00, 0x2F, 0x40, 0x1F, 0xDF, 0xF0, 0x30, 0x50, 0x07,
        0x83, 0x46, 0x6F, 0x6F, 0x01, 0xFF, 0xF0, 0x83, 0x42, 0x61, 0x72, 0x02,
        0xF0, 0x09, 0xFF, 0x64, 0x75, 0x6D, 0x6D, 0x79, 0x2E, 0x74, 0x78, 0xBF,
        0x74, 0x10, 0x44, 0xFF, 0xFF, 0xFF, 0x47, 0x4D, 0x49, 0xDF, 0x46, 0x9C,
        0x10, 0x5B, 0x41, 0x63, 0x63, 0x6F, 0x72, 0xFF, 0x64, 0x69, 0x6E, 0x67,
        0x20, 0x74, 0x6F, 0x20, 0xFF, 0x61, 0x6C, 0x6C, 0x20, 0x6B, 0x6E, 0x6F,
        0x77, 0xFF, 0x6E, 0x20, 0x6C, 0x61, 0x77, 0x73, 0x0D, 0x0A, 0xFF, 0x6F,
        0x66, 0x20, 0x61, 0x76, 0x69, 0x61, 0x74, 0xFF, 0x69, 0x6F, 0x6E, 0x2C,
        0x0D, 0x0A, 0x0D, 0x0A, 0xFF, 0x20, 0x20, 0x0D, 0x0A, 0x74, 0x68, 0x65,
        0x72, 0xFF, 0x65, 0x20, 0x69, 0x73, 0x20, 0x6E, 0x6F, 0x20, 0xFF, 0x77,
        0x61, 0x79, 0x20, 0x61, 0x20, 0x62, 0x65, 0xFF, 0x65, 0x0D, 0x0A, 0x73,
        0x68, 0x6F, 0x75, 0x6C, 0xBE, 0x64, 0x10, 0x0B, 0x20, 0x61, 0x62, 0x6C,
        0x65, 0x20, 0x4C, 0xF7, 0x66, 0x6C, 0x79, 0x2E, 0x60, 0x34, 0x49, 0x74,
        0x73, 0xDD, 0x20, 0x77, 0x10, 0x64, 0x73, 0x20, 0x61, 0x10, 0x3C, 0x74,
        0xF9, 0x6F, 0x6F, 0x20, 0x73, 0x6D, 0x20, 0x6C, 0x10, 0x73, 0x67, 0xFB,
        0x65, 0x74, 0x0D, 0x0A, 0x69, 0x10, 0x1F, 0x66, 0x61, 0xFD, 0x74, 0x20,
        0x6C, 0x69, 0x74, 0x74, 0x10, 0x3D, 0x62, 0xFF, 0x6F, 0x64, 0x79, 0x20,
        0x6F, 0x66, 0x66, 0x20, 0x7F, 0x10, 0x6C, 0x20, 0x67, 0x72, 0x6F, 0x75,
        0x6E, 0x64, 0x4B, 0x70, 0x4A, 0x54, 0x10, 0x12, 0x10, 0x71, 0x2C, 0x10,
        0x1F, 0x20, 0x63, 0xF7, 0x6F, 0x75, 0x72, 0x73, 0x10, 0x0A, 0x66, 0x6C,
        0x69, 0xB3, 0x65, 0x10, 0x5A, 0x6E, 0x79, 0x10, 0x90, 0x60, 0xA7, 0x62,
        0x65, 0xF7, 0x63, 0x61, 0x75, 0x73, 0x30, 0x2B, 0x73, 0x20, 0x64, 0xFD,
        0x6F, 0x6E, 0x27, 0x74, 0x20, 0x63, 0x10, 0x7C, 0x0D, 0xEF, 0x0A, 0x77,
        0x68, 0x10, 0x68, 0x68, 0x75, 0x6D, 0x61, 0xDD, 0x6E, 0x73, 0x10, 0x5F,
        0x69, 0x6E, 0x6B, 0x20, 0xCC, 0x69, 0xFC, 0x6D, 0x70, 0x6F, 0x73, 0x73,
        0x69, 0x10, 0xBA, 0x70, 0xB3, 0xFF, 0x59, 0x65, 0x6C, 0x6C, 0x6F, 0x77,
        0x2C, 0x20, 0xFE, 0x62, 0x6C, 0x61, 0x63, 0x6B, 0x2E, 0x20, 0xC0, 0x0E,
        0x39, 0x00, 0x1E, 0x0F, 0x41, 0x2C, 0x4F, 0x6F, 0x68, 0x50, 0x40, 0x10,
        0x9D, 0x64, 0xDF, 0x20, 0x79, 0x30, 0x52, 0x21, 0x0D, 0x0A, 0x4C, 0x65,
        0xFF, 0x74, 0x27, 0x73, 0x20, 0x73, 0x68, 0x61, 0x6B, 0x79, 0x11, 0x4A,
        0x74, 0x20, 0x75, 0x70, 0x11, 0x46, 0x40, 0xFB, 0x2E, 0x00, 0x11, 0x9B
    };
}