using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public class ScoreModuleInfo
    {
        public bool Active { get; private set; }
        public char charActive { get { if (Active == true) return 'y'; else return 'n'; } private set { } }
        public int MainMultiplicator { get; private set; }
        public string Name { get; private set; }
        class SubMultiplicator
        {
            public string name;
            public int multiplicationValue;
        }


        public ScoreModuleInfo(int mainMult,string name,LinkedList<string> names, LinkedList<int> values, bool state)
        {
            Active = state;
            Name = name;
            MainMultiplicator = mainMult;
            subMultiplicators = new LinkedList<SubMultiplicator>();
            for(int i =0; i<Math.Max(names.Count, values.Count); i++)
            {

                SubMultiplicator s = new SubMultiplicator();
                s.name = names.ElementAt(i);
                s.multiplicationValue = values.ElementAt(i);
                subMultiplicators.AddLast(s);
            }
        }
        
        private LinkedList<SubMultiplicator> subMultiplicators;
        public int subMultiplicatorsSize { get { return subMultiplicators.Count; } private set { } }
        public int getMultiplicatorAt(string argName)
        {
            foreach (SubMultiplicator smp in subMultiplicators)
            {
                if(smp.name == argName)
                {
                    return smp.multiplicationValue;
                }
            }
            return 0;
        }

    }
}
