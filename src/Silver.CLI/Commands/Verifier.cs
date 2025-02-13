﻿namespace Silver.CLI.Commands;

using Silver.CLI.Core;
using static Program;
internal class VerifierCmd : Command
{
    public static void Verify(string path, string? classPattern, string? methodPattern, string? output)
    {
        ExitIfFileNotExists(path);
        if (!Verifier.Verify(path, classPattern, methodPattern, output))
        {
            Exit(ExitResult.NOT_FOUND);
        }
        else
        {
            Exit(ExitResult.SUCCESS);
        }
    }


}

