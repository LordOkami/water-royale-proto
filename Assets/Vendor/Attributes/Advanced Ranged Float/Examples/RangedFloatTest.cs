using UnityEngine;

public class AdvancedRangedFloatTest : ScriptableObject
{
    [Header("Ranged Float Without Attribute")]
    public AdvancedRangedFloat exampleOne;

    [Header("Ranged Float With Locked Limits")]
    [AdvancedRangedFloat(0, 1, AdvancedRangedFloatAttribute.RangeDisplayType.LockedRanges)]
    public AdvancedRangedFloat exampleTwo;

    [Header("Ranged Float With Editable Limits")]
    [AdvancedRangedFloat(0, 1, AdvancedRangedFloatAttribute.RangeDisplayType.EditableRanges)]
    public AdvancedRangedFloat exampleThree;

    [Header("Ranged Float With Hidden (But Locked) Limits")]
    [AdvancedRangedFloat(0, 1, AdvancedRangedFloatAttribute.RangeDisplayType.HideRanges)]
    public AdvancedRangedFloat exampleFour;
}