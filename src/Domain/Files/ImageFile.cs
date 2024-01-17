﻿using System;
using HeyRed.Mime;
using Ardalis.GuardClauses;
using Blanche.Domain.Common;

namespace Blanche.Domain.Files
{
    public class ImageFile : ValueObject
    {
    public Uri BasePath { get; }
    public Guid Identifier { get; }
    public string Extension { get; }

    public string Filename => $"{Identifier}.{Extension}";
    public Uri FileUri => new Uri($"{BasePath}/{Filename}");

    public ImageFile(Uri basePath, string contentType)
    {
        Identifier = Guid.NewGuid();
        Extension = MimeTypesMap.GetExtension(contentType).ToLower();
        BasePath = Guard.Against.Null(basePath, nameof(basePath));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Extension.ToLower();
        yield return Identifier;
        yield return BasePath;
    }
}
}
