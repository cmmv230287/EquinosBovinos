using System;
using System.Collections.Generic;
using EquinosBovinos.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquinosBovinos.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> Lista2 = new List<string>();
            List<string> Lista = new List<string>();
            Lista.Add("bisontes");
            Lista.Add("Caballos");
            Lista.Add("bisonte americano");
            Lista.Add("Asnos");
            Lista.Add("bisonte europeo");
            Lista.Add("Cebras");
            Lista.Add("bisonte estepario");

            Lista2 = Util.FindOfList(Lista, @"" + Config.PatternBovinos);
        }
    }
}
