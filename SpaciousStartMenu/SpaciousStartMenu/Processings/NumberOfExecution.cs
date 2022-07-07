using System;

namespace SpaciousStartMenu.Processings
{
    internal class NumberOfExecution
    {
        private int _execCnt = 0;
        private readonly Action _action;

        public NumberOfExecution(Action act) => _action = act;

        public void RunOnlyOnce()
        {
            if (0 < _execCnt)
            {
                return;
            }

            _action();
            _execCnt++;
        }
    }
}
