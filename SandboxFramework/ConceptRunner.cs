namespace Framework
{
    using System;

    public static class ConceptRunner
    {
        public static void Run<TConcept>() where TConcept : IConcept
        {
            TConcept concept = (TConcept)Activator.CreateInstance(typeof(TConcept));

            concept.Run();
        }
    }
}