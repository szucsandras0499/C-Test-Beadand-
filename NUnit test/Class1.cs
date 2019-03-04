using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUnit_test
{
    [TestFixture]
    public class Class1
    {

        JaratKezelo j;

        [SetUp]
        public void Setup()
        {
            j = new JaratKezelo();
        }
        
        [Test]
        public void UjJarat() {
            j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));

         }

        [Test]
        public void Keses() {
            j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
            j.Keses("123", 10);
            Assert.AreEqual(new DateTime(2019, 3, 4, 14, 40, 05), j.MikorIndul("123"));
        }
        [Test]
        public void Keses2()
        {
            j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
            Assert.Throws<JaratKezelo.NegativKesesException>(
                () => {
                    j.Keses("123", -25);
                    //                    j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
                }
                );
            
        }

        [Test]
        public void MikorIndul() {
            j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
            Assert.AreEqual(new DateTime(2019, 3, 4, 14, 30, 05), j.MikorIndul("123"));
        }

       

        [Test]
        public void JaratokRepuloterrol() {
            List<string> ujjarat = new List<string>();
            ujjarat.Add("123");
            j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
            Assert.AreEqual(ujjarat, j.JaratokRepuloterrol("Debrecen"));
        }


        [Test]
        public void JaratokRepuloterrol2()
        {

            Assert.Throws<JaratKezelo.JaratokRepuloterrolException>(
                 () => {
                     j.JaratokRepuloterrol("Pécs");
                    //                    j.UjJarat("123", "Debrecen", "Tokió", new DateTime(2019, 3, 4, 14, 30, 05));
                }
                 );
        }
    }

}
