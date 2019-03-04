using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_test
{
    class JaratKezelo
    {
        class Jarat
        {
            public string jaratSzam { get; set; }
            public string repterHonnan { get; set; }
            public string repterHova { get; set; }
            public DateTime indulas { get; set; }
            public int keses { get; set; }

            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                this.jaratSzam = jaratSzam;
                this.repterHonnan = repterHonnan;
                this.repterHova = repterHova;
                this.indulas = indulas;
                this.keses = 0;
            }
            
        }
        List<Jarat> jaratok = new List<Jarat>();

        
        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas) {
            var j = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(j);
        }

        public void Keses(string jaratSzam, int keses) {
            foreach (var e in jaratok) {
                if (jaratSzam.Equals(e.jaratSzam)) {
                    if ((e.keses + keses) < 0)
                    {
                        throw new NegativKesesException(keses);
                    }
                    else {
                        e.keses = keses;
                    }
                }
            }
        }

       public  class NegativKesesException : Exception {
            public NegativKesesException(int keses) : base("Baj van!" + keses)
            { }
        }

        public DateTime MikorIndul(string jaratSzam) {
            foreach (var gep in jaratok)
            {
                if (jaratSzam.Equals(gep.jaratSzam)) {
                    return gep.indulas.AddMinutes(gep.keses);
                }

            }
            throw new ArgumentException("Ilyen járat nem létezik!");
        }

        public class JaratokRepuloterrolException : Exception
        {
            public JaratokRepuloterrolException(string repterHonnan) : base("Baj van repülőtér!" + repterHonnan)
            { }
        }

        public List<string> JaratokRepuloterrol(string repter) {
            List<string> jaratokLista = new List<string>();
            foreach (var e in jaratok) {
                if (repter.Equals(e.repterHonnan)) {
                    jaratokLista.Add(e.jaratSzam);
                }
            }
            if (jaratokLista.Count == 0) {
                throw new JaratokRepuloterrolException(repter);
            }
            return jaratokLista;
        }

    }
}
