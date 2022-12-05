﻿using Challenge5;

var input = await File.ReadAllLinesAsync("./Input.txt");

// Create list of 9 empty crate stacks
var crateStacks = new List<CrateStack>(
    Enumerable.Range(1, 9)
        .Select(_ => new CrateStack()));

// Add crates to stacks.  We need to work bottom-up not top-down, hence the .Reverse()
// Should probably refactor this out to a CrateSetupProcessor class or something, but hey ho
foreach (var line in input.Where(i => i.StartsWith('[')).Reverse())
{
    // Not too keen on this implementation; could possibly do something with regex or string.Split
    // but we need to keep track of which stack each crate in the line is for, and several of those
    // could be blanks so for now just gone for simple positional extraction
    var crateIds = line.ToCharArray(); 
    for (var i = 0; i < 9; i++)
    {
        var crateIdIndex = i * 4 + 1; // Bit of maths to get to the relevant part of the char[]
        var crateId = crateIds[crateIdIndex]; 

        if (crateId != ' ') // deals with no crates in a stack for this line item
        {
            crateStacks[i].AddCrate(new Crate(crateId));
        }
    }
}

// Process all the moves
foreach (var line in input.Where(i => i.StartsWith("move")))
{
    var move = new Move(line);
    move.ApplyMoveOperations(crateStacks);
}

// Write out final state
for (var i = 0; i < 9; i++)
{
    Console.WriteLine($"Top of stack {i+1} = {crateStacks[i].Crates.Peek().Identifier}");
}
