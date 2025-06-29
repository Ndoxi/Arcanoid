using App.Gameplay;
using strange.extensions.signal.impl;

namespace App.Signals
{
    public class CompleteLevelSignal : Signal<LevelProgressTracker.LevelResult> { }
}