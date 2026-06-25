using ArcadianEngine;
using VerySeriousGame.Data;

namespace VerySeriousGame.Resources;

public class RunManager()
{
    [Export]
    public int CurrentWave = 0;

    [Export]
    public List<SpellType> UnlockedSpells = [];

    [Export]
    public Dictionary<int, SpellType> EquippedSpells = [];

    public void GenerateStartData()
    {
        SpellType[] spellTypes = Enum.GetValues<SpellType>();

        foreach (var i in Enumerable.Range(0, 8))
        {
            SpellType randomSpell;
            while (true)
            {
                randomSpell = spellTypes[Random.Shared.Next(spellTypes.Length)];

                if (!UnlockedSpells.Contains(randomSpell))
                    break;
            }

            UnlockedSpells.Add(randomSpell);
            EquippedSpells.Add(i, randomSpell);
        }
    }
}

