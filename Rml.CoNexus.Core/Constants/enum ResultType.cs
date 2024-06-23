﻿namespace Rml.CoNexus.Core.Constants;

[Flags]
public enum ResultType : byte
{
    UNKNOWN,

    GROUP = 1,
    INDIVIDUAL = 2,
    CONSENSUS = 4,

    ANONYMOUS = 0x10
};
