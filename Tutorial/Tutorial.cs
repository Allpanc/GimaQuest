using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    
    #region "Fields"

    [SerializeField] protected string _name;
    [SerializeField] protected List<TutorialStep> _steps;

    public int _stepsCount { get; private set; }
    public int _currentStepIndex { get; protected set; } = 0;
    public bool _isCompleted { get; protected set; }

    #endregion

    protected virtual void Awake() => _stepsCount = _steps.Count;

    protected virtual void Start()
    {
        if (_steps.Count == 0)
            FindSteps();
    }

    public void CompleteStep()
    {
        if (_currentStepIndex < _steps.Count)
        {
            //Debug.Log("Tutorial " + _name + "   step " + _currentStepIndex + " completed");
            ExecuteStep();
            _steps[_currentStepIndex].SetCompleted(true);
            _currentStepIndex++;
        }
        else
            _isCompleted = true;
    }

    protected void FindSteps()
    {
        TutorialStep[] tutorialParts = Resources.FindObjectsOfTypeAll<TutorialStep>();
        TutorialStepComparer comparer = new TutorialStepComparer();

        foreach (TutorialStep step in tutorialParts)
            if (step.GetTutorialName() == _name)
                _steps.Add(step);

        _steps.Sort(comparer);
    }

    protected virtual void ExecuteStep(){}
}
