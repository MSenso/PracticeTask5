using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeTask5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form1 = new Form1();
            form1.Convert_From_File();
            form1.size = 3;
            form1.matrix = new double[3, 3] { { 1, 2, 3 }, { 3, 2, 1 }, { 0, 1, 0 } };
            form1.Generate_Visual_Matrix(is_from_file: false);
            form1.Calculate_B_Values();
            form1.Remove_B_Cells();
            form1.Remove_Visual_Matrix();
        }
    }
}
