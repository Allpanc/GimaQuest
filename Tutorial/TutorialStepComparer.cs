using System.Collections.Generic;

public class TutorialStepComparer : Comparer<TutorialStep>
{
    public override int Compare(TutorialStep x, TutorialStep y)
    {
        return (x.GetIndex() > y.GetIndex()) ? 1 : -1;
    }
}